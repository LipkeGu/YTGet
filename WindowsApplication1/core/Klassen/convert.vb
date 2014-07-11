Imports System.Diagnostics
Imports System.IO
Imports System.Threading

Public Class convert
    Dim _CleanReplace As New CleanReplace
    Public konverter_path As String = My.Application.Info.DirectoryPath & "\tools\ffmpeg.exe"

    Public Sub convertToMP3(ByVal source As String, ByVal target As String, ByVal ab As String, ByVal DL_entryID As String)
        If System.IO.File.Exists(target) Then
            System.IO.File.Delete(target)
        End If

        Dim pargs As String = ""

        target = _CleanReplace.replacechars(target, "Target-Filename")
        source = Replace(source, "  ", " ")

        If Main.forcedb_normalize Then
            pargs = "-i " & Chr(34) & source & Chr(34) & " -vol 89 -ar " & Main.MP3_samprate & " -ab " & ab & "k " & Chr(34) & target & Chr(34) & "#" & DL_entryID
        Else
            pargs = "-i " & Chr(34) & source & Chr(34) & " -ar " & Main.MP3_samprate & " -ab " & ab & "k " & Chr(34) & target & Chr(34) & "#" & DL_entryID
        End If

        Download_Manager.DL_Listview.Items.Item(CInt(DL_entryID)).SubItems(3).Text = "Fertig"
        
        Dim t As New Thread(AddressOf convert_dowork)

        With t
            .IsBackground = True
            .Start(CObj(pargs))
        End With
    End Sub

    Private Sub convert_dowork(ByVal e As Object)
        Dim Arguments() As String = CType(e, String).Split(CChar("#"))
        Dim entryID As Integer = CInt(Arguments(1).ToString)

        Try
            Dim p As New Process

            With p
                .StartInfo.FileName = konverter_path
                .StartInfo.Arguments = Arguments(0)
                .StartInfo.UseShellExecute = False
                .StartInfo.CreateNoWindow = False

                .Start()
                .WaitForExit()
                .Dispose()
            End With
        Catch ex As Exception
            MsgBox(Main.converter.konverter_path & " : " & ex.Message, MsgBoxStyle.Critical, Main.Text)
        End Try

    End Sub

End Class
