<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Download_Manager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Download_Manager))
        Me.DL_Listview = New System.Windows.Forms.ListView()
        Me.Header_titel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Header_Source = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Header_count = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Header_Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Header_dllink = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Header_type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Header_size = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Header_Quality = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Listview1_options = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NamenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NamenTauschen1221ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LetzteSpalteEntfernen12312ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InterpretUndTitelOptionenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InterpretZurArtistListeHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MakierenAlsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GewähltesElementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GesamteListeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FertigeElementeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.download = New System.Windows.Forms.ToolStripButton()
        Me.cancel_all_downloads = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.movie_url = New System.Windows.Forms.ToolStripTextBox()
        Me.Add_URL = New System.Windows.Forms.ToolStripButton()
        Me.Listview1_options.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DL_Listview
        '
        Me.DL_Listview.CheckBoxes = True
        Me.DL_Listview.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Header_titel, Me.Header_Source, Me.Header_count, Me.Header_Status, Me.Header_dllink, Me.Header_type, Me.Header_size, Me.Header_Quality})
        Me.DL_Listview.ContextMenuStrip = Me.Listview1_options
        Me.DL_Listview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DL_Listview.GridLines = True
        Me.DL_Listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.DL_Listview.LabelEdit = True
        Me.DL_Listview.Location = New System.Drawing.Point(0, 0)
        Me.DL_Listview.Name = "DL_Listview"
        Me.DL_Listview.ShowItemToolTips = True
        Me.DL_Listview.Size = New System.Drawing.Size(1028, 319)
        Me.DL_Listview.TabIndex = 2
        Me.DL_Listview.UseCompatibleStateImageBehavior = False
        Me.DL_Listview.View = System.Windows.Forms.View.Details
        '
        'Header_titel
        '
        Me.Header_titel.Text = "Name"
        Me.Header_titel.Width = 254
        '
        'Header_Source
        '
        Me.Header_Source.Text = "Quelle"
        Me.Header_Source.Width = 102
        '
        'Header_count
        '
        Me.Header_count.Text = "#"
        Me.Header_count.Width = 26
        '
        'Header_Status
        '
        Me.Header_Status.Text = "Status"
        Me.Header_Status.Width = 141
        '
        'Header_dllink
        '
        Me.Header_dllink.Text = "Adresse:"
        Me.Header_dllink.Width = 0
        '
        'Header_type
        '
        Me.Header_type.Text = "Type"
        Me.Header_type.Width = 126
        '
        'Header_size
        '
        Me.Header_size.Text = "Größe"
        Me.Header_size.Width = 89
        '
        'Header_Quality
        '
        Me.Header_Quality.Text = "Qualität"
        Me.Header_Quality.Width = 67
        '
        'Listview1_options
        '
        Me.Listview1_options.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NamenToolStripMenuItem, Me.InterpretUndTitelOptionenToolStripMenuItem, Me.ToolStripSeparator2, Me.MakierenAlsToolStripMenuItem, Me.ElementLöschenToolStripMenuItem})
        Me.Listview1_options.Name = "Listview1_options"
        Me.Listview1_options.Size = New System.Drawing.Size(207, 120)
        '
        'NamenToolStripMenuItem
        '
        Me.NamenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NamenTauschen1221ToolStripMenuItem, Me.LetzteSpalteEntfernen12312ToolStripMenuItem})
        Me.NamenToolStripMenuItem.Name = "NamenToolStripMenuItem"
        Me.NamenToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.NamenToolStripMenuItem.Text = "Namen"
        '
        'NamenTauschen1221ToolStripMenuItem
        '
        Me.NamenTauschen1221ToolStripMenuItem.Name = "NamenTauschen1221ToolStripMenuItem"
        Me.NamenTauschen1221ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.NamenTauschen1221ToolStripMenuItem.Text = "tauschen ({1} - {2}) -> ({2} - {1})"
        Me.NamenTauschen1221ToolStripMenuItem.Visible = False
        '
        'LetzteSpalteEntfernen12312ToolStripMenuItem
        '
        Me.LetzteSpalteEntfernen12312ToolStripMenuItem.Name = "LetzteSpalteEntfernen12312ToolStripMenuItem"
        Me.LetzteSpalteEntfernen12312ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.LetzteSpalteEntfernen12312ToolStripMenuItem.Text = "Letzte Spalte entfernen ({1} - {2}  - {3}) ->  ({1} - {2})"
        Me.LetzteSpalteEntfernen12312ToolStripMenuItem.Visible = False
        '
        'InterpretUndTitelOptionenToolStripMenuItem
        '
        Me.InterpretUndTitelOptionenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InterpretZurArtistListeHinzufügenToolStripMenuItem})
        Me.InterpretUndTitelOptionenToolStripMenuItem.Name = "InterpretUndTitelOptionenToolStripMenuItem"
        Me.InterpretUndTitelOptionenToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.InterpretUndTitelOptionenToolStripMenuItem.Text = "Interpret / Titel Optionen"
        '
        'InterpretZurArtistListeHinzufügenToolStripMenuItem
        '
        Me.InterpretZurArtistListeHinzufügenToolStripMenuItem.Name = "InterpretZurArtistListeHinzufügenToolStripMenuItem"
        Me.InterpretZurArtistListeHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(261, 22)
        Me.InterpretZurArtistListeHinzufügenToolStripMenuItem.Text = "Interpret zur Artist-Liste hinzufügen"
        Me.InterpretZurArtistListeHinzufügenToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(203, 6)
        '
        'MakierenAlsToolStripMenuItem
        '
        Me.MakierenAlsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DownloadenToolStripMenuItem})
        Me.MakierenAlsToolStripMenuItem.Name = "MakierenAlsToolStripMenuItem"
        Me.MakierenAlsToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.MakierenAlsToolStripMenuItem.Text = "makieren als..."
        '
        'DownloadenToolStripMenuItem
        '
        Me.DownloadenToolStripMenuItem.Name = "DownloadenToolStripMenuItem"
        Me.DownloadenToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.DownloadenToolStripMenuItem.Text = "Downloaden..."
        Me.DownloadenToolStripMenuItem.Visible = False
        '
        'ElementLöschenToolStripMenuItem
        '
        Me.ElementLöschenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GewähltesElementToolStripMenuItem, Me.GesamteListeToolStripMenuItem, Me.FertigeElementeToolStripMenuItem})
        Me.ElementLöschenToolStripMenuItem.Name = "ElementLöschenToolStripMenuItem"
        Me.ElementLöschenToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ElementLöschenToolStripMenuItem.Text = "Löschen"
        '
        'GewähltesElementToolStripMenuItem
        '
        Me.GewähltesElementToolStripMenuItem.Name = "GewähltesElementToolStripMenuItem"
        Me.GewähltesElementToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.GewähltesElementToolStripMenuItem.Text = "gewähltes Element"
        Me.GewähltesElementToolStripMenuItem.Visible = False
        '
        'GesamteListeToolStripMenuItem
        '
        Me.GesamteListeToolStripMenuItem.Name = "GesamteListeToolStripMenuItem"
        Me.GesamteListeToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.GesamteListeToolStripMenuItem.Text = "gesamte Liste"
        Me.GesamteListeToolStripMenuItem.Visible = False
        '
        'FertigeElementeToolStripMenuItem
        '
        Me.FertigeElementeToolStripMenuItem.Name = "FertigeElementeToolStripMenuItem"
        Me.FertigeElementeToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.FertigeElementeToolStripMenuItem.Text = "Fertige Elemente"
        Me.FertigeElementeToolStripMenuItem.Visible = False
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DL_Listview)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1028, 319)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1028, 369)
        Me.ToolStripContainer1.TabIndex = 6
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.download, Me.cancel_all_downloads})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1028, 25)
        Me.ToolStrip2.Stretch = True
        Me.ToolStrip2.TabIndex = 0
        '
        'download
        '
        Me.download.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.download.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.download.Enabled = False
        Me.download.Image = CType(resources.GetObject("download.Image"), System.Drawing.Image)
        Me.download.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.download.Name = "download"
        Me.download.Size = New System.Drawing.Size(78, 22)
        Me.download.Text = "Downloaden"
        '
        'cancel_all_downloads
        '
        Me.cancel_all_downloads.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cancel_all_downloads.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cancel_all_downloads.Enabled = False
        Me.cancel_all_downloads.Image = CType(resources.GetObject("cancel_all_downloads.Image"), System.Drawing.Image)
        Me.cancel_all_downloads.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cancel_all_downloads.Name = "cancel_all_downloads"
        Me.cancel_all_downloads.Size = New System.Drawing.Size(55, 22)
        Me.cancel_all_downloads.Text = "Stoppen"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.movie_url, Me.Add_URL})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1028, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(31, 22)
        Me.ToolStripLabel1.Text = "URL:"
        '
        'movie_url
        '
        Me.movie_url.Name = "movie_url"
        Me.movie_url.Size = New System.Drawing.Size(400, 25)
        '
        'Add_URL
        '
        Me.Add_URL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Add_URL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Add_URL.Name = "Add_URL"
        Me.Add_URL.Size = New System.Drawing.Size(73, 22)
        Me.Add_URL.Text = "Hinzufügen"
        Me.Add_URL.ToolTipText = "Hinzufügen"
        '
        'Download_Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1028, 369)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Download_Manager"
        Me.Text = "Download Manager"
        Me.Listview1_options.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DL_Listview As System.Windows.Forms.ListView
    Friend WithEvents Header_count As System.Windows.Forms.ColumnHeader
    Friend WithEvents Header_titel As System.Windows.Forms.ColumnHeader
    Friend WithEvents Header_Source As System.Windows.Forms.ColumnHeader
    Friend WithEvents Header_type As System.Windows.Forms.ColumnHeader
    Friend WithEvents Header_Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents Header_dllink As System.Windows.Forms.ColumnHeader
    Friend WithEvents Header_size As System.Windows.Forms.ColumnHeader
    Friend WithEvents Listview1_options As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NamenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NamenTauschen1221ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LetzteSpalteEntfernen12312ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InterpretUndTitelOptionenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MakierenAlsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ElementLöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GewähltesElementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GesamteListeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FertigeElementeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InterpretZurArtistListeHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents movie_url As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Add_URL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents download As System.Windows.Forms.ToolStripButton
    Friend WithEvents cancel_all_downloads As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Header_Quality As System.Windows.Forms.ColumnHeader

End Class
