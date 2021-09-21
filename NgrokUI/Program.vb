Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Threading

Friend NotInheritable Class Program
    Inherits WindowsFormsApplicationBase

    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <EditorBrowsable(EditorBrowsableState.Advanced), DebuggerHidden(), STAThread()> _
    <MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)> _
    <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
    Friend Shared Sub Main(args As String())
        Try
            Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering)
        Finally
        End Try

        Dim o As New Program
        o.Run(args)
    End Sub

#Region "Startup object"
    <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
    Public Sub New()
        MyBase.New(AuthenticationMode.Windows)
        Me.IsSingleInstance = True
        Me.EnableVisualStyles = True
        Me.SaveMySettingsOnExit = True
        Me.ShutdownStyle = ShutdownMode.AfterMainFormCloses
    End Sub

    <DebuggerStepThrough()>
    Protected Overrides Sub OnCreateMainForm()
        Me.MainForm = New frmMain
    End Sub

    <DebuggerStepThrough()>
    Protected Overrides Sub OnShutdown()
        MyBase.OnShutdown()
    End Sub
#End Region

#Region "Events"
    Private Sub MyApplication_UnhandledException(ByVal sender As Object, _
                                                 ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs _
                                                 ) Handles Me.UnhandledException
        Try
            Ape.EL.App.ErrorLog.WriteMessage(e.Exception.ToString)
            Ape.EL.WinForm.General.WarningMsg(e.Exception.Message)
        Catch ex As Exception
            MessageBox.Show(e.Exception.ToString)
        End Try

        e.ExitApplication = False
    End Sub
#End Region
End Class