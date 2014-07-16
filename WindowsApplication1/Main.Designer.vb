<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Main_mi_main = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeicherorteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_collections_festlegen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_collections_oeffnen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntfernenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BestandslisteErstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DownloaderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtrasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Speicherort = New System.Windows.Forms.ToolStripComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ch_lfd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_source = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_Message = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.VerwaltenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Main_mi_main, Me.ExtrasToolStripMenuItem, Me.Speicherort})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(985, 27)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Main_mi_main
        '
        Me.Main_mi_main.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SpeicherorteToolStripMenuItem, Me.ToolStripSeparator2, Me.DownloaderToolStripMenuItem1, Me.ToolStripSeparator3, Me.BeendenToolStripMenuItem})
        Me.Main_mi_main.Name = "Main_mi_main"
        Me.Main_mi_main.Size = New System.Drawing.Size(46, 23)
        Me.Main_mi_main.Text = "Main"
        '
        'SpeicherorteToolStripMenuItem
        '
        Me.SpeicherorteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_collections_festlegen, Me.ToolStripSeparator1, Me.Menu_collections_oeffnen, Me.ImportierenToolStripMenuItem, Me.EntfernenToolStripMenuItem, Me.BestandslisteErstellenToolStripMenuItem, Me.VerwaltenToolStripMenuItem})
        Me.SpeicherorteToolStripMenuItem.Name = "SpeicherorteToolStripMenuItem"
        Me.SpeicherorteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SpeicherorteToolStripMenuItem.Text = "Sammlungen"
        '
        'Menu_collections_festlegen
        '
        Me.Menu_collections_festlegen.Name = "Menu_collections_festlegen"
        Me.Menu_collections_festlegen.Size = New System.Drawing.Size(217, 22)
        Me.Menu_collections_festlegen.Text = "Sammlung erstellen..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(214, 6)
        '
        'Menu_collections_oeffnen
        '
        Me.Menu_collections_oeffnen.Enabled = False
        Me.Menu_collections_oeffnen.Name = "Menu_collections_oeffnen"
        Me.Menu_collections_oeffnen.Size = New System.Drawing.Size(217, 22)
        Me.Menu_collections_oeffnen.Text = "Aktuelle Sammlung öffnen"
        '
        'ImportierenToolStripMenuItem
        '
        Me.ImportierenToolStripMenuItem.Enabled = False
        Me.ImportierenToolStripMenuItem.Name = "ImportierenToolStripMenuItem"
        Me.ImportierenToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ImportierenToolStripMenuItem.Text = "MP3-Dateien Importieren..."
        '
        'EntfernenToolStripMenuItem
        '
        Me.EntfernenToolStripMenuItem.Enabled = False
        Me.EntfernenToolStripMenuItem.Name = "EntfernenToolStripMenuItem"
        Me.EntfernenToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.EntfernenToolStripMenuItem.Text = "Sammlungen entfernen..."
        '
        'BestandslisteErstellenToolStripMenuItem
        '
        Me.BestandslisteErstellenToolStripMenuItem.Name = "BestandslisteErstellenToolStripMenuItem"
        Me.BestandslisteErstellenToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.BestandslisteErstellenToolStripMenuItem.Text = "Bestandsliste erstellen..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'DownloaderToolStripMenuItem1
        '
        Me.DownloaderToolStripMenuItem1.Name = "DownloaderToolStripMenuItem1"
        Me.DownloaderToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.DownloaderToolStripMenuItem1.Text = "Downloader"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(149, 6)
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BeendenToolStripMenuItem.Text = "Beenden"
        '
        'ExtrasToolStripMenuItem
        '
        Me.ExtrasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EinstellungenToolStripMenuItem})
        Me.ExtrasToolStripMenuItem.Name = "ExtrasToolStripMenuItem"
        Me.ExtrasToolStripMenuItem.Size = New System.Drawing.Size(49, 23)
        Me.ExtrasToolStripMenuItem.Text = "extras"
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.EinstellungenToolStripMenuItem.Text = "Einstellungen"
        '
        'Speicherort
        '
        Me.Speicherort.Name = "Speicherort"
        Me.Speicherort.Size = New System.Drawing.Size(300, 23)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 374)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(985, 128)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Event-Log"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch_lfd, Me.ch_source, Me.ch_type, Me.ch_Message})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(3, 16)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(979, 109)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ch_lfd
        '
        Me.ch_lfd.Text = "#"
        Me.ch_lfd.Width = 32
        '
        'ch_source
        '
        Me.ch_source.Text = "Quelle"
        Me.ch_source.Width = 95
        '
        'ch_type
        '
        Me.ch_type.Text = "Type"
        Me.ch_type.Width = 84
        '
        'ch_Message
        '
        Me.ch_Message.Text = "Meldung"
        Me.ch_Message.Width = 900
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'VerwaltenToolStripMenuItem
        '
        Me.VerwaltenToolStripMenuItem.Name = "VerwaltenToolStripMenuItem"
        Me.VerwaltenToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.VerwaltenToolStripMenuItem.Text = "verwalten"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 502)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "YT-Get by X-Effekt"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Main_mi_main As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpeicherorteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_collections_festlegen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_collections_oeffnen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImportierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Speicherort As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DownloaderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntfernenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtrasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EinstellungenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BestandslisteErstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ch_lfd As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_source As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_type As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_Message As System.Windows.Forms.ColumnHeader
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents VerwaltenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
