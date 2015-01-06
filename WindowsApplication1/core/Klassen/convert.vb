Imports System.Diagnostics
Imports System.IO
Imports System.Threading
Imports System.Text
Public Class convert
    Dim _CleanReplace As New CleanReplace
    Public konverter_path As String = My.Application.Info.DirectoryPath & "\tools\ffmpeg.exe"
    Public Event GetDuration(ByVal duration As String, ByVal id As Integer)
    Public Event Position(ByVal position As String, ByVal id As Integer)
    Public Event Completed(ByVal id As Integer)

	Public Function convertToMP3(ByVal source As String, ByVal target As String, ByVal ab As Integer, Optional DL_entryID As Integer = -1) As Integer
		If File.Exists(konverter_path) Then
			Dim pargs As String = ""
			target = _CleanReplace.replacechars(target, "Target-Filename")

			If System.IO.File.Exists(target) Then
				Main.Eventlog.AddEvent("Konverter", EventType.Warning, "Die Ziel-Datei " & Chr(34) & target & Chr(34) & " ist bereits vorhanden!")
				System.IO.File.Delete(target)
				Main.Eventlog.AddEvent("Konverter", EventType.information, "Die Ziel-Datei " & Chr(34) & target & Chr(34) & " wurde gelöscht!")
			End If

			source = Replace(source, "  ", " ")

			If Main.forcedb_normalize Then
				pargs = "-i " & Chr(34) & source & Chr(34) & " -vol " & Main.audio_volume & " -ar " & Main.MP3_samprate & " -ab " & CStr(Main.MP3_Bitrate) & "k " & Chr(34) & target & Chr(34) & "#" & CStr(DL_entryID)
			Else
				pargs = "-i " & Chr(34) & source & Chr(34) & " -ar " & Main.MP3_samprate & " -ab " & CStr(Main.MP3_Bitrate) & "k " & Chr(34) & target & Chr(34) & "#" & CStr(DL_entryID)
			End If

			Dim t As New Thread(AddressOf convert_dowork)
			Main.Eventlog.AddEvent("Konverter", EventType.information, "Datei wird konvertiert... Parameter: " & pargs)
			With t
				.IsBackground = True
				.Start(CObj(pargs))
			End With

			Return 0
		Else
			Main.Eventlog.AddEvent("Konverter", EventType.Exception, "Die Datei " & Chr(34) & konverter_path & Chr(34) & " ist nicht vorhanden!!")
			RaiseEvent Completed(DL_entryID)

			Return 1
		End If
	End Function

    Private Sub convert_dowork(ByVal e As Object)
        Dim Arguments() As String = CType(e, String).Split(CChar("#"))
        Dim entryID As Integer = CInt(Arguments(1).ToString)

        If File.Exists(konverter_path) Then
            Dim p As New Process
            Dim _max_duration As String = ""
            Dim position As String = ""
            Dim _tmp() As String
            Dim d As Date
            Dim Ts As TimeSpan

            With p
                .StartInfo.FileName = konverter_path
                .StartInfo.Arguments = Trim(Arguments(0))
                .StartInfo.UseShellExecute = False
                .StartInfo.CreateNoWindow = True
                .StartInfo.RedirectStandardError = True
                Dim Process_msg_line As String = ""

				.Start()
				ImportTo_Collection.curconvert_count = 1
				ImportTo_Collection.weitergehts = False

                While .StandardError.EndOfStream = False
                    Process_msg_line = .StandardError.ReadLine

                    If Process_msg_line.Contains("Duration:") Then
                        'Maximale Dauer
                        d = System.Convert.ToDateTime(Trim(Replace(Mid(Process_msg_line, CStr("Duration:").Length + 3, Process_msg_line.IndexOf(".")), ", start:", "")))
                        Ts = New TimeSpan(0, d.Hour, d.Minute, d.Second, d.Millisecond)
                        _max_duration = CStr(CInt(Ts.TotalSeconds))
                        RaiseEvent GetDuration(_max_duration, CInt(Arguments(1)))
                    End If

                    'aktuelle position

                    If Process_msg_line.Contains("time=") Then
                        _tmp = Trim(Mid(Process_msg_line, Process_msg_line.IndexOf(CStr("time=")) + (CStr("time=").Length + 1), Process_msg_line.LastIndexOf("=") - CStr("bitrate").Length + 1)).Split(CChar("="))
                        d = System.Convert.ToDateTime(Trim(Replace(_tmp(0), " bitrate", "")))
                        Ts = New TimeSpan(0, d.Hour, d.Minute, d.Second, d.Millisecond)
                        position = CStr(CInt(Ts.TotalSeconds))
                        RaiseEvent Position(position, CInt(Arguments(1)))
                    End If
                End While

                .WaitForExit()
				.Dispose()

			End With
		End If
		ImportTo_Collection.curconvert_count = 0
		ImportTo_Collection.weitergehts = True
        RaiseEvent Completed(CInt(Arguments(1)))
    End Sub

End Class
