'CompanyCode is Approval Code now. (4 July 2017)
Imports Ape.EL.WinForm.General
Imports Ape.EL.Setting.MySetting

Class frmSetting
    Private Const STR_App_Profiles As String = "App_Profiles"
    Private Const STR_LastAppliedProfile As String = "LastAppliedProfile"

    ''' <summary>
    ''' Indicate that the form must be closed by pressing OK button.
    ''' </summary>
    Property m_MustSave As Boolean
    Property m_Config As ConfigStructure
    Property m_RestartRequired As Boolean

    WriteOnly Property m_DevMode As Boolean
        Set(value As Boolean)
            _m_DevMode = value
        End Set
    End Property
    Private _m_DevMode As Boolean = False

    WriteOnly Property m_ShowNgrokSetting As Boolean
        Set(value As Boolean)
            _m_ShowNgrokSetting = value
        End Set
    End Property
    Private _m_ShowNgrokSetting As Boolean = False

    Private Sub RefreshProfileList()
        Dim lastSelected As String = cbProfiles.Text
        cbProfiles.Items.Clear()
        cbProfiles.Items.AddRange((From x As DataRowView In Ape.EL.Setting.MySetting.GetDataViewEx(STR_App_Profiles)
                                   Select x("Key").ToString.ToUpper).ToArray)
        If cbProfiles.Items.Contains(lastSelected) Then
            cbProfiles.Text = lastSelected
        End If
    End Sub

    ''' <summary>
    ''' Load profile by name to screen. If profile is not provided, nothing will be changed.
    ''' </summary>
    Private Sub LoadProfileToScreen(ByVal profileName As String)
        If profileName.IsEmpty Then Exit Sub
        Static defConfig As String = (New ConfigStructure).NJSONSerialize
        Dim config As ConfigStructure = GetSettingEx(STR_App_Profiles, profileName, defConfig).NJSONDeserialize(Of ConfigStructure)()
        LoadConfigToScreen(config)
        SaveSettingEx(frmMain.STR_NgrokUI, STR_LastAppliedProfile, profileName)

        lbCurrentProfile.Text = String.Format("Profile:{0}{1}", Environment.NewLine, profileName)
    End Sub

    ''' <summary>
    ''' Save selected profile with current screen config.
    ''' </summary>
    Private Sub SaveSelectedProfile()
        If cbProfiles.Text.IsEmpty Then Exit Sub
        SaveSettingEx(STR_App_Profiles, cbProfiles.Text, GetConfigFromScreen.NJSONSerialize)
    End Sub

    ''' <summary>
    ''' Delete selected profile.
    ''' </summary>
    Private Sub DeleteSelectedProfile()
        If cbProfiles.Text.IsEmpty Then Exit Sub
        DeleteSettingEx(STR_App_Profiles, cbProfiles.Text)
        RefreshProfileList()
    End Sub

    Private Sub LoadConfigToScreen(ByVal config As ConfigStructure)
        If config Is Nothing Then config = New ConfigStructure
        cbSilentMode.Checked = config.GeneralSilentMode
        cbAutoRestart.Checked = config.GeneralAutoRestart
        txtAutoRestartInterval.Text = config.GeneralAutoRestartHourInterval

        txtWebApiPort.Text = config.WebApiPort
        cbWebApiSelfHost.Checked = config.WebApiSelfHost
        txtWebApiDir.Text = config.WebApiDir
        txtUrl.Text = config.Url
        txtUrlPort.Text = config.UrlPort
        cbUrlAutoIP.Checked = config.UrlAutoIP
        txtNgrokSubdomain.Text = config.NgrokSubdomain
        txtNgrokAuthToken.Text = config.NgrokAuthToken
        txtNgrokPort.Text = config.NgrokPort
        cbNgrokUseSSL.Checked = config.NgrokUseSSL
        cbDebug.Checked = config.Debug
        txtModuleProcessInterval.Text = config.ModuleProcessInterval
        txtCheckConnectionInterval.Text = config.CheckConnectionInterval
        cbResetIisOnLoad.Checked = config.ResetIisOnLoad

        txtErrEmail.Text = config.ErrEmail
        txtErrPassword.Text = config.ErrPass
        txtErrHost.Text = config.ErrHost
        ceErrUseSSL.Checked = config.ErrSSL
        txtErrPort.Text = config.ErrPort
        txtErrReceipient.Text = config.ErrRecipient
    End Sub

    Private Function GetConfigFromScreen() As ConfigStructure
        Dim config As New ConfigStructure
        config = m_Config.DeepCopy

        config.GeneralSilentMode = cbSilentMode.Checked
        config.GeneralAutoRestart = cbAutoRestart.Checked
        config.GeneralAutoRestartHourInterval = txtAutoRestartInterval.Text.ToInt32

        config.WebApiPort = txtWebApiPort.Text.ToInt32
        config.WebApiSelfHost = cbWebApiSelfHost.Checked
        config.WebApiDir = txtWebApiDir.Text
        config.Url = txtUrl.Text.Trim
        config.UrlPort = txtUrlPort.Text.Trim
        config.UrlAutoIP = cbUrlAutoIP.Checked
        config.NgrokSubdomain = txtNgrokSubdomain.Text
        config.NgrokAuthToken = txtNgrokAuthToken.Text
        config.NgrokPort = txtNgrokPort.Text.ToInt32
        config.NgrokUseSSL = cbNgrokUseSSL.Checked
        config.Debug = cbDebug.Checked
        config.ModuleProcessInterval = txtModuleProcessInterval.Text.ToInt32
        config.CheckConnectionInterval = txtCheckConnectionInterval.Text.ToInt32
        config.ResetIisOnLoad = cbResetIisOnLoad.Checked

        config.ErrEmail = txtErrEmail.Text
        config.ErrPass = txtErrPassword.Text
        config.ErrHost = txtErrHost.Text
        config.ErrSSL = ceErrUseSSL.Checked
        config.ErrPort = txtErrPort.Text.ToInt32
        config.ErrRecipient = txtErrReceipient.Text
        Return config
    End Function

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Static tabControl As New Ape.EL.UI.Component.TabOrder.TabOrderManager(Me)
        tabControl.SetTabOrder(Ape.EL.UI.Component.TabOrder.TabOrderManager.TabScheme.AcrossFirst)
    End Sub

    Private Sub frmSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Ape.EL.Utility.General.GetAssemblyIcon

        Static STR_RegexPort As String = "^[0-9]+$"
        txtWebApiPort.SetRegex(STR_RegexPort)
        txtNgrokPort.SetRegex(STR_RegexPort)
        txtErrPort.SetRegex(STR_RegexPort)
        txtModuleProcessInterval.SetRegex(STR_RegexPort)
        txtCheckConnectionInterval.SetRegex(STR_RegexPort)
        txtUrlPort.SetRegex(STR_RegexPort)
        txtAutoRestartInterval.SetRegex(STR_RegexPort)

        lbCurrentProfile.Text = String.Format("Profile:{0}{1}", Environment.NewLine, GetSettingEx(frmMain.STR_NgrokUI, STR_LastAppliedProfile))

        If Not _m_DevMode Then
            'tabControlSetting.TabPages.Remove(tabpageURL) 'temporary removal until future improvement.
            If Not _m_ShowNgrokSetting Then
                'tabControlSetting.TabPages.Remove(tabpageNgrok)
            End If
            tabControlSetting.TabPages.Remove(tabpageDev)
            tabControlSetting.TabPages.Remove(tabpageDev2)
            tabControlSetting.TabPages.Remove(tabpageDev3)
            lbCurrentProfile.Visible = False
        Else
        End If

        If m_MustSave Then
            btnCancel.Visible = False
            ControlBox = False
        End If
    End Sub

    Private Sub frmSetting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RefreshProfileList()
        cbProfiles.Text = GetSettingEx(frmMain.STR_NgrokUI, STR_LastAppliedProfile)
        LoadConfigToScreen(m_Config)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim tmpConfig = m_Config.DeepCopy
        Dim newConfig = GetConfigFromScreen()

        m_Config = newConfig

        cbProfiles.Text = GetSettingEx(frmMain.STR_NgrokUI, STR_LastAppliedProfile)
        SaveSelectedProfile()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub sbTestEmail_Click(sender As Object, e As EventArgs) Handles sbTestEmail.Click
        Try
            If Ape.EL.Misc.Email.SendEmail(txtErrEmail.Text,
                                            txtErrPassword.Text,
                                            txtErrHost.Text,
                                            ceErrUseSSL.Checked,
                                            txtErrPort.Text,
                                            txtErrReceipient.Text,
                                            "",
                                            "",
                                            "NgrokUIApp Tool Setting Test", "This is a test message.") Then
                MessageBox.Show("Send email successfully.")
            End If
        Catch ex As Exception
            MessageBox.Show("Fail to send email." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnProfilesAdd_Click(sender As Object, e As EventArgs) Handles btnProfilesAdd.Click
        Dim res As String = InputBox("Profile name:", " ").ToUpper

        If Not cbProfiles.Items.Contains(res) Then
            cbProfiles.Items.Add(res)
            cbProfiles.Text = res
            SaveSelectedProfile()
            LoadProfileToScreen(res)
        Else
            WarningMsg("Profile exists. Try again.")
        End If
    End Sub

    Private Sub btnProfilesDelete_Click(sender As Object, e As EventArgs) Handles btnProfilesDelete.Click
        If QuestionMsg("Delete selected profile?") = Windows.Forms.DialogResult.Yes Then DeleteSelectedProfile()
    End Sub

    Private Sub btnProfilesSave_Click(sender As Object, e As EventArgs) Handles btnProfilesSave.Click
        SaveSelectedProfile()
        InformationMsg("Updated profile.")
    End Sub

    Private Sub btnProfilesApply_Click(sender As Object, e As EventArgs) Handles btnProfilesApply.Click
        LoadProfileToScreen(cbProfiles.Text)
    End Sub

    Private Sub cbUrlAutoIP_CheckedChanged(sender As Object, e As EventArgs) Handles cbUrlAutoIP.CheckedChanged
        txtUrl.Enabled = Not cbUrlAutoIP.Checked
    End Sub

    Private Sub cbWebApiSelfHost_CheckedChanged(sender As Object, e As EventArgs) Handles cbWebApiSelfHost.CheckedChanged
        txtWebApiDir.Enabled = Not cbWebApiSelfHost.Checked
    End Sub
End Class