Imports System.IO
Imports System.Security.Cryptography


Public Class YTFileIO
    Public Event Exception(ByVal Message As String)

    Public Function TestFileName(ByVal FileName As String) As String
        If FileName.Length > 0 Then
            Dim TargetExist As Boolean = False
            Dim _tmp As String = Replace(FileName, ".mp3", "")

            If File.Exists(FileName) Then
				If File.Exists(_tmp) Then
					TargetExist = True
				End If

                If TargetExist = True Then
                    For i As Integer = 1 To 999 Step 1
                        FileName = Trim(Replace(Replace(FileName & " (" & i & ")", " (" & i & ")", ""), ".mp3", "") & " (" & i + 1 & ").mp3")

                        If Not File.Exists(FileName) Then
                            _tmp = FileName
                            Exit For
                        End If
                    Next
                End If

                Return _tmp
            Else
                Return FileName
            End If
        End If
    End Function

    Public Function Copy(ByVal Source As String, ByVal target As String, Optional ByVal overwrite As Boolean = False) As Boolean
        Try
            Dim _src As String = ""
            Dim _tar As String = ""

            If Source.Length > 1 AndAlso target.Length > 1 Then
                _tar = target
                _src = Source

                File.Copy(_src, TestFileName(_tar), overwrite)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Move(ByVal Source As String, ByVal target As String, Optional ByVal overwrite As Boolean = False) As Boolean
        Dim _src As String = ""
        Dim _tar As String = ""
        Try
            If Source.Length > 1 AndAlso target.Length > 1 Then
                _src = Source
                _tar = target

                If Not _src = _tar Then
                    File.Move(_src, TestFileName(_tar))
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Main.Eventlog.AddEvent("FileIO", EventType.Exception, ex.Message)
            Return False
        End Try

    End Function

    Public Function File_Delete(ByVal path As String) As Boolean
        Dim _file As String = ""

        Try
            If path.Length > 2 Then
                If File.Exists(path) Then
                    _file = path
                    File.Delete(_file)
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function MD5FileHash(ByVal sFile As String) As String
        Dim MD5 As New MD5CryptoServiceProvider
        Dim Hash As Byte()
        Dim Result As String = ""
        Dim Tmp As String = ""

		Try
			Dim FN As New FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
			MD5.ComputeHash(FN)
			FN.Close()

			Hash = MD5.Hash

			For i As Integer = 0 To Hash.Length - 1
				Tmp = Hex(Hash(i))
				If Len(Tmp) = 1 Then Tmp = "0" & Tmp
				Result += Tmp
			Next

			Return Result
		Catch ex As Exception
			Return Result
		End Try

    End Function

    Public Function write(ByVal path As String, ByVal _line As String, Optional append As Boolean = True) As Boolean
        If File.Exists(path) Then
            append = True
        Else
            append = False
        End If

        If _line IsNot Nothing Then

            If _line.Length > 0 Then
                Try
                    Dim sw1 As New StreamWriter(path, append)

                    With sw1
                        .AutoFlush = True
                        .WriteLine(_line)
						.Close()
						.Dispose()
                        Return True
                    End With
                Catch ex As Exception
                    RaiseEvent Exception(ex.Message)
                    Return False
                End Try
            End If
        End If
    End Function

    Public Function GetFileCount(ByVal path As String, Optional Mask As String = "*.mp3", Optional Options As SearchOption = SearchOption.TopDirectoryOnly) As Integer
        If path.Length > 1 Then
            If Directory.Exists(path) Then
                Dim _dirinfo As New DirectoryInfo(path)
                Dim i As Integer = 0

                For Each fil As FileInfo In _dirinfo.GetFiles(Mask, Options)
                    If fil.Exists = True AndAlso fil.Length > 0 Then
                        i = i + 1
                    End If
                Next

                Return i
            End If
        End If
    End Function
End Class
