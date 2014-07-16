Imports System.IO
Imports System.Threading
Imports System.Security.Cryptography
Imports System.Text

Public Class MediaImporter
    Private Event C(ByVal count As Integer)
    Public Event Completed(ByVal filcount As Integer)
    Public Event started(ByVal filecount As Integer)
    Dim target As String = ""
    Public Event ProvessChanged(ByVal f As String, ByVal count As Integer, type As Integer)
    Public Event Exception(ex As String, ByVal type As Integer)
    Public filestoread As Integer = 0
    Public ignoreprotectedfiles As Boolean = True
    Public filestoimport As New List(Of MP3File)

    Sub start(ByVal path As String)
        If Directory.Exists(path) Then
            target = path
            filestoimport.Clear()

            Dim t As New Thread(AddressOf GetFiles)
            t.IsBackground = True
            t.Start(CObj(target))
        Else
            Throw New DirectoryNotFoundException
        End If
    End Sub

    Private Sub GetFiles(ByVal _path As Object)
        If filestoread > 0 Then
            RaiseEvent started(filestoread)
        End If

        Dim _dirinfo As New DirectoryInfo(CType(_path, String))
        SyncLock Main.lock
            For Each fil As FileInfo In _dirinfo.GetFiles("*.mp3", SearchOption.AllDirectories)
                'Try
                If fil.Exists = True AndAlso fil.Length > 0 Then
                    Dim fn_parts() As String
                    Dim _strpos As Integer = 0
                    Dim Artist As String = ""
                    Dim Title As String

                    If fil.Name.Contains("-") Then
                        fn_parts = fil.Name.Split(CChar("-"))
                        _strpos = fil.Name.ToLower.IndexOf("-") + 1

                        If fn_parts.Length > 1 Then ' wir haben Artist und titel...
                            If fn_parts.Length > 2 Then ' moment da war noch 1 "-"...
                                If _strpos < 3 AndAlso fil.Name.ToLower.LastIndexOf("-") > 2 Then
                                    fn_parts(0) = Trim(fn_parts(0)) & " - " & Trim(fn_parts(1))

                                    fn_parts(1) = ""

                                    For ia As Integer = 2 To fn_parts.Length - 1 Step 1
                                        If Not fn_parts(1) = "" Then
                                            fn_parts(1) = Trim(fn_parts(1)) & " - " & Trim(fn_parts(ia))
                                        Else
                                            fn_parts(1) = Trim(fn_parts(1)) & Trim(fn_parts(ia))
                                        End If
                                    Next
                                End If
                            Else
                                fn_parts(0) = Trim(Mid(fil.Name, 1, fil.Name.IndexOf("-")))
                            End If

                            For ia As Integer = 2 To fn_parts.Length - 1 Step 1
                                If Not fn_parts(1) = "" Then
                                    fn_parts(1) = Trim(fn_parts(1)) & " - " & Trim(fn_parts(ia))
                                Else
                                    fn_parts(1) = Trim(fn_parts(1)) & Trim(fn_parts(ia))
                                End If
                            Next
                        End If

                        For i As Integer = 0 To fn_parts.Length - 1 Step 1
                            fn_parts(i) = Trim(Replace(fn_parts(i), fil.Extension, ""))

                            If fn_parts(i).EndsWith("-") Then
                                fn_parts(i) = Trim(Mid(fn_parts(i), 1, fn_parts(i).Length - 1))
                            End If

                            If i > 0 Then
                                fn_parts(i) = Replace(fn_parts(i), fn_parts(0) & " - ", "")
                                fn_parts(i) = Replace(fn_parts(i), fil.Extension, "")
                            End If
                        Next

                        Artist = fn_parts(0)
                        Title = fn_parts(1)
                    Else
                        Artist = "Unbekannt - "
                        Title = fil.Name
                    End If

                    Dim mp3 As New MP3File(Artist, Title, fil.FullName, Math.Round(fil.Length / 1024 / 1024, 2).ToString & " MB", False, target)


                    If mp3 IsNot Nothing Then
                        RaiseEvent ProvessChanged(fil.FullName, filestoimport.Count, 1)

                        If mp3.BadHeader = True Then
                            RaiseEvent Exception(mp3.Exception, 3)
                            mp3.selected = False
                        End If

                        filestoimport.Add(mp3)
                        If filestoimport.Count = filestoread Then Exit For
                    End If
                End If
                ' Catch ex As Exception
                '    
                'End Try
            Next
        End SyncLock
        RaiseEvent C(filestoimport.Count)
    End Sub ' Dateien ansich einlesen...

    Private Sub MediaImporter_Completed(count As Integer) Handles Me.C
        Dim _duplicate As Boolean = False
        Dim _duplicates As Integer = 0
        Dim cr As New CleanReplace
        SyncLock Main.lock
            For i1 As Integer = filestoimport.Count - 1 To 0 Step -1
                With filestoimport
                    .Item(i1).Artist = Trim(cr.replacechars(.Item(i1).Artist, "Name", False))
                    .Item(i1).Title = Trim(cr.replacechars(.Item(i1).Title, "Name", False))

                    For i2 As Integer = filestoimport.Count - 1 To 0 Step -1
                        If i1 <> i2 Then
                            If .Item(i1).Checksum = .Item(i2).Checksum Then
                                .Item(i1).MD5Duplicate = True
                            Else
                                If .Item(i2).Artist.ToLower = .Item(i1).Artist.ToLower AndAlso .Item(i2).Title.ToLower = .Item(i1).Title.ToLower Then
                                    .Item(i1).Duplicate = True
                                    .Item(i1).selected = False
                                    _duplicates = _duplicates + 1
                                End If

                                If .Item(i1).targetfilename.ToLower = .Item(i2).targetfilename.ToLower Then
                                    .Item(i1).Duplicate = True
                                    .Item(i1).selected = False
                                    _duplicates = _duplicates + 1
                                End If

                                If .Item(i1).Artist.ToLower.Contains(.Item(i2).Artist.ToLower) AndAlso .Item(i1).Duration = .Item(i2).Duration AndAlso .Item(i1).Bitrate = .Item(i2).Bitrate Then
                                    .Item(i1).Duplicate = True
                                    .Item(i1).selected = False
                                    _duplicates = _duplicates + 1
                                End If

                                If .Item(i1).Title.ToLower.Contains(.Item(i2).Title.ToLower) AndAlso .Item(i1).Duration = .Item(i2).Duration AndAlso .Item(i1).Bitrate = .Item(i2).Bitrate Then
                                    .Item(i1).Duplicate = True
                                    .Item(i1).selected = False
                                    _duplicates = _duplicates + 1
                                End If

                                If .Item(i1).Duration = .Item(i2).Duration AndAlso .Item(i1).Bitrate = .Item(i2).Bitrate Then
                                    If .Item(i1).Artist.Length < .Item(i2).Artist.Length Then
                                        If .Item(i2).Artist.ToLower.Contains(.Item(i1).Artist.ToLower) Then
                                            .Item(i1).Duplicate = True
                                        End If

                                        If .Item(i1).Artist.ToLower.Contains(.Item(i2).Artist.ToLower) Then
                                            .Item(i1).Duplicate = True
                                        End If
                                    End If

                                    If .Item(i1).Artist.Length > .Item(i2).Artist.Length Then
                                        If .Item(i2).Artist.ToLower.Contains(.Item(i1).Artist.ToLower) Then
                                            .Item(i1).Duplicate = True
                                        End If

                                        If .Item(i1).Artist.ToLower.Contains(.Item(i2).Artist.ToLower) Then
                                            .Item(i1).Duplicate = True
                                        End If
                                    End If
                                End If
                            End If
                            Exit For
                        End If
                    Next

                    If i1 < filestoimport.Count AndAlso i1 > -1 Then
                        If .Contains(.Item(i1)) Then
                            If File.Exists(.Item(i1).targetfilename) Then
                                If .Item(i1).Checksum = Main.FileIO.MD5FileHash(.Item(i1).targetfilename) = True Then
                                    .Item(i1).MD5Duplicate = True
                                End If
                                .Item(i1).Duplicate = True
                            End If


                            If .Item(i1).MD5Duplicate = True Then
                                filestoimport.Remove(.Item(i1))
                            End If
                        End If
                    End If
                End With
            Next
        End SyncLock
        filestoread = 0
        RaiseEvent Completed(filestoimport.Count)
    End Sub
End Class

