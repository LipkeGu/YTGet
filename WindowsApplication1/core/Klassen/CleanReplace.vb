Imports System.IO
Public Class CleanReplace

    Dim INI As New INIDatei

    Public Sub AddNewRule(ByVal Expression As String, ByVal replacewith As String, ByVal wheretodo As String)
        Dim item As ListViewItem
        item = settings.CR_Listview.Items.Add(Expression)
        item.SubItems.Add(replacewith)
        item.SubItems.Add(wheretodo)
        settings.CR_Listview.Refresh()
    End Sub

#Region "Laden der Regeln"
    Public Sub Loadruleset()
        If File.Exists(My.Application.Info.DirectoryPath & "\clean_replace.ini") Then
            INI.Pfad = My.Application.Info.DirectoryPath & "\clean_replace.ini"
            Dim rulecount As Integer = 0
            Dim rule() As String
            rulecount = CInt(INI.WertLesen("info", "count"))

            If rulecount > 0 Then
                settings.CR_Listview.Items.Clear()

                SyncLock Main.lock
                    For ruleindex As Integer = 0 To rulecount - 1
                        rule = Split(INI.WertLesen("ruleset", "Rule" & CStr(ruleindex)), "##-##")

                        If rule(0) <> "" And rule(2) <> "" Then
                            If rule(1) Is Nothing Then rule(1) = ""
                            AddNewRule(rule(0), rule(1), rule(2))
                        End If
                    Next
                End SyncLock
            End If
        Else
            SaveRulelist()
            Loadruleset()
        End If
    End Sub

    Public Sub Loadruleset2()
        If File.Exists(My.Application.Info.DirectoryPath & "\clean_replace.ini") Then
            INI.Pfad = My.Application.Info.DirectoryPath & "\clean_replace.ini"
            Dim rulecount As Integer = 0
            Dim rule As String = ""

            rulecount = CInt(INI.WertLesen("info", "tp_count"))

            If rulecount > 0 Then
                settings.title_pattern_list.Items.Clear()
                SyncLock Main.lock
                    For ruleindex As Integer = 0 To rulecount - 1
                        rule = INI.WertLesen("tp_ruleset", "tp_Rule" & CStr(ruleindex), "")
                        If rule Is Nothing Then rule = ""

                        If rule <> "" Then
                            If Not settings.title_pattern_list.Items.Contains(rule) Then
                                settings.title_pattern_list.Items.Add(rule)
                            End If
                        End If
                    Next
                End SyncLock
            End If
        Else
            SaveRulelist2()
            Loadruleset2()
        End If
    End Sub

    Public Sub Loadruleset3()
        If File.Exists(My.Application.Info.DirectoryPath & "\clean_replace.ini") Then
            INI.Pfad = My.Application.Info.DirectoryPath & "\clean_replace.ini"
            Dim rulecount As Integer = 0
            Dim rule As String = ""

            rulecount = CInt(INI.WertLesen("info", "ap_count"))

            If rulecount > 0 Then
                settings.artist_pattern_list.Items.Clear()
                SyncLock Main.lock
                    For ruleindex As Integer = 0 To rulecount - 1
                        rule = INI.WertLesen("ap_ruleset", "ap_Rule" & CStr(ruleindex), "")
                        If rule Is Nothing Then rule = ""

                        If rule <> "" Then
                            If Not settings.artist_pattern_list.Items.Contains(rule) Then
                                settings.artist_pattern_list.Items.Add(Trim(rule))
                            End If
                        End If
                    Next
                End SyncLock
            End If
        Else
            SaveRulelist3()
            Loadruleset3()
        End If
    End Sub
#End Region

#Region "Speichern der Regeln"
    Public Sub SaveRulelist()
        settings.Button7.Enabled = False
        settings.Button8.Enabled = False
        settings.Button9.Enabled = False

        INI.SektionLöschen("ruleset")

        INI.WertSchreiben("info", "count", CStr(settings.CR_Listview.Items.Count))

        For i As Integer = 0 To settings.CR_Listview.Items.Count - 1
            INI.WertSchreiben("ruleset", "rule" & i, settings.CR_Listview.Items.Item(i).SubItems(0).Text & "##-##" & settings.CR_Listview.Items.Item(i).SubItems(1).Text & "##-##" & settings.CR_Listview.Items.Item(i).SubItems(2).Text)
        Next

        Loadruleset()
        settings.Button7.Enabled = True
        settings.Button8.Enabled = True
        settings.Button9.Enabled = True

    End Sub

    Public Sub SaveRulelist2()
        INI.SektionLöschen("tp_ruleset")
        INI.WertSchreiben("info", "tp_count", CStr(settings.title_pattern_list.Items.Count))

        SyncLock Main.lock
            For i As Integer = 0 To settings.title_pattern_list.Items.Count - 1
                INI.WertSchreiben("tp_ruleset", "tp_Rule" & i, settings.title_pattern_list.Items.Item(i).ToString)
            Next
        End SyncLock

        Loadruleset2()
    End Sub

    Public Sub SaveRulelist3()
        INI.SektionLöschen("ap_ruleset")

        INI.WertSchreiben("info", "ap_count", CStr(settings.artist_pattern_list.Items.Count))

        SyncLock Main.lock
            For i As Integer = 0 To settings.artist_pattern_list.Items.Count - 1
                INI.WertSchreiben("ap_ruleset", "ap_Rule" & i, settings.artist_pattern_list.Items.Item(i).ToString)
            Next
        End SyncLock

        Loadruleset3()
    End Sub
#End Region
    Public Function Entferne_ab_Stelle(ByVal input As String, ByVal pattern As String) As String
        Dim orig As String = input
        Dim cleaned As String = ""
        Dim delimeter_start As Integer = 0
        Dim delimeter_ende As Integer = 0

        If orig.ToLower.Contains(pattern.ToLower) Then
            delimeter_ende = orig.ToLower.IndexOf(pattern.ToLower)
            cleaned = Mid(orig, 1, delimeter_ende)

            Return Trim(cleaned)
        Else
            Return input
        End If
    End Function

    Public Function replacechars(ByVal input As String, ByVal whereto As String, Optional ByVal nicht_entklammern As Boolean = False) As String
        If input.Length > 0 Then
            INI.Pfad = My.Application.Info.DirectoryPath & "\clean_replace.ini"
            Dim rulecount As Integer = 0
            Dim rule() As String

            ' X-Effekt: Try to detect patterns and clean/replace them

            If whereto = "name" Or whereto = "author" Or whereto = "Target-Filename" Or whereto = "Source-Filename" Then
                If whereto = "name" Then
                    If input.Contains(") (") Then
                        input = Replace(input, ") (", "")
                    End If

                    If nicht_entklammern = False Then
                        Dim delimeter_start, delimeter_ende, count As Integer

                        '()-Klammern

                        If input.Contains("(") AndAlso input.Contains(")") Then
                            delimeter_start = input.LastIndexOf("(")
                            delimeter_ende = input.LastIndexOf(")")

                            If delimeter_ende > delimeter_start Then
                                count = (delimeter_ende - delimeter_start)
                            Else
                                count = (delimeter_start - delimeter_ende)
                            End If

                            input = Trim(input.Remove(delimeter_start, count))
                        End If

                        ' []-Klammern
                        If input.Contains("] [") Then
                            input = Replace(input, "] [", "")
                        End If

                        If input.Contains("[") AndAlso input.Contains("]") Then
                            delimeter_start = input.LastIndexOf("[")
                            delimeter_ende = input.LastIndexOf("]")

                            If delimeter_ende > delimeter_start Then
                                count = (delimeter_ende - delimeter_start)
                            Else
                                count = (delimeter_start - delimeter_ende)
                            End If

                            input = Trim(input.Remove(delimeter_start, count))
                        End If

                        ' {}-Klammern
                        If input.Contains("} {") Then
                            input = Replace(input, "} {", "")
                        End If

                        If input.Contains("{") AndAlso input.Contains("}") Then
                            delimeter_start = input.LastIndexOf("{")
                            delimeter_ende = input.LastIndexOf("}")

                            If delimeter_ende > delimeter_start Then
                                count = (delimeter_ende - delimeter_start)
                            Else
                                count = (delimeter_start - delimeter_ende)
                            End If

                            input = Trim(input.Remove(delimeter_start, count))
                        End If
                    End If

                    For _year As Integer = 1990 To My.Computer.Clock.LocalTime.Year
                        If input.Contains(_year.ToString) Then
                            input = Replace(input, _year.ToString, "")
                        End If
                    Next

                    input = Replace(input, "♥", "")
                    input = Replace(input, "✤", "")
                    input = Replace(input, "♫", "")
                    input = Replace(input, "★", "")
                    input = Replace(input, "✭", "")
                    input = Replace(input, "►", "")
                    input = Replace(input, "◄", "")
                    input = Replace(input, "_", "")
                    input = Replace(input, "ღ", "")
                    input = Replace(input, "→", "")
                    input = Replace(input, "%20", " ")
                    input = Replace(input, "?", "")
                    input = Replace(input, "'", "")
                    input = Replace(input, "♪", "")
                    input = Replace(input, "&#39;", "")
                    input = Replace(input, "&amp;", "")
                    input = Replace(input, "&quot;", "")
                    input = Replace(input, "featuring", "feat")
                    input = Replace(input, " Vs ", " feat ")
                    input = Replace(input, " Vs. ", " feat ")
                    input = Replace(input, " vs ", " feat ")
                    input = Replace(input, " vs. ", " feat ")
                    input = Replace(input, "/", " & ")
                    input = Replace(input, "()", "")

                    If input.Contains(".mp3") Then
                        input = Replace(input, ".mp3", "")
                    End If

                    If input.Contains(".MP3") Then
                        input = Replace(input, ".MP3", "")
                    End If

                    If input.Contains(".") Then
                        input = Replace(input, ".", "")
                    End If

                    If settings.detect_by_artist.Checked = True Then ' Wenn kein Trenner vorhanden... nutze Artist-erkennung um den Artisten zu ermitteln!
                        For i As Integer = 0 To settings.artist_pattern_list.Items.Count - 1 Step 1
                            If input.ToLower = CStr(settings.artist_pattern_list.Items.Item(i)).ToLower Then
                                input = CStr(settings.artist_pattern_list.Items.Item(i))
                            End If
                        Next
                    End If
                End If

                If whereto = "Author" Then
                    If input = "" Then input = "Unbekannt"
                End If
            End If

            If whereto = "source_code" Then
                input = Replace(input, "%252F", "/")
                input = Replace(input, "%2F", "/")
                input = Replace(input, "%5C", "/")
                input = Replace(input, "%2522", """")
                input = Replace(input, "%22", """")
                input = Replace(input, "////", "//")
                input = Replace(input, "%252C", ",")
                input = Replace(input, "%2C", ",")
                input = Replace(input, "%253F", "?")
                input = Replace(input, "%3F", "?")
                input = Replace(input, "%253D", "=")
                input = Replace(input, "%3D", "=")
                input = Replace(input, "\/", "/")
                input = Replace(input, "%26", "&")
                input = Replace(input, "%253A", ":")
                input = Replace(input, "%2F", "/")
                input = Replace(input, "%3A", ":")
                input = Replace(input, "\u0026", "&")
            End If

            If whereto = "Download-URL" Then
                input = Replace(input, "&&", "&")
                input = Replace(input, "?&", "?")
                input = Replace(input, "??", "?")
            End If

            If whereto = "Name" Or whereto = "Target-Directory" Then
                input = Entferne_ab_Stelle(input, " feat. ")
                input = Entferne_ab_Stelle(input, " feat ")
                input = Entferne_ab_Stelle(input, " ft ")
                input = Entferne_ab_Stelle(input, " vs ")
                input = Entferne_ab_Stelle(input, ";")
                input = Replace(input, ".", "")
            End If

            If whereto = "Target-Directory_only" Then
                input = Replace(input, " Vs ", " feat ")
                input = Replace(input, " Vs. ", " feat ")
                input = Replace(input, " vs ", " feat ")
                input = Replace(input, " vs. ", " feat ")
                input = Replace(input, ",", "")
                input = Replace(input, ".", "")

                input = Entferne_ab_Stelle(input, " & ")
                input = Entferne_ab_Stelle(input, " feat.")
                input = Entferne_ab_Stelle(input, " feat ")
                input = Entferne_ab_Stelle(input, " ft ")
                input = Entferne_ab_Stelle(input, " vs ")
                input = Entferne_ab_Stelle(input, ";")

            End If

            'X-Effekt: parse custom Rules for additional patterns

            rulecount = CInt(INI.WertLesen("info", "count"))

            If rulecount > 0 Then
                SyncLock Main.lock
                    For ruleindex As Integer = 0 To rulecount - 1
                        rule = Split(INI.WertLesen("ruleset", "Rule" & CStr(ruleindex)), "##-##")

                        If rule.Length > 0 Then
                            If input IsNot Nothing Then
                                If input.Contains(rule(0).ToLower) AndAlso rule(2) = whereto Then
                                    input = Replace(input, rule(0).ToLower, rule(1))
                                End If

                                If input.Contains(rule(0)) AndAlso rule(2) = whereto Then
                                    input = Replace(input, rule(0), rule(1))
                                End If

                                If input.Contains(rule(0).ToUpper) AndAlso rule(2) = whereto Then
                                    input = Replace(input, rule(0).ToUpper, rule(1))
                                End If
                            Else
                                input = ""
                                Exit For
                            End If
                        End If
                    Next
                End SyncLock
            End If

            If input.EndsWith("(") AndAlso Not input.Contains(")") Then
                input = Replace(input, "(", "")
            End If

            If input.EndsWith(")") AndAlso Not input.Contains("(") Then
                input = Replace(input, ")", "")
            End If

            Return Trim(Replace(input, "  ", " "))
        Else
            Return ""
        End If
    End Function

    Public Sub training()
        Dim _path As String = Main.Collections.Aktuelle_Sammlung.Path

        If Not Directory.Exists(_path) = True Then
            Dim fbd As New FolderBrowserDialog

            With fbd
                .Description = "Verzeichnis eines Bestandes zum lernen angeben!"
                .ShowNewFolderButton = False

                If .ShowDialog = DialogResult.OK Then
                    If System.IO.Directory.Exists(fbd.SelectedPath) Then
                        If fbd.SelectedPath.EndsWith("\") Then
                            _path = fbd.SelectedPath
                        Else
                            _path = fbd.SelectedPath & "\"
                        End If
                    End If
                End If
            End With
        End If

        Dim _dirinfo As New DirectoryInfo(_path)
        Dim _tmp As String
        Dim _strpos As Integer = 0

        SyncLock Main.lock
            For Each fil As FileInfo In _dirinfo.GetFiles("*.mp3", SearchOption.AllDirectories)
                If fil.Exists = True Then
                    If fil.Name.Contains("-") Then
                        _tmp = Trim(replacechars(Mid(fil.Name, 1, fil.Name.LastIndexOf("-")), "Target-Filename"))

                        If _tmp.Length > 1 AndAlso _tmp.Length > 2 AndAlso _tmp.ToLower <> "unbekannt" AndAlso _tmp.ToLower <> "various artists" Then
                            If Not settings.artist_pattern_list.Items.Contains(_tmp) Then
                                settings.artist_pattern_list.Items.Add(_tmp)
                            End If
                        End If
                    End If
                End If
            Next
        End SyncLock

        If settings.artist_pattern_list.Items.Count > 0 Then
            MsgBox("Es wurden " & settings.artist_pattern_list.Items.Count & " Interpreten erkannt, überprüfen sie die Liste, auf eventuelle falsche Einträge!", MsgBoxStyle.Information)
        End If
    End Sub
End Class
