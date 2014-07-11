Imports System.IO
Imports System.Security.Cryptography


Public Class YTFileIO

    Public Function Copy(ByVal Source As String, ByVal target As String, Optional ByVal overwrite As Boolean = False) As Boolean
        Dim _src As String = ""
        Dim _tar As String = ""

        Try
            If Source.Length > 1 AndAlso target.Length > 1 Then

                If File.Exists(Source) Then
                    _src = Source
                Else
                    Throw New Exception("")
                End If

                _tar = target

                If Not _src = _tar Then
                    File.Copy(_src, _tar, overwrite)
                    Return True
                Else
                    Throw New Exception("")
                End If
            Else
                Throw New Exception("")
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

                If File.Exists(Source) Then
                    _src = Source
                Else
                    Throw New Exception("")
                End If

                _tar = target

                If Not _src = _tar Then
                    File.Move(_src, _tar)
                    Return True
                Else
                    Throw New Exception("")
                End If
            Else
                Throw New Exception("")
            End If
        Catch ex As Exception
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
    End Function
End Class
