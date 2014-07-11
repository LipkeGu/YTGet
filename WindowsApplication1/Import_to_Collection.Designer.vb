<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportTo_Collection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportTo_Collection))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ch_artist = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_title = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_count = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_source = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_size = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_Target = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_duration = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_bitrate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_exception = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InterpretTitelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LetztesSegemntAlsTitelAllesAndereAlsInterpretToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TeilDesTitelsAnInterpretenAnhängenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TeilDesTitelsAlsInterpretNutzenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImTitelEntfernenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InterpretAusTitelEntfernenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InterpretZurArtistSchlagwortlisteHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LetzteSektionEntfernenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InterpretUndTitelTauschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InterpretFestlegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÄnderungAnDateiAnwendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InMusikPlayerÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErweitertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SucheUndErsetzeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Listing_BGW = New System.ComponentModel.BackgroundWorker()
        Me.Import_BGW = New System.ComponentModel.BackgroundWorker()
        Me.donotcleanup = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 329)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MP3-Dateien importieren"
        '
        'ListView1
        '
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch_artist, Me.ch_title, Me.ch_count, Me.ch_source, Me.ch_size, Me.ch_Target, Me.ch_duration, Me.ch_bitrate, Me.ch_exception})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(3, 16)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(754, 310)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ch_artist
        '
        Me.ch_artist.Text = "Interpret"
        Me.ch_artist.Width = 130
        '
        'ch_title
        '
        Me.ch_title.Text = "Titel"
        Me.ch_title.Width = 231
        '
        'ch_count
        '
        Me.ch_count.Text = "#"
        Me.ch_count.Width = 59
        '
        'ch_source
        '
        Me.ch_source.Text = "Quelle"
        Me.ch_source.Width = 289
        '
        'ch_size
        '
        Me.ch_size.Text = "Größe"
        Me.ch_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ch_size.Width = 84
        '
        'ch_Target
        '
        Me.ch_Target.Text = "Ziel-Verzeichnis"
        Me.ch_Target.Width = 105
        '
        'ch_duration
        '
        Me.ch_duration.Text = "Titel-Länge"
        Me.ch_duration.Width = 71
        '
        'ch_bitrate
        '
        Me.ch_bitrate.Text = "Bitrate (Kbits/s)"
        '
        'ch_exception
        '
        Me.ch_exception.Text = "Fehler"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InterpretTitelToolStripMenuItem, Me.ÄnderungAnDateiAnwendenToolStripMenuItem, Me.InMusikPlayerÖffnenToolStripMenuItem, Me.ErweitertToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(232, 92)
        '
        'InterpretTitelToolStripMenuItem
        '
        Me.InterpretTitelToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LetztesSegemntAlsTitelAllesAndereAlsInterpretToolStripMenuItem, Me.ImTitelEntfernenToolStripMenuItem, Me.InterpretAusTitelEntfernenToolStripMenuItem, Me.InterpretZurArtistSchlagwortlisteHinzufügenToolStripMenuItem, Me.LetzteSektionEntfernenToolStripMenuItem, Me.InterpretUndTitelTauschenToolStripMenuItem, Me.InterpretFestlegenToolStripMenuItem})
        Me.InterpretTitelToolStripMenuItem.Name = "InterpretTitelToolStripMenuItem"
        Me.InterpretTitelToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.InterpretTitelToolStripMenuItem.Text = "Interpret / Titel"
        '
        'LetztesSegemntAlsTitelAllesAndereAlsInterpretToolStripMenuItem
        '
        Me.LetztesSegemntAlsTitelAllesAndereAlsInterpretToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TeilDesTitelsAnInterpretenAnhängenToolStripMenuItem, Me.TeilDesTitelsAlsInterpretNutzenToolStripMenuItem})
        Me.LetztesSegemntAlsTitelAllesAndereAlsInterpretToolStripMenuItem.Name = "LetztesSegemntAlsTitelAllesAndereAlsInterpretToolStripMenuItem"
        Me.LetztesSegemntAlsTitelAllesAndereAlsInterpretToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.LetztesSegemntAlsTitelAllesAndereAlsInterpretToolStripMenuItem.Text = "Segment versetzen"
        '
        'TeilDesTitelsAnInterpretenAnhängenToolStripMenuItem
        '
        Me.TeilDesTitelsAnInterpretenAnhängenToolStripMenuItem.Name = "TeilDesTitelsAnInterpretenAnhängenToolStripMenuItem"
        Me.TeilDesTitelsAnInterpretenAnhängenToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.TeilDesTitelsAnInterpretenAnhängenToolStripMenuItem.Text = "1. Teil des Titels an Interpret anhängen"
        '
        'TeilDesTitelsAlsInterpretNutzenToolStripMenuItem
        '
        Me.TeilDesTitelsAlsInterpretNutzenToolStripMenuItem.Name = "TeilDesTitelsAlsInterpretNutzenToolStripMenuItem"
        Me.TeilDesTitelsAlsInterpretNutzenToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.TeilDesTitelsAlsInterpretNutzenToolStripMenuItem.Text = "1. Teil des Titels als Interpret nutzen"
        '
        'ImTitelEntfernenToolStripMenuItem
        '
        Me.ImTitelEntfernenToolStripMenuItem.Name = "ImTitelEntfernenToolStripMenuItem"
        Me.ImTitelEntfernenToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.ImTitelEntfernenToolStripMenuItem.Text = """ - "" im Titel entfernen"
        '
        'InterpretAusTitelEntfernenToolStripMenuItem
        '
        Me.InterpretAusTitelEntfernenToolStripMenuItem.Name = "InterpretAusTitelEntfernenToolStripMenuItem"
        Me.InterpretAusTitelEntfernenToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.InterpretAusTitelEntfernenToolStripMenuItem.Text = "Interpret aus Titel entfernen"
        '
        'InterpretZurArtistSchlagwortlisteHinzufügenToolStripMenuItem
        '
        Me.InterpretZurArtistSchlagwortlisteHinzufügenToolStripMenuItem.Name = "InterpretZurArtistSchlagwortlisteHinzufügenToolStripMenuItem"
        Me.InterpretZurArtistSchlagwortlisteHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.InterpretZurArtistSchlagwortlisteHinzufügenToolStripMenuItem.Text = "Interpret zur Artist-Schlagwortliste hinzufügen"
        '
        'LetzteSektionEntfernenToolStripMenuItem
        '
        Me.LetzteSektionEntfernenToolStripMenuItem.Name = "LetzteSektionEntfernenToolStripMenuItem"
        Me.LetzteSektionEntfernenToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.LetzteSektionEntfernenToolStripMenuItem.Text = "Letzte Sektion entfernen"
        '
        'InterpretUndTitelTauschenToolStripMenuItem
        '
        Me.InterpretUndTitelTauschenToolStripMenuItem.Name = "InterpretUndTitelTauschenToolStripMenuItem"
        Me.InterpretUndTitelTauschenToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.InterpretUndTitelTauschenToolStripMenuItem.Text = "Interpret und titel tauschen"
        '
        'InterpretFestlegenToolStripMenuItem
        '
        Me.InterpretFestlegenToolStripMenuItem.Name = "InterpretFestlegenToolStripMenuItem"
        Me.InterpretFestlegenToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.InterpretFestlegenToolStripMenuItem.Text = "Interpret festlegen"
        '
        'ÄnderungAnDateiAnwendenToolStripMenuItem
        '
        Me.ÄnderungAnDateiAnwendenToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ÄnderungAnDateiAnwendenToolStripMenuItem.Name = "ÄnderungAnDateiAnwendenToolStripMenuItem"
        Me.ÄnderungAnDateiAnwendenToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ÄnderungAnDateiAnwendenToolStripMenuItem.Text = "Änderung an Datei anwenden"
        '
        'InMusikPlayerÖffnenToolStripMenuItem
        '
        Me.InMusikPlayerÖffnenToolStripMenuItem.Name = "InMusikPlayerÖffnenToolStripMenuItem"
        Me.InMusikPlayerÖffnenToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.InMusikPlayerÖffnenToolStripMenuItem.Text = "In Musik-Player öffnen"
        '
        'ErweitertToolStripMenuItem
        '
        Me.ErweitertToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SucheUndErsetzeToolStripMenuItem})
        Me.ErweitertToolStripMenuItem.Name = "ErweitertToolStripMenuItem"
        Me.ErweitertToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ErweitertToolStripMenuItem.Text = "Erweitert"
        '
        'SucheUndErsetzeToolStripMenuItem
        '
        Me.SucheUndErsetzeToolStripMenuItem.Name = "SucheUndErsetzeToolStripMenuItem"
        Me.SucheUndErsetzeToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SucheUndErsetzeToolStripMenuItem.Text = "Suche und ersetze"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(586, 459)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(186, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Selektierte Elemente Importieren"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(325, 460)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(79, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Durchsuchen"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(246, 347)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(22, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "-"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(15, 347)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(102, 23)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Titel bearbeiten"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(15, 395)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(186, 17)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "Vorhande Elemente überspringen!"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.ForeColor = System.Drawing.Color.DarkRed
        Me.CheckBox2.Location = New System.Drawing.Point(15, 419)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(150, 17)
        Me.CheckBox2.TabIndex = 6
        Me.CheckBox2.Text = "MP3-Dateien Verschieben"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 486)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(771, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(150, 16)
        Me.ToolStripProgressBar1.Visible = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(37, 17)
        Me.ToolStripStatusLabel1.Text = "Bereit"
        '
        'Listing_BGW
        '
        Me.Listing_BGW.WorkerReportsProgress = True
        Me.Listing_BGW.WorkerSupportsCancellation = True
        '
        'Import_BGW
        '
        Me.Import_BGW.WorkerReportsProgress = True
        Me.Import_BGW.WorkerSupportsCancellation = True
        '
        'donotcleanup
        '
        Me.donotcleanup.AutoSize = True
        Me.donotcleanup.ForeColor = System.Drawing.Color.DarkRed
        Me.donotcleanup.Location = New System.Drawing.Point(15, 442)
        Me.donotcleanup.Name = "donotcleanup"
        Me.donotcleanup.Size = New System.Drawing.Size(206, 17)
        Me.donotcleanup.TabIndex = 8
        Me.donotcleanup.Text = "Bereinigungs-Regeln nicht anwenden!"
        Me.donotcleanup.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.ForeColor = System.Drawing.Color.DarkRed
        Me.CheckBox3.Location = New System.Drawing.Point(15, 465)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(124, 17)
        Me.CheckBox3.TabIndex = 9
        Me.CheckBox3.Text = "Klammern ignorieren!"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(123, 347)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(107, 23)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Interpet bearbeiten "
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(432, 461)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(86, 23)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "Abrechen"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(654, 347)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(105, 23)
        Me.Button7.TabIndex = 12
        Me.Button7.Text = "Alle Auswählen"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(546, 347)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(102, 23)
        Me.Button8.TabIndex = 13
        Me.Button8.Text = "Alle Abwählen"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'ImportTo_Collection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 508)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.donotcleanup)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImportTo_Collection"
        Me.Text = "Import mp3-files into the collection!"
        Me.GroupBox1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ch_artist As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_title As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_count As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_source As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Listing_BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents Import_BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ch_size As System.Windows.Forms.ColumnHeader
    Friend WithEvents donotcleanup As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents InterpretTitelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LetztesSegemntAlsTitelAllesAndereAlsInterpretToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImTitelEntfernenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InterpretAusTitelEntfernenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InterpretZurArtistSchlagwortlisteHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TeilDesTitelsAnInterpretenAnhängenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TeilDesTitelsAlsInterpretNutzenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÄnderungAnDateiAnwendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents InMusikPlayerÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ch_Target As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_duration As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_bitrate As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_exception As System.Windows.Forms.ColumnHeader
    Friend WithEvents LetzteSektionEntfernenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InterpretUndTitelTauschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InterpretFestlegenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErweitertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SucheUndErsetzeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
End Class
