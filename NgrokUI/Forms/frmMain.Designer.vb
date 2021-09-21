<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.lbLastUpdatex = New System.Windows.Forms.Label()
        Me.lbLastUpdate = New System.Windows.Forms.Label()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.lbStatusx = New System.Windows.Forms.Label()
        Me.lbURL = New System.Windows.Forms.Label()
        Me.lbURLx = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisableDevModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.noticon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.mns = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideOnStartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoStartupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoInitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlwaysOnTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowNotificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UseTestServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingDirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestFuncToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestFuncNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PauseThreadsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.lbWebApi = New System.Windows.Forms.Label()
        Me.lbWebApix = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pbOrb = New System.Windows.Forms.PictureBox()
        Me.dgvLog = New System.Windows.Forms.DataGridView()
        Me.tabControlMain = New System.Windows.Forms.TabControl()
        Me.tabpageStatus = New System.Windows.Forms.TabPage()
        Me.ttip = New System.Windows.Forms.ToolTip(Me.components)
        Me.cms.SuspendLayout()
        Me.mns.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        CType(Me.pbOrb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControlMain.SuspendLayout()
        Me.tabpageStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbLastUpdatex
        '
        Me.lbLastUpdatex.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbLastUpdatex.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLastUpdatex.Location = New System.Drawing.Point(12, 33)
        Me.lbLastUpdatex.Name = "lbLastUpdatex"
        Me.lbLastUpdatex.Size = New System.Drawing.Size(100, 30)
        Me.lbLastUpdatex.TabIndex = 10
        Me.lbLastUpdatex.Tag = "Success establish connection time."
        Me.lbLastUpdatex.Text = "Last Update:"
        Me.lbLastUpdatex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLastUpdate
        '
        Me.lbLastUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbLastUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLastUpdate.Location = New System.Drawing.Point(118, 33)
        Me.lbLastUpdate.Name = "lbLastUpdate"
        Me.lbLastUpdate.Size = New System.Drawing.Size(280, 30)
        Me.lbLastUpdate.TabIndex = 5
        Me.lbLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbStatus
        '
        Me.lbStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatus.ForeColor = System.Drawing.Color.Red
        Me.lbStatus.Location = New System.Drawing.Point(118, 3)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(280, 30)
        Me.lbStatus.TabIndex = 7
        Me.lbStatus.Text = "Disconnected"
        Me.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbStatusx
        '
        Me.lbStatusx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbStatusx.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatusx.Location = New System.Drawing.Point(12, 3)
        Me.lbStatusx.Name = "lbStatusx"
        Me.lbStatusx.Size = New System.Drawing.Size(100, 30)
        Me.lbStatusx.TabIndex = 6
        Me.lbStatusx.Text = "Status:"
        Me.lbStatusx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbURL
        '
        Me.lbURL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbURL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbURL.Location = New System.Drawing.Point(118, 93)
        Me.lbURL.Name = "lbURL"
        Me.lbURL.Size = New System.Drawing.Size(280, 30)
        Me.lbURL.TabIndex = 5
        Me.lbURL.Tag = "localhost"
        Me.lbURL.Text = "localhost"
        Me.lbURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbURLx
        '
        Me.lbURLx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbURLx.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbURLx.Location = New System.Drawing.Point(12, 93)
        Me.lbURLx.Name = "lbURLx"
        Me.lbURLx.Size = New System.Drawing.Size(100, 30)
        Me.lbURLx.TabIndex = 4
        Me.lbURLx.Text = "URL:"
        Me.lbURLx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Enabled = False
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(-9999, -10026)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 35)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        Me.btnExit.Visible = False
        '
        'btnSetting
        '
        Me.btnSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSetting.Enabled = False
        Me.btnSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetting.Location = New System.Drawing.Point(-9999, -10026)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(80, 35)
        Me.btnSetting.TabIndex = 4
        Me.btnSetting.Text = "Setting"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'cms
        '
        Me.cms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowToolStripMenuItem, Me.DisableDevModeToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.cms.Name = "ContextMenuStrip1"
        Me.cms.Size = New System.Drawing.Size(163, 70)
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ShowToolStripMenuItem.Text = "Show"
        '
        'DisableDevModeToolStripMenuItem
        '
        Me.DisableDevModeToolStripMenuItem.Name = "DisableDevModeToolStripMenuItem"
        Me.DisableDevModeToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.DisableDevModeToolStripMenuItem.Text = "Disable Dev Mode"
        Me.DisableDevModeToolStripMenuItem.Visible = False
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'noticon
        '
        Me.noticon.ContextMenuStrip = Me.cms
        Me.noticon.Text = "NgrokUI"
        Me.noticon.Visible = True
        '
        'mns
        '
        Me.mns.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mns.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.ModulesToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.mns.Location = New System.Drawing.Point(0, 0)
        Me.mns.Name = "mns"
        Me.mns.Size = New System.Drawing.Size(479, 26)
        Me.mns.TabIndex = 11
        Me.mns.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestartToolStripMenuItem, Me.ClearLogToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem1})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(40, 22)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'RestartToolStripMenuItem
        '
        Me.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem"
        Me.RestartToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.RestartToolStripMenuItem.Text = "Restart"
        '
        'ClearLogToolStripMenuItem
        '
        Me.ClearLogToolStripMenuItem.Name = "ClearLogToolStripMenuItem"
        Me.ClearLogToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ClearLogToolStripMenuItem.Text = "Clear Log"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(133, 6)
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingToolStripMenuItem, Me.HideOnStartToolStripMenuItem, Me.AutoStartupToolStripMenuItem, Me.AutoInitToolStripMenuItem, Me.AlwaysOnTopToolStripMenuItem, Me.ShowNotificationToolStripMenuItem, Me.UseTestServerToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(69, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'HideOnStartToolStripMenuItem
        '
        Me.HideOnStartToolStripMenuItem.Name = "HideOnStartToolStripMenuItem"
        Me.HideOnStartToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.HideOnStartToolStripMenuItem.Text = "Hide On Start"
        '
        'AutoStartupToolStripMenuItem
        '
        Me.AutoStartupToolStripMenuItem.Name = "AutoStartupToolStripMenuItem"
        Me.AutoStartupToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AutoStartupToolStripMenuItem.Text = "Auto Startup"
        Me.AutoStartupToolStripMenuItem.Visible = False
        '
        'AutoInitToolStripMenuItem
        '
        Me.AutoInitToolStripMenuItem.Name = "AutoInitToolStripMenuItem"
        Me.AutoInitToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AutoInitToolStripMenuItem.Text = "Auto Init"
        Me.AutoInitToolStripMenuItem.Visible = False
        '
        'AlwaysOnTopToolStripMenuItem
        '
        Me.AlwaysOnTopToolStripMenuItem.Name = "AlwaysOnTopToolStripMenuItem"
        Me.AlwaysOnTopToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AlwaysOnTopToolStripMenuItem.Text = "Always On Top"
        '
        'ShowNotificationToolStripMenuItem
        '
        Me.ShowNotificationToolStripMenuItem.Name = "ShowNotificationToolStripMenuItem"
        Me.ShowNotificationToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ShowNotificationToolStripMenuItem.Text = "Show Notification"
        Me.ShowNotificationToolStripMenuItem.Visible = False
        '
        'UseTestServerToolStripMenuItem
        '
        Me.UseTestServerToolStripMenuItem.Name = "UseTestServerToolStripMenuItem"
        Me.UseTestServerToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.UseTestServerToolStripMenuItem.Text = "Use Test Server"
        Me.UseTestServerToolStripMenuItem.Visible = False
        '
        'ModulesToolStripMenuItem
        '
        Me.ModulesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.TestFuncToolStripMenuItem, Me.TestFuncNameToolStripMenuItem, Me.PauseThreadsToolStripMenuItem})
        Me.ModulesToolStripMenuItem.Name = "ModulesToolStripMenuItem"
        Me.ModulesToolStripMenuItem.Size = New System.Drawing.Size(62, 22)
        Me.ModulesToolStripMenuItem.Text = "Debug"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingDirToolStripMenuItem, Me.ErrorLogToolStripMenuItem})
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SettingDirToolStripMenuItem
        '
        Me.SettingDirToolStripMenuItem.Name = "SettingDirToolStripMenuItem"
        Me.SettingDirToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.SettingDirToolStripMenuItem.Text = "Setting Dir"
        '
        'ErrorLogToolStripMenuItem
        '
        Me.ErrorLogToolStripMenuItem.Name = "ErrorLogToolStripMenuItem"
        Me.ErrorLogToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ErrorLogToolStripMenuItem.Text = "Error Log"
        '
        'TestFuncToolStripMenuItem
        '
        Me.TestFuncToolStripMenuItem.Name = "TestFuncToolStripMenuItem"
        Me.TestFuncToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.TestFuncToolStripMenuItem.Text = "Test Func"
        '
        'TestFuncNameToolStripMenuItem
        '
        Me.TestFuncNameToolStripMenuItem.Name = "TestFuncNameToolStripMenuItem"
        Me.TestFuncNameToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.TestFuncNameToolStripMenuItem.Text = "Test Func Name"
        '
        'PauseThreadsToolStripMenuItem
        '
        Me.PauseThreadsToolStripMenuItem.Name = "PauseThreadsToolStripMenuItem"
        Me.PauseThreadsToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.PauseThreadsToolStripMenuItem.Text = "Pause Threads"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(58, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.Enabled = False
        Me.btnMinimize.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinimize.Location = New System.Drawing.Point(-9999, -10026)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(80, 35)
        Me.btnMinimize.TabIndex = 12
        Me.btnMinimize.Text = "Minimize"
        Me.btnMinimize.UseVisualStyleBackColor = True
        '
        'lbWebApi
        '
        Me.lbWebApi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbWebApi.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbWebApi.Location = New System.Drawing.Point(118, 63)
        Me.lbWebApi.Name = "lbWebApi"
        Me.lbWebApi.Size = New System.Drawing.Size(280, 30)
        Me.lbWebApi.TabIndex = 15
        Me.lbWebApi.Tag = "localhost"
        Me.lbWebApi.Text = "localhost"
        Me.lbWebApi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbWebApix
        '
        Me.lbWebApix.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbWebApix.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbWebApix.Location = New System.Drawing.Point(12, 63)
        Me.lbWebApix.Name = "lbWebApix"
        Me.lbWebApix.Size = New System.Drawing.Size(100, 30)
        Me.lbWebApix.TabIndex = 14
        Me.lbWebApix.Text = "Website:"
        Me.lbWebApix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.btnExit)
        Me.pnlMain.Controls.Add(Me.btnMinimize)
        Me.pnlMain.Controls.Add(Me.btnSetting)
        Me.pnlMain.Controls.Add(Me.pbOrb)
        Me.pnlMain.Controls.Add(Me.lbStatusx)
        Me.pnlMain.Controls.Add(Me.lbWebApi)
        Me.pnlMain.Controls.Add(Me.lbURLx)
        Me.pnlMain.Controls.Add(Me.lbWebApix)
        Me.pnlMain.Controls.Add(Me.lbURL)
        Me.pnlMain.Controls.Add(Me.lbStatus)
        Me.pnlMain.Controls.Add(Me.lbLastUpdatex)
        Me.pnlMain.Controls.Add(Me.lbLastUpdate)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMain.Location = New System.Drawing.Point(3, 3)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(465, 132)
        Me.pnlMain.TabIndex = 16
        '
        'pbOrb
        '
        Me.pbOrb.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbOrb.Image = Global.NgrokUIApp.My.Resources.Resources.Red_ball
        Me.pbOrb.InitialImage = Nothing
        Me.pbOrb.Location = New System.Drawing.Point(412, 78)
        Me.pbOrb.Name = "pbOrb"
        Me.pbOrb.Size = New System.Drawing.Size(48, 48)
        Me.pbOrb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbOrb.TabIndex = 16
        Me.pbOrb.TabStop = False
        '
        'dgvLog
        '
        Me.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLog.Location = New System.Drawing.Point(0, 188)
        Me.dgvLog.Name = "dgvLog"
        Me.dgvLog.Size = New System.Drawing.Size(479, 237)
        Me.dgvLog.TabIndex = 17
        '
        'tabControlMain
        '
        Me.tabControlMain.Controls.Add(Me.tabpageStatus)
        Me.tabControlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabControlMain.Location = New System.Drawing.Point(0, 26)
        Me.tabControlMain.Name = "tabControlMain"
        Me.tabControlMain.SelectedIndex = 0
        Me.tabControlMain.Size = New System.Drawing.Size(479, 162)
        Me.tabControlMain.TabIndex = 17
        '
        'tabpageStatus
        '
        Me.tabpageStatus.Controls.Add(Me.pnlMain)
        Me.tabpageStatus.Location = New System.Drawing.Point(4, 27)
        Me.tabpageStatus.Name = "tabpageStatus"
        Me.tabpageStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageStatus.Size = New System.Drawing.Size(471, 131)
        Me.tabpageStatus.TabIndex = 0
        Me.tabpageStatus.Text = "Status"
        Me.tabpageStatus.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(479, 425)
        Me.Controls.Add(Me.dgvLog)
        Me.Controls.Add(Me.tabControlMain)
        Me.Controls.Add(Me.mns)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.mns
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.cms.ResumeLayout(False)
        Me.mns.ResumeLayout(False)
        Me.mns.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.pbOrb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControlMain.ResumeLayout(False)
        Me.tabpageStatus.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSetting As System.Windows.Forms.Button
    Friend WithEvents lbURL As System.Windows.Forms.Label
    Friend WithEvents lbURLx As System.Windows.Forms.Label
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents lbStatusx As System.Windows.Forms.Label
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents noticon As System.Windows.Forms.NotifyIcon
    Friend WithEvents lbLastUpdatex As System.Windows.Forms.Label
    Friend WithEvents lbLastUpdate As System.Windows.Forms.Label
    Friend WithEvents DisableDevModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mns As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideOnStartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMinimize As System.Windows.Forms.Button
    Friend WithEvents SettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbWebApi As System.Windows.Forms.Label
    Friend WithEvents lbWebApix As System.Windows.Forms.Label
    Friend WithEvents AutoInitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents ModulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoStartupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbOrb As System.Windows.Forms.PictureBox
    Friend WithEvents ClearLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvLog As System.Windows.Forms.DataGridView
    Friend WithEvents AlwaysOnTopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestFuncToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingDirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestFuncNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PauseThreadsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowNotificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents tabpageStatus As System.Windows.Forms.TabPage
    Friend WithEvents UseTestServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ttip As System.Windows.Forms.ToolTip

End Class
