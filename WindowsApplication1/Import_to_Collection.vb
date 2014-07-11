Imports System.IO


Public Class ImportTo_Collection
    Public WithEvents Importer As New MediaImporter
    Dim move_instead_of_copy As Boolean = False
    Dim Replace_Files As Boolean = False
    Dim skip_existing_files As Boolean = True
    Dim lock As New Object
    Public _root As String = ""
    Dim _size As Integer = 0
    Dim _klammern_ignorieren As Boolean = False
    Dim _abort_Progress As Boolean = False
    Dim _duplicates As Integer = 0
    Dim copied As Integer = 0
    Public filcount As Integer = 0
    Dim _ablage As String = ""


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Minimum = 0
        ToolStripStatusLabel1.Visible = True

        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False

        CheckBox1.Enabled = False
        CheckBox2.Enabled = False
        CheckBox3.Enabled = False

        ListView1.Enabled = False

        If Import_BGW.IsBusy = False Then
            Import_BGW.RunWorkerAsync()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListFiles()
    End Sub

    Private Sub _addlistitem(artist As String, titel As String, source As String, ByVal size As String, ByVal isDuplicate As Boolean, ByVal TargetFilename As String, ByVal duration As String, ByVal bitrate As String, ByVal selected As Boolean, ByVal BadHeader As Boolean, ByVal errormsg As String)
        Dim item As New ListViewItem

        If isDuplicate = False AndAlso BadHeader = False Then
            item.Checked = True
        End If

        item.Text = artist

        If BadHeader = True Then
            item.BackColor = Color.Red
            item.Checked = False
        End If

        If isDuplicate = True Then
            item.BackColor = Color.Yellow
            item.Checked = False
        End If

        With item.SubItems
            .Add(titel)
            .Add(CStr(ListView1.Items.Count))
            .Add(source)
            .Add(size)
            .Add(TargetFilename)
            .Add(duration)
            .Add(bitrate)
            .Add(errormsg)
        End With

        ListView1.Items.Add(item)
    End Sub

    Private Sub ImportTo_Collection_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Importer.filestoimport.Clear()
        ListView1.Items.Clear()
        Main.Speicherort.Enabled = True
    End Sub

    Private Sub ImportTo_Collection_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        GroupBox1.Location = New Point(0, 0)
        GroupBox1.Width = Me.Width - 10
        GroupBox1.Height = Me.Height - 220

        ListView1.Location = GroupBox1.Location
        ListView1.Width = GroupBox1.Width
        ListView1.Height = GroupBox1.Height

        Button1.Location = New Point(Me.Width - (Button1.Width + 30), ListView1.Height + Button1.Height)
        Button2.Location = New Point(Button2.Location.X, ListView1.Height + Button2.Height)
        Button3.Location = New Point(Button3.Location.X, ListView1.Height + Button3.Height)
        Button4.Location = New Point(Button4.Location.X, ListView1.Height + Button4.Height)
        Button5.Location = New Point(Button5.Location.X, ListView1.Height + Button4.Height)

        CheckBox1.Location = New Point(Button4.Location.X, ListView1.Height + (Button4.Height + CheckBox1.Height))
        CheckBox2.Location = New Point(Button4.Location.X, CheckBox1.Location.Y + (CheckBox1.Height + CheckBox2.Height))
        donotcleanup.Location = New Point(Button4.Location.X, CheckBox2.Location.Y + (CheckBox2.Height + donotcleanup.Height))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ListView1.FocusedItem IsNot Nothing Then
            With ListView1.FocusedItem
                SyncLock lock
                    For Each entry As MP3File In Importer.filestoimport
                        If entry.Artist = .Text AndAlso entry.Source = .SubItems(3).Text AndAlso .SubItems(1).Text = entry.Title Then
                            Importer.filestoimport.Remove(entry)
                            ListView1.FocusedItem.Remove()
                            Exit For
                        End If
                    Next
                End SyncLock
            End With
        End If
        ListView1.Refresh()

        If ListView1.Items.Count = 0 Then
            Button1.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ListView1.FocusedItem IsNot Nothing Then
            With ListView1.FocusedItem
                Dim _tmp As String = InputBox("Titel bearbeiten", "", .SubItems(1).Text)
                SyncLock lock

                    If _tmp.Length > 0 Then
                        If Not .SubItems(1).Text.ToLower = _tmp.ToLower Then
                            .SubItems(1).Text = _tmp

                            For Each entry As MP3File In Importer.filestoimport
                                If entry.Artist = .Text AndAlso entry.Source = .SubItems(3).Text Then
                                    entry.Title = .SubItems(1).Text
                                    .SubItems(5).Text = _root & entry.Artist & " - " & entry.Title & ".mp3"
                                    entry.targetfilename = .SubItems(5).Text

                                    If Not File.Exists(entry.targetfilename) Then
                                        .BackColor = Color.SkyBlue
                                        .Checked = True
                                    Else
                                        .BackColor = Color.Yellow
                                        .Checked = False
                                    End If

                                    Exit For
                                End If
                            Next
                        Else
                            MsgBox("Keine Änderungen vorgenommen!", MsgBoxStyle.Exclamation)
                        End If
                    End If

                    ListView1.Refresh()
                End SyncLock
            End With
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        If CheckBox1.Checked = True Then
            With ListView1.Items

                For i As Integer = .Count - 1 To 0 Step -1
                    If .Item(i).BackColor = Color.Yellow Then
                        .Remove(.Item(i))
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            move_instead_of_copy = True
        Else
            move_instead_of_copy = False
        End If
    End Sub

    Private Sub ImportTo_Collection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _root = Main.Collections.Aktuelle_Sammlung.Path
        Main.Speicherort.Enabled = False
        Me.Text = "MP3-Dateien nach " & Main.Collections.Aktuelle_Sammlung.Name & " importieren..."

        ToolStripStatusLabel1.Text = "Bereit..."

    End Sub

    Private Sub ListFiles()
        If Main.Collections.Aktuelle_Sammlung IsNot Nothing Then
            _root = Main.Collections.Aktuelle_Sammlung.Path
            Dim fbd As New FolderBrowserDialog
            Dim _srcpath As String = ""
         
            With fbd
                .Description = "Verzeichnis auswählen, welches MP3-Dateien die in die Sammlung importiert werden sollen, enthält..."
                .RootFolder = Environment.SpecialFolder.Desktop
                .ShowNewFolderButton = False
            End With

            If fbd.ShowDialog = DialogResult.OK Then
                Try
                    If Directory.Exists(fbd.SelectedPath) Then
                        If Not fbd.SelectedPath.EndsWith("\") Then
                            _srcpath = fbd.SelectedPath & "\"
                        Else
                            _srcpath = fbd.SelectedPath
                        End If

                        Dim _dirinfo As New DirectoryInfo(CType(_srcpath, String))

                        For Each fil As FileInfo In _dirinfo.GetFiles("*.mp3", SearchOption.AllDirectories)

                            If fil.Exists = True Then
                                filcount = filcount + 1
                            End If
                        Next

                        If Dialog1.ShowDialog = Windows.Forms.DialogResult.OK Then


                            If Not _srcpath.Contains(Main.Collections.Aktuelle_Sammlung.Path) Then
                                If MsgBox("Die gewählte Sammlung ist: " & Main.Collections.Aktuelle_Sammlung.Name & vbCrLf & " Pfad der Sammlung:  " & Main.Collections.Aktuelle_Sammlung.Path & vbCrLf & " Ist das Richtig?", MsgBoxStyle.YesNo, "Wirklich Fortfahren?") = MsgBoxResult.Yes Then
                                    Button1.Enabled = False
                                    Button2.Enabled = False
                                    Button3.Enabled = False
                                    Button4.Enabled = False

                                    CheckBox1.Enabled = False
                                    CheckBox2.Enabled = False
                                    donotcleanup.Enabled = False

                                    ListView1.Enabled = False

                                    Button6.Enabled = True
                                    ToolStripProgressBar1.Visible = True
                                    ToolStripStatusLabel1.Text = "Ermitteln der Dateien..."
                                    Importer.start(_srcpath)
                                Else
                                    MsgBox("Abgebrochen!", MsgBoxStyle.Information)
                                End If
                            Else
                                MsgBox("Die Sammlung darf nicht als Teil Pfads, der zu importierenden MP3-Dateien sein!", MsgBoxStyle.Critical)
                            End If
                        Else
                            MsgBox("Verzeichnis kann nicht gefunden werden!", MsgBoxStyle.Critical)
                        End If
                    End If
                Catch ex As UnauthorizedAccessException
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            Else
                MsgBox("Abgebrochen!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Keine Sammlung ausgewählt!", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub Import_BGW_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Import_BGW.DoWork
        Dim Files_to_copy As Integer = 0
        Dim target As String = ""
        Dim DirName As String = ""

        If Not _root.Length > 1 Then
            MsgBox("Keine Sammlung angegeben!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Importer.filestoimport.Count > 0 Then
            With Importer.filestoimport
                SyncLock Main.lock
                    For i As Integer = 0 To .Count - 1 Step 1
                        If Importer.filestoimport.Item(i) IsNot Nothing Then
                            If .Item(i).BadHeader = False AndAlso .Item(i).Duplicate = False AndAlso .Item(i).selected = True Then
                                If .Item(i).Artist.Length > 1 Then
                                    If .Item(i).Artist.ToLower.Contains("&") Or .Item(i).Artist.ToLower.Contains("feat") Or .Item(i).Artist.ToLower.Contains("vs") Then
                                        DirName = Trim(Main.CleanReplace.replacechars(Main.CleanReplace.replacechars(.Item(i).Artist, "name", CheckBox3.Checked), "Target-Directory_only", CheckBox3.Checked))
                                    Else
                                        DirName = Trim(Main.CleanReplace.replacechars(.Item(i).Artist, "name", CheckBox3.Checked))
                                    End If

                                    If Not Directory.Exists(_root & DirName) Then
                                        Directory.CreateDirectory(_root & DirName)
                                    End If

                                    If .Item(i).Title.Length < 1 Or .Item(i).Artist.Length < 2 Then
                                        target = _root & DirName & "\" & Replace(Mid(target, target.LastIndexOf("\") + 1), ".mp3", "") & ".mp3"
                                    Else
                                        target = _root & DirName & "\" & .Item(i).Artist & " - " & .Item(i).Title & ".mp3"
                                        target = Replace(target, ".mp3", "") & ".mp3"
                                    End If

                                    If skip_existing_files = True Then
                                        If File.Exists(target) Then
                                            copied = copied + 1
                                            Import_BGW.ReportProgress(i, "[" & i & "] Überspringe " & Chr(34) & .Item(i).Artist & " - " & .Item(i).Title & ".mp3" & Chr(34) & " ...")
                                            Continue For
                                        End If
                                    Else
                                        If File.Exists(target) AndAlso Not .Item(i).Checksum = Main.FileIO.MD5FileHash(target) Then
                                            Import_BGW.ReportProgress(i, "[" & i & "] Benutze Original-Dateinamen für " & Chr(34) & .Item(i).Artist & " - " & .Item(i).Title & ".mp3" & Chr(34) & " in der Sammlung...")
                                            target = _root & DirName & "\" & Replace(Mid(target, target.LastIndexOf("\") + 1), ".mp3", "") & ".mp3"
                                        End If
                                    End If

                                    If move_instead_of_copy = False Then
                                        If Main.FileIO.Copy(.Item(i).Source, target, Replace_Files) = True Then
                                            Import_BGW.ReportProgress(i, "[" & i & "] kopiere " & Chr(34) & .Item(i).Source & Chr(34) & " als " & Chr(34) & .Item(i).Artist & " - " & .Item(i).Title & ".mp3" & Chr(34) & " in die Sammlung...")
                                            copied = copied + 1
                                        End If
                                    Else
                                        If Main.FileIO.Move(.Item(i).Source, target) = True Then
                                            Import_BGW.ReportProgress(i, "[" & i & "] verschiebe " & Chr(34) & .Item(i).Source & Chr(34) & " als " & Chr(34) & .Item(i).Artist & " - " & .Item(i).Title & ".mp3" & Chr(34) & " in die Sammlung...")
                                            copied = copied + 1
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                End SyncLock
            End With
        End If
    End Sub

    Private Sub Import_BGW_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles Import_BGW.ProgressChanged
        ToolStripStatusLabel1.Text = CStr(e.UserState)
        ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub Import_BGW_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Import_BGW.RunWorkerCompleted


        Importer.filestoimport.Clear()
        ListView1.Items.Clear()

        ToolStripProgressBar1.Value = 0

        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True

        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        donotcleanup.Enabled = True

        ListView1.Enabled = True

        ToolStripStatusLabel1.Text = ""
        _abort_Progress = False

        Importer.filestoimport.Clear()
        ListView1.Items.Clear()

        If copied > 0 Then
            MsgBox(copied.ToString & " Elemente kopiert!", MsgBoxStyle.Information)
            copied = 0
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Replace_Files = False
        Else
            Replace_Files = True
        End If
    End Sub

    Private Sub ImTitelEntfernenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImTitelEntfernenToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            With ListView1.FocusedItem
                .SubItems(1).Text = Replace(.SubItems(1).Text, " - ", " ")
                .SubItems(1).Text = Replace(.SubItems(1).Text, " -", "")


                SyncLock Main.lock
                    For Each item As MP3File In Importer.filestoimport
                        If item.Source = .SubItems(3).Text AndAlso item.Artist = .Text Then
                            item.Title = .SubItems(1).Text

                            .SubItems(5).Text = _root & .Text & "\" & .Text & " - " & .SubItems(1).Text & ".mp3"
                            item.targetfilename = .SubItems(5).Text



                            If Not File.Exists(item.targetfilename) Then
                                .BackColor = Color.SkyBlue
                            Else
                                .BackColor = Color.Yellow
                            End If

                            Exit For
                        End If
                    Next
                End SyncLock
            End With
        End If
    End Sub

    Private Sub InterpretAusTitelEntfernenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterpretAusTitelEntfernenToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            With ListView1.FocusedItem
                If .SubItems(1).Text.Contains(.Text) Then
                    .SubItems(1).Text = Trim(Replace(.SubItems(1).Text, .Text & " - ", ""))
                    .SubItems(1).Text = Trim(Replace(.SubItems(1).Text, .Text, ""))

                    SyncLock Main.lock
                        For Each item As MP3File In Importer.filestoimport
                            If item.Source = .SubItems(3).Text AndAlso item.Artist = .Text Then
                                item.Title = .SubItems(1).Text

                                item.targetfilename = _root & .Text & "\" & .Text & " - " & .SubItems(1).Text & ".mp3"
                                .SubItems(5).Text = item.targetfilename

                                If Not File.Exists(item.targetfilename) Then
                                    .BackColor = Color.SkyBlue
                                    .Checked = True
                                Else
                                    .BackColor = Color.Yellow
                                    .Checked = False
                                End If
                                Exit For
                            End If
                        Next
                    End SyncLock
                End If
            End With
        End If
    End Sub

    Private Sub InterpretZurArtistSchlagwortlisteHinzufügenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterpretZurArtistSchlagwortlisteHinzufügenToolStripMenuItem.Click
        If Not settings.artist_pattern_list.Items.Contains(Trim(ListView1.FocusedItem.Text)) Then
            settings.artist_pattern_list.Items.Add(Trim(ListView1.FocusedItem.Text))
            Main.CleanReplace.SaveRulelist3()
        End If
    End Sub

    Private Sub TeilDesTitelsAnInterpretenAnhängenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeilDesTitelsAnInterpretenAnhängenToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            With ListView1.FocusedItem
                If .SubItems(1).Text.Contains("-") Then
                    Dim fn_parts() As String = Split(Trim(.SubItems(1).Text), "-")

                    .Text = Trim(.Text) & " " & Trim(fn_parts(0))

                    If fn_parts.Length > 1 Then
                        For ia As Integer = 2 To fn_parts.Length - 1 Step 1
                            If Not fn_parts(1) = "" Then
                                fn_parts(1) = Trim(fn_parts(1)) & " - " & Trim(fn_parts(ia))
                            Else
                                fn_parts(1) = Trim(fn_parts(1)) & Trim(fn_parts(ia))
                            End If
                        Next
                    End If

                    SyncLock Main.lock
                        For Each item As MP3File In Importer.filestoimport
                            If item.Source = .SubItems(3).Text AndAlso item.Artist = .Text Then
                                item.Title = .SubItems(1).Text
                                item.targetfilename = _root & .Text & "\" & .Text & " - " & .SubItems(1).Text & ".mp3"

                                If Not File.Exists(item.targetfilename) Then
                                    .BackColor = Color.SkyBlue
                                    .Checked = True
                                Else
                                    .BackColor = Color.Yellow
                                    .Checked = False
                                End If

                                Exit For
                            End If
                        Next
                    End SyncLock
                End If
            End With
        End If
    End Sub

    Private Sub TeilDesTitelsAlsInterpretNutzenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeilDesTitelsAlsInterpretNutzenToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            With ListView1.FocusedItem
                If .SubItems(1).Text.Contains("-") Then
                    Dim tmp_name() As String = Split(Trim(.SubItems(1).Text), "-")
                    .Text = Trim(tmp_name(0))
                    .SubItems(1).Text = Trim(tmp_name(1))

                    SyncLock Main.lock
                        For Each item As MP3File In Importer.filestoimport
                            If item.Source = .SubItems(3).Text AndAlso item.Size = .SubItems(4).Text Then
                                item.Title = .SubItems(1).Text
                                item.Artist = .Text

                                item.targetfilename = _root & .Text & "\" & .Text & " - " & .SubItems(1).Text & ".mp3"

                                If Not File.Exists(item.targetfilename) Then
                                    .BackColor = Color.SkyBlue
                                    .Checked = True
                                Else
                                    .BackColor = Color.Yellow
                                    .Checked = False
                                End If

                                Exit For
                            End If
                        Next
                    End SyncLock
                End If
            End With
        End If
    End Sub

    Private Sub ÄnderungAnDateiAnwendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÄnderungAnDateiAnwendenToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            With ListView1.FocusedItem
                Dim _path As String = Trim(Mid(.SubItems(3).Text, 1, .SubItems(3).Text.LastIndexOf("\") + 1))

                Try
                    If Not File.Exists(_path & Trim(.Text) & " - " & Trim(.SubItems(1).Text) & ".mp3") Then
                        File.Move(ListView1.FocusedItem.SubItems(3).Text, Trim(_path & .Text) & " - " & Trim(.SubItems(1).Text) & ".mp3")
                        .SubItems(3).Text = Trim(_path & Trim(.Text) & " - " & Trim(.SubItems(1).Text) & ".mp3")

                        For Each item As MP3File In Importer.filestoimport
                            If item.Artist = .Text AndAlso .SubItems(1).Text = item.Title Then
                                item.Source = Trim(.SubItems(3).Text)
                                item.targetfilename = _root & .Text & "\" & .Text & " - " & .SubItems(1).Text & ".mp3"
                                .SubItems(5).Text = item.targetfilename

                                If File.Exists(item.targetfilename) = True Then
                                    .BackColor = Color.Yellow
                                    .Checked = False
                                    item.selected = False
                                Else
                                    .BackColor = Color.SkyBlue
                                    item.selected = True
                                End If
                                Exit For
                            End If
                        Next
                    Else
                        .BackColor = Color.Yellow
                        .Checked = False
                    End If
                Catch ex As Exception
                    MsgBox("Die Datei existiert bereits!", MsgBoxStyle.Critical)
                    .BackColor = Color.DarkRed
                End Try
            End With
            ÄnderungAnDateiAnwendenToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub IdentischeDateienAusListeEntfernenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim _path As String = ""
        SyncLock Main.lock
            ListView1.Enabled = False
            For Each item As ListViewItem In ListView1.Items
                If ListView1.Items.Contains(item) Then
                    If item IsNot Nothing Then
                        _path = Mid(Trim(item.SubItems(3).Text), 1, Trim(item.SubItems(3).Text).LastIndexOf("\") + 1)

                        If Trim(item.Text).Length > 1 AndAlso Trim(item.SubItems(1).Text).Length > 1 Then
                            If File.Exists(_path & Trim(item.Text) & " - " & Trim(item.SubItems(1).Text) & ".mp3") Then
                                item.Remove()
                            End If
                        End If
                    End If
                End If
            Next
        End SyncLock

        ListView1.Enabled = True
        ListView1.Refresh()

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        If ListView1.FocusedItem IsNot Nothing Then
            With ListView1.FocusedItem
                Dim _tmp As String = InputBox("Artist bearbeiten", "", .Text)
                SyncLock lock
                    If _tmp.Length > 1 Then
                        If Not .Text.ToLower = _tmp.ToLower Then
                            .Text = _tmp

                            For Each entry As MP3File In Importer.filestoimport
                                If entry.Title = .SubItems(1).Text AndAlso entry.Source = .SubItems(3).Text Then
                                    entry.Artist = .Text
                                    entry.targetfilename = _root & .Text & "\" & .Text & " - " & .SubItems(1).Text & ".mp3"
                                    .SubItems(5).Text = entry.targetfilename

                                    If Not File.Exists(entry.targetfilename) Then
                                        .BackColor = Color.SkyBlue
                                        .Checked = True
                                    Else
                                        .BackColor = Color.Yellow
                                        .Checked = False
                                    End If

                                    Exit For
                                End If
                            Next
                        Else
                            MsgBox("Keine Änderungen erkannt!", MsgBoxStyle.Exclamation)
                        End If
                    End If
                    ListView1.Refresh()
                End SyncLock
            End With
        End If
    End Sub

    Private Sub InMusikPlayerÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InMusikPlayerÖffnenToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            If File.Exists(ListView1.FocusedItem.SubItems(3).Text) Then
                Try
                    Dim mp3_player As New Process

                    With mp3_player
                        .StartInfo.FileName = ListView1.FocusedItem.SubItems(3).Text
                        .Start()
                    End With
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            Else
                MsgBox("Datei existiert nicht!", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If _abort_Progress = False Then
            _abort_Progress = True
        End If
    End Sub

    Private Sub ListView1_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles ListView1.ItemChecked
        If e.Item IsNot Nothing Then
            With e.Item
                SyncLock Main.lock
                    For Each entry As MP3File In Importer.filestoimport
                        If entry.Source = .SubItems(3).Text AndAlso entry.Size = .SubItems(4).Text Then
                            entry.selected = e.Item.Checked
                        End If
                    Next
                End SyncLock
            End With
        End If

        If ListView1.CheckedItems.Count > 0 Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.FocusedItem Is Nothing Then
            ContextMenuStrip1.Enabled = False
        Else
            ContextMenuStrip1.Enabled = True
            With ListView1.FocusedItem
                If .SubItems(3).Text = Mid(Trim(.SubItems(3).Text), 1, Trim(.SubItems(3).Text).LastIndexOf("\") + 1) & .Text & " - " & .SubItems(1).Text & ".mp3" Then
                    ÄnderungAnDateiAnwendenToolStripMenuItem.Enabled = False
                Else
                    ÄnderungAnDateiAnwendenToolStripMenuItem.Enabled = True
                End If
            End With
        End If
    End Sub

    Private Sub ImportTo_Collection_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ListFiles()
    End Sub

    Delegate Sub delegated_Importer_Completed(count As Integer)

    Private Sub Importer_Completed(count As Integer) Handles Importer.Completed
        If Me.InvokeRequired Then
            Me.Invoke(New delegated_Importer_Completed(AddressOf _listfiles), count)
        Else
            _listfiles(count)
        End If
    End Sub

    Private Sub _listfiles(count As Integer)
        ToolStripStatusLabel1.Text = "Auflisten der Dateien..."
        SyncLock Main.lock
            Dim _tmp As String = ""


            For i As Integer = Importer.filestoimport.Count - 1 To 0 Step -1
                With Importer.filestoimport.Item(i)
                    If .MD5Duplicate = False Then
                        If .ISVariableBitrate = True Then
                            _tmp = CStr(.Bitrate) & " (VBR)"
                        Else
                            _tmp = CStr(.Bitrate) & " (CBR)"
                        End If

                        _addlistitem(.Artist, .Title, .Source, .Size, .Duplicate, _root & .targetfilename, .Duration, _tmp, .selected, .BadHeader, .Exception)
                    End If
                End With
            Next
        End SyncLock

        ToolStripProgressBar1.Visible = False
        ToolStripProgressBar1.Value = 0
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True

        donotcleanup.Enabled = True

        ListView1.Enabled = True
        ToolStripStatusLabel1.Text = "Fertig!"
    End Sub

    Private Sub _Importer_Exception(ex As String)
        ToolStripStatusLabel1.ForeColor = Color.Red
        ToolStripStatusLabel1.Text = "Fehler: " & ex
    End Sub


    Delegate Sub delegated_Importer_exception(ex As String)

    Private Sub Importer_exception(ex As String) Handles Importer.Exception
        If Me.InvokeRequired Then
            Me.Invoke(New delegated_Importer_exception(AddressOf _Importer_Exception), ex)
        Else
            _Importer_Exception(ex)
        End If
    End Sub


    Private Sub Importer_ProvessChanged(f As String, count As Integer) Handles Importer.ProvessChanged
        If Me.InvokeRequired Then
            Me.Invoke(New delegated_importer_report(AddressOf importer_report), f, count)
        Else
            importer_report(f, count)
        End If

    End Sub

    Delegate Sub delegated_importer_report(f As String, count As Integer)

    Private Sub importer_report(f As String, count As Integer)
        If Importer.filestoimport IsNot Nothing AndAlso ToolStripProgressBar1 IsNot Nothing Then
            If ToolStripProgressBar1.Value < Importer.filestoimport.Count Then
                ToolStripProgressBar1.Value = ToolStripProgressBar1.Value + 1
                ToolStripStatusLabel1.ForeColor = Color.Black
                ToolStripStatusLabel1.Text = "[" & count.ToString & "] Datei einlesen: " & f
            End If
        End If
    End Sub

    Private Sub Importer_started(filecount As Integer) Handles Importer.started
        If Me.InvokeRequired Then
            Me.Invoke(New delegated_Importer_started(AddressOf _Importer_started), filecount)
        Else
            _Importer_started(filecount)
        End If

    End Sub

    Delegate Sub delegated_Importer_started(filecount As Integer)

    Private Sub _Importer_started(ByVal filcount As Integer)
        If filcount > 0 Then
            With ToolStripProgressBar1
                .Maximum = filcount
            End With
        End If
    End Sub

    Private Sub LetzteSektionEntfernenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LetzteSektionEntfernenToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            With ListView1.FocusedItem
                Dim tmp_name() As String = Split(.SubItems(1).Text, " - ")

                For i As Integer = 0 To tmp_name.Length - 2
                    If i > 0 Then
                        tmp_name(0) = tmp_name(i)

                    ElseIf tmp_name.Length > 2 Then
                        tmp_name(0) = tmp_name(0) & " - " & tmp_name(i)
                    End If
                Next

                .SubItems(1).Text = tmp_name(0)

                For Each entry As MP3File In Importer.filestoimport
                    If entry IsNot Nothing Then
                        If entry.Source = .SubItems(3).Text AndAlso entry.Size = .SubItems(4).Text Then
                            entry.Title = .SubItems(1).Text

                            entry.targetfilename = _root & .Text & "\" & .Text & " - " & .SubItems(1).Text & ".mp3"
                            .SubItems(5).Text = entry.targetfilename

                            If Not File.Exists(entry.targetfilename) Then
                                .BackColor = Color.SkyBlue
                                .Checked = True
                            Else
                                .BackColor = Color.Yellow
                                .Checked = False
                            End If

                            Exit For
                        End If
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub InterpretUndTitelTauschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterpretUndTitelTauschenToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            With ListView1.FocusedItem
                Dim _artist As String = .Text
                Dim _titel As String = .SubItems(1).Text

                .Text = _titel
                .SubItems(1).Text = _artist


                For Each entry As MP3File In Importer.filestoimport
                    If entry.Source = .SubItems(3).Text AndAlso entry.Size = .SubItems(4).Text Then
                        entry.Title = .SubItems(1).Text
                        entry.Artist = .Text

                        entry.targetfilename = _root & .Text & "\" & .Text & " - " & .SubItems(1).Text & ".mp3"
                        .SubItems(5).Text = entry.targetfilename

                        If Not File.Exists(entry.targetfilename) Then
                            .BackColor = Color.SkyBlue
                            .Checked = True
                        Else
                            .BackColor = Color.Yellow
                            .Checked = False
                        End If

                        Exit For
                    End If
                Next
            End With

        End If
    End Sub

    Private Sub InterpretFestlegenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterpretFestlegenToolStripMenuItem.Click
        If ListView1.FocusedItem IsNot Nothing Then
            With ListView1.FocusedItem
                SyncLock Main.lock
                    Dim _artist As String = Trim(InputBox("Entfernen sie alles was nicht zum Interpreten gehört", "Interpret aus zeichenvolge festlegen...", .SubItems(1).Text))
                    Dim _title As String = ""

                    If _artist.Length > 0 Then
                        _title = Trim(Replace(.SubItems(1).Text, _artist, ""))
                        .Text = _artist
                        .SubItems(1).Text = _title
                    End If

                    For Each entry As MP3File In Importer.filestoimport
                        If entry.Source = .SubItems(3).Text AndAlso entry.Size = .SubItems(4).Text Then
                            entry.Title = .SubItems(1).Text
                            entry.Artist = .Text

                            entry.targetfilename = _root & .Text & "\" & .Text & " - " & .SubItems(1).Text & ".mp3"
                            .SubItems(5).Text = entry.targetfilename

                            If Not File.Exists(entry.targetfilename) Then
                                .BackColor = Color.SkyBlue
                                .Checked = True
                            Else
                                .BackColor = Color.Yellow
                                .Checked = False
                            End If

                            Exit For
                        End If
                    Next
                End SyncLock
            End With
        End If
    End Sub

    Private Sub SucheUndErsetzeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SucheUndErsetzeToolStripMenuItem.Click
        Dim _Searchpattern As String = InputBox("Zeichenfolge angeben die ersetzt werden soll", "Zeichenfolge In Liste ersetzen", "Lyrics")
        Dim _ReplacePattern As String = InputBox("Zeichenfolge angeben durch die " & Chr(34) & _Searchpattern & Chr(34) & " soll", "Zeichenfolge In Liste ersetzen", "")

        If _Searchpattern.Length > 0 Then
            SyncLock Main.lock
                For Each item As ListViewItem In ListView1.Items
                    With item

                        ' Artist
                        If .Text.Contains(_Searchpattern) Then
                            .Text = Replace(.Text, _Searchpattern, _ReplacePattern)

                            For Each entry In Importer.filestoimport
                                If entry.Title = .SubItems(1).Text AndAlso .SubItems(3).Text.ToLower = entry.Source.ToLower Then
                                    entry.Artist = .Text
                                    entry.targetfilename = _root & .Text & "\" & .Text & " - " & .SubItems(1).Text & ".mp3"
                                    .SubItems(5).Text = entry.targetfilename

                                    If Not File.Exists(entry.targetfilename) Then
                                        .BackColor = Color.SkyBlue
                                        .Checked = True
                                    Else
                                        .BackColor = Color.Yellow
                                        .Checked = False
                                    End If
                                    Exit For
                                End If
                            Next
                        End If

                        ' Titel
                        If .SubItems(1).Text.Contains(_Searchpattern) Then
                            .SubItems(1).Text = Trim(Replace(.SubItems(1).Text, _Searchpattern, _ReplacePattern))

                            For Each entry In Importer.filestoimport
                                If entry.Artist = .Text AndAlso .SubItems(3).Text.ToLower = entry.Source.ToLower Then
                                    entry.Title = .SubItems(1).Text
                                    entry.targetfilename = _root & .Text & "\" & .Text & " - " & .SubItems(1).Text & ".mp3"
                                    .SubItems(5).Text = entry.targetfilename

                                    If Not File.Exists(entry.targetfilename) Then
                                        .BackColor = Color.SkyBlue
                                        .Checked = True
                                    Else
                                        .BackColor = Color.Yellow
                                        .Checked = False
                                    End If
                                    Exit For
                                End If
                            Next
                        End If
                    End With
                Next
            End SyncLock
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If ListView1.Items.Count > 0 Then
            For Each item As ListViewItem In ListView1.Items
                If item.Checked = False Then
                    item.Checked = True
                End If
            Next
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If ListView1.Items.Count > 0 Then
            For Each item As ListViewItem In ListView1.Items
                If item.Checked = True Then
                    item.Checked = False
                End If
            Next
        End If
    End Sub
End Class

