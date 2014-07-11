Imports System.IO

Public Class ImportTo_Collection
    Dim clean_replace As New CleanReplace

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Files_to_copy As Integer = 0
        Dim target As String = ""
        Dim copied As Integer = 0
        Dim DirName As String = ""

        If ListView1.Items.Count > 0 Then
            Files_to_copy = ListView1.Items.Count - 1

            For i As Integer = 0 To Files_to_copy Step 1
                If ListView1.Items.Item(i) IsNot Nothing Then
                    If ListView1.Items.Item(i).Text.Length > 1 Then
                        If Not Directory.Exists(main.collectdir & ListView1.Items.Item(i).Text) Then
                            DirName = clean_replace.replacechars(ListView1.Items.Item(i).Text, "Target-Directory")

                            Directory.CreateDirectory(main.collectdir & DirName)
                        Else
                            ListView1.Items.Item(i).BackColor = Color.Blue
                        End If

                        target = main.collectdir & ListView1.Items.Item(i).Text & "\" & ListView1.Items.Item(i).Text & " - " & ListView1.Items.Item(i).SubItems(1).Text & ".mp3"

                        If Not File.Exists(target) Then
                            Try
                                File.Copy(ListView1.Items.Item(i).SubItems(3).Text, target)
                                copied = copied + 1
                                ListView1.Items.Item(i).BackColor = Color.Green
                            Catch ex As Exception
                                ListView1.Items.Item(i).BackColor = Color.Red
                            End Try
                            ListView1.Refresh()
                        Else
                            If CheckBox1.Checked = False Then
                                File.Copy(ListView1.Items.Item(i).SubItems(3).Text, target)
                                copied = copied + 1
                                ListView1.Items.Item(i).BackColor = Color.Green
                            End If
                        End If
                    End If
                    Application.DoEvents()
                End If
            Next
            MsgBox(copied & " Elemente kiopiert!")
        End If
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fbd As New FolderBrowserDialog
        Dim _srcpath As String = ""

        With fbd
            .Description = "Quellverzeichnis auswählen, welches MP3-Dateien enthält..."
            .RootFolder = Environment.SpecialFolder.Desktop
            .ShowNewFolderButton = False
        End With

        If fbd.ShowDialog = DialogResult.OK Then
            If Not fbd.SelectedPath.EndsWith("\") Then
                _srcpath = fbd.SelectedPath & "\"
            Else
                _srcpath = fbd.SelectedPath
            End If

            If Directory.Exists(_srcpath) AndAlso _srcpath <> main.collectdir Then
                Dim dirinfo As New DirectoryInfo(_srcpath)
                Dim fn_parts() As String
                Dim _strpos As Integer = 0

                For Each fil As FileInfo In dirinfo.GetFiles("*.mp3", SearchOption.AllDirectories)
                    Try
                        If fil.Exists() Then
                            If fil.Name.Contains("-") Then
                                fn_parts = clean_replace.replacechars(fil.Name, "Target-Filename").Split(CChar("-"))

                                If fn_parts.Length > 1 Then

                                    'X-Effekt : sometimes we have "A-rtist - title"-format so let us check here ;)
                                    If fn_parts.Length > 2 Then
                                        fn_parts(0) = Trim(Mid(clean_replace.replacechars(fil.Name, "Target-Filename"), 1, clean_replace.replacechars(fil.Name, "Target-Filename").LastIndexOf("-")))
                                        fn_parts(1) = Trim(fn_parts(fn_parts.Length - 1))
                                    End If

                                    For i As Integer = 0 To fn_parts.Length - 1 Step 1
                                        fn_parts(i) = Replace(fn_parts(i), ".mp3", "")
                                        fn_parts(i) = Trim(fn_parts(i))
                                    Next

                                    If main.detect_by_artist.Checked = True Then ' Wenn kein Trenner vorhanden... nutze Artist-erkennung um den Artisten zu ermitteln!
                                        For i As Integer = 0 To main.artist_pattern_list.Items.Count - 1 Step 1
                                            If fn_parts(0).ToLower = CStr(main.artist_pattern_list.Items.Item(i)).ToLower Then
                                                fn_parts(0) = CStr(main.artist_pattern_list.Items.Item(i))
                                            ElseIf fn_parts(0).ToLower = CStr(main.artist_pattern_list.Items.Item(i)).ToLower Then
                                                If MsgBox("Soll der Treffer (" & main.artist_pattern_list.Items.Item(i).ToString & ")" & vbCrLf & " für """ & fn_parts(0) & """ aus der Artisten-liste verwendet werden?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                                                    fn_parts(0) = CStr(main.artist_pattern_list.Items.Item(i).ToString)
                                                    Exit For
                                                End If
                                            End If
                                        Next
                                    End If

                                    _addlistitem(fn_parts(0), fn_parts(1), fil.FullName)

                                    If ListView1.Items.Count > 0 Then
                                        Button1.Enabled = True
                                        Button3.Enabled = True
                                        Button4.Enabled = True
                                    Else
                                        Button1.Enabled = False
                                        Button3.Enabled = False
                                        Button4.Enabled = False
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox(fil.FullName & " : " & ex.Message, MsgBoxStyle.Critical)
                    End Try
                Next

                If CheckBox1.Checked = True Then
                    For i As Integer = ListView1.Items.Count - 1 To 0 Step -1
                        If ListView1.Items.Item(i).BackColor = Color.Yellow Then
                            ListView1.Items.Remove(ListView1.Items.Item(i))
                        End If
                    Next
                End If

                ListView1.Refresh()

                If ListView1.Items.Count = 0 AndAlso CheckBox1.Checked = True Then
                    MsgBox("Es befinden sich alle Dateien in der Sammlung!", MsgBoxStyle.Information)
                End If
            End If
        End If
    End Sub

    Private Sub _addlistitem(param1 As String, param2 As String, param3 As String)
        Dim item As New ListViewItem

        item = ListView1.Items.Add(Trim(clean_replace.replacechars(Trim(param1), "Name")))
        item.SubItems.Add(Trim(clean_replace.replacechars(Trim(param2), "Name")))
        item.SubItems.Add(CStr(ListView1.Items.Count))
        item.SubItems.Add(param3)

        If File.Exists(main.collectdir & Trim(clean_replace.replacechars(Trim(param1), "Name")) & "\" & Trim(clean_replace.replacechars(Trim(param1), "Name")) & " - " & Trim(clean_replace.replacechars(Trim(param2), "Name")) & ".mp3") Then
            item.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub ImportTo_Collection_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        GroupBox1.Width = Me.Width
        GroupBox1.Height = Me.Height - 120
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ListView1.FocusedItem IsNot Nothing Then
            ListView1.FocusedItem.Remove()
        End If

        If ListView1.Items.Count = 0 Then
            Button1.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ListView1.FocusedItem IsNot Nothing Then
            Dim _tmp As String = InputBox("Titel bearbeiten", "", ListView1.FocusedItem.SubItems(1).Text)

            If _tmp.Length > 1 Then
                ListView1.FocusedItem.SubItems(1).Text = _tmp
            End If
            ListView1.Refresh()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If CheckBox1.Checked = True Then
            For i As Integer = ListView1.Items.Count - 1 To 0 Step -1
                If ListView1.Items.Item(i).BackColor = Color.Yellow Then
                    ListView1.Items.Remove(ListView1.Items.Item(i))
                End If
            Next
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Button5.Enabled = False
        Else
            Button5.Enabled = True
        End If
    End Sub
End Class