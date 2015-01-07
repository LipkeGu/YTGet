<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settings
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
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.Button12 = New System.Windows.Forms.Button()
		Me.Button11 = New System.Windows.Forms.Button()
		Me.extensions = New System.Windows.Forms.ListBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.Button6 = New System.Windows.Forms.Button()
		Me.Button5 = New System.Windows.Forms.Button()
		Me.ListBox1 = New System.Windows.Forms.ListBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Button13 = New System.Windows.Forms.Button()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Download_pfad = New System.Windows.Forms.TextBox()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.Clean_Replace_Controls = New System.Windows.Forms.GroupBox()
		Me.Button7 = New System.Windows.Forms.Button()
		Me.Button9 = New System.Windows.Forms.Button()
		Me.Button10 = New System.Windows.Forms.Button()
		Me.Button8 = New System.Windows.Forms.Button()
		Me.CR_Listview = New System.Windows.Forms.ListView()
		Me.searchfor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.replacewith = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.location = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.TabPage3 = New System.Windows.Forms.TabPage()
		Me.collection_options = New System.Windows.Forms.GroupBox()
		Me.remove_collection = New System.Windows.Forms.Button()
		Me.Add_collection = New System.Windows.Forms.Button()
		Me.Clear_collection_list = New System.Windows.Forms.Button()
		Me.save_collection_list = New System.Windows.Forms.Button()
		Me.Collection_list = New System.Windows.Forms.ListBox()
		Me.artist_detection_options = New System.Windows.Forms.GroupBox()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.detect_by_artist = New System.Windows.Forms.RadioButton()
		Me.save_artist_list = New System.Windows.Forms.Button()
		Me.al_training = New System.Windows.Forms.Button()
		Me.clear_artist_list = New System.Windows.Forms.Button()
		Me.al_remove_entry = New System.Windows.Forms.Button()
		Me.al_add_entry = New System.Windows.Forms.Button()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.artist_pattern_list = New System.Windows.Forms.ListBox()
		Me.mp3_settings = New System.Windows.Forms.GroupBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.write_short_hdr = New System.Windows.Forms.CheckBox()
		Me.audio_sampling_rate = New System.Windows.Forms.ComboBox()
		Me.clean_on_close = New System.Windows.Forms.CheckBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.set_db_level = New System.Windows.Forms.CheckBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.sort_by_Artist = New System.Windows.Forms.CheckBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.audio_bitrate = New System.Windows.Forms.ComboBox()
		Me.title_detection_options = New System.Windows.Forms.GroupBox()
		Me.detect_by_title = New System.Windows.Forms.RadioButton()
		Me.save_title_list = New System.Windows.Forms.Button()
		Me.clear_title_list = New System.Windows.Forms.Button()
		Me.tl_remove_entry = New System.Windows.Forms.Button()
		Me.tl_add_entry = New System.Windows.Forms.Button()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.title_pattern_list = New System.Windows.Forms.ListBox()
		Me.TabControl1.SuspendLayout()
		Me.TabPage1.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabPage2.SuspendLayout()
		Me.Clean_Replace_Controls.SuspendLayout()
		Me.TabPage3.SuspendLayout()
		Me.collection_options.SuspendLayout()
		Me.artist_detection_options.SuspendLayout()
		Me.mp3_settings.SuspendLayout()
		Me.title_detection_options.SuspendLayout()
		Me.SuspendLayout()
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.TabPage1)
		Me.TabControl1.Controls.Add(Me.TabPage2)
		Me.TabControl1.Controls.Add(Me.TabPage3)
		Me.TabControl1.Location = New System.Drawing.Point(0, 1)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(702, 559)
		Me.TabControl1.TabIndex = 7
		'
		'TabPage1
		'
		Me.TabPage1.Controls.Add(Me.GroupBox3)
		Me.TabPage1.Controls.Add(Me.GroupBox2)
		Me.TabPage1.Controls.Add(Me.GroupBox1)
		Me.TabPage1.Location = New System.Drawing.Point(4, 22)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(694, 533)
		Me.TabPage1.TabIndex = 3
		Me.TabPage1.Text = "Allgemein"
		Me.TabPage1.UseVisualStyleBackColor = True
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.Button12)
		Me.GroupBox3.Controls.Add(Me.Button11)
		Me.GroupBox3.Controls.Add(Me.extensions)
		Me.GroupBox3.Location = New System.Drawing.Point(547, 6)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(144, 245)
		Me.GroupBox3.TabIndex = 2
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "Content-Management"
		'
		'Button12
		'
		Me.Button12.Location = New System.Drawing.Point(43, 212)
		Me.Button12.Name = "Button12"
		Me.Button12.Size = New System.Drawing.Size(26, 23)
		Me.Button12.TabIndex = 2
		Me.Button12.Text = "-"
		Me.Button12.UseVisualStyleBackColor = True
		'
		'Button11
		'
		Me.Button11.Location = New System.Drawing.Point(11, 212)
		Me.Button11.Name = "Button11"
		Me.Button11.Size = New System.Drawing.Size(26, 23)
		Me.Button11.TabIndex = 1
		Me.Button11.Text = "+"
		Me.Button11.UseVisualStyleBackColor = True
		'
		'extensions
		'
		Me.extensions.FormattingEnabled = True
		Me.extensions.Items.AddRange(New Object() {".avi", ".exe", ".flv", ".iso", ".mp3", ".mp4", ".mov", ".mpg", ".nrg", ".mpeg", ".rar", ".wav", ".wma", ".wmv", ".zip"})
		Me.extensions.Location = New System.Drawing.Point(11, 19)
		Me.extensions.Name = "extensions"
		Me.extensions.Size = New System.Drawing.Size(120, 186)
		Me.extensions.TabIndex = 0
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.Button6)
		Me.GroupBox2.Controls.Add(Me.Button5)
		Me.GroupBox2.Controls.Add(Me.ListBox1)
		Me.GroupBox2.Location = New System.Drawing.Point(393, 3)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(148, 248)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Youtube-Parameter"
		'
		'Button6
		'
		Me.Button6.Location = New System.Drawing.Point(35, 211)
		Me.Button6.Name = "Button6"
		Me.Button6.Size = New System.Drawing.Size(23, 23)
		Me.Button6.TabIndex = 2
		Me.Button6.Text = "-"
		Me.Button6.UseVisualStyleBackColor = True
		'
		'Button5
		'
		Me.Button5.Location = New System.Drawing.Point(6, 211)
		Me.Button5.Name = "Button5"
		Me.Button5.Size = New System.Drawing.Size(23, 23)
		Me.Button5.TabIndex = 1
		Me.Button5.Text = "+"
		Me.Button5.UseVisualStyleBackColor = True
		'
		'ListBox1
		'
		Me.ListBox1.FormattingEnabled = True
		Me.ListBox1.Items.AddRange(New Object() {"cpn", "cver", "fexp", "keepalive", "key", "ms", "mt", "mv", "mws", "ratebypas", "signature", "sver", "algorithm"})
		Me.ListBox1.Location = New System.Drawing.Point(6, 19)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(128, 186)
		Me.ListBox1.TabIndex = 0
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Button13)
		Me.GroupBox1.Controls.Add(Me.Label10)
		Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
		Me.GroupBox1.Controls.Add(Me.Label3)
		Me.GroupBox1.Controls.Add(Me.TextBox1)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.Button1)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.Download_pfad)
		Me.GroupBox1.Location = New System.Drawing.Point(0, 3)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(387, 248)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Downloader"
		'
		'Button13
		'
		Me.Button13.Location = New System.Drawing.Point(300, 19)
		Me.Button13.Name = "Button13"
		Me.Button13.Size = New System.Drawing.Size(63, 23)
		Me.Button13.TabIndex = 7
		Me.Button13.Text = "Standard"
		Me.Button13.UseVisualStyleBackColor = True
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Location = New System.Drawing.Point(6, 82)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(147, 13)
		Me.Label10.TabIndex = 6
		Me.Label10.Text = "Max gleichzeitige Downloads:"
		'
		'NumericUpDown1
		'
		Me.NumericUpDown1.Location = New System.Drawing.Point(228, 80)
		Me.NumericUpDown1.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
		Me.NumericUpDown1.Name = "NumericUpDown1"
		Me.NumericUpDown1.Size = New System.Drawing.Size(65, 20)
		Me.NumericUpDown1.TabIndex = 3
		Me.NumericUpDown1.Value = New Decimal(New Integer() {3, 0, 0, 0})
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(270, 57)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(23, 13)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "MB"
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(228, 54)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(36, 20)
		Me.TextBox1.TabIndex = 4
		Me.TextBox1.Text = "1.9"
		Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(3, 57)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(219, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Medien welche kleiner als  nicht akzeptieren:"
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(270, 18)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(24, 24)
		Me.Button1.TabIndex = 2
		Me.Button1.Text = "..."
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(3, 22)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(32, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Pfad:"
		'
		'Download_pfad
		'
		Me.Download_pfad.BackColor = System.Drawing.Color.White
		Me.Download_pfad.Location = New System.Drawing.Point(41, 19)
		Me.Download_pfad.Name = "Download_pfad"
		Me.Download_pfad.ReadOnly = True
		Me.Download_pfad.Size = New System.Drawing.Size(223, 20)
		Me.Download_pfad.TabIndex = 0
		'
		'TabPage2
		'
		Me.TabPage2.Controls.Add(Me.Clean_Replace_Controls)
		Me.TabPage2.Controls.Add(Me.CR_Listview)
		Me.TabPage2.Location = New System.Drawing.Point(4, 22)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(694, 533)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "Bereinigen / Ersetzen"
		Me.TabPage2.UseVisualStyleBackColor = True
		'
		'Clean_Replace_Controls
		'
		Me.Clean_Replace_Controls.Controls.Add(Me.Button7)
		Me.Clean_Replace_Controls.Controls.Add(Me.Button9)
		Me.Clean_Replace_Controls.Controls.Add(Me.Button10)
		Me.Clean_Replace_Controls.Controls.Add(Me.Button8)
		Me.Clean_Replace_Controls.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Clean_Replace_Controls.Location = New System.Drawing.Point(3, 430)
		Me.Clean_Replace_Controls.Name = "Clean_Replace_Controls"
		Me.Clean_Replace_Controls.Size = New System.Drawing.Size(688, 100)
		Me.Clean_Replace_Controls.TabIndex = 7
		Me.Clean_Replace_Controls.TabStop = False
		'
		'Button7
		'
		Me.Button7.Location = New System.Drawing.Point(6, 19)
		Me.Button7.Name = "Button7"
		Me.Button7.Size = New System.Drawing.Size(64, 23)
		Me.Button7.TabIndex = 1
		Me.Button7.Text = "Speichern"
		Me.Button7.UseVisualStyleBackColor = True
		'
		'Button9
		'
		Me.Button9.Location = New System.Drawing.Point(181, 19)
		Me.Button9.Name = "Button9"
		Me.Button9.Size = New System.Drawing.Size(29, 23)
		Me.Button9.TabIndex = 4
		Me.Button9.Text = "+"
		Me.Button9.UseVisualStyleBackColor = True
		'
		'Button10
		'
		Me.Button10.Location = New System.Drawing.Point(216, 19)
		Me.Button10.Name = "Button10"
		Me.Button10.Size = New System.Drawing.Size(29, 23)
		Me.Button10.TabIndex = 5
		Me.Button10.Text = "-"
		Me.Button10.UseVisualStyleBackColor = True
		'
		'Button8
		'
		Me.Button8.Location = New System.Drawing.Point(76, 19)
		Me.Button8.Name = "Button8"
		Me.Button8.Size = New System.Drawing.Size(64, 23)
		Me.Button8.TabIndex = 2
		Me.Button8.Text = "Laden"
		Me.Button8.UseVisualStyleBackColor = True
		'
		'CR_Listview
		'
		Me.CR_Listview.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.searchfor, Me.replacewith, Me.location})
		Me.CR_Listview.Dock = System.Windows.Forms.DockStyle.Top
		Me.CR_Listview.FullRowSelect = True
		Me.CR_Listview.GridLines = True
		Me.CR_Listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		Me.CR_Listview.LabelEdit = True
		Me.CR_Listview.Location = New System.Drawing.Point(3, 3)
		Me.CR_Listview.Name = "CR_Listview"
		Me.CR_Listview.Size = New System.Drawing.Size(688, 348)
		Me.CR_Listview.TabIndex = 0
		Me.CR_Listview.UseCompatibleStateImageBehavior = False
		Me.CR_Listview.View = System.Windows.Forms.View.Details
		'
		'searchfor
		'
		Me.searchfor.Text = "suche nach:"
		Me.searchfor.Width = 92
		'
		'replacewith
		'
		Me.replacewith.Text = "und ersetze mit:"
		Me.replacewith.Width = 106
		'
		'location
		'
		Me.location.Text = "in:/wo:"
		Me.location.Width = 203
		'
		'TabPage3
		'
		Me.TabPage3.Controls.Add(Me.collection_options)
		Me.TabPage3.Controls.Add(Me.artist_detection_options)
		Me.TabPage3.Controls.Add(Me.mp3_settings)
		Me.TabPage3.Controls.Add(Me.title_detection_options)
		Me.TabPage3.Location = New System.Drawing.Point(4, 22)
		Me.TabPage3.Name = "TabPage3"
		Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage3.Size = New System.Drawing.Size(694, 533)
		Me.TabPage3.TabIndex = 2
		Me.TabPage3.Text = "Anderes"
		Me.TabPage3.UseVisualStyleBackColor = True
		'
		'collection_options
		'
		Me.collection_options.Controls.Add(Me.remove_collection)
		Me.collection_options.Controls.Add(Me.Add_collection)
		Me.collection_options.Controls.Add(Me.Clear_collection_list)
		Me.collection_options.Controls.Add(Me.save_collection_list)
		Me.collection_options.Controls.Add(Me.Collection_list)
		Me.collection_options.Location = New System.Drawing.Point(341, 262)
		Me.collection_options.Name = "collection_options"
		Me.collection_options.Size = New System.Drawing.Size(343, 183)
		Me.collection_options.TabIndex = 5
		Me.collection_options.TabStop = False
		Me.collection_options.Text = "Speicherorte"
		'
		'remove_collection
		'
		Me.remove_collection.Location = New System.Drawing.Point(136, 153)
		Me.remove_collection.Name = "remove_collection"
		Me.remove_collection.Size = New System.Drawing.Size(28, 23)
		Me.remove_collection.TabIndex = 4
		Me.remove_collection.Text = "-"
		Me.remove_collection.UseVisualStyleBackColor = True
		'
		'Add_collection
		'
		Me.Add_collection.Location = New System.Drawing.Point(170, 153)
		Me.Add_collection.Name = "Add_collection"
		Me.Add_collection.Size = New System.Drawing.Size(27, 23)
		Me.Add_collection.TabIndex = 3
		Me.Add_collection.Text = "+"
		Me.Add_collection.UseVisualStyleBackColor = True
		'
		'Clear_collection_list
		'
		Me.Clear_collection_list.Location = New System.Drawing.Point(8, 154)
		Me.Clear_collection_list.Name = "Clear_collection_list"
		Me.Clear_collection_list.Size = New System.Drawing.Size(59, 23)
		Me.Clear_collection_list.TabIndex = 2
		Me.Clear_collection_list.Text = "leeren"
		Me.Clear_collection_list.UseVisualStyleBackColor = True
		'
		'save_collection_list
		'
		Me.save_collection_list.Location = New System.Drawing.Point(251, 154)
		Me.save_collection_list.Name = "save_collection_list"
		Me.save_collection_list.Size = New System.Drawing.Size(75, 23)
		Me.save_collection_list.TabIndex = 1
		Me.save_collection_list.Text = "Speichern"
		Me.save_collection_list.UseVisualStyleBackColor = True
		'
		'Collection_list
		'
		Me.Collection_list.FormattingEnabled = True
		Me.Collection_list.Location = New System.Drawing.Point(8, 20)
		Me.Collection_list.Name = "Collection_list"
		Me.Collection_list.Size = New System.Drawing.Size(318, 121)
		Me.Collection_list.TabIndex = 0
		'
		'artist_detection_options
		'
		Me.artist_detection_options.Controls.Add(Me.Button2)
		Me.artist_detection_options.Controls.Add(Me.detect_by_artist)
		Me.artist_detection_options.Controls.Add(Me.save_artist_list)
		Me.artist_detection_options.Controls.Add(Me.al_training)
		Me.artist_detection_options.Controls.Add(Me.clear_artist_list)
		Me.artist_detection_options.Controls.Add(Me.al_remove_entry)
		Me.artist_detection_options.Controls.Add(Me.al_add_entry)
		Me.artist_detection_options.Controls.Add(Me.Label5)
		Me.artist_detection_options.Controls.Add(Me.artist_pattern_list)
		Me.artist_detection_options.Location = New System.Drawing.Point(340, 6)
		Me.artist_detection_options.Name = "artist_detection_options"
		Me.artist_detection_options.Size = New System.Drawing.Size(344, 249)
		Me.artist_detection_options.TabIndex = 4
		Me.artist_detection_options.TabStop = False
		Me.artist_detection_options.Text = "Artist-Erkennung"
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(205, 218)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(41, 23)
		Me.Button2.TabIndex = 8
		Me.Button2.Text = "edit"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'detect_by_artist
		'
		Me.detect_by_artist.AutoSize = True
		Me.detect_by_artist.Checked = True
		Me.detect_by_artist.Location = New System.Drawing.Point(9, 16)
		Me.detect_by_artist.Name = "detect_by_artist"
		Me.detect_by_artist.Size = New System.Drawing.Size(159, 17)
		Me.detect_by_artist.TabIndex = 7
		Me.detect_by_artist.TabStop = True
		Me.detect_by_artist.Text = "Artist-Erkennung verwenden"
		Me.detect_by_artist.UseVisualStyleBackColor = True
		'
		'save_artist_list
		'
		Me.save_artist_list.Location = New System.Drawing.Point(252, 218)
		Me.save_artist_list.Name = "save_artist_list"
		Me.save_artist_list.Size = New System.Drawing.Size(75, 23)
		Me.save_artist_list.TabIndex = 6
		Me.save_artist_list.Text = "Speichern"
		Me.save_artist_list.UseVisualStyleBackColor = True
		'
		'al_training
		'
		Me.al_training.Location = New System.Drawing.Point(6, 218)
		Me.al_training.Name = "al_training"
		Me.al_training.Size = New System.Drawing.Size(62, 23)
		Me.al_training.TabIndex = 5
		Me.al_training.Text = "Training..."
		Me.al_training.UseVisualStyleBackColor = True
		'
		'clear_artist_list
		'
		Me.clear_artist_list.Location = New System.Drawing.Point(74, 218)
		Me.clear_artist_list.Name = "clear_artist_list"
		Me.clear_artist_list.Size = New System.Drawing.Size(57, 23)
		Me.clear_artist_list.TabIndex = 4
		Me.clear_artist_list.Text = "Leeren"
		Me.clear_artist_list.UseVisualStyleBackColor = True
		'
		'al_remove_entry
		'
		Me.al_remove_entry.Location = New System.Drawing.Point(137, 218)
		Me.al_remove_entry.Name = "al_remove_entry"
		Me.al_remove_entry.Size = New System.Drawing.Size(28, 23)
		Me.al_remove_entry.TabIndex = 3
		Me.al_remove_entry.Text = "-"
		Me.al_remove_entry.UseVisualStyleBackColor = True
		'
		'al_add_entry
		'
		Me.al_add_entry.Location = New System.Drawing.Point(171, 218)
		Me.al_add_entry.Name = "al_add_entry"
		Me.al_add_entry.Size = New System.Drawing.Size(27, 23)
		Me.al_add_entry.TabIndex = 2
		Me.al_add_entry.Text = "+"
		Me.al_add_entry.UseVisualStyleBackColor = True
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(6, 36)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(284, 13)
		Me.Label5.TabIndex = 1
		Me.Label5.Text = "In der Liste enthaltende Schlagwörter makieren einen Artist"
		'
		'artist_pattern_list
		'
		Me.artist_pattern_list.FormattingEnabled = True
		Me.artist_pattern_list.Location = New System.Drawing.Point(6, 62)
		Me.artist_pattern_list.Name = "artist_pattern_list"
		Me.artist_pattern_list.Size = New System.Drawing.Size(321, 147)
		Me.artist_pattern_list.TabIndex = 0
		'
		'mp3_settings
		'
		Me.mp3_settings.Controls.Add(Me.Label9)
		Me.mp3_settings.Controls.Add(Me.write_short_hdr)
		Me.mp3_settings.Controls.Add(Me.audio_sampling_rate)
		Me.mp3_settings.Controls.Add(Me.clean_on_close)
		Me.mp3_settings.Controls.Add(Me.Label8)
		Me.mp3_settings.Controls.Add(Me.set_db_level)
		Me.mp3_settings.Controls.Add(Me.Label7)
		Me.mp3_settings.Controls.Add(Me.sort_by_Artist)
		Me.mp3_settings.Controls.Add(Me.Label6)
		Me.mp3_settings.Controls.Add(Me.audio_bitrate)
		Me.mp3_settings.Location = New System.Drawing.Point(8, 261)
		Me.mp3_settings.Name = "mp3_settings"
		Me.mp3_settings.Size = New System.Drawing.Size(326, 184)
		Me.mp3_settings.TabIndex = 3
		Me.mp3_settings.TabStop = False
		Me.mp3_settings.Text = "MP3-Einstellungen"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(159, 136)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(20, 13)
		Me.Label9.TabIndex = 5
		Me.Label9.Text = "Hz"
		'
		'write_short_hdr
		'
		Me.write_short_hdr.AutoSize = True
		Me.write_short_hdr.Checked = True
		Me.write_short_hdr.CheckState = System.Windows.Forms.CheckState.Checked
		Me.write_short_hdr.Enabled = False
		Me.write_short_hdr.Location = New System.Drawing.Point(6, 89)
		Me.write_short_hdr.Name = "write_short_hdr"
		Me.write_short_hdr.Size = New System.Drawing.Size(173, 17)
		Me.write_short_hdr.TabIndex = 12
		Me.write_short_hdr.Text = "Kurzen MP3-Header Schreiben"
		Me.write_short_hdr.UseVisualStyleBackColor = True
		'
		'audio_sampling_rate
		'
		Me.audio_sampling_rate.FormattingEnabled = True
		Me.audio_sampling_rate.Items.AddRange(New Object() {"32000", "44100", "48000"})
		Me.audio_sampling_rate.Location = New System.Drawing.Point(84, 133)
		Me.audio_sampling_rate.Name = "audio_sampling_rate"
		Me.audio_sampling_rate.Size = New System.Drawing.Size(69, 21)
		Me.audio_sampling_rate.TabIndex = 4
		Me.audio_sampling_rate.Text = "44100"
		'
		'clean_on_close
		'
		Me.clean_on_close.AutoSize = True
		Me.clean_on_close.Checked = True
		Me.clean_on_close.CheckState = System.Windows.Forms.CheckState.Checked
		Me.clean_on_close.Location = New System.Drawing.Point(6, 66)
		Me.clean_on_close.Name = "clean_on_close"
		Me.clean_on_close.Size = New System.Drawing.Size(218, 17)
		Me.clean_on_close.TabIndex = 11
		Me.clean_on_close.Text = "Tempöre Dateien beim beenden löschen"
		Me.clean_on_close.UseVisualStyleBackColor = True
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(3, 136)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(79, 13)
		Me.Label8.TabIndex = 3
		Me.Label8.Text = "Sampling-Rate:"
		'
		'set_db_level
		'
		Me.set_db_level.AutoSize = True
		Me.set_db_level.Checked = True
		Me.set_db_level.CheckState = System.Windows.Forms.CheckState.Checked
		Me.set_db_level.Location = New System.Drawing.Point(6, 43)
		Me.set_db_level.Name = "set_db_level"
		Me.set_db_level.Size = New System.Drawing.Size(180, 17)
		Me.set_db_level.TabIndex = 10
		Me.set_db_level.Text = "MP3-Lautstärke auf 96db setzen"
		Me.set_db_level.UseVisualStyleBackColor = True
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(159, 109)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(34, 13)
		Me.Label7.TabIndex = 2
		Me.Label7.Text = "kbit/s"
		'
		'sort_by_Artist
		'
		Me.sort_by_Artist.AutoSize = True
		Me.sort_by_Artist.Checked = True
		Me.sort_by_Artist.CheckState = System.Windows.Forms.CheckState.Checked
		Me.sort_by_Artist.Location = New System.Drawing.Point(6, 20)
		Me.sort_by_Artist.Name = "sort_by_Artist"
		Me.sort_by_Artist.Size = New System.Drawing.Size(137, 17)
		Me.sort_by_Artist.TabIndex = 9
		Me.sort_by_Artist.Text = "Nach Interpret sortieren"
		Me.sort_by_Artist.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(3, 109)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(65, 13)
		Me.Label6.TabIndex = 1
		Me.Label6.Text = "MP3-Bitrate:"
		'
		'audio_bitrate
		'
		Me.audio_bitrate.FormattingEnabled = True
		Me.audio_bitrate.Items.AddRange(New Object() {"32", "40", "64", "80", "96", "112", "128", "160", "192", "224", "256", "320"})
		Me.audio_bitrate.Location = New System.Drawing.Point(84, 106)
		Me.audio_bitrate.Name = "audio_bitrate"
		Me.audio_bitrate.Size = New System.Drawing.Size(69, 21)
		Me.audio_bitrate.TabIndex = 0
		Me.audio_bitrate.Text = "192"
		'
		'title_detection_options
		'
		Me.title_detection_options.Controls.Add(Me.detect_by_title)
		Me.title_detection_options.Controls.Add(Me.save_title_list)
		Me.title_detection_options.Controls.Add(Me.clear_title_list)
		Me.title_detection_options.Controls.Add(Me.tl_remove_entry)
		Me.title_detection_options.Controls.Add(Me.tl_add_entry)
		Me.title_detection_options.Controls.Add(Me.Label4)
		Me.title_detection_options.Controls.Add(Me.title_pattern_list)
		Me.title_detection_options.Location = New System.Drawing.Point(8, 6)
		Me.title_detection_options.Name = "title_detection_options"
		Me.title_detection_options.Size = New System.Drawing.Size(326, 249)
		Me.title_detection_options.TabIndex = 2
		Me.title_detection_options.TabStop = False
		Me.title_detection_options.Text = "Titel-Erkennung"
		'
		'detect_by_title
		'
		Me.detect_by_title.AutoSize = True
		Me.detect_by_title.Location = New System.Drawing.Point(6, 16)
		Me.detect_by_title.Name = "detect_by_title"
		Me.detect_by_title.Size = New System.Drawing.Size(156, 17)
		Me.detect_by_title.TabIndex = 6
		Me.detect_by_title.TabStop = True
		Me.detect_by_title.Text = "Titel Erkennung verwenden"
		Me.detect_by_title.UseVisualStyleBackColor = True
		'
		'save_title_list
		'
		Me.save_title_list.Enabled = False
		Me.save_title_list.Location = New System.Drawing.Point(245, 218)
		Me.save_title_list.Name = "save_title_list"
		Me.save_title_list.Size = New System.Drawing.Size(75, 23)
		Me.save_title_list.TabIndex = 5
		Me.save_title_list.Text = "Speichern"
		Me.save_title_list.UseVisualStyleBackColor = True
		'
		'clear_title_list
		'
		Me.clear_title_list.Enabled = False
		Me.clear_title_list.Location = New System.Drawing.Point(6, 218)
		Me.clear_title_list.Name = "clear_title_list"
		Me.clear_title_list.Size = New System.Drawing.Size(48, 23)
		Me.clear_title_list.TabIndex = 4
		Me.clear_title_list.Text = "leeren"
		Me.clear_title_list.UseVisualStyleBackColor = True
		'
		'tl_remove_entry
		'
		Me.tl_remove_entry.Enabled = False
		Me.tl_remove_entry.Location = New System.Drawing.Point(60, 218)
		Me.tl_remove_entry.Name = "tl_remove_entry"
		Me.tl_remove_entry.Size = New System.Drawing.Size(28, 23)
		Me.tl_remove_entry.TabIndex = 3
		Me.tl_remove_entry.Text = "-"
		Me.tl_remove_entry.UseVisualStyleBackColor = True
		'
		'tl_add_entry
		'
		Me.tl_add_entry.Enabled = False
		Me.tl_add_entry.Location = New System.Drawing.Point(94, 218)
		Me.tl_add_entry.Name = "tl_add_entry"
		Me.tl_add_entry.Size = New System.Drawing.Size(27, 23)
		Me.tl_add_entry.TabIndex = 2
		Me.tl_add_entry.Text = "+"
		Me.tl_add_entry.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(6, 36)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(284, 13)
		Me.Label4.TabIndex = 1
		Me.Label4.Text = "In der Liste enthaltende Schlagwörter makieren einen Titel:"
		'
		'title_pattern_list
		'
		Me.title_pattern_list.Enabled = False
		Me.title_pattern_list.FormattingEnabled = True
		Me.title_pattern_list.Location = New System.Drawing.Point(6, 62)
		Me.title_pattern_list.Name = "title_pattern_list"
		Me.title_pattern_list.Size = New System.Drawing.Size(314, 147)
		Me.title_pattern_list.TabIndex = 0
		'
		'settings
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(702, 562)
		Me.Controls.Add(Me.TabControl1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "settings"
		Me.Text = "Einstellungen"
		Me.TabControl1.ResumeLayout(False)
		Me.TabPage1.ResumeLayout(False)
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabPage2.ResumeLayout(False)
		Me.Clean_Replace_Controls.ResumeLayout(False)
		Me.TabPage3.ResumeLayout(False)
		Me.collection_options.ResumeLayout(False)
		Me.artist_detection_options.ResumeLayout(False)
		Me.artist_detection_options.PerformLayout()
		Me.mp3_settings.ResumeLayout(False)
		Me.mp3_settings.PerformLayout()
		Me.title_detection_options.ResumeLayout(False)
		Me.title_detection_options.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Clean_Replace_Controls As System.Windows.Forms.GroupBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents CR_Listview As System.Windows.Forms.ListView
    Friend WithEvents searchfor As System.Windows.Forms.ColumnHeader
    Friend WithEvents replacewith As System.Windows.Forms.ColumnHeader
    Friend WithEvents location As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents collection_options As System.Windows.Forms.GroupBox
    Friend WithEvents remove_collection As System.Windows.Forms.Button
    Friend WithEvents Add_collection As System.Windows.Forms.Button
    Friend WithEvents Clear_collection_list As System.Windows.Forms.Button
    Friend WithEvents save_collection_list As System.Windows.Forms.Button
    Friend WithEvents Collection_list As System.Windows.Forms.ListBox
    Friend WithEvents artist_detection_options As System.Windows.Forms.GroupBox
    Friend WithEvents detect_by_artist As System.Windows.Forms.RadioButton
    Friend WithEvents save_artist_list As System.Windows.Forms.Button
    Friend WithEvents al_training As System.Windows.Forms.Button
    Friend WithEvents clear_artist_list As System.Windows.Forms.Button
    Friend WithEvents al_remove_entry As System.Windows.Forms.Button
    Friend WithEvents al_add_entry As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents artist_pattern_list As System.Windows.Forms.ListBox
    Friend WithEvents mp3_settings As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents write_short_hdr As System.Windows.Forms.CheckBox
    Friend WithEvents audio_sampling_rate As System.Windows.Forms.ComboBox
    Friend WithEvents clean_on_close As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents set_db_level As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents sort_by_Artist As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents audio_bitrate As System.Windows.Forms.ComboBox
    Friend WithEvents title_detection_options As System.Windows.Forms.GroupBox
    Friend WithEvents detect_by_title As System.Windows.Forms.RadioButton
    Friend WithEvents save_title_list As System.Windows.Forms.Button
    Friend WithEvents clear_title_list As System.Windows.Forms.Button
    Friend WithEvents tl_remove_entry As System.Windows.Forms.Button
    Friend WithEvents tl_add_entry As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents title_pattern_list As System.Windows.Forms.ListBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Download_pfad As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents extensions As System.Windows.Forms.ListBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
