Imports System.IO

Public Class ManageMyCollection
	Dim WithEvents importer As New MediaImporter
	Dim onlymorethanonefiles As Boolean = False

	Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
		Dim _dirinfo As New System.IO.DirectoryInfo(Main.Collections.Aktuelle_Sammlung.Path)
		Dim minfilecount As Integer = 1


		If onlymorethanonefiles = True Then
			minfilecount = 2
		End If

		ListView1.Items.Clear()
		ListView1.Enabled = False

		TreeView1.Nodes.Clear()
		TreeView1.ImageIndex = 0



		Dim TNCur As New TreeNode

		With TNCur
			.Tag = _dirinfo.FullName
			.Text = "."
			.ImageIndex = 0
		End With

		TreeView1.Nodes.Add(TNCur)

		For Each Dir As System.IO.DirectoryInfo In _dirinfo.GetDirectories()
			Dim _foundfiles As Integer = 0

			For Each fil As FileInfo In Dir.GetFiles("*.mp3", SearchOption.AllDirectories)
				If fil.Exists = True AndAlso fil.Length >= minfilecount Then
					_foundfiles = _foundfiles + 1
				End If
			Next

			If Dir.Exists = True AndAlso _foundfiles >= minfilecount Then
				Dim TN As New TreeNode

				With TN
					.Tag = Dir.FullName
					.Text = Dir.Name
					.ImageIndex = 0
				End With

				TreeView1.Nodes.Add(TN)
			End If
		Next
	End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If TreeView1.SelectedNode IsNot Nothing Then
            Dim _dirinfo As New DirectoryInfo(CStr(TreeView1.SelectedNode.Tag) & "\")
         
            importer.filestoread = Main.FileIO.GetFileCount(_dirinfo.FullName, "*.mp3", SearchOption.TopDirectoryOnly)

            If importer.filestoread > 0 Then
                ListView1.Items.Clear()
                TreeView1.Enabled = False
                importer.start(CStr(e.Node.Tag))
            End If
        Else
            ListView1.Items.Clear()
        End If
    End Sub

    Delegate Sub delegated_addlistitem(ByVal mp3 As MP3File)

    Private Sub _addlistitem(ByVal mp3 As MP3File)
        Dim item As New ListViewItem
        item.ImageIndex = 1
        item.Text = CStr(ListView1.Items.Count + 1)

        With item.SubItems
            .Add(mp3.Artist)
            .Add(mp3.Title)
            .Add(CStr(mp3.Bitrate))
            .Add(mp3.Duration)
            .Add(mp3.Source)
        End With

        ListView1.Items.Add(item)
    End Sub

    Private Sub importer_Completed(filcount As Integer) Handles importer.Completed
        If Me.InvokeRequired = True Then
            For Each item As MP3File In importer.filestoimport
                Me.Invoke(New delegated_addlistitem(AddressOf _addlistitem), item)
            Next

            Me.Invoke(New _release(AddressOf release))
        Else
            For Each item As MP3File In importer.filestoimport
                _addlistitem(item)
            Next
            release()
        End If

    End Sub

    Delegate Sub _release()
    Sub release()
        TreeView1.Enabled = True
        ListView1.Enabled = True
        ListView1.Refresh()
        GroupBox1.Text = "Inhalt von " & CStr(TreeView1.SelectedNode.Tag)
    End Sub

    Private Sub UmbenennenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UmbenennenToolStripMenuItem.Click
        If TreeView1.SelectedNode IsNot Nothing Then
            TreeView1.Enabled = False
            ListView1.Enabled = False

            With TreeView1.SelectedNode
                Dim _curname As String = .Text 'Name des Verzeichnisses
                Dim Newname As String = InputBox("Verzeichnis umbennen in", "Umbenennen", _curname)
                Dim _Curpath As String = CStr(.Tag)
                Dim _NewPath As String = ""
                Dim _targetexist As Boolean = True
                Dim _Question As String = "Das Verzeichnis wurde Umbenannt, sollen die Interpreten-Einträge an den neuen Verzeichnisnamen angepasst werden?"
				Dim dir As New DirectoryInfo(_Curpath)

                Try
					If Not Newname = _curname AndAlso Newname.Length > 1 AndAlso Directory.Exists(_Curpath) AndAlso Not _Curpath = dir.Parent.FullName & "\" & Newname Then
						_NewPath = dir.Parent.FullName & "\" & Newname

						If Not Directory.Exists(dir.Parent.FullName & "\" & Newname) Then
							_targetexist = False
						Else
							_targetexist = True
						End If

						If _targetexist = False Then
							Directory.CreateDirectory(dir.Parent.FullName & "\" & Newname)
						Else
							Main.Eventlog.AddEvent("MediaManager", EventType.Warning, "Ziel existiert bereits, Inhalt wird zusammengeführt!")
						End If

						For Each fil As FileInfo In dir.GetFiles("*.mp3", SearchOption.AllDirectories)
							If fil.Exists = True AndAlso fil.Length > 0 Then
								Main.FileIO.Move(fil.FullName, _NewPath & "\" & fil.Name & fil.Extension)
							End If
						Next

						Main.Eventlog.AddEvent("MediaManager", EventType.information, "Der Inhalt von " & Chr(34) & _Curpath & Chr(34) & " wurde nach " & Chr(34) & dir.Parent.FullName & "\" & Newname & Chr(34) & " verschoben!")

						If _targetexist = True AndAlso Directory.Exists(_Curpath) AndAlso Main.FileIO.GetFileCount(_Curpath, "*.mp3", SearchOption.AllDirectories) = 0 Then
							Directory.Delete(_Curpath)
							TreeView1.SelectedNode.Remove()
							Main.Eventlog.AddEvent("MediaManager", EventType.Warning, "Das alte leere Verzeichnis wurde gelöscht!")
						Else
							Main.Eventlog.AddEvent("MediaManager", EventType.Warning, "Das alte leere Verzeichnis wurde nicht gelöscht, da sich noch Dateien in diesem Verzeichnis befinden!")
						End If
					Else
						Throw New Exception("Quelle und Ziel sind Identisch!")
					End If
				Catch ex As Exception
					Main.Eventlog.AddEvent("MediaManager", EventType.Exception, ex.Message)
				End Try
			End With

			TreeView1.Enabled = True
			ListView1.Enabled = True
		Else
			ListView1.Items.Clear()
			ListView1.Enabled = False
		End If
    End Sub

    Private Sub ManageMyCollection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Enabled = False
    End Sub

    Private Sub VerzeichnisnameAlsInterpetNutzenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerzeichnisnameAlsInterpetNutzenToolStripMenuItem.Click
        If ListView1.Items.Count > 0 AndAlso TreeView1.SelectedNode IsNot Nothing Then
            Dim _Curpath As String = CStr(TreeView1.SelectedNode.Tag)

			For Each item As ListViewItem In ListView1.Items
				If item Is Nothing Then Continue For

				With item
					.SubItems(1).Text = TreeView1.SelectedNode.Text
					If Main.FileIO.Move(.SubItems(5).Text, _Curpath & "\" & .SubItems(1).Text & " - " & .SubItems(2).Text & ".mp3", False) = False Then
						Main.Eventlog.AddEvent("MediaManager", EventType.Warning, "Datei " & .SubItems(5).Text & "kann nicht umbenannt werden!")
					Else
						.SubItems(5).Text = _Curpath & "\" & .SubItems(1).Text & " - " & .SubItems(2).Text & ".mp3"
						Main.Eventlog.AddEvent("MediaManager", EventType.information, "Datei " & .SubItems(5).Text & " wurde Umbenannt!")
					End If
				End With
			Next
        End If
    End Sub

	Private Sub LöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LöschenToolStripMenuItem.Click
		If ListView1.Items.Count > 0 AndAlso TreeView1.SelectedNode IsNot Nothing Then
			Dim _Curpath As String = CStr(TreeView1.SelectedNode.Tag)

			If Directory.Exists(_Curpath) AndAlso Not TreeView1.SelectedNode.Text = "." Then

				Directory.Delete(_Curpath)
				Main.Eventlog.AddEvent("MediaManager", EventType.information, "Verzeichnis " & TreeView1.SelectedNode.Text & " wurde entfernt!")
				TreeView1.SelectedNode.Remove()
			End If
		End If
	End Sub

	Private Sub DateiLöschen_Click(sender As Object, e As EventArgs) Handles DateiLöschen.Click
		If ListView1.Items.Count > 0 AndAlso ListView1.FocusedItem.SubItems(5).Text IsNot Nothing Then
			Dim _Curpath As String = CStr(ListView1.FocusedItem.SubItems(5).Text)

			If File.Exists(_Curpath) Then
				File.Delete(_Curpath)
				Main.Eventlog.AddEvent("MediaManager", EventType.information, "Datei " & _Curpath & " wurde entfernt!")
				ListView1.FocusedItem.Remove()
			End If
		End If
	End Sub

	Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
		onlymorethanonefiles = CheckBox1.Checked
	End Sub
End Class