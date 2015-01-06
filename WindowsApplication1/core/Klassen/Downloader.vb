Imports System.Net
Imports System.IO

Class Downloads

#Region "Interne-Deklarationen"

    Dim _cleanreplace As New CleanReplace
    Dim lock As New Object

    Public Event Download_Fertig(ByVal ref As Download)
    Public Event Download_Abgebrochen(ByVal ref As Download)
    Public Event Download_Fortschritt(ByVal Percent As Integer, ByVal current_bytes As Integer, ByVal total_bytes As Integer, ByVal ref As Download)
    Public Event Download_begonnen(ByVal ref As Download)

    Public Current_Downloads As New List(Of Download)


    Public ReadOnly Property Aktelle_Downloads As Integer
        Get
            Return Current_Downloads.Count
        End Get
    End Property

    Private ReadOnly Property Max_Downloads As Integer
        Get
            Return Main.max_Downloads
        End Get
    End Property

#End Region

    Public Sub Add_Download(ByVal source As String, ByVal target As String, ByVal identifider As Integer)

		SyncLock lock
			Dim dl As New Download(source, target, identifider)

			With dl
				._reference = dl
				AddHandler .Download_started, AddressOf Begonnen
				AddHandler .Download_completed, AddressOf Fertig
				AddHandler .Download_Process_changed, AddressOf Fortschritt
			End With

			Current_Downloads.Add(dl)
			Main.Eventlog.AddEvent("Download-Manager", EventType.information, "Download hinzugefügt!")
		End SyncLock
    End Sub

    Public Sub Cancel()
		For i As Integer = Current_Downloads.Count - 1 To 0
			Try
				If Current_Downloads.Item(i) IsNot Nothing Then
					If Current_Downloads.Item(i).Fertig = False Then
						Current_Downloads.Item(i).Cancel_Download()

						If File.Exists(Current_Downloads.Item(i).Ziel) Then
							File.Delete(Current_Downloads.Item(i).Ziel)
							Remove(Current_Downloads.Item(i))
						End If

						Exit For
					End If
				End If
			Catch ex As Exception

			End Try
		Next

    End Sub

    Public Sub Cancel(ByVal id As Integer)
        For i As Integer = Current_Downloads.Count - 1 To 0 Step 1
            If Current_Downloads.Item(i) IsNot Nothing Then
                If i = Current_Downloads.Item(i).Id Then
                    Current_Downloads.Item(i).Cancel_Download()
                    Exit For
                End If
            End If
        Next
    End Sub


#Region "Events"
    Private Sub Fertig(ref As Download)
        If ref.canceled = False Then
            Dim target As String = ""
            Dim dirmask As String = ""

            If Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(0).Text.Contains("-") Then
                dirmask = _cleanreplace.replacechars(Trim(Mid(Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(0).Text, 1, Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(0).Text.LastIndexOf("-"))), "Target-Directory")
            End If

            If Not Directory.Exists(Main.Collections.Aktuelle_Sammlung.Path & dirmask) Then
                Directory.CreateDirectory(Main.Collections.Aktuelle_Sammlung.Path & dirmask)
            End If

            target = Main.Collections.Aktuelle_Sammlung.Path & dirmask & "\" & Main.FileIO.TestFileName(Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(0).Text & ".mp3")

            If File.Exists(ref.Ziel) Then
                If ref.Ziel.Contains(".mp4") Or ref.Ziel.Contains(".flv") AndAlso File.Exists(Main.converter.konverter_path) Then
                    Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(3).Text = "Konvertiere"
					Download_Manager.converter.convertToMP3(ref.Ziel, target, Main.MP3_Bitrate, ref.Id)
                End If

                RaiseEvent Download_Fertig(ref)
                Main.Eventlog.AddEvent("Download-Manager", EventType.information, "Die Datei wurde erfolgreich Heruntergeladen!")
            Else
                Main.Eventlog.AddEvent("Download-Manager", EventType.Exception, "Datei " & Chr(34) & ref.Ziel & Chr(34) & " wurde nicht gefunden!")
                RaiseEvent Download_Abgebrochen(ref)
            End If

            Download_Manager.cancel_all_downloads.Enabled = False
            Download_Manager.download.Enabled = True

			Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(3).Text = "Fertig"
			Current_Downloads.Remove(ref)
        End If

        Main.canceling = False
        Remove(ref)
    End Sub

    Private Sub Fortschritt(Percent As Integer, current_bytes As Integer, total_bytes As Integer, ref As Download)
        If ref.canceled = False Then
            RaiseEvent Download_Fortschritt(Percent, current_bytes, total_bytes, ref)
        End If
    End Sub

    Private Sub Begonnen(ref As Download)
        Main.Eventlog.AddEvent("Download-Manager", EventType.information, "Download gestartet!")
        Main.canceling = True
        RaiseEvent Download_begonnen(ref)
    End Sub

    Public Sub Remove(ByVal id As Integer)
        SyncLock lock
            For i As Integer = Current_Downloads.Count - 1 To 0 Step 1
                If Current_Downloads.Item(i).Id = id Then
                    Current_Downloads.Item(i).Webclient.Dispose()
                    Current_Downloads.Remove(Current_Downloads.Item(i))
                    Main.Eventlog.AddEvent("Download", EventType.information, "Download beendet!")
                    Exit For
                End If
            Next
        End SyncLock
    End Sub

    Public Sub Remove(ByVal ref As Download)
        SyncLock lock
            If Current_Downloads.Count > 0 Then
                If ref IsNot Nothing Then
                    If ref.Webclient IsNot Nothing Then
                        ref.Webclient.Dispose()
                        ref = Nothing
                    End If

                    Current_Downloads.Remove(ref)
                    Main.Eventlog.AddEvent("Download", EventType.information, "Download entfernt!")
                End If
            End If
        End SyncLock
    End Sub
#End Region
End Class

Class Download

#Region "Interne-Deklarationen"
    Public Event Download_completed(ByVal ref As Download)
    Public Event Download_Aborted(ByVal ref As Download)
    Public Event Download_Process_changed(ByVal Percent As Integer, ByVal current_bytes As Integer, ByVal total_bytes As Integer, ByVal ref As Download)
    Public Event Download_started(ByVal ref As Download)
    Public Event Download_Errormsg(ByVal Message As String, ByVal ref As Download)

    Private WithEvents _webclient As New WebClient
    Private _errormsg As String = ""
    Private _aborted As Boolean = False
    Private _finisch As Boolean = False
    Private _source As String = ""
    Private _identifider As Integer = 0
    Private _target As String = ""
    Private _bytes_received As Integer = 0
    Private _total_bytes As Integer = 0
    Private _percentage_completed As Integer = 0
    Public _reference As Download = Nothing
    Private _content_type As String = ""


    Public ReadOnly Property Webclient As WebClient
        Get
            Return _webclient
        End Get
    End Property

    Public ReadOnly Property Ziel As String
        Get
            Return _target
        End Get
    End Property

    Public ReadOnly Property Quelle As String
        Get
            Return _source
        End Get
    End Property

    Public ReadOnly Property Id As Integer
        Get
            Return _identifider
        End Get
    End Property

    Public ReadOnly Property Fertig As Boolean
        Get
            Return _finisch
        End Get
    End Property

    Public ReadOnly Property canceled As Boolean
        Get
            Return _aborted
        End Get
    End Property

#End Region

    Sub New(ByVal source As String, ByVal target As String, ByVal identifider As Integer)
        _finisch = False

        If source.Length > 10 Then
            _source = source
        End If

        If target.Length > 4 Then
            _target = target
        End If

        If identifider > -1 Then
            _identifider = identifider
        End If

        With _webclient
            AddHandler .DownloadFileCompleted, AddressOf _completed
            AddHandler .DownloadProgressChanged, AddressOf _changed

            .DownloadFileAsync(New Uri(_source), _target)
        End With

        RaiseEvent Download_started(_reference)

    End Sub

#Region "Events"
    Private Sub _changed(sender As Object, e As DownloadProgressChangedEventArgs)
        _finisch = False

        _total_bytes = CInt(e.TotalBytesToReceive)
        _bytes_received = CInt(e.BytesReceived)
        _percentage_completed = e.ProgressPercentage

        RaiseEvent Download_Process_changed(_percentage_completed, _bytes_received, _total_bytes, _reference)
    End Sub

    Private Sub _completed(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
        RaiseEvent Download_completed(_reference)
    End Sub

    Public Sub Cancel_Download()
        _aborted = True
        _webclient.CancelAsync()
        _webclient.Dispose()
        _webclient = Nothing
        Main.Eventlog.AddEvent("Download-Manager", EventType.information, "Download beendet!")
    End Sub
#End Region

End Class
