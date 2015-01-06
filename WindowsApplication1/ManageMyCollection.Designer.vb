<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageMyCollection
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManageMyCollection))
		Me.TreeView1 = New System.Windows.Forms.TreeView()
		Me.DirTreeOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.UmbenennenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.filesystem = New System.Windows.Forms.ImageList(Me.components)
		Me.DirectoryTree = New System.Windows.Forms.ToolStripContainer()
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
		Me.ListView1 = New System.Windows.Forms.ListView()
		Me.ch_count = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.ch_artist = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.ch_title = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.ch_bitrate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.ch_duration = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.ch_source = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.InterpretTitelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.InterpretToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.VerzeichnisnameAlsInterpetNutzenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DateiLöschen = New System.Windows.Forms.ToolStripMenuItem()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.CheckBox1 = New System.Windows.Forms.CheckBox()
		Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.DirTreeOptions.SuspendLayout()
		Me.DirectoryTree.ContentPanel.SuspendLayout()
		Me.DirectoryTree.TopToolStripPanel.SuspendLayout()
		Me.DirectoryTree.SuspendLayout()
		Me.ToolStrip1.SuspendLayout()
		Me.ContextMenuStrip1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.SuspendLayout()
		'
		'TreeView1
		'
		Me.TreeView1.ContextMenuStrip = Me.DirTreeOptions
		Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TreeView1.ImageIndex = 0
		Me.TreeView1.ImageList = Me.filesystem
		Me.TreeView1.Location = New System.Drawing.Point(0, 0)
		Me.TreeView1.Name = "TreeView1"
		Me.TreeView1.SelectedImageIndex = 0
		Me.TreeView1.Size = New System.Drawing.Size(300, 582)
		Me.TreeView1.TabIndex = 0
		'
		'DirTreeOptions
		'
		Me.DirTreeOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UmbenennenToolStripMenuItem, Me.LöschenToolStripMenuItem})
		Me.DirTreeOptions.Name = "DirTreeOptions"
		Me.DirTreeOptions.Size = New System.Drawing.Size(147, 48)
		'
		'UmbenennenToolStripMenuItem
		'
		Me.UmbenennenToolStripMenuItem.Name = "UmbenennenToolStripMenuItem"
		Me.UmbenennenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		Me.UmbenennenToolStripMenuItem.Text = "Umbenennen"
		'
		'LöschenToolStripMenuItem
		'
		Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
		Me.LöschenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
		Me.LöschenToolStripMenuItem.Text = "Löschen"
		'
		'filesystem
		'
		Me.filesystem.ImageStream = CType(resources.GetObject("filesystem.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.filesystem.TransparentColor = System.Drawing.Color.Transparent
		Me.filesystem.Images.SetKeyName(0, "directory.ico")
		Me.filesystem.Images.SetKeyName(1, "file.ico")
		'
		'DirectoryTree
		'
		'
		'DirectoryTree.ContentPanel
		'
		Me.DirectoryTree.ContentPanel.Controls.Add(Me.TreeView1)
		Me.DirectoryTree.ContentPanel.Size = New System.Drawing.Size(300, 582)
		Me.DirectoryTree.Dock = System.Windows.Forms.DockStyle.Left
		Me.DirectoryTree.Location = New System.Drawing.Point(0, 0)
		Me.DirectoryTree.Name = "DirectoryTree"
		Me.DirectoryTree.Size = New System.Drawing.Size(300, 607)
		Me.DirectoryTree.TabIndex = 1
		Me.DirectoryTree.Text = "ToolStripContainer1"
		'
		'DirectoryTree.TopToolStripPanel
		'
		Me.DirectoryTree.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSplitButton1})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(300, 25)
		Me.ToolStrip1.Stretch = True
		Me.ToolStrip1.TabIndex = 0
		'
		'ToolStripButton1
		'
		Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButton1.Name = "ToolStripButton1"
		Me.ToolStripButton1.Size = New System.Drawing.Size(58, 22)
		Me.ToolStripButton1.Text = "Auflisten"
		'
		'ListView1
		'
		Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch_count, Me.ch_artist, Me.ch_title, Me.ch_bitrate, Me.ch_duration, Me.ch_source})
		Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
		Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ListView1.Enabled = False
		Me.ListView1.FullRowSelect = True
		Me.ListView1.GridLines = True
		Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		Me.ListView1.Location = New System.Drawing.Point(3, 16)
		Me.ListView1.Name = "ListView1"
		Me.ListView1.Size = New System.Drawing.Size(574, 199)
		Me.ListView1.SmallImageList = Me.filesystem
		Me.ListView1.TabIndex = 2
		Me.ListView1.UseCompatibleStateImageBehavior = False
		Me.ListView1.View = System.Windows.Forms.View.Details
		'
		'ch_count
		'
		Me.ch_count.Text = "#"
		Me.ch_count.Width = 40
		'
		'ch_artist
		'
		Me.ch_artist.Text = "Artist"
		Me.ch_artist.Width = 100
		'
		'ch_title
		'
		Me.ch_title.Text = "Titel"
		Me.ch_title.Width = 300
		'
		'ch_bitrate
		'
		Me.ch_bitrate.Text = "Bitrate"
		'
		'ch_duration
		'
		Me.ch_duration.Text = "Länge"
		Me.ch_duration.Width = 90
		'
		'ch_source
		'
		Me.ch_source.Text = "Quelle"
		Me.ch_source.Width = 300
		'
		'ContextMenuStrip1
		'
		Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InterpretTitelToolStripMenuItem, Me.DateiToolStripMenuItem})
		Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
		Me.ContextMenuStrip1.Size = New System.Drawing.Size(154, 48)
		'
		'InterpretTitelToolStripMenuItem
		'
		Me.InterpretTitelToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InterpretToolStripMenuItem, Me.ToolStripSeparator1})
		Me.InterpretTitelToolStripMenuItem.Name = "InterpretTitelToolStripMenuItem"
		Me.InterpretTitelToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
		Me.InterpretTitelToolStripMenuItem.Text = "Interpret / Titel"
		'
		'InterpretToolStripMenuItem
		'
		Me.InterpretToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerzeichnisnameAlsInterpetNutzenToolStripMenuItem})
		Me.InterpretToolStripMenuItem.Name = "InterpretToolStripMenuItem"
		Me.InterpretToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
		Me.InterpretToolStripMenuItem.Text = "Interpret"
		'
		'VerzeichnisnameAlsInterpetNutzenToolStripMenuItem
		'
		Me.VerzeichnisnameAlsInterpetNutzenToolStripMenuItem.Name = "VerzeichnisnameAlsInterpetNutzenToolStripMenuItem"
		Me.VerzeichnisnameAlsInterpetNutzenToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
		Me.VerzeichnisnameAlsInterpetNutzenToolStripMenuItem.Text = "Verzeichnisname als Interpet nutzen"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(116, 6)
		'
		'DateiToolStripMenuItem
		'
		Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiLöschen})
		Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
		Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
		Me.DateiToolStripMenuItem.Text = "Datei"
		'
		'DateiLöschen
		'
		Me.DateiLöschen.Name = "DateiLöschen"
		Me.DateiLöschen.Size = New System.Drawing.Size(118, 22)
		Me.DateiLöschen.Text = "Löschen"
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.ListView1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.GroupBox1.Location = New System.Drawing.Point(300, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(580, 218)
		Me.GroupBox1.TabIndex = 3
		Me.GroupBox1.TabStop = False
		'
		'CheckBox1
		'
		Me.CheckBox1.AutoSize = True
		Me.CheckBox1.Location = New System.Drawing.Point(6, 19)
		Me.CheckBox1.Name = "CheckBox1"
		Me.CheckBox1.Size = New System.Drawing.Size(211, 17)
		Me.CheckBox1.TabIndex = 4
		Me.CheckBox1.Text = "Zeige Verzeichnisse mit mehr als 1 Titel"
		Me.CheckBox1.UseVisualStyleBackColor = True
		'
		'ToolStripSplitButton1
		'
		Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
		Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
		Me.ToolStripSplitButton1.Size = New System.Drawing.Size(136, 22)
		Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.CheckBox1)
		Me.GroupBox2.Location = New System.Drawing.Point(307, 225)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(561, 191)
		Me.GroupBox2.TabIndex = 5
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Verzeichnisbaum - Optionen"
		'
		'ManageMyCollection
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(880, 607)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.DirectoryTree)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
		Me.Name = "ManageMyCollection"
		Me.Text = "ManageMyCollection"
		Me.DirTreeOptions.ResumeLayout(False)
		Me.DirectoryTree.ContentPanel.ResumeLayout(False)
		Me.DirectoryTree.TopToolStripPanel.ResumeLayout(False)
		Me.DirectoryTree.TopToolStripPanel.PerformLayout()
		Me.DirectoryTree.ResumeLayout(False)
		Me.DirectoryTree.PerformLayout()
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.ContextMenuStrip1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
	Friend WithEvents DirectoryTree As System.Windows.Forms.ToolStripContainer
	Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
	Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
	Friend WithEvents filesystem As System.Windows.Forms.ImageList
	Friend WithEvents ListView1 As System.Windows.Forms.ListView
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents ch_count As System.Windows.Forms.ColumnHeader
	Friend WithEvents ch_artist As System.Windows.Forms.ColumnHeader
	Friend WithEvents ch_title As System.Windows.Forms.ColumnHeader
	Friend WithEvents ch_bitrate As System.Windows.Forms.ColumnHeader
	Friend WithEvents ch_duration As System.Windows.Forms.ColumnHeader
	Friend WithEvents DirTreeOptions As System.Windows.Forms.ContextMenuStrip
	Friend WithEvents UmbenennenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents LöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ch_source As System.Windows.Forms.ColumnHeader
	Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
	Friend WithEvents InterpretTitelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents InterpretToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents VerzeichnisnameAlsInterpetNutzenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents DateiLöschen As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
	Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
