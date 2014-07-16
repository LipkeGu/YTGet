Imports System.IO

Public Enum EventType As Integer
    Debug = 0
    information = 1
    Warning = 2
    Exception = 3
End Enum

Public Class EventLog
    Public Event GotEvent(ByVal src As String, ByVal type As String, ByVal Message As String, ByVal type_numeric As EventType)

    Public Sub AddEvent(src As String, type As EventType, Message As String)
        Dim _type As String = ""

        Select Case type
            Case EventType.Debug
                _type = "Debug"
            Case EventType.information
                _type = "Info"
            Case EventType.Warning
                _type = "Warn"
            Case EventType.Exception
                _type = "Error"
        End Select

        RaiseEvent GotEvent(src, _type, Message, type)
    End Sub
End Class

