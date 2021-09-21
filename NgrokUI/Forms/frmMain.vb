Imports Ape.EL.Setting.MySetting
Imports Ape.EL.WinForm.General
Imports Ape.EL.Misc.WebHelper
Imports CassiniDev

Imports NgrokUIApp.Properties

Class frmMain
#Region "Fields"
    Friend Const STR_NgrokUI As String = "NgrokUI"
    Friend Const STR_FirstInit As String = "FirstInit"
    Friend Const STR_Token As String = "Token"
    Friend Const STR_ConfigJson As String = "ConfigJson"
    Friend Const STR_DevMode As String = "DevMode"
    Friend Const STR_ShowNgrokSetting As String = "ShowNgrokSetting"
    Friend Const STR_ShowTestServerSetting As String = "ShowTestServerSetting"
    Friend Const STR_UseTestServer As String = "UseTestServer"
    Friend Const STR_Connected As String = "Connected"

    Friend Const STR_NgrokUIAppLog As String = "NgrokUIAppLog"

    Friend Const STR_LastUpdate As String = "LastUpdate"
    Friend Const STR_HideOnStart As String = "HideOnStart"
    Friend Const STR_AutoStart As String = "AutoStart"
    Friend Const STR_AutoInit As String = "AutoInit"
    Friend Const STR_LogShow As String = "LogShow"
    Friend Const STR_AlwaysOnTop As String = "AlwaysOnTop"
    Friend Const STR_ShowNotification As String = "ShowNotification"

    Private ReadOnly STR_ClearLogCode As String = String.Format("clear{0}", Integer.MaxValue)

    Private server As CassiniDevServer = Nothing
    Private nw As NgrokWrapper = Nothing

    Private dtLog As DataTable
    Private dtSubscription As DataTable

    Private bLoaded As Boolean
    Private tmpDevMode As Boolean

    ''' <summary>
    ''' Used to determine which setup was last performed. Add in the beginning of each Setup____ routine.
    ''' </summary>
    Private lastSetup As SetupEnum = SetupEnum.None

    ''' <summary>
    ''' Indicator for failure control.
    ''' </summary>
    Private Enum SetupEnum
        None
        WebApi
        License
        Ngrok
        ServerInfo
        Finalize
    End Enum
#End Region

#Region "Properties"
    Private Property DevMode As Boolean
        Get
            Return _DevMode
        End Get
        Set(value As Boolean)
            _DevMode = value

            DisableDevModeToolStripMenuItem.Visible = value
            AutoInitToolStripMenuItem.Visible = value
            ModulesToolStripMenuItem.Visible = value
            SaveSettingEx(STR_NgrokUI, STR_DevMode, value)
        End Set
    End Property
    Private _DevMode As Boolean

    Private Property ShowNgrokSetting As Boolean
        Get
            Return GetSettingEx(STR_NgrokUI, STR_ShowNgrokSetting).ToBoolean
        End Get
        Set(value As Boolean)
            SaveSettingEx(STR_NgrokUI, STR_ShowNgrokSetting, value.ToString)
        End Set
    End Property

    Private Property UseTestServer As Boolean
        Get
            Return GetSettingEx(STR_NgrokUI, STR_UseTestServer).ToBoolean
        End Get
        Set(value As Boolean)
            SaveConfigToFile()
            SaveSettingEx(STR_NgrokUI, STR_UseTestServer, value.ToString)
        End Set
    End Property

    Private Property ShowTestServerSetting As Boolean
        Get
            Return _ShowTestServerSetting
        End Get
        Set(value As Boolean)
            _ShowTestServerSetting = value

            UseTestServerToolStripMenuItem.Visible = value
            SaveSettingEx(STR_NgrokUI, STR_ShowTestServerSetting, value)
        End Set
    End Property
    Private _ShowTestServerSetting As Boolean

    Private Property InitMode As Boolean
        Get
            Return _InitMode
        End Get
        Set(value As Boolean)
            _InitMode = value

            btnSetting.BeginInvokeIfRequired(Sub(x As Button) x.Enabled = Not value)
            Me.BeginInvoke(Sub() RestartToolStripMenuItem.Enabled = Not value)
            'Me.BeginInvoke(Sub() ModulesToolStripMenuItem.Enabled = Not value)
        End Set
    End Property
    Private _InitMode As Boolean

    ''' <summary>
    ''' Only on dev mode, determine whether all threads should be suspended. Any exit thread function will need to wait for PauseThread set to false.
    ''' </summary>
    Private ReadOnly Property PauseThread As Boolean
        Get
            Return DevMode AndAlso PauseThreadsToolStripMenuItem.Checked
        End Get
    End Property
#End Region

#Region "Methods"
#Region "Cross Thread Function"
    ''' <summary>
    ''' Show WarningMsg and wait for the messagebox to be closed on main thread.
    ''' </summary>
    Private Sub SynchronousWarningMsg(ByVal msg As String, Optional ByVal useMsgBox As Boolean = False)
        WriteLog("Warning: " & msg)

        If m_Config.GeneralSilentMode And Not useMsgBox Then

        Else
            Dim asyncRes As System.IAsyncResult = Me.BeginInvoke(Sub()
                                                                     If Not Me.Visible Then Me.Show()
                                                                     WarningMsg(msg)
                                                                 End Sub)
            While True
                'this will make secondary thread to wait
                ' for WarningMsg above (on main thread) to be closed.
                If asyncRes.IsCompleted Then
                    Exit While
                End If
                Threading.Thread.Sleep(1)
            End While
        End If
    End Sub

    ''' <summary>
    ''' Same as SynchronousWarningMsg, but for exception.
    ''' </summary>
    Private Sub SynchronousExceptionMsg(ByVal ex As Exception, Optional ByVal useMsgBox As Boolean = False)
        WriteLog("Error: " & ex.Message)

        If m_Config.GeneralSilentMode And Not useMsgBox Then
            Ape.EL.App.ErrorLog.Debug(ex.Message)
        Else
            Dim asyncRes As System.IAsyncResult = Me.BeginInvoke(Sub()
                                                                     If Not Me.Visible Then Me.Show()
                                                                     ExceptionErrorMsg(ex)
                                                                 End Sub)
            While True
                If asyncRes.IsCompleted Then
                    Exit While
                End If
                Threading.Thread.Sleep(1)
            End While
        End If
    End Sub

    ''' <summary>
    ''' Update status label message and set the state.
    ''' </summary>
    ''' <param name="isEverythingOk">True will result in green, else will become red.</param>
    Private Sub UpdateStatus(ByVal msg As String, ByVal isEverythingOK As Boolean, Optional ByVal log As Boolean = True, Optional tip As String = "")
        If log Then WriteLog("Status: " & msg)
        Try
            lbStatus.InvokeIfRequired(Sub(x)
                                          x.Text = msg
                                          ttip.SetToolTip(lbStatus, tip)
                                          If isEverythingOK Then
                                              x.ForeColor = Color.Green
                                          Else
                                              x.ForeColor = Color.Red
                                          End If
                                      End Sub)
        Catch ex As Exception
            SynchronousExceptionMsg(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Determine if current status label is in OK state and connection is established.
    ''' </summary>
    Private Function IsStatusOK() As Boolean
        Try
            Return lbStatus.ForeColor = Color.Green AndAlso IsConnectionAlive()
        Catch ex As Exception
            SynchronousExceptionMsg(ex)
        End Try
        Return False
    End Function

    ''' <summary>Write to log and save to MySetting.</summary>
    Private Sub WriteLog(ByVal str As String)
        Try
            If dtLog IsNot Nothing Then
                dgvLog.BeginInvokeIfRequired(Sub(x As DataGridView)
                                                 If str = STR_ClearLogCode Then
                                                     dtLog.Clear()
                                                 Else
                                                     Dim updateSameRow As Boolean
                                                     'check if last log message is same. if is same, we just update the datetime.
                                                     If dtLog.Rows.Count > 0 AndAlso str = If(x.Rows(dtLog.Rows.Count - 1).Cells("Message").Value, "") Then
                                                         x.Rows(dtLog.Rows.Count - 1).Cells("Datetime").Value = Format(Now, "yyyy.MM.dd HH:mm:ss")
                                                         updateSameRow = True
                                                     Else
                                                         Dim dr As DataRow = dtLog.Rows.Add
                                                         dr.BeginEdit()
                                                         dr("Datetime") = Format(Now, "yyyy.MM.dd HH:mm:ss")
                                                         dr("Message") = str
                                                         dr.EndEdit()
                                                     End If

                                                     If dtLog.Rows.Count > 0 Then
                                                         If dtLog.Rows.Count > If(DevMode, 1000, 50) Then
                                                             dtLog.Rows(0).Delete()
                                                         End If

                                                         Dim goLast As Boolean = If(dtLog.Rows.Count > 1 AndAlso x.SelectedRows.Count = 1, x.SelectedRows.Contains(x.Rows(dtLog.Rows.Count - If(updateSameRow, 1, 2))) OrElse x.SelectedRows.Count = 0, False)
                                                         If goLast Then
                                                             x.ClearSelection()
                                                             x.FirstDisplayedScrollingRowIndex = dtLog.Rows.Count - 1
                                                             x.Rows(dtLog.Rows.Count - 1).Selected = True
                                                             x.Update()
                                                         Else
                                                             'x.Rows(dtLog.Rows.Count - 1).Selected = (x.Rows.Count = 1)
                                                         End If
                                                     End If
                                                 End If
                                             End Sub)

                Try
                    Me.BeginInvokeIfRequired(Sub() SaveSettingEx(STR_NgrokUIAppLog, STR_NgrokUIAppLog, dtLog.NJSONSerialize))
                Catch e2 As Exception
                End Try
            End If
        Catch ex As Exception
            Ape.EL.App.ErrorLog.Debug(ex.ToString)
        End Try
    End Sub
#End Region

#Region "1. Setup Thread"
    'Note: This region contains functions to initialize connection with another thread. (see InitializeProgram)
    'Since it's running on another thread, all feedback to main form and its controls MUST USE InvokeIfRequired to update its state.
    'And for show message box synchronously on main thread, I've provided SynchronousWarningMsg method which will wait for the messagebox to be closed.
    'Again, you have to use SynchronousWarningMsg (or its kind) to show messagebox gracefully on the main thread.

    ''' <summary>
    ''' Only use in InitializeProgram.
    ''' Load all setting from registry.
    ''' </summary>
    Private Function LoadSetting() As Boolean
        Dim res As Boolean = False
        Try
            LoadConfigFromFile()
            m_Token = GetSettingEx(STR_NgrokUI, STR_Token)

            lbLastUpdate.Text = GetSettingEx(STR_NgrokUI, STR_LastUpdate)
            res = True
        Catch ex As Exception
            SynchronousWarningMsg("Load setting was unsuccessful.")
        End Try
        Return res
    End Function

    ''' <summary>
    ''' Only use in InitializeProgram.
    ''' Set up WebAPI (CassiniDev).
    ''' This is the backbone of this program (the WebApi), and needed to be set up in the initialization stage.
    ''' </summary>
    Private Function SetupWebApi() As Boolean
        lastSetup = SetupEnum.WebApi
        UpdateStatus("Establishing connection 1/3.", False)

        Dim res As Boolean

        Try
            lbWebApi.InvokeIfRequired(Sub(x As Label) x.Text = "")
            lbWebApix.InvokeIfRequired(Sub(x As Label) x.SetExProperty("info", ""))

            If server IsNot Nothing Then
                server.StopServer()
                server.Dispose()
                server = Nothing
            End If

            If Not m_Config.WebApiSelfHost Then
                Dim countFail As Integer = 0
                While True
                    Try
                        'Setup CassiniDev locally.
                        'check if port is available
                        If Ape.EL.Utility.Network.IsPortOpen("localhost", m_Config.WebApiPort) Or m_Config.WebApiPort = 0 Then
                            If m_Config.WebApiRandomPort Then
                                'if setting port is not available, we use randomized port between 40000 and 45000
                                Dim whileCount As Integer = 0
                                While True
                                    If whileCount >= 5 Then Throw New ApplicationException("Can't generate available port.")
                                    Dim newPort As Integer = (New System.Random).Next(40000, 45000 + 1)
                                    If Not Ape.EL.Utility.Network.IsPortOpen("localhost", newPort) Then
                                        m_Config.WebApiPort = newPort
                                        Exit While
                                    End If
                                    whileCount += 1
                                End While
                            Else
                                Throw New ApplicationException(String.Format("Port [{0}] not available.", m_Config.WebApiPort))
                            End If
                        End If

                        Dim strWebDir As String = Ape.EL.Utility.General.GetCleanPath(m_Config.WebApiDir) 'System.IO.Path.Combine(Environment.CurrentDirectory, m_Config.WebApiDir)

                        server = New CassiniDevServer()
                        server.StartServer(strWebDir, m_Config.WebApiPort, "", "localhost")
                        m_WebApiRootUrl = server.Server.RootUrl

                        Exit While
                    Catch ex As Exception
                        If countFail >= 3 Then Throw ex
                        SynchronousExceptionMsg(ex)
                        countFail += 1
                    End Try
                    Threading.Thread.Sleep(1)
                End While
            Else
                'If SelfHost is enabled, use the provided localhost port for the connection. No port checking conducted.
                m_WebApiRootUrl = String.Format("http://localhost:{0}", m_Config.WebApiPort)
            End If

            lbWebApi.InvokeIfRequired(Sub(x As Label) x.Text = m_WebApiRootUrl)

            res = True
        Catch ex As Exception
            SynchronousExceptionMsg(ex)
        End Try

        Return res
    End Function

    ''' <summary>
    ''' Only use in InitializeProgram.
    ''' Make sure user has proper license before make ngrok connection.
    ''' </summary>
    Private Function SetupLicense() As Boolean
        lastSetup = SetupEnum.License
        UpdateStatus("Establishing connection 2/3.", False)

        Dim res As Boolean

        Try
            res = True
        Catch ex As Exception
            SynchronousWarningMsg(ex.Message)
        End Try

        Return res
    End Function

    ''' <summary>
    ''' Only use in InitializeProgram.
    ''' Set up Ngrok through NgrokWrapper.
    ''' </summary>
    Private Function SetupNgrok() As Boolean
        lastSetup = SetupEnum.Ngrok
        UpdateStatus("Establishing connection 3/3.", False)

        Dim res As Boolean

        Try
            If nw IsNot Nothing Then
                'close existing ngrok instance
                nw.Dispose()
                nw = Nothing
            End If

            If m_Config.UseNgrokUrl Then
                'check if port is available
                If Ape.EL.Utility.Network.IsPortOpen("localhost", m_Config.NgrokPort) Or m_Config.NgrokPort = 0 Then
                    'if setting port is not available, we use randomized port between 50000 and 55000
                    Dim whileCount As Integer = 0
                    While True
                        If whileCount >= 5 Then Throw New ApplicationException("Can't generate available port.")
                        Dim newPort As Integer = (New System.Random).Next(50000, 55000 + 1)
                        If Not Ape.EL.Utility.Network.IsPortOpen("localhost", newPort) Then
                            m_Config.NgrokPort = newPort
                            Exit While
                        End If
                        whileCount += 1
                    End While
                End If

                'create new ngrok instance
                Dim hasExited As Boolean
                nw = New NgrokWrapper("localhost", m_Config.WebApiPort)
                nw.AuthToken = m_Config.NgrokAuthToken
                nw.Subdomain = m_Config.NgrokSubdomain
                nw.NgrokPort = m_Config.NgrokPort
                AddHandler nw.Reply, Sub(str As String)
                                         If m_Config.Debug Then WriteLog("NgrokWrapper > " & str)
                                     End Sub
                AddHandler nw.Exited, Sub()
                                          hasExited = True
                                      End Sub
                nw.Start()

                While True
                    If hasExited Then
                        Throw New ApplicationException("Failed to establish connection 3/3. Please check log.")
                    End If
                    Try
                        Dim str = Ape.EL.Misc.WebHelper.GetWebAPI(String.Format("localhost:{0}", m_Config.NgrokPort), "api/tunnels")
                        Dim nat = str.NJSONDeserialize(Of Ngrok.API.GET_API_Tunnels)()
                        If nat IsNot Nothing AndAlso nat.Tunnels.FirstOrDefault IsNot Nothing Then
                            m_RootUrl = nat.Tunnels.FirstOrDefault.Public_URL
                        Else
                            Throw New ApplicationException("")
                        End If

                        Exit While
                    Catch ex As Exception
                        Threading.Thread.Sleep(1000)
                    End Try
                    Threading.Thread.Sleep(1)
                End While
            Else
                m_RootUrl = m_Config.Url2
            End If

            lbURL.InvokeIfRequired(Sub(x As Label) x.Text = m_RootUrl)

            res = True
        Catch ex As Exception
            SynchronousExceptionMsg(ex)
        End Try

        Return res
    End Function

    ''' <summary>
    ''' Only use in InitializeProgram.
    ''' </summary>
    Private Function SetupServerInfo() As Boolean
        lastSetup = SetupEnum.ServerInfo
        UpdateStatus("Updating server info.", False)

        Dim res As Boolean

        Try
            If Not m_Config.UseNgrokUrl Then
                'since Url has been set by user manually, we just set the Url immediately, assuming that the connection can be established.
                m_RootUrl = m_Config.Url2
                lbURL.InvokeIfRequired(Sub(x As Label) x.Text = m_RootUrl)
            End If

        Catch ex As Exception
            SynchronousWarningMsg(ex.Message)
        End Try

        Return res
    End Function

    ''' <summary>
    ''' Only use in ExitApp.
    ''' </summary>
    Private Function DeregisterServerInfo() As Boolean
        UpdateStatus("Updating server info.", False)

        Dim res As Boolean

        Try
        Catch ex As Exception
            'SynchronousWarningMsg(ex.Message)
        End Try

        Return res
    End Function

    ''' <summary>
    ''' Finalize successful setup.
    ''' </summary>
    Private Function SetupFinalize() As Boolean
        lastSetup = SetupEnum.Finalize
        UpdateStatus("Finalize connection.", False)

        Dim res As Boolean

        Try
            'nothing to finalize right now.
            res = True
        Catch ex As Exception
            SynchronousExceptionMsg(ex)
        End Try

        Return res
    End Function

    ''' <summary>
    ''' Close ngrok and cassinidev or other programs executed from this app.
    ''' </summary>
    Private Sub CloseProgram()
        Try
            'Make sure we set Connected to false
            SaveSettingEx(STR_NgrokUI, STR_Connected, False)

            'Logging for stopping connection
            Dim stoppedsomething As Boolean

            'Close cassinidev
            If server IsNot Nothing Then
                server.StopServer()
                server.Dispose()
                server = Nothing
                stoppedsomething = True
            End If

            'Close ngrok
            If nw IsNot Nothing Then
                nw.Dispose()
                nw = Nothing
                stoppedsomething = True
            End If

            If stoppedsomething Then WriteLog("Stopped opened connections.")
        Catch ex As Exception
            'ignore exception
        End Try
    End Sub

    ''' <summary>
    ''' Begin program initialization.
    ''' </summary>
    Private Sub InitializeProgram()
        Try
            'At this stage, all setting must be correct.
            Dim numberOfTries As Integer = 0
            While Not LoadSetting()
                If numberOfTries >= 3 Then Throw New ApplicationException("Setting is not loaded correctly. Application will exit now.")
                numberOfTries += 1
                btnSetting_Click(Nothing, Nothing)
            End While

            Static id As Integer
            Static list As New List(Of Threading.Thread)
            For Each f As Threading.Thread In list
                'tell the existing thread to exit immediately as a new thread has been created.
                f.SetExProperty("exit", True)
            Next
            list.ClearList(True)
            id += 1

            Dim _thread As New Threading.Thread(Sub() InitializeProgramThread())
            list.Add(_thread)
            _thread.SetExProperty("id", id) 'set unique running identifier
            _thread.SetExProperty("loop", m_Config.GeneralSilentMode) 'tell the thread that it is created in silentmode.
            _thread.Start() 'begin the process.
        Catch ex As Exception
            SynchronousExceptionMsg(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Use in InitializeProgram only! Setting up the connection through threading.
    ''' </summary>
    Private Sub InitializeProgramThread()
        PauseThreadCheck()

        Try
            Dim thisThread As Threading.Thread = Threading.Thread.CurrentThread
            Dim countInit As Integer = thisThread.GetExPropertyStr("countInit").ToInt32  ' for silent mode usage only
            If m_Config.Debug Then WriteLog(String.Format("Start thread {0}", thisThread.GetExPropertyStr("id")))

            'stop silentmode looping when silentmode has been disabled or when exit property is set true.
            If (m_Config.GeneralSilentMode = False AndAlso thisThread.GetExPropertyStr("loop").ToBoolean) OrElse thisThread.GetExPropertyStr("exit").ToBoolean Then
                If m_Config.Debug Then WriteLog(String.Format("Force exit thread {0}", thisThread.GetExPropertyStr("id")))
                Exit Sub
            End If

            '#### Begin Initialization ####
            UpdateStatus("Initializing.", False)

            NgrokWrapper.StopNgrokInstances()
            lbWebApi.InvokeIfRequired(Sub(x As Label) x.Text = "")
            lbURL.InvokeIfRequired(Sub(x As Label) x.Text = "")
            CloseProgram()

            Dim failed As Boolean

            '#setup part1
            If Not failed Then
                'check for internet connection.
                If Debugger.IsAttached = False AndAlso Not DevMode Then
                    If Not Ape.EL.Misc.WebHelper.HasInternetConnection Then
                        'Show message
                        SynchronousWarningMsg("You must be connected to internet. Restart when you are connected to internet.")
                        If thisThread.GetExPropertyStr("loop").ToBoolean Then
                            'keep looping
                            failed = True
                        Else
                            UpdateStatus("No Internet.", False)
                            If m_Config.Debug Then WriteLog(String.Format("Force exit thread {0} without internet", thisThread.GetExPropertyStr("id")))
                            Exit Sub 'exit the thread
                        End If
                    End If
                End If
            End If

            '#setup part2
            If Not failed Then
                InitMode = True 'make sure we block other controls on initialization.
                lastSetup = SetupEnum.None 'clear last setup history.
                'Begin setup connection.
                If Not SetupWebApi() OrElse
                           Not SetupLicense() OrElse
                           Not SetupNgrok() OrElse
                           Not SetupFinalize() Then
                    failed = True
                End If
                InitMode = False
            End If

            If failed Then
                UpdateStatus(String.Format("## FAILURE ##"), False)
                '## FAILURE ##
                '#do something when it has failed.
                CloseProgram()
                If thisThread.GetExPropertyStr("loop").ToBoolean Then
                    countInit += 1
                    thisThread.SetExProperty("countInit", countInit)
                    'if this thread was created in silentmode, loop it on failed initialization attempt.
                    If countInit > 0 AndAlso countInit Mod 3 = 0 Then
                        Dim sleepingTime As Integer = 3 * 60 * 1000 'sleep for 3 minutes before trying again.
                        thisThread.SetExProperty("countInit", 0)  'reset count init
                        SendEmail("Program failed to restart.", "You get this email because you have setup error email setting.<br/>You have to restart manually.<br/>If error persists, please contact support.")
                        If m_Config.Debug Then WriteLog(String.Format("Sleep thread {0} for {1} ms", thisThread.GetExPropertyStr("id"), sleepingTime))

                        Dim sleepInterval As Integer = 1000

                        While sleepingTime > 0
                            PauseThreadCheck()

                            If thisThread.GetExPropertyStr("exit").ToBoolean Then
                                Exit While
                            End If
                            If m_Config.GeneralSilentMode Then
                                sleepingTime -= sleepInterval
                                UpdateStatus(String.Format("Too many failed attempts. Restart in {0} s.", sleepingTime \ 1000), False, False)
                                Threading.Thread.Sleep(sleepInterval)
                            Else
                                UpdateStatus(String.Format("Disconnected"), False)
                                Exit While
                            End If
                        End While
                    End If

                    If m_Config.Debug Then WriteLog(String.Format("Loop thread {0}", thisThread.GetExPropertyStr("id")))
                    InitializeProgramThread() 'loop this thread
                Else
                    'if not created in silentmode, then the thread should exit gracefully.
                    'there is nothing to do there. ending the thread.
                End If
            Else
                UpdateStatus(String.Format("## SUCCESS ##"), True)
                '## SUCCESS ##
                '#everything is working! update the status and end the thread gracefully!
                lbLastUpdate.InvokeIfRequired(Sub(x As Label) x.Text = System.DateTime.Now)
                SaveSettingEx(STR_NgrokUI, STR_LastUpdate, lbLastUpdate.Text)

                'Make sure we set Connected to true to make sure ModuleService in webapi works.
                SaveSettingEx(STR_NgrokUI, STR_Connected, True)

                UpdateStatus("OK", True, False)

                'Check if the local webapi is still alive.
                Dim sleepingTime As Integer
                Dim sleepInterval As Integer = 1000
                Dim autoRestartTime As Integer = If(m_Config.GeneralAutoRestartHourInterval >= 1, m_Config.GeneralAutoRestartHourInterval * 3600000, 3600000)
                While True
                    PauseThreadCheck()

                    'Exit loop condition.
                    If thisThread.GetExPropertyStr("exit").ToBoolean Then
                        If m_Config.Debug Then WriteLog(String.Format("Force exit thread {0}", thisThread.GetExPropertyStr("id")))
                        Exit While
                    End If

                    If m_Config.GeneralSilentMode Then
                        'Check for auto restart.
                        If m_Config.GeneralAutoRestart Then
                            If autoRestartTime <= 0 Then
                                UpdateStatus("## AUTO RESTART CONNECTION ##", False)
                                InitializeProgramThread() 'loop this thread
                                Exit Sub
                            End If
                            autoRestartTime -= sleepInterval
                        End If

                        'Check for connection status.
                        If sleepingTime <= 0 Then
                            If IsConnectionAlive() Then
                                If m_Config.Debug Then WriteLog("WebApi is still alive.")
                                'if connection still alive, update last connection time.
                                Try
                                    '!!! if there is any server-client last connection update, you should put it here.
                                    'eg. using SetupServerInfo, it will update last connection to eMenu Service for the last connection and its connection status.
                                    'Any failure will be caught, and logged only. No need to stop connection.
                                    If SetupServerInfo() Then
                                        'SetGeneralSetting("WebApiLastConnected", Now.ToString)
                                    End If
                                Catch ex As Exception
                                    WriteLog("Warning: " & ex.Message)
                                End Try

                                '#everything is working! update last update time again on every successful attempt.
                                lbLastUpdate.InvokeIfRequired(Sub(x As Label) x.Text = System.DateTime.Now)
                                SaveSettingEx(STR_NgrokUI, STR_LastUpdate, lbLastUpdate.Text)
                            Else
                                If m_Config.Debug Then WriteLog(String.Format("WebApi is not alive. Loop thread {0}", thisThread.GetExPropertyStr("id")))
                                UpdateStatus("## CONNECTION HAS ISSUE ##", False)
                                InitializeProgramThread() 'loop this thread
                                Exit Sub
                            End If
                            sleepingTime = If(m_Config.CheckConnectionInterval >= 1000, m_Config.CheckConnectionInterval, 1000)  'sleep for n seconds before checking status again.
                        End If

                        sleepingTime -= sleepInterval

                        Dim message As String = String.Format("Check status in {0}.", Utility.MiliSecondToMinuteAndSeconds(sleepingTime))
                        Dim tip As String = ""
                        If m_Config.GeneralAutoRestart Then
                            tip.Append(String.Format("Restart in {0}.", Utility.MiliSecondToMinuteAndSeconds(autoRestartTime)))
                        End If
                        UpdateStatus(message, True, False, tip)

                        'Add a sleep interval to prevent over using CPU resource.
                        Threading.Thread.Sleep(sleepInterval)
                    Else
                        'SetGeneralSetting("WebApiLastConnected", Now.ToString)
                        UpdateStatus("OK", True, False)
                        Exit While
                    End If
                End While
            End If
            '#### End Initialization ####
        Catch exAsync As Threading.ThreadAbortException
            'do nothing
        Catch ex As Exception
            SynchronousExceptionMsg(ex)
        Finally
            Threading.Thread.Sleep(1)
            InitMode = False
        End Try
    End Sub
#End Region

#Region "2. Back End Process Thread"
    ''' <summary>
    ''' Check Status color, and update the pb periodically based on the status color.
    ''' </summary>
    Private Sub UpdateOrbStatus()
        Static imgRed As Image = My.Resources.Red_ball
        Static imgGreen As Image = My.Resources.Green_ball
        Static imgGrey As Image = My.Resources.Grey_ball

        Dim b As Boolean = True
        Dim img As Image = Nothing

        If b Then
            If IsStatusOK() Then
                img = imgGreen
            Else
                img = imgRed
            End If
        Else
            img = Nothing
        End If

        pbOrb.InvokeIfRequired(Sub(x As PictureBox) x.Image = img)
    End Sub

    ''' <summary>
    ''' Perform some back end process that will be executed every second.
    ''' </summary>
    Private Sub BackEndProcessing()
        Dim _thread As New System.Threading.Thread(Sub()
                                                       While True
                                                           PauseThreadCheck()

                                                           UpdateOrbStatus()
                                                           Threading.Thread.Sleep(1000)
                                                       End While
                                                   End Sub)
        _thread.Start()
    End Sub
#End Region

#Region "3. Modules Thread"
    ''' <summary>
    ''' Execute modules that implements IModuleBackground interface.
    ''' </summary>
    Private Sub RunModule()
        'Create instance once.
        Static mBackground As List(Of Interfaces.IModuleBackground) = Nothing
        If mBackground Is Nothing Then
            mBackground = New List(Of Interfaces.IModuleBackground)
            Dim asm As Reflection.Assembly = Ape.EL.Misc.AssemblyHelper.GetTrueEntryAssembly
            For Each o As Type In asm.GetTypes()
                If (GetType(Interfaces.IModuleBackground).IsAssignableFrom(o)) AndAlso
                    o IsNot GetType(Interfaces.IModuleBackground) Then
                    'condition check if it implements IModuleBackground.
                Else
                    'Skip if the type not based on above conditions.
                    Continue For
                End If

                mBackground.Add(o.GetInstance)
            Next
        End If

        'Begin execution
        For Each o As Interfaces.IModuleBackground In mBackground
            If o.IsDisabled Then Continue For
            Try
                If o.SleepCycle <= 0 Then
                    If Not o.Run() Then
                        Throw New ApplicationException("")
                    Else
                        If m_Config.Debug Then
                            WriteLog(String.Format("Executed {0} module successfully.", o.GetType.Name))
                        End If
                    End If
                    o.SleepCycle = o.Cycles
                End If
                o.SleepCycle -= 1
            Catch ex As Exception
                If Not ex.Message.IsEmpty Then
                    WriteLog(String.Format("Module {0} Error: " & ex.Message, o.GetType.Name))
                End If
            End Try
        Next
    End Sub

    ''' <summary>
    ''' Create RunModule thread that will be executed every second.
    ''' </summary>
    Private Sub ModuleProcessing()
        Dim _thread As New System.Threading.Thread(Sub()
                                                       While True
                                                           PauseThreadCheck()

                                                           If IsStatusOK() Then
                                                               RunModule()
                                                           End If
                                                           Threading.Thread.Sleep(If(m_Config.ModuleProcessInterval >= 1000, m_Config.ModuleProcessInterval, 1000))
                                                       End While
                                                   End Sub)
        _thread.Start()
    End Sub

#End Region

#Region "Others"

#End Region

    ''' <summary>
    ''' If PauseThread is true, make the current thread sleep for a second until PauseThread is false.
    ''' </summary>
    Private Sub PauseThreadCheck()
        While PauseThread
            Threading.Thread.Sleep(1000)
        End While
    End Sub

    ''' <summary>
    ''' Save configuration to file.
    ''' </summary>
    Private Sub SaveConfigToFile()
        SaveSettingEx(STR_NgrokUI, STR_ConfigJson, m_Config.NJSONSerialize)
    End Sub

    ''' <summary>
    ''' Load configuration from file.
    ''' </summary>
    Private Sub LoadConfigFromFile()
        Try
            m_Config = GetSettingEx(STR_NgrokUI, STR_ConfigJson).NJSONDeserialize(Of ConfigStructure)()
        Catch ex As Exception
        End Try
        If m_Config Is Nothing Then
            m_Config = New ConfigStructure
            SaveConfigToFile()
        End If
    End Sub

    ''' <summary>Send email.</summary>
    Private Function SendEmail(ByVal Subject As String,
                               ByVal Body As String) As Boolean
        Try
            'Dont send email if debugger is attached or email setting is incomplete.
            If Debugger.IsAttached OrElse m_Config.ErrEmail.IsEmpty OrElse m_Config.ErrPass.IsEmpty OrElse m_Config.ErrHost.IsEmpty OrElse m_Config.ErrRecipient.IsEmpty Then
                Return False
            End If

            If Ape.EL.Misc.Email.SendEmail(m_Config.ErrEmail,
                                            m_Config.ErrPass,
                                            m_Config.ErrHost,
                                            m_Config.ErrSSL,
                                            m_Config.ErrPort,
                                            m_Config.ErrRecipient,
                                            "",
                                            m_Config.ErrEmail,
                                            Environment.MachineName & " - " & Subject, Body) Then
                WriteLog("A message sent to email " & m_Config.ErrRecipient)
                Return True
            End If
        Catch ex As Exception
            WriteLog("A message was NOT sent to email. Please set up email correctly.")
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Safely exit the application and release all resources.
    ''' </summary>
    Private Sub ExitApp()
        If IsStatusOK() Then
            DeregisterServerInfo()
        End If

        CloseProgram()

        WriteLog("APP CLOSE")
        noticon.Visible = False
        Ape.EL.App.General.KillProgram()
    End Sub

    Private Sub BindLogDatatable()
        If dtLog IsNot Nothing AndAlso dgvLog IsNot Nothing Then
            dgvLog.DataSource = dtLog
            dgvLog.FirstDisplayedScrollingRowIndex = 0
            dgvLog.AllowUserToAddRows = False
            dgvLog.AllowUserToResizeRows = False
            'dgvLog.AllowUserToResizeColumns = False
            dgvLog.RowHeadersVisible = False
            dgvLog.ReadOnly = True
            dgvLog.ColumnHeadersVisible = False
            dgvLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvLog.Columns("Datetime").Width = 145
            dgvLog.Columns("Message").Width = 310
            dgvLog.MultiSelect = True

            If dtLog.Rows.Count > 0 Then
                dgvLog.ClearSelection()
                dgvLog.FirstDisplayedScrollingRowIndex = dgvLog.RowCount - 1
                dgvLog.Rows(dgvLog.RowCount - 1).Selected = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' Add columns that exist only in dt2 to dt1.
    ''' </summary>
    Private Sub AddMissingColumns(ByRef dt1 As DataTable, ByVal dt2 As DataTable)
        If dt1 IsNot Nothing AndAlso dt2 IsNot Nothing Then
            For Each col As DataColumn In dt2.Columns
                If Not dt1.Columns.Contains(col.ColumnName) Then
                    dt1.Columns.Add(col.ColumnName, col.DataType)
                End If
            Next
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Static tabControl As New Ape.EL.UI.Component.TabOrder.TabOrderManager(Me)
        tabControl.SetTabOrder(Ape.EL.UI.Component.TabOrder.TabOrderManager.TabScheme.AcrossFirst)

        lbWebApi.Text = ""
        lbURL.Text = ""
        lbLastUpdate.Text = GetSettingEx(STR_NgrokUI, STR_LastUpdate)

        'set up error logging to ..\ProgramData\Namespace\error.log.
        Ape.EL.App.ErrorLog.Properties.ErrorLogDirectory = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Ape.EL.Utility.General.GetAsmNamespace(Ape.EL.Misc.AssemblyHelper.GetTrueEntryAssembly))
        Ape.EL.Utility.General.MakePath(Ape.EL.App.ErrorLog.Properties.ErrorLogDirectory)
        Ape.EL.Utility.General.SetFullAccess(Ape.EL.App.ErrorLog.Properties.ErrorLogDirectory)

        'set up dgvLog
        dtLog = New DataTable
        dtLog.Columns.Add("Datetime", GetType(String))
        dtLog.Columns.Add("Message", GetType(String))
        BindLogDatatable()
    End Sub
#End Region

#Region "Events"
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Opacity = 0
            Me.Icon = Ape.EL.Utility.General.GetAssemblyIcon
            Me.Text = m_AppTitle
            noticon.Icon = Me.Icon
            noticon.Text = Me.Text

            Dim jsonNgrokUIAppLog As String = GetSettingEx(STR_NgrokUIAppLog, STR_NgrokUIAppLog)
            If jsonNgrokUIAppLog.StartsWith("[{") AndAlso jsonNgrokUIAppLog.EndsWith("}]") Then
                Try
                    Dim tmpdtLog = jsonNgrokUIAppLog.NJSONDeserialize(Of DataTable)()
                    AddMissingColumns(tmpdtLog, dtLog)
                    dtLog = tmpdtLog
                    BindLogDatatable()
                Catch ex As Exception
                End Try
            End If

            DevMode = GetSettingEx(STR_NgrokUI, STR_DevMode).ToBoolean
            ShowTestServerSetting = GetSettingEx(STR_NgrokUI, STR_ShowTestServerSetting).ToBoolean

            HideOnStartToolStripMenuItem.Checked = GetSettingEx(STR_NgrokUI, STR_HideOnStart).ToBoolean
            AutoStartupToolStripMenuItem.Checked = GetSettingEx(STR_NgrokUI, STR_AutoStart).ToBoolean
            AutoInitToolStripMenuItem.Checked = GetSettingEx(STR_NgrokUI, STR_AutoInit, True).ToBoolean
            AlwaysOnTopToolStripMenuItem.Checked = GetSettingEx(STR_NgrokUI, STR_AlwaysOnTop).ToBoolean
            ShowNotificationToolStripMenuItem.Checked = GetSettingEx(STR_NgrokUI, STR_ShowNotification).ToBoolean
            UseTestServerToolStripMenuItem.Checked = UseTestServer

            If Ape.EL.Utility.General.IsRdp Then
                WarningMsg("This program cannot run in Remote Desktop environment.")
                ExitApp()
                Exit Sub
            End If

            WriteLog("APP START")
            BackEndProcessing()
            ModuleProcessing()
            LoadSetting()

            'Reset IIS express if needed
            If m_Config.ResetIisOnLoad Then
                Ape.EL.App.Cmd.Run("Start /wait """" taskkill /F /IM iisexpress.exe")
            End If

            'Create a token for first time installation
            If GetSettingEx(STR_NgrokUI, STR_Token).IsEmpty Then
                Dim newToken As String = Ape.EL.Utility.Data.Crypt.GetHash(Environment.MachineName & Format(Now, "ddHHmmssfffffff"))
                SaveSettingEx(STR_NgrokUI, STR_Token, newToken)
            End If

            'First time init
            If Not GetSettingEx(STR_NgrokUI, STR_FirstInit).ToBoolean Then
                InformationMsg("Please set up this program for first time use.")
                btnSetting_Click("save", Nothing)
                SaveSettingEx(STR_NgrokUI, STR_FirstInit, True)
                If AutoInitToolStripMenuItem.Checked AndAlso QuestionMsg("Initialize connection now?") <> Windows.Forms.DialogResult.Yes Then
                    AutoInitToolStripMenuItem.Checked = False
                End If
            End If

            'Begin initlize program if silent mode or auto init is on.
            If AutoInitToolStripMenuItem.Checked Then
                If Not Debugger.IsAttached OrElse QuestionMsg("Debugger is attacted, initialize?") = Windows.Forms.DialogResult.Yes Then
                    InitializeProgram()
                End If
            End If

            bLoaded = True
        Catch ex As Exception
            Ape.EL.App.ErrorLog.WriteMessage(ex.ToString)
            Ape.EL.WinForm.General.WarningMsg(ex.Message)
            ExitApp()
        End Try
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If HideOnStartToolStripMenuItem.Checked Then Me.Close()
        Me.Opacity = 100
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If CBool(e.CloseReason And CloseReason.UserClosing) Then
            Me.Hide()
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim SecretCodeFeature As String = Ape.EL.Misc.SecretCodesHelper.GetSecretCodes(e.KeyChar.ToString.ToUpper, GetType(Misc.CodesConfig))
        If Not String.IsNullOrEmpty(SecretCodeFeature) Then
            Select Case SecretCodeFeature
                Case Misc.CodesConfig.AtariCode
                    DevMode = True
                    InformationMsg("You have turned on dev mode. To disable it, click the notify icon and select Disable Dev Mode.")
                Case Misc.CodesConfig.AtariCode2
                    tmpDevMode = True
                    btnSetting_Click(Nothing, Nothing)
                    tmpDevMode = False
                Case Misc.CodesConfig.UnlockNgrok
                    ShowNgrokSetting = Not ShowNgrokSetting
                Case Misc.CodesConfig.TestServer
                    ShowTestServerSetting = True
                    InformationMsg("You have turned on test mode.")
            End Select
        End If
    End Sub

    Private Sub lbWebApix_DoubleClick(sender As Object, e As EventArgs) Handles lbWebApix.DoubleClick
        Dim info As String = lbWebApix.GetExPropertyStr("info")
        If Not info.IsEmpty Then InformationMsg(info)
    End Sub

#Region "Button Events"

    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        Using f As New frmSetting
            f.m_DevMode = DevMode Or tmpDevMode
            f.m_ShowNgrokSetting = ShowNgrokSetting
            f.m_Config = m_Config.DeepCopy
            If sender = "save" Then
                f.m_MustSave = True
            End If

            If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                If f.m_RestartRequired Then
                    If IsStatusOK() Then DeregisterServerInfo()
                End If

                m_Config = f.m_Config.DeepCopy
                SaveConfigToFile()

                If f.m_RestartRequired Then
                    InitializeProgram()
                ElseIf IsStatusOK() Then
                    'UpdatedSetting()
                End If
            Else
                If f.m_MustSave Then
                    If QuestionMsg("You have to save to continue use of this program. Try again?") = Windows.Forms.DialogResult.Yes Then
                        btnSetting_Click(sender, e)
                    Else
                        ExitApp()
                    End If
                End If
            End If
        End Using
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Show()
        If QuestionMsg("Are you sure want to exit?") = Windows.Forms.DialogResult.Yes Then
            'Dim val As String = Ape.EL.Misc.PasswordHelper.GenerateRandomAphanumeric(4)
            'If DevMode OrElse val.ToLower = InputBox(String.Format("Please key in '{0}' to confirm.", val), "Confirm Exit").ToLower Then
            ExitApp()
            'End If
        End If
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.Hide()
    End Sub

    Private Sub btnRefreshSubscription_Click(sender As Object, e As EventArgs)
        Ape.EL.App.General.RunMethodOnNewThread(Sub()
                                                    Try
                                                        If IsStatusOK() Then

                                                        Else
                                                            SynchronousWarningMsg("Try again when connection is established.", True)
                                                        End If
                                                    Catch ex As Exception
                                                        SynchronousWarningMsg("Failed to refresh subscription.", True)
                                                    End Try
                                                End Sub)
    End Sub
#End Region

#Region "MenuStrip Events"
    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub DisableDevModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableDevModeToolStripMenuItem.Click
        DevMode = False
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        btnExit_Click(Nothing, Nothing)
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        If QuestionMsg("Are you sure want to restart?") = Windows.Forms.DialogResult.Yes Then
            InitializeProgram()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        btnExit_Click(Nothing, Nothing)
    End Sub

    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem.Click
        btnSetting_Click(Nothing, Nothing)
    End Sub

    Private Sub ClearLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearLogToolStripMenuItem.Click
        WriteLog(STR_ClearLogCode)
    End Sub

    Private Sub HideOnStartToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles HideOnStartToolStripMenuItem.CheckedChanged
        SaveSettingEx(STR_NgrokUI, STR_HideOnStart, HideOnStartToolStripMenuItem.Checked.ToStr)
    End Sub

    Private Sub HideOnStartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideOnStartToolStripMenuItem.Click
        HideOnStartToolStripMenuItem.Checked = Not HideOnStartToolStripMenuItem.Checked
    End Sub

    Private Sub AutoStartupToolStripMenuItem_CheckStateChanged(sender As Object, e As EventArgs) Handles AutoStartupToolStripMenuItem.CheckStateChanged
        SaveSettingEx(STR_NgrokUI, STR_AutoStart, AutoStartupToolStripMenuItem.Checked.ToStr)
    End Sub

    Private Sub AutoStartupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoStartupToolStripMenuItem.Click
        AutoStartupToolStripMenuItem.Checked = Not AutoStartupToolStripMenuItem.Checked

        Ape.EL.Utility.General.SetProgramAutoRun(AutoStartupToolStripMenuItem.Checked)
    End Sub

    Private Sub AutoInitToolStripMenuItem_CheckStateChanged(sender As Object, e As EventArgs) Handles AutoInitToolStripMenuItem.CheckStateChanged
        SaveSettingEx(STR_NgrokUI, STR_AutoInit, AutoInitToolStripMenuItem.Checked.ToStr)
    End Sub

    Private Sub AutoInitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoInitToolStripMenuItem.Click
        AutoInitToolStripMenuItem.Checked = Not AutoInitToolStripMenuItem.Checked
    End Sub

    Private Sub AlwaysOnTopToolStripMenuItem_CheckStateChanged(sender As Object, e As EventArgs) Handles AlwaysOnTopToolStripMenuItem.CheckStateChanged
        SaveSettingEx(STR_NgrokUI, STR_AlwaysOnTop, AlwaysOnTopToolStripMenuItem.Checked.ToStr)

        Me.TopMost = AlwaysOnTopToolStripMenuItem.Checked
    End Sub

    Private Sub AlwaysOnTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlwaysOnTopToolStripMenuItem.Click
        AlwaysOnTopToolStripMenuItem.Checked = Not AlwaysOnTopToolStripMenuItem.Checked
    End Sub

    Private Sub ShowNotificationToolStripMenuItem_CheckStateChanged(sender As Object, e As EventArgs) Handles ShowNotificationToolStripMenuItem.CheckStateChanged
        SaveSettingEx(STR_NgrokUI, STR_ShowNotification, ShowNotificationToolStripMenuItem.Checked.ToStr)
    End Sub

    Private Sub ShowNotificationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowNotificationToolStripMenuItem.Click
        ShowNotificationToolStripMenuItem.Checked = Not ShowNotificationToolStripMenuItem.Checked
    End Sub

    Private Sub UseTestServerToolStripMenuItem_CheckStateChanged(sender As Object, e As EventArgs) Handles UseTestServerToolStripMenuItem.CheckStateChanged
        If bLoaded Then _
        UseTestServer = UseTestServerToolStripMenuItem.Checked
    End Sub

    Private Sub UseTestServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UseTestServerToolStripMenuItem.Click
        UseTestServerToolStripMenuItem.Checked = Not UseTestServerToolStripMenuItem.Checked
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Using f As New frmAbout
            f.ShowDialog(Me)
        End Using
    End Sub

    Private Sub PauseThreadsToolStripMenuItem_CheckStateChanged(sender As Object, e As EventArgs) Handles PauseThreadsToolStripMenuItem.CheckStateChanged

    End Sub

    Private Sub PauseThreadsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PauseThreadsToolStripMenuItem.Click
        PauseThreadsToolStripMenuItem.Checked = Not PauseThreadsToolStripMenuItem.Checked
    End Sub
#End Region

#Region "Run Functions"
    Private Sub TestFuncToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestFuncToolStripMenuItem.Click
        'Please clear function after test.
    End Sub

    Private Sub SettingDirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingDirToolStripMenuItem.Click
        Process.Start("explorer.exe", Ape.EL.Setting.MySetting.Path)
    End Sub

    Private Sub ErrorLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ErrorLogToolStripMenuItem.Click
        Process.Start("notepad.exe", Ape.EL.App.ErrorLog.Properties.ErrorLogPath)
    End Sub

    Private Sub TestFuncNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestFuncNameToolStripMenuItem.Click
        Dim func As String = InputBox("Input function name.", " ")
        If Not func.Trim.IsEmpty Then
            Try
                Ape.EL.Reflex.PropertyHelper.Invoke(Of Object)(Me, func.Trim, Nothing)
            Catch ex As Exception
                SynchronousWarningMsg("TestFuncName - " & ex.Message)
            End Try
        End If
    End Sub
#End Region

#Region "Noticon Events"
    Private Sub noticon_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles noticon.MouseClick
        If e.Button = MouseButtons.Right Then noticon.ContextMenuStrip.Show() '// Show ContextMenu on Right Mouse click.
    End Sub

    Private Sub noticon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles noticon.MouseDoubleClick
        Me.Show()
        Me.BringToFront()
        Me.Activate()
    End Sub
#End Region

    Private Sub lbURL_Click(sender As Object, e As EventArgs) Handles lbURL.Click
        If Not lbURL.Text.IsEmpty Then
            Clipboard.SetText(lbURL.Text)
            InformationMsg("Copied to clipboard!")
        End If
    End Sub

    Private Sub lbWebApi_Click(sender As Object, e As EventArgs) Handles lbWebApi.Click
        If Not lbWebApi.Text.IsEmpty Then
            Clipboard.SetText(lbWebApi.Text)
            InformationMsg("Copied to clipboard!")
        End If
    End Sub
#End Region
End Class