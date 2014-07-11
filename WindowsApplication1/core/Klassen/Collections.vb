Imports System.IO

Public Class Collections
    Public Collections As New List(Of Collection)

    Private _ref As Collection = Nothing

    Public Property Aktuelle_Sammlung As Collection
        Get
            Return _ref
        End Get
        Set(value As Collection)
            _ref = value
        End Set
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return Collections.Count
        End Get
    End Property

    Public Sub Load_collections()
        Try
            If File.Exists(Main.path_to_config) Then
                Main.INIDatei.Pfad = Main.path_to_config

                Dim rulecount As Integer = 0
                Dim rule() As String

                rulecount = CInt(Main.INIDatei.WertLesen("info", "col_count"))

                If rulecount > 0 Then
                    Collections.Clear()

                    SyncLock Main.lock
                        For ruleindex As Integer = 0 To rulecount - 1
                            rule = Split(Main.INIDatei.WertLesen("collections", "collection" & CStr(ruleindex)), "##-##")

                            If rule(0) <> "" And rule(2) <> "" Then
                                If rule(1) Is Nothing Then rule(1) = ""
                                Add(rule(1))
                            End If
                        Next
                    End SyncLock
                End If
            Else
                Save_Collections()
                Load_collections()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Save_Collections()
        If File.Exists(Main.path_to_config) Then
            Main.INIDatei.SektionLöschen("collections")
            Main.INIDatei.WertSchreiben("info", "col_count", CStr(Collections.Count))

            SyncLock Main.lock
                For i As Integer = 0 To Collections.Count - 1
                    Main.INIDatei.WertSchreiben("collections", "collection" & i, Collections.Item(i).Name & "##-##" & Collections.Item(i).Path & "##-##" & Collections.Item(i).Type)
                Next
            End SyncLock
        End If
    End Sub

    Public Sub Add()
        Dim ofd As New FolderBrowserDialog

        With ofd
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
            .Description = "Wählen sie einen Ort für die neue Sammlung aus oder wählen sie eine bestehende Sammlung aus!"
        End With

        If ofd.ShowDialog = DialogResult.OK Then
            If Directory.Exists(ofd.SelectedPath) = True Then
                Dim _path As String = ""


                If ofd.SelectedPath.EndsWith("\") Then
                    _path = ofd.SelectedPath
                Else
                    _path = ofd.SelectedPath & "\"
                End If

                Dim _Name As String = InputBox("Der Collection einen Namen geben!", "Name für die Collection!", "Meine Collection " & Collections.Count.ToString)
                Dim _already_in_list As Boolean = False

                SyncLock Main.lock
                    For Each c As Collection In Collections
                        If c.Path.ToLower.Contains(_path.ToLower) Then
                            _already_in_list = True
                        End If
                    Next
                End SyncLock

                If _already_in_list = False Then
                    Dim col As New Collection(_path, "audio", _Name)

                    With Main
                        Collections.Add(col)

                        If Not .Speicherort.Items.ToString.ToLower.Contains(col.Path.ToLower) Then
                            If Collections.Count < 2 Then
                                .Speicherort.Items.Add(col.Path)
                                .Speicherort.Text = col.Path
                                Aktuelle_Sammlung = col
                            Else
                                If Not .Speicherort.Items.ToString.ToLower.Contains(col.Path.ToLower) Then
                                    .Speicherort.Items.Add(col.Path)
                                End If
                            End If

                            If Not settings.Collection_list.Items.Contains(col.Path) Then
                                settings.Collection_list.Items.Add(col.Path)
                            End If

                            Main.Menu_collections_oeffnen.Enabled = True
                            Main.ImportierenToolStripMenuItem.Enabled = True
                        End If
                    End With

                    If col.Einträge > 0 Then
                        MsgBox("Speicherort """ & col.Name & """ wurde erfolgreich hinzugefügt und enthält " & col.Einträge.ToString & " Dateien!", MsgBoxStyle.Information)
                    Else
                        MsgBox("Speicherort """ & col.Name & """ wurde erfolgreich angelegt!", MsgBoxStyle.Information)
                    End If

                Else
                    MsgBox("Dieser Speicherort darf nicht Teil einer anderen Collection sein!", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Public Sub Add(ByVal path As String)
        If Directory.Exists(path) = True Then
            Dim _path As String = ""

            If path.EndsWith("\") Then
                _path = path
            Else
                _path = path & "\"
            End If

            Dim _already_in_list As Boolean = False
            SyncLock Main.lock
                For Each c As Collection In Collections
                    If c.Path.ToLower.Contains(path.ToLower) Then
                        _already_in_list = True
                    End If
                Next
            End SyncLock

            If _already_in_list = False Then
                Dim col As New Collection(_path, "audio", "Meine Collection " & Collections.Count.ToString)

                Collections.Add(col)

                With Main
                    If Not .Speicherort.Items.ToString.ToLower.Contains(col.Path.ToLower) Then
                        If Collections.Count < 2 Then
                            .Speicherort.Items.Add(col.Path)
                            .Speicherort.Text = col.Path
                            _ref = col
                        Else
                            If Not .Speicherort.Items.ToString.ToLower.Contains(col.Path.ToLower) Then
                                .Speicherort.Items.Add(col.Path)
                            End If
                        End If

                        If Not settings.Collection_list.Items.Contains(col.Path) Then
                            settings.Collection_list.Items.Add(col.Path)
                        End If
                    End If
                End With
            End If
        End If
    End Sub

    Public Sub Remove(ByVal col As Collection)
        SyncLock Main.lock
            If col.Path = settings.Collection_list.SelectedItem.ToString Then
                For Each entry As String In Main.Speicherort.Items
                    If entry.ToString = col.Path Then
                        Main.Speicherort.Items.Remove(entry)
                        Exit For
                    End If
                Next

                For Each entry As String In settings.Collection_list.Items
                    If entry.ToString = col.Path Then
                        settings.Collection_list.Items.Remove(entry)
                        Exit For
                    End If
                Next

                MsgBox(col.Name & " wurde entfernt!", MsgBoxStyle.Information)

                Collections.Remove(col)
            End If
        End SyncLock
    End Sub

    Public Sub Remove(ByVal path As String)
        SyncLock Main.lock
            For Each col As Collection In Collections
                If col.Path = path Then
                    For Each entry As String In settings.Collection_list.Items
                        If entry.ToString = col.Path Then
                            settings.Collection_list.Items.Remove(entry)
                            Exit For
                        End If
                    Next

                    For Each entry As String In Main.Speicherort.Items
                        If entry.ToString = col.Path Then
                            Main.Speicherort.Items.Remove(entry)
                            Exit For
                        End If
                    Next

                    MsgBox(col.Name & " wurde entfernt!", MsgBoxStyle.Information)
                    Collections.Remove(col)
                    Exit For
                End If
            Next
        End SyncLock
    End Sub

    Public Sub Remove()
        SyncLock Main.lock
            For Each col As Collection In Collections
                If col.Path = settings.Collection_list.SelectedItem.ToString Then
                    For Each entry As String In settings.Collection_list.Items
                        If settings.Collection_list.SelectedItem.ToString = entry.ToString Then
                            settings.Collection_list.Items.Remove(entry)
                            Exit For
                        End If
                    Next

                    For Each entry As String In Main.Speicherort.Items
                        If entry.ToString = col.Path Then
                            Main.Speicherort.Items.Remove(entry)
                            Exit For
                        End If
                    Next

                    MsgBox(col.Name & " wurde entfernt!", MsgBoxStyle.Information)
                    Collections.Remove(col)
                    Exit For
                End If
            Next
        End SyncLock
    End Sub

    Public Sub Bestandslisteerstellen()
        Dim dirinfo As New DirectoryInfo(Main.Collections.Aktuelle_Sammlung.Path)
        Dim sw1 As New StreamWriter(Main.Application_Directory & "\bestand.txt")

        If Directory.Exists(Main.Collections.Aktuelle_Sammlung.Path) Then
            sw1.WriteLine("Bestand von: " & Main.Collections.Aktuelle_Sammlung.Path & vbCrLf & vbCrLf)
            For Each Fil As FileInfo In dirinfo.GetFiles("*.mp3", SearchOption.AllDirectories)
                If Fil.Exists Then
                    sw1.WriteLine(Fil.FullName)
                End If
            Next

            sw1.Close()
            MsgBox("Bestand erstellt!", MsgBoxStyle.Information)
        End If

        Dim p As New Process
        With p
            .StartInfo.FileName = Main.Application_Directory & "\bestand.txt"
            .Start()
        End With
    End Sub

End Class

Public Class Collection
    Private _path As String = ""
    Private _type As String = ""
    Private _count As Integer = 0
    Private _valid As Boolean = False
    Private _Name As String = ""

    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property

    Public ReadOnly Property Type As String
        Get
            Return _type
        End Get
    End Property

    Public ReadOnly Property Path As String
        Get
            Return _path
        End Get
    End Property

    Public ReadOnly Property Einträge As Integer
        Get
            Return _count
        End Get
    End Property

    Sub New(ByVal path As String, ByVal type As String, ByVal Name As String)
        If Directory.Exists(path) Then
            _path = path

            _Name = Name

            If type = "audio" Or type = "video" Then
                _type = type
            Else
                _type = "audio"
            End If

            If _type = "audio" Then
                Dim dirinfo As New DirectoryInfo(_path)
                SyncLock Main.lock
                    For Each fil As FileInfo In dirinfo.GetFiles("*.mp3", SearchOption.AllDirectories)
                        If fil.Exists = True Then
                            _count = _count + 1
                        End If
                    Next
                End SyncLock
                _valid = True
            End If
        End If
    End Sub
End Class
