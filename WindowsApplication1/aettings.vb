Public Class settings
    'Public do_not_cleanup_on_import As Boolean = True

    Private Sub tl_add_entry_Click(sender As Object, e As EventArgs) Handles tl_add_entry.Click
        Dim _pattern As String = ""

        _pattern = InputBox("Geben sie das Schlagwort, was einen Titel-Teil makieren soll ein", "Schlagwort hinzufügen")

        If _pattern.Length > 2 Then
            If Not artist_pattern_list.Items.Contains(_pattern) Then
                artist_pattern_list.Items.Add(_pattern)
            Else
                MsgBox("Schlagwort bereits enthalten!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Schlagwort zu kurz!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub tl_remove_entry_Click(sender As Object, e As EventArgs) Handles tl_remove_entry.Click


        If artist_pattern_list.SelectedItem IsNot Nothing Then
            If title_pattern_list.SelectedItems.Count > 0 Then
                title_pattern_list.Items.Remove(title_pattern_list.SelectedItem)
            End If
        End If
    End Sub

    Private Sub al_remove_entry_Click(sender As Object, e As EventArgs) Handles al_remove_entry.Click
        If artist_pattern_list.SelectedItem IsNot Nothing Then
            If artist_pattern_list.SelectedItems.Count > 0 Then
                artist_pattern_list.Items.Remove(artist_pattern_list.SelectedItem)
            End If
        End If
    End Sub

    Private Sub clear_artist_list_Click(sender As Object, e As EventArgs) Handles clear_artist_list.Click
        If MsgBox("Schlagwörterliste wirklich leeren?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            artist_pattern_list.Items.Clear()
            MsgBox("Alle Einträge entfernt!", MsgBoxStyle.Information, Me.Text)
        End If
    End Sub

    Private Sub al_training_Click(sender As Object, e As EventArgs) Handles al_training.Click
        Main.CleanReplace.training()
    End Sub

    Private Sub audio_sampling_rate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles audio_sampling_rate.SelectedIndexChanged
        If audio_sampling_rate.SelectedItem IsNot Nothing Then
            Main.MP3_Samprate = CStr(audio_sampling_rate.SelectedItem)
        Else
            Main.MP3_Samprate = "44100"
        End If
    End Sub

    Private Sub save_collection_list_Click(sender As Object, e As EventArgs) Handles save_collection_list.Click
        Main.Collections.Save_Collections()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Add_collection.Click
        Main.Collections.Add()
    End Sub

    Private Sub audio_bitrate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles audio_bitrate.SelectedIndexChanged
        If audio_bitrate.SelectedItem IsNot Nothing Then
			Main.MP3_Bitrate = CInt(audio_bitrate.SelectedItem)
        Else
			Main.MP3_Bitrate = 128
        End If
    End Sub

    Private Sub clear_title_list_Click(sender As Object, e As EventArgs) Handles clear_title_list.Click
        If MsgBox("Schlagwörterliste wirklich leeren?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            title_pattern_list.Items.Clear()
            MsgBox("Alle Einträge entfernt!", MsgBoxStyle.Information, Me.Text)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles sort_by_Artist.CheckedChanged
        If sort_by_Artist.Checked Then
            Main.sortbyartist = True
        Else
            Main.sortbyartist = False
        End If
    End Sub

    Private Sub set_db_level_CheckedChanged(sender As Object, e As EventArgs) Handles set_db_level.CheckedChanged
        If set_db_level.Checked = True Then
            Main.forcedb_normalize = True
        Else
            Main.forcedb_normalize = False
        End If
    End Sub

    Private Sub clean_on_close_CheckedChanged(sender As Object, e As EventArgs) Handles clean_on_close.CheckedChanged
        Main.cleanup_on_close = clean_on_close.Checked
    End Sub

    Private Sub write_short_hdr_CheckedChanged(sender As Object, e As EventArgs) Handles write_short_hdr.CheckedChanged
        Main.write_short_Header = write_short_hdr.Checked
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Main.CleanReplace.SaveRulelist()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Main.CleanReplace.Loadruleset()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ruleeditor.MdiParent = Main
        ruleeditor.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If CR_Listview.FocusedItem IsNot Nothing Then
            CR_Listview.FocusedItem.Remove()
            Main.CleanReplace.SaveRulelist()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles remove_collection.Click
        If Collection_list.SelectedItem IsNot Nothing Then
            Main.Collections.Remove(Collection_list.SelectedItem.ToString)

            If Collection_list.Items.Count < 1 Then
                Main.Collections.Add()
            End If
        End If
    End Sub

    Private Sub al_add_entry_Click(sender As Object, e As EventArgs) Handles al_add_entry.Click
        Dim _tmp As String = InputBox("neuen Interpreten hinzufügen:", "Interpet zur Schlagwort-Liste hinzufügen")

        If _tmp.Length > 1 Then
            If Not artist_pattern_list.Items.Contains(_tmp) Then
                artist_pattern_list.Items.Add(_tmp)
                Main.CleanReplace.SaveRulelist3()
            End If
        End If
    End Sub

    Private Sub _resize()
        TabControl1.Location = New Point(0, 0)
        TabControl1.Width = Me.Width
        TabControl1.Height = Me.Height

        CR_Listview.Height = Clean_Replace_Controls.Location.Y

        title_detection_options.Location = New Point(0, 0)
        title_detection_options.Width = CInt((TabControl1.Width / 2))
        title_detection_options.Height = CInt((TabControl1.Height / 2))

        title_pattern_list.Width = title_detection_options.Width - 10
        title_pattern_list.Height = title_detection_options.Height - 120

        clear_title_list.Location = New Point(0, title_detection_options.Height - (clear_title_list.Height + 10))
        tl_remove_entry.Location = New Point(tl_remove_entry.Location.X, clear_title_list.Location.Y)
        tl_add_entry.Location = New Point(tl_add_entry.Location.X, clear_title_list.Location.Y)
        save_title_list.Location = New Point(title_detection_options.Width - (save_title_list.Width + 10), clear_title_list.Location.Y)

        ' Artisten Optionen
        artist_detection_options.Location = New Point(title_detection_options.Width, 0)
        artist_detection_options.Width = CInt((TabControl1.Width / 2))
        artist_detection_options.Height = CInt((TabControl1.Height / 2))

        al_training.Location = New Point(0, artist_detection_options.Height - (al_training.Height + 10))
        clear_artist_list.Location = New Point(0, artist_detection_options.Height - (clear_artist_list.Height + 10))
        al_remove_entry.Location = New Point(al_remove_entry.Location.X, clear_artist_list.Location.Y)
        al_add_entry.Location = New Point(al_add_entry.Location.X, clear_artist_list.Location.Y)
        save_artist_list.Location = New Point(artist_detection_options.Width - (save_artist_list.Width + 10), clear_artist_list.Location.Y)

        artist_pattern_list.Width = title_pattern_list.Width
        artist_pattern_list.Height = title_pattern_list.Height

        mp3_settings.Location = New Point(0, title_detection_options.Height)
        mp3_settings.Width = CInt((TabControl1.Width / 2))
        mp3_settings.Height = CInt((TabControl1.Height / 2))

        collection_options.Location = New Point(artist_detection_options.Location.X, mp3_settings.Location.Y)
        collection_options.Width = mp3_settings.Width
        collection_options.Height = mp3_settings.Height

        Collection_list.Height = artist_pattern_list.Height
        Collection_list.Width = artist_pattern_list.Width

        Clear_collection_list.Location = New Point(0, Collection_list.Height + 40)
        remove_collection.Location = New Point(remove_collection.Location.X, Collection_list.Height + 40)
        Add_collection.Location = New Point(al_add_entry.Location.X, Collection_list.Height + 40)
        save_collection_list.Location = New Point(save_artist_list.Location.X, Collection_list.Height + 40)
    End Sub

    Private Sub settings_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        _resize()
    End Sub

    Private Sub settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Main.Dlpath.Length > 2 Then
            Download_pfad.Text = Main.Dlpath
            TextBox1.Text = Main.min_contentlength
        End If

        _resize()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fbd As New FolderBrowserDialog()

        With fbd
            .RootFolder = Environment.SpecialFolder.Desktop
            .ShowNewFolderButton = True
            .Description = "Download-Pfad angeben..."
        End With

        If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Not Main.Speicherort.Text = fbd.SelectedPath AndAlso Not Main.Speicherort.Text.Contains(fbd.SelectedPath) Then
                If System.IO.Directory.Exists(fbd.SelectedPath) Then
                    If fbd.SelectedPath.EndsWith("\") Then
                        Download_pfad.Text = fbd.SelectedPath
                    Else
                        Download_pfad.Text = fbd.SelectedPath & "\"
                    End If

                    Main.Dlpath = Download_pfad.Text
                End If
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim _tmp As String = InputBox("Parameter", "Parameter hinzufügen", "")

        If _tmp.Length > 0 Then
            If Not ListBox1.Items.Contains(_tmp) Then
                ListBox1.Items.Add(_tmp)
            End If
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim _tmp As String = InputBox("Erweiterung angeben", "Datei-Erweiterung angeben", "")

        If _tmp.Length > 3 Then
            If Not _tmp.StartsWith(".") Then
                _tmp = "." & _tmp
            End If

            extensions.Items.Add(_tmp)
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If extensions.SelectedItem IsNot Nothing Then
            If extensions.SelectedItems.Count > 0 Then
                extensions.Items.Remove(extensions.SelectedItem)
            End If
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If CInt(NumericUpDown1.Value) > 0 Then
            Main.max_Downloads = CInt(NumericUpDown1.Value) + 1
        ElseIf CInt(NumericUpDown1.Value) > 5 Then
            NumericUpDown1.Value = 3
            Main.max_Downloads = 4
        Else
            NumericUpDown1.Value = 1
            Main.max_Downloads = 2
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Main.Dlpath = Main.Application_Directory & "\Downloads\"
        If Not System.IO.Directory.Exists(Main.Application_Directory & "\Downloads\") Then
            Try
                System.IO.Directory.CreateDirectory(Main.Application_Directory & "\Downloads\")
                Download_pfad.Text = Main.Dlpath
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub save_artist_list_Click(sender As Object, e As EventArgs) Handles save_artist_list.Click
        Main.CleanReplace.SaveRulelist3()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim _old As String = CStr(artist_pattern_list.SelectedItem)
        Dim _tmp As String = InputBox("", "", CStr(artist_pattern_list.SelectedItem))

        If _tmp.Length > 2 Then
            For i As Integer = 0 To artist_pattern_list.Items.Count - 1 Step 1
                If artist_pattern_list.Items.Item(i).ToString = _old Then
                    artist_pattern_list.Items.Item(i) = _tmp
                    artist_pattern_list.Refresh()
                    Exit For
                End If
            Next

        End If
    End Sub
End Class