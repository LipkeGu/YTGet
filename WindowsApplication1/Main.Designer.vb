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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Main_mi_main = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeicherorteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_collections_festlegen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_collections_oeffnen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntfernenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DownloaderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtrasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Speicherort = New System.Windows.Forms.ToolStripComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BestandslisteErstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
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
        Me.SpeicherorteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_collections_festlegen, Me.ToolStripSeparator1, Me.Menu_collections_oeffnen, Me.ImportierenToolStripMenuItem, Me.EntfernenToolStripMenuItem, Me.BestandslisteErstellenToolStripMenuItem})
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
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBar1, Me.StatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 480)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(985, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ProgressBar1.Visible = False
        '
        'StatusLabel1
        '
        Me.StatusLabel1.Name = "StatusLabel1"
        Me.StatusLabel1.Size = New System.Drawing.Size(46, 17)
        Me.StatusLabel1.Text = "Bereit..."
        '
        'BestandslisteErstellenToolStripMenuItem
        '
        Me.BestandslisteErstellenToolStripMenuItem.Name = "BestandslisteErstellenToolStripMenuItem"
        Me.BestandslisteErstellenToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.BestandslisteErstellenToolStripMenuItem.Text = "Bestandsliste erstellen..."
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 502)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "YT-Get by X-Effekt"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
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
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents StatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DownloaderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntfernenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtrasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EinstellungenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BestandslisteErstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
