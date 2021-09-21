<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lbWebApiPort = New System.Windows.Forms.Label()
        Me.txtWebApiPort = New System.Windows.Forms.TextBox()
        Me.gbPOS = New System.Windows.Forms.GroupBox()
        Me.txtSAPass = New System.Windows.Forms.TextBox()
        Me.txtServerName = New System.Windows.Forms.TextBox()
        Me.lbSAPass = New System.Windows.Forms.Label()
        Me.lbServerName = New System.Windows.Forms.Label()
        Me.lbPOSInfo = New System.Windows.Forms.Label()
        Me.myToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbWebApiSelfHost = New System.Windows.Forms.CheckBox()
        Me.lbSilentMode = New System.Windows.Forms.Label()
        Me.lbModuleProcessInterval = New System.Windows.Forms.Label()
        Me.lbCheckConnectionInterval = New System.Windows.Forms.Label()
        Me.btnProfilesDelete = New System.Windows.Forms.Button()
        Me.btnProfilesAdd = New System.Windows.Forms.Button()
        Me.btnProfilesSave = New System.Windows.Forms.Button()
        Me.btnProfilesApply = New System.Windows.Forms.Button()
        Me.lbResetIisOnLoad = New System.Windows.Forms.Label()
        Me.txtUrlPort = New System.Windows.Forms.TextBox()
        Me.lbAutoRestart = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tabControlSetting = New System.Windows.Forms.TabControl()
        Me.tabpageGeneral = New System.Windows.Forms.TabPage()
        Me.lbAutoRestartInterval = New System.Windows.Forms.Label()
        Me.txtAutoRestartInterval = New System.Windows.Forms.TextBox()
        Me.cbAutoRestart = New System.Windows.Forms.CheckBox()
        Me.txtWebApiDir = New System.Windows.Forms.TextBox()
        Me.lbWebApiDir = New System.Windows.Forms.Label()
        Me.lbNgrokPort = New System.Windows.Forms.Label()
        Me.txtNgrokPort = New System.Windows.Forms.TextBox()
        Me.tabpageURL = New System.Windows.Forms.TabPage()
        Me.cbUrlAutoIP = New System.Windows.Forms.CheckBox()
        Me.lbUriInfo = New System.Windows.Forms.Label()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.lbUrl = New System.Windows.Forms.Label()
        Me.tabpageNgrok = New System.Windows.Forms.TabPage()
        Me.lblNgrokInfo = New System.Windows.Forms.Label()
        Me.txtNgrokAuthToken = New System.Windows.Forms.TextBox()
        Me.lblNgrokAuthToken = New System.Windows.Forms.Label()
        Me.txtNgrokSubdomain = New System.Windows.Forms.TextBox()
        Me.lblNgrokSubdomain = New System.Windows.Forms.Label()
        Me.tabpageErrorEmail = New System.Windows.Forms.TabPage()
        Me.sbTestEmail = New System.Windows.Forms.Button()
        Me.txtErrReceipient = New System.Windows.Forms.TextBox()
        Me.lbErrEmail = New System.Windows.Forms.Label()
        Me.lbRecipient = New System.Windows.Forms.Label()
        Me.lbErrPassword = New System.Windows.Forms.Label()
        Me.ceErrUseSSL = New System.Windows.Forms.CheckBox()
        Me.txtErrEmail = New System.Windows.Forms.TextBox()
        Me.txtErrPort = New System.Windows.Forms.TextBox()
        Me.txtErrPassword = New System.Windows.Forms.TextBox()
        Me.txtErrHost = New System.Windows.Forms.TextBox()
        Me.lbErrHost = New System.Windows.Forms.Label()
        Me.lbErrPort = New System.Windows.Forms.Label()
        Me.lbErrUseSSL = New System.Windows.Forms.Label()
        Me.tabpageDev = New System.Windows.Forms.TabPage()
        Me.cbDebug = New System.Windows.Forms.CheckBox()
        Me.lbDebug = New System.Windows.Forms.Label()
        Me.cbSilentMode = New System.Windows.Forms.CheckBox()
        Me.tabpageDev2 = New System.Windows.Forms.TabPage()
        Me.cbResetIisOnLoad = New System.Windows.Forms.CheckBox()
        Me.txtCheckConnectionInterval = New System.Windows.Forms.TextBox()
        Me.txtModuleProcessInterval = New System.Windows.Forms.TextBox()
        Me.tabpageDev3 = New System.Windows.Forms.TabPage()
        Me.cbProfiles = New System.Windows.Forms.ComboBox()
        Me.lbProfiles = New System.Windows.Forms.Label()
        Me.lbCurrentProfile = New System.Windows.Forms.Label()
        Me.gbPOS.SuspendLayout()
        Me.tabControlSetting.SuspendLayout()
        Me.tabpageGeneral.SuspendLayout()
        Me.tabpageURL.SuspendLayout()
        Me.tabpageNgrok.SuspendLayout()
        Me.tabpageErrorEmail.SuspendLayout()
        Me.tabpageDev.SuspendLayout()
        Me.tabpageDev2.SuspendLayout()
        Me.tabpageDev3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(12, 240)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 40)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lbWebApiPort
        '
        Me.lbWebApiPort.Location = New System.Drawing.Point(10, 44)
        Me.lbWebApiPort.Name = "lbWebApiPort"
        Me.lbWebApiPort.Size = New System.Drawing.Size(100, 23)
        Me.lbWebApiPort.TabIndex = 0
        Me.lbWebApiPort.Text = "Website Port"
        '
        'txtWebApiPort
        '
        Me.txtWebApiPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWebApiPort.Location = New System.Drawing.Point(136, 41)
        Me.txtWebApiPort.MaxLength = 5
        Me.txtWebApiPort.Name = "txtWebApiPort"
        Me.txtWebApiPort.Size = New System.Drawing.Size(150, 24)
        Me.txtWebApiPort.TabIndex = 3
        '
        'gbPOS
        '
        Me.gbPOS.Controls.Add(Me.txtSAPass)
        Me.gbPOS.Controls.Add(Me.txtServerName)
        Me.gbPOS.Controls.Add(Me.lbSAPass)
        Me.gbPOS.Controls.Add(Me.lbServerName)
        Me.gbPOS.Controls.Add(Me.lbPOSInfo)
        Me.gbPOS.Location = New System.Drawing.Point(4000, 146)
        Me.gbPOS.Name = "gbPOS"
        Me.gbPOS.Size = New System.Drawing.Size(329, 100)
        Me.gbPOS.TabIndex = 11
        Me.gbPOS.TabStop = False
        Me.gbPOS.Text = "POS Setting"
        Me.gbPOS.Visible = False
        '
        'txtSAPass
        '
        Me.txtSAPass.Location = New System.Drawing.Point(111, 67)
        Me.txtSAPass.Name = "txtSAPass"
        Me.txtSAPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSAPass.Size = New System.Drawing.Size(198, 24)
        Me.txtSAPass.TabIndex = 1
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(111, 40)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(198, 24)
        Me.txtServerName.TabIndex = 0
        '
        'lbSAPass
        '
        Me.lbSAPass.Location = New System.Drawing.Point(6, 67)
        Me.lbSAPass.Name = "lbSAPass"
        Me.lbSAPass.Size = New System.Drawing.Size(85, 13)
        Me.lbSAPass.TabIndex = 0
        Me.lbSAPass.Text = "SA Password"
        Me.lbSAPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbServerName
        '
        Me.lbServerName.Location = New System.Drawing.Point(6, 43)
        Me.lbServerName.Name = "lbServerName"
        Me.lbServerName.Size = New System.Drawing.Size(85, 13)
        Me.lbServerName.TabIndex = 0
        Me.lbServerName.Text = "Server Name"
        Me.lbServerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbPOSInfo
        '
        Me.lbPOSInfo.AutoSize = True
        Me.lbPOSInfo.Location = New System.Drawing.Point(12, 19)
        Me.lbPOSInfo.Name = "lbPOSInfo"
        Me.lbPOSInfo.Size = New System.Drawing.Size(274, 18)
        Me.lbPOSInfo.TabIndex = 0
        Me.lbPOSInfo.Text = "Note: Leave empty to use default setting."
        '
        'myToolTip
        '
        Me.myToolTip.AutomaticDelay = 200
        '
        'cbWebApiSelfHost
        '
        Me.cbWebApiSelfHost.AutoSize = True
        Me.cbWebApiSelfHost.Location = New System.Drawing.Point(292, 41)
        Me.cbWebApiSelfHost.Name = "cbWebApiSelfHost"
        Me.cbWebApiSelfHost.Size = New System.Drawing.Size(88, 22)
        Me.cbWebApiSelfHost.TabIndex = 7
        Me.cbWebApiSelfHost.Text = "Self Host"
        Me.myToolTip.SetToolTip(Me.cbWebApiSelfHost, "Check this box if you have set up WebAPI using other method." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This will skip setu" &
        "p for CassiniDev from Web directory.")
        Me.cbWebApiSelfHost.UseVisualStyleBackColor = True
        '
        'lbSilentMode
        '
        Me.lbSilentMode.Location = New System.Drawing.Point(9, 37)
        Me.lbSilentMode.Name = "lbSilentMode"
        Me.lbSilentMode.Size = New System.Drawing.Size(100, 23)
        Me.lbSilentMode.TabIndex = 14
        Me.lbSilentMode.Text = "Silent Mode"
        Me.myToolTip.SetToolTip(Me.lbSilentMode, "All messages will be logged or emailed instead of message prompt.")
        '
        'lbModuleProcessInterval
        '
        Me.lbModuleProcessInterval.Location = New System.Drawing.Point(9, 9)
        Me.lbModuleProcessInterval.Name = "lbModuleProcessInterval"
        Me.lbModuleProcessInterval.Size = New System.Drawing.Size(100, 23)
        Me.lbModuleProcessInterval.TabIndex = 7
        Me.lbModuleProcessInterval.Text = "Mod Interval"
        Me.myToolTip.SetToolTip(Me.lbModuleProcessInterval, "Module Process Interval in Millisecond")
        '
        'lbCheckConnectionInterval
        '
        Me.lbCheckConnectionInterval.Location = New System.Drawing.Point(9, 39)
        Me.lbCheckConnectionInterval.Name = "lbCheckConnectionInterval"
        Me.lbCheckConnectionInterval.Size = New System.Drawing.Size(100, 23)
        Me.lbCheckConnectionInterval.TabIndex = 9
        Me.lbCheckConnectionInterval.Text = "Chk Interval"
        Me.myToolTip.SetToolTip(Me.lbCheckConnectionInterval, "Check Connection Interval in Millisecond")
        '
        'btnProfilesDelete
        '
        Me.btnProfilesDelete.Location = New System.Drawing.Point(303, 6)
        Me.btnProfilesDelete.Name = "btnProfilesDelete"
        Me.btnProfilesDelete.Size = New System.Drawing.Size(26, 26)
        Me.btnProfilesDelete.TabIndex = 3
        Me.btnProfilesDelete.Text = "-"
        Me.myToolTip.SetToolTip(Me.btnProfilesDelete, "Delete selected profile")
        Me.btnProfilesDelete.UseVisualStyleBackColor = True
        '
        'btnProfilesAdd
        '
        Me.btnProfilesAdd.Location = New System.Drawing.Point(271, 6)
        Me.btnProfilesAdd.Name = "btnProfilesAdd"
        Me.btnProfilesAdd.Size = New System.Drawing.Size(26, 26)
        Me.btnProfilesAdd.TabIndex = 2
        Me.btnProfilesAdd.Text = "+"
        Me.myToolTip.SetToolTip(Me.btnProfilesAdd, "Add new profile")
        Me.btnProfilesAdd.UseVisualStyleBackColor = True
        '
        'btnProfilesSave
        '
        Me.btnProfilesSave.Location = New System.Drawing.Point(335, 6)
        Me.btnProfilesSave.Name = "btnProfilesSave"
        Me.btnProfilesSave.Size = New System.Drawing.Size(26, 26)
        Me.btnProfilesSave.TabIndex = 4
        Me.btnProfilesSave.Text = "&S"
        Me.myToolTip.SetToolTip(Me.btnProfilesSave, "Save current setting with this profile")
        Me.btnProfilesSave.UseVisualStyleBackColor = True
        '
        'btnProfilesApply
        '
        Me.btnProfilesApply.Location = New System.Drawing.Point(367, 6)
        Me.btnProfilesApply.Name = "btnProfilesApply"
        Me.btnProfilesApply.Size = New System.Drawing.Size(26, 26)
        Me.btnProfilesApply.TabIndex = 5
        Me.btnProfilesApply.Text = "&A"
        Me.myToolTip.SetToolTip(Me.btnProfilesApply, "Apply selected profile")
        Me.btnProfilesApply.UseVisualStyleBackColor = True
        '
        'lbResetIisOnLoad
        '
        Me.lbResetIisOnLoad.Location = New System.Drawing.Point(9, 67)
        Me.lbResetIisOnLoad.Name = "lbResetIisOnLoad"
        Me.lbResetIisOnLoad.Size = New System.Drawing.Size(100, 23)
        Me.lbResetIisOnLoad.TabIndex = 11
        Me.lbResetIisOnLoad.Text = "Reset IIS"
        Me.myToolTip.SetToolTip(Me.lbResetIisOnLoad, "Reset IIS Express on program load. This can help program to close opened port by " &
        "previous IIS instance.")
        '
        'txtUrlPort
        '
        Me.txtUrlPort.Location = New System.Drawing.Point(115, 36)
        Me.txtUrlPort.Name = "txtUrlPort"
        Me.txtUrlPort.Size = New System.Drawing.Size(200, 24)
        Me.txtUrlPort.TabIndex = 11
        Me.myToolTip.SetToolTip(Me.txtUrlPort, "Port. Leave empty if not have to set port.")
        '
        'lbAutoRestart
        '
        Me.lbAutoRestart.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.lbAutoRestart.Location = New System.Drawing.Point(11, 103)
        Me.lbAutoRestart.Name = "lbAutoRestart"
        Me.lbAutoRestart.Size = New System.Drawing.Size(100, 23)
        Me.lbAutoRestart.TabIndex = 22
        Me.lbAutoRestart.Text = "Auto Restart"
        Me.lbAutoRestart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.myToolTip.SetToolTip(Me.lbAutoRestart, "This option will automatically restart connection." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you are unsure about this " &
        "option, leave it unchanged.")
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Port"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.myToolTip.SetToolTip(Me.Label1, "Public port used for port forwarding from router.")
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(98, 240)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 40)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tabControlSetting
        '
        Me.tabControlSetting.Controls.Add(Me.tabpageGeneral)
        Me.tabControlSetting.Controls.Add(Me.tabpageURL)
        Me.tabControlSetting.Controls.Add(Me.tabpageNgrok)
        Me.tabControlSetting.Controls.Add(Me.tabpageErrorEmail)
        Me.tabControlSetting.Controls.Add(Me.tabpageDev)
        Me.tabControlSetting.Controls.Add(Me.tabpageDev2)
        Me.tabControlSetting.Controls.Add(Me.tabpageDev3)
        Me.tabControlSetting.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabControlSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControlSetting.ItemSize = New System.Drawing.Size(0, 30)
        Me.tabControlSetting.Location = New System.Drawing.Point(0, 0)
        Me.tabControlSetting.Name = "tabControlSetting"
        Me.tabControlSetting.SelectedIndex = 0
        Me.tabControlSetting.Size = New System.Drawing.Size(426, 225)
        Me.tabControlSetting.TabIndex = 12
        '
        'tabpageGeneral
        '
        Me.tabpageGeneral.Controls.Add(Me.lbAutoRestartInterval)
        Me.tabpageGeneral.Controls.Add(Me.txtAutoRestartInterval)
        Me.tabpageGeneral.Controls.Add(Me.cbAutoRestart)
        Me.tabpageGeneral.Controls.Add(Me.lbAutoRestart)
        Me.tabpageGeneral.Controls.Add(Me.txtWebApiDir)
        Me.tabpageGeneral.Controls.Add(Me.lbWebApiDir)
        Me.tabpageGeneral.Controls.Add(Me.cbWebApiSelfHost)
        Me.tabpageGeneral.Controls.Add(Me.txtWebApiPort)
        Me.tabpageGeneral.Controls.Add(Me.lbWebApiPort)
        Me.tabpageGeneral.Controls.Add(Me.lbNgrokPort)
        Me.tabpageGeneral.Controls.Add(Me.txtNgrokPort)
        Me.tabpageGeneral.Location = New System.Drawing.Point(4, 34)
        Me.tabpageGeneral.Name = "tabpageGeneral"
        Me.tabpageGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageGeneral.Size = New System.Drawing.Size(418, 187)
        Me.tabpageGeneral.TabIndex = 5
        Me.tabpageGeneral.Text = "General"
        Me.tabpageGeneral.UseVisualStyleBackColor = True
        '
        'lbAutoRestartInterval
        '
        Me.lbAutoRestartInterval.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.lbAutoRestartInterval.Location = New System.Drawing.Point(210, 103)
        Me.lbAutoRestartInterval.Name = "lbAutoRestartInterval"
        Me.lbAutoRestartInterval.Size = New System.Drawing.Size(100, 23)
        Me.lbAutoRestartInterval.TabIndex = 25
        Me.lbAutoRestartInterval.Text = "Hour(s)"
        Me.lbAutoRestartInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAutoRestartInterval
        '
        Me.txtAutoRestartInterval.Location = New System.Drawing.Point(136, 103)
        Me.txtAutoRestartInterval.Name = "txtAutoRestartInterval"
        Me.txtAutoRestartInterval.Size = New System.Drawing.Size(68, 24)
        Me.txtAutoRestartInterval.TabIndex = 24
        '
        'cbAutoRestart
        '
        Me.cbAutoRestart.AutoSize = True
        Me.cbAutoRestart.Location = New System.Drawing.Point(115, 109)
        Me.cbAutoRestart.Name = "cbAutoRestart"
        Me.cbAutoRestart.Size = New System.Drawing.Size(15, 14)
        Me.cbAutoRestart.TabIndex = 23
        Me.cbAutoRestart.UseVisualStyleBackColor = True
        '
        'txtWebApiDir
        '
        Me.txtWebApiDir.Location = New System.Drawing.Point(136, 71)
        Me.txtWebApiDir.Name = "txtWebApiDir"
        Me.txtWebApiDir.Size = New System.Drawing.Size(200, 24)
        Me.txtWebApiDir.TabIndex = 6
        '
        'lbWebApiDir
        '
        Me.lbWebApiDir.Location = New System.Drawing.Point(10, 74)
        Me.lbWebApiDir.Name = "lbWebApiDir"
        Me.lbWebApiDir.Size = New System.Drawing.Size(100, 23)
        Me.lbWebApiDir.TabIndex = 5
        Me.lbWebApiDir.Text = "Website Dir"
        '
        'lbNgrokPort
        '
        Me.lbNgrokPort.Location = New System.Drawing.Point(10, 12)
        Me.lbNgrokPort.Name = "lbNgrokPort"
        Me.lbNgrokPort.Size = New System.Drawing.Size(100, 23)
        Me.lbNgrokPort.TabIndex = 5
        Me.lbNgrokPort.Text = "Ngrok Port"
        '
        'txtNgrokPort
        '
        Me.txtNgrokPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNgrokPort.Location = New System.Drawing.Point(136, 9)
        Me.txtNgrokPort.MaxLength = 5
        Me.txtNgrokPort.Name = "txtNgrokPort"
        Me.txtNgrokPort.Size = New System.Drawing.Size(150, 24)
        Me.txtNgrokPort.TabIndex = 6
        '
        'tabpageURL
        '
        Me.tabpageURL.Controls.Add(Me.Label1)
        Me.tabpageURL.Controls.Add(Me.txtUrlPort)
        Me.tabpageURL.Controls.Add(Me.cbUrlAutoIP)
        Me.tabpageURL.Controls.Add(Me.lbUriInfo)
        Me.tabpageURL.Controls.Add(Me.txtUrl)
        Me.tabpageURL.Controls.Add(Me.lbUrl)
        Me.tabpageURL.Location = New System.Drawing.Point(4, 34)
        Me.tabpageURL.Name = "tabpageURL"
        Me.tabpageURL.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageURL.Size = New System.Drawing.Size(418, 187)
        Me.tabpageURL.TabIndex = 1
        Me.tabpageURL.Text = "URL"
        Me.tabpageURL.UseVisualStyleBackColor = True
        '
        'cbUrlAutoIP
        '
        Me.cbUrlAutoIP.AutoSize = True
        Me.cbUrlAutoIP.Location = New System.Drawing.Point(321, 8)
        Me.cbUrlAutoIP.Name = "cbUrlAutoIP"
        Me.cbUrlAutoIP.Size = New System.Drawing.Size(74, 22)
        Me.cbUrlAutoIP.TabIndex = 10
        Me.cbUrlAutoIP.Text = "Auto IP"
        Me.cbUrlAutoIP.UseVisualStyleBackColor = True
        '
        'lbUriInfo
        '
        Me.lbUriInfo.Location = New System.Drawing.Point(9, 63)
        Me.lbUriInfo.Name = "lbUriInfo"
        Me.lbUriInfo.Size = New System.Drawing.Size(306, 116)
        Me.lbUriInfo.TabIndex = 9
        Me.lbUriInfo.Text = "Note: If your router is allowed to set port forwarding, you can set the static UR" &
    "L on Custom URL above." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Leave blank and tick ""Auto IP"" to use system generated" &
    " URL."
        '
        'txtUrl
        '
        Me.txtUrl.Location = New System.Drawing.Point(115, 6)
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(200, 24)
        Me.txtUrl.TabIndex = 8
        '
        'lbUrl
        '
        Me.lbUrl.Location = New System.Drawing.Point(9, 9)
        Me.lbUrl.Name = "lbUrl"
        Me.lbUrl.Size = New System.Drawing.Size(100, 23)
        Me.lbUrl.TabIndex = 7
        Me.lbUrl.Text = "Custom URL"
        Me.lbUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabpageNgrok
        '
        Me.tabpageNgrok.Controls.Add(Me.lblNgrokInfo)
        Me.tabpageNgrok.Controls.Add(Me.txtNgrokAuthToken)
        Me.tabpageNgrok.Controls.Add(Me.lblNgrokAuthToken)
        Me.tabpageNgrok.Controls.Add(Me.txtNgrokSubdomain)
        Me.tabpageNgrok.Controls.Add(Me.lblNgrokSubdomain)
        Me.tabpageNgrok.Location = New System.Drawing.Point(4, 34)
        Me.tabpageNgrok.Name = "tabpageNgrok"
        Me.tabpageNgrok.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageNgrok.Size = New System.Drawing.Size(418, 187)
        Me.tabpageNgrok.TabIndex = 7
        Me.tabpageNgrok.Text = "ngrok"
        Me.tabpageNgrok.UseVisualStyleBackColor = True
        '
        'lblNgrokInfo
        '
        Me.lblNgrokInfo.Location = New System.Drawing.Point(9, 66)
        Me.lblNgrokInfo.Name = "lblNgrokInfo"
        Me.lblNgrokInfo.Size = New System.Drawing.Size(306, 118)
        Me.lblNgrokInfo.TabIndex = 3
        Me.lblNgrokInfo.Text = "Note: If you have ngrok paid plan, you can set your subdomain and auth token in t" &
    "his page." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Leave blank to use default setting."
        '
        'txtNgrokAuthToken
        '
        Me.txtNgrokAuthToken.Location = New System.Drawing.Point(115, 6)
        Me.txtNgrokAuthToken.Name = "txtNgrokAuthToken"
        Me.txtNgrokAuthToken.Size = New System.Drawing.Size(200, 24)
        Me.txtNgrokAuthToken.TabIndex = 1
        '
        'lblNgrokAuthToken
        '
        Me.lblNgrokAuthToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgrokAuthToken.Location = New System.Drawing.Point(9, 9)
        Me.lblNgrokAuthToken.Name = "lblNgrokAuthToken"
        Me.lblNgrokAuthToken.Size = New System.Drawing.Size(100, 23)
        Me.lblNgrokAuthToken.TabIndex = 0
        Me.lblNgrokAuthToken.Text = "ngrok Auth Token"
        Me.lblNgrokAuthToken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNgrokSubdomain
        '
        Me.txtNgrokSubdomain.Location = New System.Drawing.Point(115, 36)
        Me.txtNgrokSubdomain.Name = "txtNgrokSubdomain"
        Me.txtNgrokSubdomain.Size = New System.Drawing.Size(200, 24)
        Me.txtNgrokSubdomain.TabIndex = 2
        '
        'lblNgrokSubdomain
        '
        Me.lblNgrokSubdomain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgrokSubdomain.Location = New System.Drawing.Point(9, 37)
        Me.lblNgrokSubdomain.Name = "lblNgrokSubdomain"
        Me.lblNgrokSubdomain.Size = New System.Drawing.Size(100, 23)
        Me.lblNgrokSubdomain.TabIndex = 0
        Me.lblNgrokSubdomain.Text = "ngrok Subdomain"
        Me.lblNgrokSubdomain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabpageErrorEmail
        '
        Me.tabpageErrorEmail.Controls.Add(Me.sbTestEmail)
        Me.tabpageErrorEmail.Controls.Add(Me.txtErrReceipient)
        Me.tabpageErrorEmail.Controls.Add(Me.lbErrEmail)
        Me.tabpageErrorEmail.Controls.Add(Me.lbRecipient)
        Me.tabpageErrorEmail.Controls.Add(Me.lbErrPassword)
        Me.tabpageErrorEmail.Controls.Add(Me.ceErrUseSSL)
        Me.tabpageErrorEmail.Controls.Add(Me.txtErrEmail)
        Me.tabpageErrorEmail.Controls.Add(Me.txtErrPort)
        Me.tabpageErrorEmail.Controls.Add(Me.txtErrPassword)
        Me.tabpageErrorEmail.Controls.Add(Me.txtErrHost)
        Me.tabpageErrorEmail.Controls.Add(Me.lbErrHost)
        Me.tabpageErrorEmail.Controls.Add(Me.lbErrPort)
        Me.tabpageErrorEmail.Controls.Add(Me.lbErrUseSSL)
        Me.tabpageErrorEmail.Location = New System.Drawing.Point(4, 34)
        Me.tabpageErrorEmail.Name = "tabpageErrorEmail"
        Me.tabpageErrorEmail.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageErrorEmail.Size = New System.Drawing.Size(418, 187)
        Me.tabpageErrorEmail.TabIndex = 4
        Me.tabpageErrorEmail.Text = "Error Email"
        Me.tabpageErrorEmail.UseVisualStyleBackColor = True
        '
        'sbTestEmail
        '
        Me.sbTestEmail.Location = New System.Drawing.Point(321, 138)
        Me.sbTestEmail.Name = "sbTestEmail"
        Me.sbTestEmail.Size = New System.Drawing.Size(59, 43)
        Me.sbTestEmail.TabIndex = 16
        Me.sbTestEmail.Text = "Test"
        '
        'txtErrReceipient
        '
        Me.txtErrReceipient.Location = New System.Drawing.Point(115, 156)
        Me.txtErrReceipient.Name = "txtErrReceipient"
        Me.txtErrReceipient.Size = New System.Drawing.Size(200, 24)
        Me.txtErrReceipient.TabIndex = 15
        '
        'lbErrEmail
        '
        Me.lbErrEmail.Location = New System.Drawing.Point(9, 9)
        Me.lbErrEmail.Name = "lbErrEmail"
        Me.lbErrEmail.Size = New System.Drawing.Size(100, 23)
        Me.lbErrEmail.TabIndex = 5
        Me.lbErrEmail.Text = "Email"
        '
        'lbRecipient
        '
        Me.lbRecipient.Location = New System.Drawing.Point(9, 159)
        Me.lbRecipient.Name = "lbRecipient"
        Me.lbRecipient.Size = New System.Drawing.Size(100, 23)
        Me.lbRecipient.TabIndex = 17
        Me.lbRecipient.Text = "Recipient"
        '
        'lbErrPassword
        '
        Me.lbErrPassword.Location = New System.Drawing.Point(9, 39)
        Me.lbErrPassword.Name = "lbErrPassword"
        Me.lbErrPassword.Size = New System.Drawing.Size(100, 23)
        Me.lbErrPassword.TabIndex = 6
        Me.lbErrPassword.Text = "Password"
        '
        'ceErrUseSSL
        '
        Me.ceErrUseSSL.Location = New System.Drawing.Point(115, 96)
        Me.ceErrUseSSL.Name = "ceErrUseSSL"
        Me.ceErrUseSSL.Size = New System.Drawing.Size(83, 24)
        Me.ceErrUseSSL.TabIndex = 13
        '
        'txtErrEmail
        '
        Me.txtErrEmail.Location = New System.Drawing.Point(115, 6)
        Me.txtErrEmail.Name = "txtErrEmail"
        Me.txtErrEmail.Size = New System.Drawing.Size(200, 24)
        Me.txtErrEmail.TabIndex = 7
        '
        'txtErrPort
        '
        Me.txtErrPort.Location = New System.Drawing.Point(115, 126)
        Me.txtErrPort.Name = "txtErrPort"
        Me.txtErrPort.Size = New System.Drawing.Size(200, 24)
        Me.txtErrPort.TabIndex = 14
        '
        'txtErrPassword
        '
        Me.txtErrPassword.Location = New System.Drawing.Point(115, 36)
        Me.txtErrPassword.Name = "txtErrPassword"
        Me.txtErrPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtErrPassword.Size = New System.Drawing.Size(200, 24)
        Me.txtErrPassword.TabIndex = 8
        '
        'txtErrHost
        '
        Me.txtErrHost.Location = New System.Drawing.Point(115, 66)
        Me.txtErrHost.Name = "txtErrHost"
        Me.txtErrHost.Size = New System.Drawing.Size(200, 24)
        Me.txtErrHost.TabIndex = 12
        '
        'lbErrHost
        '
        Me.lbErrHost.Location = New System.Drawing.Point(9, 69)
        Me.lbErrHost.Name = "lbErrHost"
        Me.lbErrHost.Size = New System.Drawing.Size(100, 23)
        Me.lbErrHost.TabIndex = 9
        Me.lbErrHost.Text = "Host"
        '
        'lbErrPort
        '
        Me.lbErrPort.Location = New System.Drawing.Point(9, 129)
        Me.lbErrPort.Name = "lbErrPort"
        Me.lbErrPort.Size = New System.Drawing.Size(100, 23)
        Me.lbErrPort.TabIndex = 11
        Me.lbErrPort.Text = "Port"
        '
        'lbErrUseSSL
        '
        Me.lbErrUseSSL.Location = New System.Drawing.Point(9, 98)
        Me.lbErrUseSSL.Name = "lbErrUseSSL"
        Me.lbErrUseSSL.Size = New System.Drawing.Size(100, 23)
        Me.lbErrUseSSL.TabIndex = 10
        Me.lbErrUseSSL.Text = "Use SSL"
        '
        'tabpageDev
        '
        Me.tabpageDev.Controls.Add(Me.cbDebug)
        Me.tabpageDev.Controls.Add(Me.lbDebug)
        Me.tabpageDev.Controls.Add(Me.cbSilentMode)
        Me.tabpageDev.Controls.Add(Me.lbSilentMode)
        Me.tabpageDev.Location = New System.Drawing.Point(4, 34)
        Me.tabpageDev.Name = "tabpageDev"
        Me.tabpageDev.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageDev.Size = New System.Drawing.Size(418, 187)
        Me.tabpageDev.TabIndex = 3
        Me.tabpageDev.Text = "Dev"
        Me.tabpageDev.UseVisualStyleBackColor = True
        '
        'cbDebug
        '
        Me.cbDebug.AutoSize = True
        Me.cbDebug.Location = New System.Drawing.Point(115, 12)
        Me.cbDebug.Name = "cbDebug"
        Me.cbDebug.Size = New System.Drawing.Size(15, 14)
        Me.cbDebug.TabIndex = 9
        Me.cbDebug.UseVisualStyleBackColor = True
        '
        'lbDebug
        '
        Me.lbDebug.Location = New System.Drawing.Point(9, 9)
        Me.lbDebug.Name = "lbDebug"
        Me.lbDebug.Size = New System.Drawing.Size(100, 23)
        Me.lbDebug.TabIndex = 8
        Me.lbDebug.Text = "Debug"
        '
        'cbSilentMode
        '
        Me.cbSilentMode.Location = New System.Drawing.Point(115, 35)
        Me.cbSilentMode.Name = "cbSilentMode"
        Me.cbSilentMode.Size = New System.Drawing.Size(83, 24)
        Me.cbSilentMode.TabIndex = 15
        '
        'tabpageDev2
        '
        Me.tabpageDev2.Controls.Add(Me.cbResetIisOnLoad)
        Me.tabpageDev2.Controls.Add(Me.lbResetIisOnLoad)
        Me.tabpageDev2.Controls.Add(Me.txtCheckConnectionInterval)
        Me.tabpageDev2.Controls.Add(Me.lbCheckConnectionInterval)
        Me.tabpageDev2.Controls.Add(Me.txtModuleProcessInterval)
        Me.tabpageDev2.Controls.Add(Me.lbModuleProcessInterval)
        Me.tabpageDev2.Location = New System.Drawing.Point(4, 34)
        Me.tabpageDev2.Name = "tabpageDev2"
        Me.tabpageDev2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageDev2.Size = New System.Drawing.Size(418, 187)
        Me.tabpageDev2.TabIndex = 6
        Me.tabpageDev2.Text = "Dev2"
        Me.tabpageDev2.UseVisualStyleBackColor = True
        '
        'cbResetIisOnLoad
        '
        Me.cbResetIisOnLoad.AutoSize = True
        Me.cbResetIisOnLoad.Location = New System.Drawing.Point(115, 70)
        Me.cbResetIisOnLoad.Name = "cbResetIisOnLoad"
        Me.cbResetIisOnLoad.Size = New System.Drawing.Size(15, 14)
        Me.cbResetIisOnLoad.TabIndex = 12
        Me.cbResetIisOnLoad.UseVisualStyleBackColor = True
        '
        'txtCheckConnectionInterval
        '
        Me.txtCheckConnectionInterval.Location = New System.Drawing.Point(115, 36)
        Me.txtCheckConnectionInterval.Name = "txtCheckConnectionInterval"
        Me.txtCheckConnectionInterval.Size = New System.Drawing.Size(150, 24)
        Me.txtCheckConnectionInterval.TabIndex = 10
        '
        'txtModuleProcessInterval
        '
        Me.txtModuleProcessInterval.Location = New System.Drawing.Point(115, 6)
        Me.txtModuleProcessInterval.Name = "txtModuleProcessInterval"
        Me.txtModuleProcessInterval.Size = New System.Drawing.Size(150, 24)
        Me.txtModuleProcessInterval.TabIndex = 8
        '
        'tabpageDev3
        '
        Me.tabpageDev3.Controls.Add(Me.btnProfilesApply)
        Me.tabpageDev3.Controls.Add(Me.btnProfilesSave)
        Me.tabpageDev3.Controls.Add(Me.btnProfilesDelete)
        Me.tabpageDev3.Controls.Add(Me.btnProfilesAdd)
        Me.tabpageDev3.Controls.Add(Me.cbProfiles)
        Me.tabpageDev3.Controls.Add(Me.lbProfiles)
        Me.tabpageDev3.Location = New System.Drawing.Point(4, 34)
        Me.tabpageDev3.Name = "tabpageDev3"
        Me.tabpageDev3.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageDev3.Size = New System.Drawing.Size(418, 187)
        Me.tabpageDev3.TabIndex = 8
        Me.tabpageDev3.Text = "Dev3"
        Me.tabpageDev3.UseVisualStyleBackColor = True
        '
        'cbProfiles
        '
        Me.cbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProfiles.FormattingEnabled = True
        Me.cbProfiles.Location = New System.Drawing.Point(115, 6)
        Me.cbProfiles.Name = "cbProfiles"
        Me.cbProfiles.Size = New System.Drawing.Size(150, 26)
        Me.cbProfiles.TabIndex = 1
        '
        'lbProfiles
        '
        Me.lbProfiles.AutoSize = True
        Me.lbProfiles.Location = New System.Drawing.Point(9, 9)
        Me.lbProfiles.Name = "lbProfiles"
        Me.lbProfiles.Size = New System.Drawing.Size(58, 18)
        Me.lbProfiles.TabIndex = 0
        Me.lbProfiles.Text = "Profiles"
        '
        'lbCurrentProfile
        '
        Me.lbCurrentProfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbCurrentProfile.ForeColor = System.Drawing.Color.Red
        Me.lbCurrentProfile.Location = New System.Drawing.Point(285, 240)
        Me.lbCurrentProfile.Name = "lbCurrentProfile"
        Me.lbCurrentProfile.Size = New System.Drawing.Size(137, 40)
        Me.lbCurrentProfile.TabIndex = 13
        Me.lbCurrentProfile.Text = "<Profile>"
        Me.lbCurrentProfile.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'frmSetting
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(426, 292)
        Me.Controls.Add(Me.lbCurrentProfile)
        Me.Controls.Add(Me.tabControlSetting)
        Me.Controls.Add(Me.gbPOS)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setting"
        Me.gbPOS.ResumeLayout(False)
        Me.gbPOS.PerformLayout()
        Me.tabControlSetting.ResumeLayout(False)
        Me.tabpageGeneral.ResumeLayout(False)
        Me.tabpageGeneral.PerformLayout()
        Me.tabpageURL.ResumeLayout(False)
        Me.tabpageURL.PerformLayout()
        Me.tabpageNgrok.ResumeLayout(False)
        Me.tabpageNgrok.PerformLayout()
        Me.tabpageErrorEmail.ResumeLayout(False)
        Me.tabpageErrorEmail.PerformLayout()
        Me.tabpageDev.ResumeLayout(False)
        Me.tabpageDev.PerformLayout()
        Me.tabpageDev2.ResumeLayout(False)
        Me.tabpageDev2.PerformLayout()
        Me.tabpageDev3.ResumeLayout(False)
        Me.tabpageDev3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lbWebApiPort As System.Windows.Forms.Label
    Friend WithEvents txtWebApiPort As System.Windows.Forms.TextBox
    Friend WithEvents gbPOS As System.Windows.Forms.GroupBox
    Friend WithEvents lbPOSInfo As System.Windows.Forms.Label
    Friend WithEvents txtSAPass As System.Windows.Forms.TextBox
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
    Friend WithEvents lbSAPass As System.Windows.Forms.Label
    Friend WithEvents lbServerName As System.Windows.Forms.Label
    Private WithEvents myToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tabControlSetting As System.Windows.Forms.TabControl
    Friend WithEvents tabpageURL As System.Windows.Forms.TabPage
    Friend WithEvents lbNgrokPort As System.Windows.Forms.Label
    Friend WithEvents txtNgrokPort As System.Windows.Forms.TextBox
    Friend WithEvents tabpageDev As System.Windows.Forms.TabPage
    Friend WithEvents lbUriInfo As System.Windows.Forms.Label
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox
    Friend WithEvents lbUrl As System.Windows.Forms.Label
    Friend WithEvents cbWebApiSelfHost As System.Windows.Forms.CheckBox
    Friend WithEvents lbWebApiDir As System.Windows.Forms.Label
    Friend WithEvents txtWebApiDir As System.Windows.Forms.TextBox
    Friend WithEvents tabpageErrorEmail As System.Windows.Forms.TabPage
    Friend WithEvents sbTestEmail As System.Windows.Forms.Button
    Friend WithEvents txtErrReceipient As System.Windows.Forms.TextBox
    Friend WithEvents lbErrEmail As System.Windows.Forms.Label
    Friend WithEvents lbRecipient As System.Windows.Forms.Label
    Friend WithEvents lbErrPassword As System.Windows.Forms.Label
    Friend WithEvents ceErrUseSSL As System.Windows.Forms.CheckBox
    Friend WithEvents txtErrEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtErrPort As System.Windows.Forms.TextBox
    Friend WithEvents txtErrPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtErrHost As System.Windows.Forms.TextBox
    Friend WithEvents lbErrHost As System.Windows.Forms.Label
    Friend WithEvents lbErrPort As System.Windows.Forms.Label
    Friend WithEvents lbErrUseSSL As System.Windows.Forms.Label
    Friend WithEvents tabpageGeneral As System.Windows.Forms.TabPage
    Friend WithEvents lbSilentMode As System.Windows.Forms.Label
    Friend WithEvents cbSilentMode As System.Windows.Forms.CheckBox
    Friend WithEvents cbDebug As System.Windows.Forms.CheckBox
    Friend WithEvents lbDebug As System.Windows.Forms.Label
    Friend WithEvents tabpageDev2 As System.Windows.Forms.TabPage
    Friend WithEvents txtModuleProcessInterval As System.Windows.Forms.TextBox
    Friend WithEvents lbModuleProcessInterval As System.Windows.Forms.Label
    Friend WithEvents txtCheckConnectionInterval As System.Windows.Forms.TextBox
    Friend WithEvents lbCheckConnectionInterval As System.Windows.Forms.Label
    Friend WithEvents tabpageNgrok As System.Windows.Forms.TabPage
    Friend WithEvents txtNgrokSubdomain As System.Windows.Forms.TextBox
    Friend WithEvents lblNgrokSubdomain As System.Windows.Forms.Label
    Friend WithEvents txtNgrokAuthToken As System.Windows.Forms.TextBox
    Friend WithEvents lblNgrokAuthToken As System.Windows.Forms.Label
    Friend WithEvents lblNgrokInfo As System.Windows.Forms.Label
    Friend WithEvents tabpageDev3 As System.Windows.Forms.TabPage
    Friend WithEvents btnProfilesDelete As System.Windows.Forms.Button
    Friend WithEvents btnProfilesAdd As System.Windows.Forms.Button
    Friend WithEvents cbProfiles As System.Windows.Forms.ComboBox
    Friend WithEvents lbProfiles As System.Windows.Forms.Label
    Friend WithEvents btnProfilesSave As System.Windows.Forms.Button
    Friend WithEvents btnProfilesApply As System.Windows.Forms.Button
    Friend WithEvents lbCurrentProfile As System.Windows.Forms.Label
    Friend WithEvents cbUrlAutoIP As System.Windows.Forms.CheckBox
    Friend WithEvents cbResetIisOnLoad As System.Windows.Forms.CheckBox
    Friend WithEvents lbResetIisOnLoad As System.Windows.Forms.Label
    Friend WithEvents cbAutoRestart As System.Windows.Forms.CheckBox
    Friend WithEvents lbAutoRestart As System.Windows.Forms.Label
    Friend WithEvents txtUrlPort As System.Windows.Forms.TextBox
    Friend WithEvents lbAutoRestartInterval As System.Windows.Forms.Label
    Friend WithEvents txtAutoRestartInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
