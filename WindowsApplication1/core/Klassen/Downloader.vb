Imports System.Net
Imports System.IO

Class Downloads

#Region "Interne-Deklarationen"
    Dim converter As New convert
    Dim _cleanreplace As New CleanReplace
    Dim lock As New Object

    Public Event Download_Fertig(ByVal ref As Download)
    Public Event Download_Abgebrochen(ByVal ref As Download)
    Public Event Download_Fortschritt(ByVal Percent As Integer, ByVal current_bytes As Integer, ByVal total_bytes As Integer, ByVal ref As Download)
    Public Event Download_begonnen(ByVal ref As Download)

    Public Current_Downloads As New List(Of Download)
#End Region

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

    Public Sub Add_Download(ByVal source As String, ByVal target As String, ByVal identifider As Integer)
        If Current_Downloads.Count < Main.max_Downloads Then
            SyncLock lock
                Dim dl As New Download(source, target, identifider)

                With dl
                    ._reference = dl
                    AddHandler dl.Download_started, AddressOf Begonnen
                    AddHandler dl.Download_completed, AddressOf Fertig
                    AddHandler dl.Download_Aborted, AddressOf Abgebrochen
                    AddHandler dl.Download_Process_changed, AddressOf Fortschritt
                End With

                Current_Downloads.Add(dl)
            End SyncLock
        End If
    End Sub

    Public Sub Cancel()
        For Each slot As Download In Current_Downloads
            If slot IsNot Nothing Then
                If slot.Fertig = False Then
                    slot.Webclient.CancelAsync()
                End If
            End If
        Next
    End Sub

    

#Region "Events"
    Private Sub Fertig(ref As Download)
        If Main.canceling = False Then


            Dim target As String = ""

            If Main.sortbyartist = True Then
                Dim dirmask As String = ""

                If Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(0).Text.Contains("-") Then
                    dirmask = _cleanreplace.replacechars(Trim(Mid(Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(0).Text, 1, Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(0).Text.LastIndexOf("-"))), "Target-Directory")
                End If

                If Not Directory.Exists(Main.Collections.Aktuelle_Sammlung.Path & dirmask) Then
                    Directory.CreateDirectory(Main.Collections.Aktuelle_Sammlung.Path & dirmask)
                End If

                target = Main.Collections.Aktuelle_Sammlung.Path & dirmask & "\" & Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(0).Text & ".mp3"
            Else
                target = Main.Collections.Aktuelle_Sammlung.Path & Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(0).Text & ".mp3"
            End If

            If File.Exists(ref.Ziel) Then
                If ref.Ziel.Contains(".mp4") Or ref.Ziel.Contains(".flv") AndAlso File.Exists(Main.converter.konverter_path) Then
                    Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(3).Text = "Konvertieren..."
                    converter.convertToMP3(ref.Ziel, target, Main.MP3_Bitrate, ref.Id.ToString)
                End If

                RaiseEvent Download_Fertig(ref)
            Else
                MsgBox("Datei " & ref.Ziel & " wurde nicht gefunden!", MsgBoxStyle.Critical)
                RaiseEvent Download_Abgebrochen(ref)
            End If

            Download_Manager.cancel_all_downloads.Enabled = False
            Download_Manager.download.Enabled = True
        Else
            RaiseEvent Download_Abgebrochen(ref)
            Main.canceling = False
        End If

        Download_Manager.DL_Listview.Items.Item(ref.Id).SubItems(3).Text = "Fertig"
        Remove(ref)
    End Sub

    Private Sub Abgebrochen(ref As Download)
        RaiseEvent Download_Abgebrochen(ref)
        Remove(ref)
    End Sub

    Private Sub Fortschritt(Percent As Integer, current_bytes As Integer, total_bytes As Integer, ref As Download)
        RaiseEvent Download_Fortschritt(Percent, current_bytes, total_bytes, ref)
    End Sub

    Private Sub Begonnen(ref As Download)
        RaiseEvent Download_begonnen(ref)
    End Sub

    Public Sub Remove(ByVal ref As Download)
        SyncLock lock
            If Current_Downloads.Count > 0 Then
                Current_Downloads.Remove(ref)
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
#End Region

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

        AddHandler _webclient.DownloadFileCompleted, AddressOf _completed
        AddHandler _webclient.DownloadProgressChanged, AddressOf _changed

        _webclient.DownloadFileAsync(New Uri(_source), _target)
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
        _finisch = True

        If e.Cancelled = False Then
            RaiseEvent Download_completed(_reference)
        Else
            RaiseEvent Download_Aborted(_reference)
        End If
    End Sub

    Private Sub Cancel_Download(ByVal ref As Download)
        If ref.Fertig = False Then
            ref._webclient.CancelAsync()
            RaiseEvent Download_Aborted(ref)
        End If
    End Sub
#End Region

End Class
