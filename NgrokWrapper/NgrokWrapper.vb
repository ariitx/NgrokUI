Imports System.Text.RegularExpressions
Imports System.Diagnostics
Imports System.IO

Public Class NgrokWrapper
    Implements IDisposable

    ''' <summary>
    ''' Forward ngrok to provided IP.
    ''' </summary>
    Property IP As String = ""
    ''' <summary>
    ''' Forward ngrok to provided Port.
    ''' </summary>
    Property Port As Integer = -1
    ''' <summary>
    ''' Ngrok subdomain to be used. Only usable if authtoken is provided.
    ''' </summary>
    Property Subdomain As String = ""

    ''' <summary>
    ''' Ngrok authtoken for premium ngrok user.
    ''' </summary>
    Property AuthToken As String = ""

    ''' <summary>
    ''' Ngrok region to be used. Default is using asia pacific.
    ''' </summary>
    Property Region As Regions = Regions.ap

    ''' <summary>
    ''' Enable HTTPS.
    ''' </summary>
    ''' <returns></returns>
    Property UseTLS As Boolean = False

    ''' <summary>
    ''' Local Ngrok IP address. Default is 4040.
    ''' </summary>
    Property NgrokPort As Integer = 4040

    Public Event Reply As Action(Of String)
    Public Event Exited As Action

    Private Shared ReadOnly ngrokPath As String = String.Format("{0}NgrokWrapper\", System.IO.Path.GetTempPath)
    Private Shared ngrokFile As String = String.Format("{0}ngrok.exe", ngrokPath)
    Private Shared ngrokConfig As String = String.Format("{0}ngrok.yml", ngrokPath)

    Private process As Process = Nothing

    Public Sub New()
        'Kill existing ngrok instances. Delete the existing files.
        StopNgrokInstances()
        Try
            If System.IO.File.Exists(ngrokFile) Then System.IO.File.Delete(ngrokFile)
            If System.IO.File.Exists(ngrokConfig) Then System.IO.File.Delete(ngrokConfig)
            Ape.EL.Utility.General.MakePath(ngrokPath)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub New(ByVal IP As String, ByVal Port As Integer)
        Me.New()
        Me.IP = IP
        Me.Port = Port
    End Sub

    Public Sub Start()
        If Port <= 0 OrElse Port >= 65535 Then
            Throw New ApplicationException("Please use a valid port.")
        End If

        If NgrokPort <= 0 OrElse NgrokPort >= 65535 Then
            Throw New ApplicationException("Please use a valid ngrok port.")
        End If

        'Setup ngrok config
        Dim config As New Config
        config.region = Region
        config.log = "false" 'String.Format("{0}ngrok.log", ngrokPath) 'set false to disable logging.
        config.web_addr = String.Format("localhost:{0}", NgrokPort)
        config.authtoken = AuthToken

        config.tunnels.Add(New Config.ConfigTunnel With {.Name = "default",
                                                         .Addr = String.Format("{0}:{1}", IP, Port),
                                                         .Host_Header = "preserve",
                                                         .Subdomain = Subdomain,
                                                         .Bind_TLS = UseTLS})

        'delete ngrok.log file if size is over 5 mb
        If System.IO.File.Exists(config.log) Then
            Try
                Dim logInfo As New FileInfo(config.log)
                If logInfo.Length > (5 * 1024 * 1024) Then
                    logInfo.Delete()
                End If
            Catch ex As Exception
                'ignore any error
            End Try
        End If

        'Write ngrok binary and config to temporary folder.
        Try
            System.IO.File.WriteAllBytes(ngrokFile, My.Resources.ngrok)
        Catch ex As Exception
        End Try
        'config must be rewritten! Any exception should be thrown.
        System.IO.File.WriteAllText(ngrokConfig, config.GetConfig)

        'Run ngrok using process
        Dim sbCommandLine As New System.Text.StringBuilder
        'sbCommandLine.Append("http -host-header=rewrite ") 'Default commandline for WebAPI to work.
        'sbCommandLine.Append("-region ap ")                'Add region to it. In this case Asia Pacific.
        'sbCommandLine.Append(String.Format("{0}:{1} ", Me.IP, Me.Port)) 'Add the IP and Port.
        'Console.WriteLine(String.Format("{0} {1}", ngrokFilepath, sbCommandLine.ToStr))
        sbCommandLine.AppendFormat("start -config=""{0}"" --all", ngrokConfig)

        If process IsNot Nothing Then
            process.Close()
            process.Dispose()
            process = Nothing
        End If

        process = New Process
        process.EnableRaisingEvents = True
        AddHandler process.OutputDataReceived, AddressOf process_OutputDataReceived
        AddHandler process.ErrorDataReceived, AddressOf process_ErrorDataReceived
        AddHandler process.Exited, AddressOf process_Exited

        process.StartInfo.FileName = ngrokFile
        process.StartInfo.Arguments = sbCommandLine.ToStr
        process.StartInfo.UseShellExecute = False
        process.StartInfo.RedirectStandardError = True
        process.StartInfo.RedirectStandardOutput = True
        process.StartInfo.UseShellExecute = False
        process.StartInfo.CreateNoWindow = True 'hide console

        process.Start()
        process.BeginErrorReadLine()
        process.BeginOutputReadLine()
        RaiseEvent Reply(String.Format("Process started at {0}", Now.ToStr))
    End Sub

    Private Sub process_Exited(sender As Object, e As EventArgs)
        RaiseEvent Reply(String.Format("Process exited at {0}.", Now.ToStr))
        RaiseEvent Exited()
    End Sub

    Private Sub process_ErrorDataReceived(sender As Object, e As DataReceivedEventArgs)
        RaiseEvent Reply(e.Data)
    End Sub

    Private Sub process_OutputDataReceived(sender As Object, e As DataReceivedEventArgs)
        RaiseEvent Reply(e.Data)
    End Sub

    Public Sub [Stop]()
        Try
            If process IsNot Nothing Then
                process.Kill()
                process.Close()
                process.Dispose()
                process = Nothing
            End If
            StopNgrokInstances()
            Dim count As Integer
            While count < 3
                Try
                    If System.IO.File.Exists(ngrokFile) Then System.IO.File.Delete(ngrokFile)
                    Exit While
                Catch ex As Exception
                    Threading.Thread.Sleep(300)
                    count += 1
                End Try
            End While
        Catch ex As Exception
            'ignore exception
        End Try
    End Sub

    ''' <summary>
    ''' Kill all ngrok instances.
    ''' </summary>
    Public Shared Sub StopNgrokInstances()
        Try
            Static p() As Process
            p = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(ngrokFile))
            If p.Count > 0 Then
                ' Process is running
                For Each pp In p
                    pp.Kill()
                Next
            Else
                ' Process is not running
            End If
        Catch ex As Exception
            'ignore exception...
        End Try
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                Me.Stop()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class