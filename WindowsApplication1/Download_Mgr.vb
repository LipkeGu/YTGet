Imports System.Net
Imports System.IO
Imports System.Threading

Public Class Download_Manager

    Public Event reportstate(ByVal message As String)
    Public Error_Handler As New EventLog
    Dim WithEvents Downloads As New Downloads
    Dim WithEvents ytlib As New Youtube_libary
    Public WithEvents converter As New convert
    Dim download_active As Boolean = True
	Public weitergehts As Boolean = False
    Dim ms As Integer = 1000
    Public statusliste As New List(Of ProgressBar)

    Delegate Sub __ytlib_releaseButtons(ByVal actiona As Boolean)

    Public Sub _ytlib_releaseButtons(action As Boolean)
        Add_URL.Enabled = True
    End Sub

    Delegate Sub __addlistitem(Video_Name As String, param2 As String, param3 As String, param4 As String, param5 As String, ByVal param6 As String)

    Private Sub _addlistitem(Video_name As String, param2 As String, param3 As String, param4 As String, param5 As String, ByVal param6 As String)
        Dim item As New ListViewItem

        If param4.Contains("video/") Or param4.Contains("audio/") Then
            If Video_name.Contains("-") Then
                Dim NameParts() As String = Split(Video_name, "-")

                If NameParts.Length > 1 Then
                    With settings.title_pattern_list.Items
                        If settings.detect_by_title.Checked = True Then ' Titel-Erkennung
                            If NameParts(0).Length > NameParts(1).Length Then
                                If NameParts(1).Contains(" Dj ") Or NameParts(1).Contains(" DJ ") Or NameParts(1).Contains(" dj ") Then
                                    Video_name = NameParts(1) & " - " & NameParts(0)
                                End If
                            End If

                            SyncLock Main.lock
                                For i As Integer = 0 To .Count - 1 Step 1
                                    If NameParts(0).ToLower.Contains(CStr(.Item(i)).ToLower) Then
                                        Video_name = NameParts(1) & " - " & NameParts(0)
                                    End If
                                Next
                            End SyncLock
                        End If
                    End With

                    With settings.artist_pattern_list.Items
                        If settings.detect_by_artist.Checked = True Then ' Artist-Erkennung
                            SyncLock Main.lock
                                For i As Integer = 0 To .Count - 1 Step 1
                                    If NameParts(1).ToLower.Contains(CStr(.Item(i)).ToLower) Then
                                        Video_name = CStr(.Item(i)) & " - " & NameParts(0)
                                    End If
                                Next

                                For i As Integer = 0 To .Count - 1 Step 1
                                    If NameParts(0).ToLower.Contains(CStr(.Item(i)).ToLower) Then
                                        Video_name = CStr(.Item(i)) & " - " & NameParts(1)
                                    End If
                                Next
                            End SyncLock
                        End If
                    End With
                Else
                    With settings.artist_pattern_list.Items
                        SyncLock Main.lock
                            For i As Integer = 0 To .Count - 1 Step 1
                                If Video_name.ToLower.Contains(CStr(.Item(i)).ToLower) Then
                                    Video_name = Replace(Video_name, CStr(.Item(i)), CStr(.Item(i)))
                                    Exit For
                                End If
                            Next
                        End SyncLock
                    End With
                End If
            Else
                With settings.artist_pattern_list.Items
                    SyncLock Main.lock
                        For i As Integer = 0 To .Count - 1 Step 1
                            If Video_name.ToLower.Contains(CStr(.Item(i)).ToLower) Then
                                Video_name = Replace(Video_name, CStr(.Item(i)), CStr(.Item(i)) & " - ")
                                Exit For
                            End If
                        Next
                    End SyncLock

                    If Not Video_name.Contains("-") Then
                        Dim _tmp As String = InputBox("Namen per hand bereinigen...", "Namen bereinigen", Video_name)

                        If _tmp.Length > 2 Then
                            Video_name = _tmp

                            If Video_name.Contains("-") Then
                                _tmp = Mid(Video_name, 1, Video_name.IndexOf("-") - 1)

                                If Not settings.artist_pattern_list.Items.Contains(_tmp) Then
                                    settings.artist_pattern_list.Items.Add(_tmp)
                                End If
                            End If
                        End If
                    End If
                End With
            End If
        End If

        item = DL_Listview.Items.Add(Replace(Video_name, "  ", " "))

        With item
            .Checked = True

            With item.SubItems
                .Add(param2)
                .Add(CStr(DL_Listview.Items.Count))
                .Add("Bereit")

                .Add(param3)
                .Add(param4)
                .Add(param5)
                .Add(param6)

                If Not param2.Contains(".7z") Then
                    .Add(Main.Dlpath & Video_name & ".flv")
                Else
                    .Add(Main.Dlpath & Video_name & ".7z")
                End If
            End With
        End With

        If DL_Listview.CheckedIndices.Count < 1 Then
            download.Enabled = False
        Else
            download.Enabled = True
        End If
        statusliste.Add(AddProgressBar(DL_Listview, DL_Listview.Items.Count - 1, 3, False))
        DL_Listview.Refresh()
        movie_url.Text = ""

    End Sub


    Public Function AddProgressBar(ByVal pListView As ListView, ByVal ItemIndex As Integer, ByVal ColumnIndex As Integer, Optional visible As Boolean = False) As ProgressBar
        'pgrogressbar erstellen funktion
        Dim r As Rectangle
        Dim pb As New ProgressBar

        r = pListView.Items(ItemIndex).SubItems(3).Bounds()
        With r
            .Location = DL_Listview.Items.Item(ItemIndex).SubItems(3).Bounds.Location
            .Width = pListView.Items(ItemIndex).SubItems(3).Bounds().Width
        End With

        With pb
            .Parent = pListView
            .SetBounds(r.X, r.Y, r.Width, r.Height)
            .Name = CStr("pb" & ItemIndex)
            .Maximum = 100
            .Value = 0
            .Style = ProgressBarStyle.Continuous
            .Visible = visible
        End With

        Return pb
    End Function

    Private Sub ytlib_Content(ByVal param1 As String, ByVal param2 As String, ByVal param3 As String, ByVal param4 As String, ByVal param5 As String, param6 As String) Handles ytlib.Content
        If Me.InvokeRequired Then
            Me.Invoke(New __addlistitem(AddressOf _addlistitem), param1, param2, param3, param4, param5, param6)
        Else
            _addlistitem(param1, param2, param3, param4, param5, param6)
        End If
    End Sub

    Private Sub ytlib_releaseButtons(ByVal action As Boolean) Handles ytlib.releaseButtons

        If Me.InvokeRequired Then
            Me.Invoke(New __ytlib_releaseButtons(AddressOf _ytlib_releaseButtons), action)
        Else
            _ytlib_releaseButtons(action)
        End If

    End Sub

	Public Sub wartezeit(ByVal sekunden As Integer)
		Try
			ms = sekunden * 1000
			weitergehts = False

			Dim t As Thread = New Thread(AddressOf warten)

			t.IsBackground = True
			t.Start()

			Do
				Application.DoEvents()
			Loop Until weitergehts = True
		Catch ex As Exception

		End Try

	End Sub

	Public Sub warten()
		Do

			If Downloads.Aktelle_Downloads < Main.max_Downloads Then
				weitergehts = True
			End If

			Thread.Sleep(ms)
			weitergehts = True
		Loop Until weitergehts = True
	End Sub

    Private Sub Download_Manager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Main.Speicherort.Enabled = True
    End Sub

    Private Sub DL_Listview_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles DL_Listview.ColumnWidthChanging

        For i As Integer = 0 To DL_Listview.Items.Count - 1
            CType(statusliste(i), ProgressBar).Location = DL_Listview.Items.Item(i).SubItems(3).Bounds.Location
            CType(statusliste(i), ProgressBar).Width = DL_Listview.Items.Item(i).SubItems(3).Bounds.Width
        Next
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DL_Listview.SelectedIndexChanged
        If DL_Listview.FocusedItem IsNot Nothing Then
            If DL_Listview.CheckedIndices.Count < 1 Then
                download.Enabled = False
            Else
                download.Enabled = True
            End If
        End If

        If DL_Listview.Items.Count > 0 Then
            GesamteListeToolStripMenuItem.Visible = True
            FertigeElementeToolStripMenuItem.Visible = True

            If DL_Listview.FocusedItem IsNot Nothing Then
                GewähltesElementToolStripMenuItem.Visible = True
                DownloadenToolStripMenuItem.Visible = True

                If DL_Listview.FocusedItem.Text.Contains("-") Then
                    NamenTauschen1221ToolStripMenuItem.Visible = True
                    LetzteSpalteEntfernen12312ToolStripMenuItem.Visible = True
                    InterpretZurArtistListeHinzufügenToolStripMenuItem.Visible = True
                Else
                    NamenTauschen1221ToolStripMenuItem.Visible = False
                    LetzteSpalteEntfernen12312ToolStripMenuItem.Visible = False
                    InterpretZurArtistListeHinzufügenToolStripMenuItem.Visible = False
                End If
            Else
                DownloadenToolStripMenuItem.Visible = False
                GewähltesElementToolStripMenuItem.Visible = False
            End If
        Else
            GesamteListeToolStripMenuItem.Visible = False
            FertigeElementeToolStripMenuItem.Visible = False
        End If

    End Sub

    Private Sub UserAgentToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ytlib._useragent = InputBox(Me.Text & " soll sich auf Youtube als folgenden identifizieren als:", "User-Agent ändern", ytlib._useragent)

        If Main.HAVE_CONFIG_FILE = True Then
            Main.INIDatei.WertSchreiben("Settings", "UserAgent", ytlib._useragent)
        End If
    End Sub

    Private Sub NamenTauschen1221ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NamenTauschen1221ToolStripMenuItem.Click
        If DL_Listview.FocusedItem IsNot Nothing Then
            Dim tmp_name() As String = Split(DL_Listview.FocusedItem.Text, " - ", 2)
            DL_Listview.FocusedItem.SubItems(0).Text = Trim(tmp_name(1)) & " - " & Trim(tmp_name(0))
        End If

    End Sub

    Private Sub LetzteSpalteEntfernen12312ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LetzteSpalteEntfernen12312ToolStripMenuItem.Click
        If DL_Listview.FocusedItem IsNot Nothing Then
            Dim tmp_name() As String = Split(DL_Listview.FocusedItem.Text, " - ")
            DL_Listview.FocusedItem.SubItems(0).Text = Trim(tmp_name(0) & " - " & tmp_name(1))
        End If
    End Sub

    Private Sub NamenTrimmenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NamenTauschen1221ToolStripMenuItem.Click
        If DL_Listview.FocusedItem IsNot Nothing Then
            DL_Listview.FocusedItem.SubItems(0).Text = Trim(DL_Listview.FocusedItem.SubItems(0).Text)
        End If
    End Sub

    Private Sub DownloadenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadenToolStripMenuItem.Click
        If DL_Listview.FocusedItem IsNot Nothing Then
            DL_Listview.FocusedItem.SubItems(3).Text = "Bereit..."
        End If
    End Sub

    Private Sub GewähltesElementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GewähltesElementToolStripMenuItem.Click
        If DL_Listview.Items.Count > 0 Then
            If DL_Listview.FocusedItem IsNot Nothing Then

                If DL_Listview.FocusedItem.SubItems(3).Text = "Downloaden" Then
                    Downloads.Cancel(DL_Listview.FocusedItem.Index)
                End If

                statusliste.Item(DL_Listview.FocusedItem.Index).Dispose()
                statusliste.Remove(statusliste.Item(DL_Listview.FocusedItem.Index))

                DL_Listview.FocusedItem.Remove()

                If DL_Listview.CheckedIndices.Count < 1 Then
                    download.Enabled = False
                Else
                    download.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub GesamteListeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GesamteListeToolStripMenuItem.Click
        If download_active = True Then
            Downloads.Cancel()
            Downloads.Current_Downloads.Clear()
        End If

        DL_Listview.Items.Clear()

        For Each ProgressBar In statusliste
            ProgressBar.Dispose()
        Next

        statusliste.Clear()
        If DL_Listview.CheckedIndices.Count < 1 Then
            download.Enabled = False
        Else
            download.Enabled = True
        End If
    End Sub

    Private Sub FertigeElementeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FertigeElementeToolStripMenuItem.Click
        SyncLock Main.lock
            For Each item As ListViewItem In DL_Listview.Items
                If item IsNot Nothing And DL_Listview.Items.Contains(item) Then
                    If item.SubItems(3).Text = "Fertig" Then
                        statusliste.Item(item.Index).Dispose()
                        statusliste.Remove(statusliste.Item(item.Index))
                        item.Remove()
                    End If
                End If
            Next
        End SyncLock
    End Sub

    Private Sub InterpretZurArtistListeHinzufügenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterpretZurArtistListeHinzufügenToolStripMenuItem.Click
        Dim _tmp() As String

        If DL_Listview.FocusedItem IsNot Nothing Then
            _tmp = DL_Listview.FocusedItem.Text.Split(CChar("-"))

            If _tmp.Length > 1 Then
                If Not settings.artist_pattern_list.Items.Contains(Trim(_tmp(0))) Then
                    settings.artist_pattern_list.Items.Add(Trim(_tmp(0)))
                    Main.CleanReplace.SaveRulelist3()
                    Main.Eventlog.AddEvent("Settings", EventType.information, "Interpret " & Chr(34) & Trim(_tmp(0)) & Chr(34) & " erfolgreich hinzugefügt!")
                Else
                    Main.Eventlog.AddEvent("Settings", EventType.information, "Interpret " & Chr(34) & Trim(_tmp(0)) & Chr(34) & " bereits vorhanden!")
                End If
            End If
        End If
    End Sub

    Delegate Sub _respond_state(ByVal str As String, ByVal entryid As Integer)

    Public Sub respond_state(ByVal str As String, ByVal entryid As Integer)
        If DL_Listview.Items.Contains(DL_Listview.Items.Item(entryid)) Then
            If DL_Listview.Items.Item(entryid) IsNot Nothing Then
                DL_Listview.Items.Item(entryid).SubItems(3).Text = str
            End If
        End If
    End Sub

    Private Sub Downloads_Download_Abgebrochen(ref As Download) Handles Downloads.Download_Abgebrochen
        If DL_Listview.Items.Contains(DL_Listview.Items.Item(ref.Id)) Then
                If DL_Listview.Items.Item(ref.Id) IsNot Nothing Then
                    DL_Listview.Items.Item(ref.Id).SubItems(3).Text = "Abgebrochen!"

                    If statusliste.Contains(statusliste.Item(ref.Id)) Then
                        statusliste.Item(ref.Id).Visible = False
                    End If
                End If
            Else
                Downloads.Remove(ref)
            End If
            cancel_all_downloads.Enabled = False
            download.Enabled = True
    End Sub

    Private Sub Downloads_Download_begonnen(ref As Download) Handles Downloads.Download_begonnen
        SyncLock Main.lock
            If DL_Listview.Items.Contains(DL_Listview.Items.Item(ref.Id)) Then
                DL_Listview.Items.Item(ref.Id).SubItems(3).Text = "Downloaden"

                For i As Integer = statusliste.Count - 1 To 0 Step 1
                    If DL_Listview.Items.Item(i).SubItems(3).Text = "Downloaden" Then
                        DL_Listview.Items.Item(ref.Id).SubItems(3).Text = "Fertig"

                        If statusliste.Contains(statusliste.Item(ref.Id)) Then
                            statusliste.Item(i).Visible = True
                        End If
                    End If
                Next
            Else
                ref.Cancel_Download()
            End If
        End SyncLock

        cancel_all_downloads.Enabled = True
        download.Enabled = False
    End Sub

    Private Sub Downloads_Download_Fertig(ref As Download) Handles Downloads.Download_Fertig
        SyncLock Main.lock
                If DL_Listview.Items.Contains(DL_Listview.Items.Item(ref.Id)) Then
                    For i As Integer = statusliste.Count - 1 To 0 Step 1
                        If DL_Listview.Items.Item(i).SubItems(3).Text = "Downloaden" Then
                            DL_Listview.Items.Item(ref.Id).SubItems(3).Text = "Fertig"

                            If statusliste.Contains(statusliste.Item(i)) Then
                                statusliste.Item(i).Visible = False
                            End If
                        End If
                    Next
                End If
        End SyncLock

        cancel_all_downloads.Enabled = False
    End Sub

    Private Sub Downloads_Download_Fortschritt(Percent As Integer, current_bytes As Integer, total_bytes As Integer, ref As Download) Handles Downloads.Download_Fortschritt
        cancel_all_downloads.Enabled = True
        SyncLock Main.lock
            If DL_Listview.Items.Contains(DL_Listview.Items.Item(ref.Id)) Then
                DL_Listview.Items.Item(ref.Id).SubItems(3).Text = "Downloaden"

                If DL_Listview.Items.Item(ref.Id).SubItems(3).Text = "Downloaden" Then
                    If statusliste.Contains(statusliste.Item(ref.Id)) Then
                        statusliste.Item(ref.Id).Visible = True
                        statusliste.Item(ref.Id).Value = Percent
                    End If
                End If
            Else
                ref.Cancel_Download()
            End If

        End SyncLock
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles Add_URL.Click
        If movie_url.Text <> "" Then
            Add_URL.Enabled = False

            If movie_url.Text.Length > 1 Then
                ytlib.seiteAufrufen(movie_url.Text)
            End If
        Else
            If movie_url.Text.Length < 3 Then Error_Handler.AddEvent("Download-Manager", EventType.Exception, "Ungültige URL: " & Chr(34) & movie_url.Text & Chr(34))
        End If
    End Sub

Private Sub download_Click(sender As Object, e As EventArgs) Handles download.Click
		SyncLock Main.lock
			For i = 0 To DL_Listview.CheckedIndices.Count - 1
				With DL_Listview.Items
					If .Item(i).SubItems(3).Text <> "Fertig" Then
						If Downloads.Aktelle_Downloads < Main.max_Downloads Then
							If .Item(i).SubItems(5).Text = "audio/mpeg" Then
								Downloads.Add_Download(.Item(i).SubItems(4).Text, Main.Dlpath & .Item(i).SubItems(0).Text & ".mp3", DL_Listview.CheckedIndices.Item(i))
							ElseIf .Item(i).SubItems(5).Text = "video/mp4" Then
								Downloads.Add_Download(.Item(i).SubItems(4).Text, Main.Dlpath & .Item(i).SubItems(0).Text & ".mp4", DL_Listview.CheckedIndices.Item(i))
							Else
								Downloads.Add_Download(.Item(i).SubItems(4).Text, Main.Dlpath & .Item(i).SubItems(0).Text, DL_Listview.CheckedIndices.Item(i))
							End If
						Else
							i = i - 1
							wartezeit(1)
						End If
					End If
				End With
			Next
		End SyncLock
	End Sub

    Private Sub cancel_all_downloads_Click_1(sender As Object, e As EventArgs) Handles cancel_all_downloads.Click
        Downloads.Cancel()
        download.Enabled = True
    End Sub

    Private Sub movie_url_TextChanged(sender As Object, e As EventArgs) Handles movie_url.TextChanged
        If movie_url.Text.Length > 0 Then
            Add_URL.Enabled = True
        Else
            Add_URL.Enabled = False
        End If
    End Sub

    Private Sub Download_Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main.Speicherort.Enabled = False
        If movie_url.Text.Length < 1 Then
            Add_URL.Enabled = False
        End If
    End Sub

    Private Sub convertcomplete(id As Integer)
        SyncLock Main.lock
            statusliste.Item(id).Visible = False
        End SyncLock
        Main.Eventlog.AddEvent("Konverter", EventType.information, "Konverter Beendet...")
    End Sub

    Private Sub converter_Completed(id As Integer) Handles converter.Completed
        If Me.InvokeRequired = True Then
            Me.Invoke(New _convertcomplete(AddressOf convertcomplete), id)
        Else
            convertcomplete(id)
        End If
    End Sub

    Private Sub converter_GetDuration(duration As String, id As Integer) Handles converter.GetDuration
        If Me.InvokeRequired = True Then
            Me.Invoke(New _SetMaxval_pb(AddressOf SetMaxval_pb), duration, id)
        Else
            SetMaxval_pb(duration, id)
        End If
    End Sub

    Delegate Sub _SetMaxval_pb(duration As String, id As Integer)
    Delegate Sub _Setvaluel_pb(position As String, id As Integer)
    Delegate Sub _convertcomplete(id As Integer)

    Private Sub SetMaxval_pb(duration As String, id As Integer)
        SyncLock Main.lock

            Main.Eventlog.AddEvent("Konverter", EventType.information, "Konverter gestartet...")

            If DL_Listview.Items.Item(id).SubItems(3).Text = "Konvertiere" Then
                If statusliste.Contains(statusliste.Item(id)) Then
                    With statusliste.Item(id)
                        If .Visible = False Then
                            .Visible = True
                            .Minimum = 0
                            .Value = 0
                            .Maximum = CInt(duration)
                        End If
                    End With
                End If
            End If
        End SyncLock
    End Sub

    Private Sub Setvalue_pb(position As String, id As Integer)
        If DL_Listview.Items.Item(id).SubItems(3).Text = "Konvertiere" Then
            If statusliste.Contains(statusliste.Item(id)) Then
                With statusliste.Item(id)

                    If .Name = "pb" & CStr(id) Then
                        If CInt(position) < .Maximum Then
                            .Value = CInt(position)
                        Else
                            .Value = .Maximum
                        End If
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub converter_Position(position As String, id As Integer) Handles converter.Position
        If Me.InvokeRequired = True Then
            Me.Invoke(New _Setvaluel_pb(AddressOf Setvalue_pb), position, id)
        Else
            Setvalue_pb(position, id)
        End If
    End Sub
End Class
