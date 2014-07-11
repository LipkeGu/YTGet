Imports System.IO

Public Class Errorhandler
    Public Event Show_Exception(ByVal ex_msg As String)

	Public Function dumpLineToFile(ByVal line As String, ByVal key As String, ByVal expression As String) As String
		Try
			Dim streamw As New StreamWriter("exception_" & My.Computer.Clock.LocalTime.Date.Day.ToString & "_" & My.Computer.Clock.LocalTime.Date.Hour.ToString & "_" & My.Computer.Clock.LocalTime.Date.Minute.ToString & "_" & key & ".txt", False)

			streamw.WriteLine(line)
			streamw.WriteLine(vbCrLf)
			streamw.WriteLine(expression)
			streamw.Flush()
			streamw.Close()

		Catch ex As Exception
            ShowError(ex.Message)
		End Try
	End Function


    Public Sub ShowError(ByVal exception As String) Handles Me.Show_Exception
        MsgBox(exception, MsgBoxStyle.Critical, Download_Manager.Text)
    End Sub
End Class
