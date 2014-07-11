Imports System.Net

Public Class Main
    Public Event status(ByVal message As String)

    Public CleanReplace As New CleanReplace()
    Public FileIO As New YTFileIO
    Public Collections As New Collections
    Dim WithEvents Errorhandler As New Errorhandler

    Public INIDatei As New INIDatei
    Public converter As New convert

    Public path_to_config As String = ""
    Public HAVE_CONFIG_FILE As Boolean = False
    Public HAVE_TOOLS_DIR As Boolean = False
    Public lock As New Object
    Public Application_Directory As String = My.Application.Info.DirectoryPath
    Public Dlpath As String = Application_Directory & "\Downloads\"
    Public MP3_Bitrate As String = "192"
    Public MP3_samprate As String = "44100"

    Public sortbyartist As Boolean = False
    Public forcedb_normalize As Boolean = True
    Public cleanup_on_close As Boolean = False
    Public write_short_Header As Boolean = True

    Public audio_volume As String = "89"
    Public max_Downloads As Integer = 3
    Public min_contentlength As String = "1.9"
    Public max_contentlength As String = "200.9"
    Public canceling As Boolean = False

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If System.IO.File.Exists(path_to_config) Then
            Collections.Save_Collections()
            Save_Extensioninfos()
            CleanReplace.SaveRulelist3()

            INIDatei.WertSchreiben("Settings", "MP3_Bitrate", MP3_Bitrate)
            INIDatei.WertSchreiben("Settings", "MP3_Sampling", MP3_samprate)

            If Dlpath <> Application_Directory & "\Downloads" Then
                INIDatei.WertSchreiben("Main", "DownloadPath", Dlpath)
            End If

            If settings.detect_by_artist.Checked = True Then
                INIDatei.WertSchreiben("Settings", "DetectMethod", "2")
            Else
                INIDatei.WertSchreiben("Settings", "DetectMethod", "1")
            End If
        End If

        cleanup()

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim desktopSize As Size
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize

        Me.Width = CInt(desktopSize.Width / 2)
        Me.Height = CInt(desktopSize.Height / 2)

        Me.Location = New Point(1, 1)

        If Not System.IO.Directory.Exists(Application_Directory & "\Tools") Then
            Try
                System.IO.Directory.CreateDirectory(Application_Directory & "\Tools")
                HAVE_TOOLS_DIR = True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Application.Exit()
            End Try
        Else
            HAVE_TOOLS_DIR = True
        End If

        If System.IO.File.Exists(Application_Directory & "\config.ini") Then
            path_to_config = Application_Directory & "\config.ini"
            HAVE_CONFIG_FILE = True
        Else

            Dim _result As MsgBoxResult

            _result = MsgBox("Es existiert keine Konfiguration, möchten sie eine andere auswählen?", MsgBoxStyle.YesNoCancel)

            If _result = MsgBoxResult.Yes Then
                Dim ofd As New OpenFileDialog()

                With ofd
                    .CheckFileExists = True
                    .CheckPathExists = True
                    .Multiselect = False
                    .ShowReadOnly = True
                    .Title = "Bitte wählen sie die Konfiguration..."
                    .Filter = "config.ini|config.ini"
                End With

                If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    path_to_config = ofd.FileName
                    HAVE_CONFIG_FILE = True
                Else
                    HAVE_CONFIG_FILE = False
                End If
            ElseIf _result = MsgBoxResult.No Then
                path_to_config = Application_Directory & "\config.ini"
                INIDatei.Pfad = path_to_config
                System.IO.File.WriteAllText(path_to_config, "[Main]" & vbCrLf & vbCrLf & "[Settings]")
                HAVE_CONFIG_FILE = True
            Else
                HAVE_CONFIG_FILE = False
            End If
        End If

        If HAVE_CONFIG_FILE = True Then
            INIDatei.Pfad = path_to_config
            Dim _tmp As String

            _tmp = INIDatei.WertLesen("Settings", "DetectMethod", "2")

            If _tmp IsNot Nothing Then
                If _tmp = "2" Then
                    settings.detect_by_artist.Checked = True
                Else
                    settings.detect_by_artist.Checked = False
                End If
            Else
                settings.detect_by_artist.Checked = True
            End If

            _tmp = INIDatei.WertLesen("Settings", "MP3_Bitrate", "192")

            If _tmp IsNot Nothing Then
                MP3_Bitrate = _tmp
            Else
                MP3_Bitrate = "192"
            End If

            settings.audio_bitrate.Text = MP3_Bitrate

            _tmp = INIDatei.WertLesen("Settings", "MP3_Sampling", "44100")

            If _tmp IsNot Nothing Then
                MP3_samprate = _tmp
            Else
                MP3_samprate = "44100"
            End If

            settings.audio_sampling_rate.Text = MP3_samprate

            _tmp = INIDatei.WertLesen("Settings", "UserAgent", "")

            If _tmp IsNot Nothing Then
                'Download._useragent = _tmp
            End If

            Collections.Load_collections()

            If Collections.Count < 1 Then
                Collections.Add()
            End If

            _tmp = INIDatei.WertLesen("Main", "DownloadPath", Nothing)

            If _tmp IsNot Nothing Then
                If _tmp.Length > 0 Then
                    If Dlpath <> _tmp Then Dlpath = _tmp
                End If
            Else
                Dlpath = Application_Directory & "\Downloads\"
            End If

            Dlpath = Replace(Dlpath, "\\", "\")

            If Not System.IO.Directory.Exists(Dlpath) Then
                Try
                    System.IO.Directory.CreateDirectory(Dlpath)
                Catch ex As Exception
                    Dlpath = Application_Directory & "\Downloads\"
                End Try

            End If

            If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\clean_replace.ini") Then
                With CleanReplace
                    .Loadruleset()
                    .Loadruleset2()
                    .Loadruleset3()

                    If System.IO.Directory.Exists(Collections.Aktuelle_Sammlung.Path) Then
                        If settings.artist_pattern_list.Items.Count = 0 Then
                            .training()
                            .SaveRulelist3()
                        End If
                    End If
                End With
            Else
                System.IO.File.WriteAllText(My.Application.Info.DirectoryPath & "\clean_replace.ini", "[info]" & vbCrLf & "count=0" & vbCrLf & "tp_count=0" & vbCrLf & "ap_count=0" & vbCrLf & vbCrLf & "[ruleset]" & vbCrLf & vbCrLf & "[ap_ruleset]" & vbCrLf & vbCrLf & "[tp_ruleset]" & vbCrLf)
            End If
        Else
            MP3_Bitrate = "192"
            MP3_samprate = "44100"
            settings.detect_by_artist.Checked = True
            Dlpath = Application_Directory & "\Downloads\"
        End If

        If HAVE_TOOLS_DIR Then
            converter.konverter_path = Application_Directory & "\tools\ffmpeg.exe"

        End If

        If HAVE_CONFIG_FILE = True AndAlso HAVE_TOOLS_DIR = True Then
            Load_Extensioninfos()



            If Not System.IO.File.Exists(converter.konverter_path) Then
                If Not System.IO.File.Exists(Dlpath & "\ffmpeg-latest-win32-static.7z") Then
                    MsgBox("Der FFMPEG-Konverter wurde in den Download-Manager eingereiht!, laden sie die Datei herunter und entpacken sie die Datei ""ffmpeg.exe"" nach """ & converter.konverter_path & """ ab und starte YT-Get neu!", MsgBoxStyle.Exclamation)

                    With Download_Manager
                        .MdiParent = Me
                        .Width = CInt((Me.Width / 2))
                        .Height = CInt((Me.Height / 2))
                        .Show()

                        .movie_url.Text = "http://ffmpeg.zeranoe.com/builds/win32/static/ffmpeg-latest-win32-static.7z"
                        .Add_URL.Enabled = True
                        .Add_URL.PerformClick()

                        If .DL_Listview.Items.Count > 0 Then
                            .download.Enabled = True
                            .download.PerformClick()
                        End If

                    End With
                Else
                    MsgBox("Entpacken sie die heruntergeladene Datei "" ffmpeg-latest-win32-static.7z "", danach kopieren sie die Datei ""ffmpeg.exe"" nach """ & converter.konverter_path & """ und starte YT-Get neu!", MsgBoxStyle.Exclamation)
                End If
            End If
        End If

        If Speicherort.Text = "" Then
            Application.Exit()
        Else
            Menu_collections_oeffnen.Enabled = True
            ImportierenToolStripMenuItem.Enabled = True
        End If

    End Sub

    Private Sub Menu_collections_festlegen_Click(sender As Object, e As EventArgs) Handles Menu_collections_festlegen.Click
        Collections.Add()
    End Sub

    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Speicherort.Alignment = ToolStripItemAlignment.Right
        Speicherort.Size = New Size(300, Speicherort.Size.Height)

        If ImportTo_Collection.Visible Then
            If Me.WindowState = FormWindowState.Maximized Then
                ImportTo_Collection.WindowState = Me.WindowState
            Else
                ImportTo_Collection.WindowState = Me.WindowState
                ImportTo_Collection.Width = CInt((Me.Width / 2))
                ImportTo_Collection.Height = CInt((Me.Height / 2))
            End If
        End If

        If Download_Manager.Visible = True Then
            If Me.WindowState = FormWindowState.Maximized Then
                Download_Manager.WindowState = Me.WindowState
            Else
                Download_Manager.WindowState = Me.WindowState
                Download_Manager.Width = CInt((Me.Width / 2))
                Download_Manager.Height = CInt((Me.Height / 2))
            End If
        End If
    End Sub

    Private Sub ImportierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportierenToolStripMenuItem.Click
        ImportTo_Collection.MdiParent = Me

        ImportTo_Collection.Width = CInt((Me.Width / 2))
        ImportTo_Collection.Height = CInt((Me.Height / 2))
        ImportTo_Collection.Show()
    End Sub

    Private Sub Menu_collections_oeffnen_Click(sender As Object, e As EventArgs) Handles Menu_collections_oeffnen.Click
        Dim p As New Process

        With p
            .StartInfo.FileName = "explorer.exe"
            .StartInfo.Arguments = Speicherort.Text
            Try
                .Start()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, Menu_collections_oeffnen.Text)
            End Try
        End With
    End Sub

    Private Sub DownloaderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DownloaderToolStripMenuItem1.Click
        Download_Manager.Width = CInt((Me.Width / 2))
        Download_Manager.Height = CInt((Me.Height / 2))

        Download_Manager.MdiParent = Me
        Download_Manager.Show()
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub speicherort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Speicherort.SelectedIndexChanged
        If Speicherort.SelectedItem.ToString <> Speicherort.Text Then
            For Each col As Collection In Collections.Collections
                If col.Path = Me.Speicherort.SelectedItem.ToString Then
                    Collections.Aktuelle_Sammlung = col
                End If
            Next
        End If
    End Sub

    Private Sub EntfernenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntfernenToolStripMenuItem.Click
        Collections.Remove(Speicherort.Text)
    End Sub

    Private Sub EinstellungenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EinstellungenToolStripMenuItem.Click
        Try
            settings.MdiParent = Me
            settings.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cleanup()
        Dim fil As System.IO.FileInfo

        If System.IO.Directory.Exists(Dlpath) Then
            Dim dirinfo As New System.IO.DirectoryInfo(Dlpath)

            For Each File As System.IO.FileInfo In dirinfo.GetFiles("*.flv", System.IO.SearchOption.TopDirectoryOnly)
                Try
                    File.Delete()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
                End Try
            Next

            For Each File As System.IO.FileInfo In dirinfo.GetFiles("*.mp4", System.IO.SearchOption.TopDirectoryOnly)
                Try
                    File.Delete()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
                End Try
            Next
        End If
    End Sub

    Private Sub Speicherort_Click(sender As Object, e As EventArgs) Handles Speicherort.SelectedIndexChanged
        For Each col As Collection In Collections.Collections
            If col.Path = Speicherort.Text Then
                Collections.Aktuelle_Sammlung = col
            End If
        Next
    End Sub

    Public Sub Load_Extensioninfos()
        Try
            If System.IO.File.Exists(path_to_config) Then

                INIDatei.Pfad = path_to_config

                Dim rulecount As Integer = 0
                Dim rule As String

                rulecount = CInt(INIDatei.WertLesen("info", "ext_count"))

                If rulecount > 0 Then
                    settings.extensions.Items.Clear()

                    SyncLock lock
                        For ruleindex As Integer = 0 To rulecount - 1
                            rule = INIDatei.WertLesen("Extensions", "extension" & CStr(ruleindex))

                            If rule.Length > 2 Then
                                If Not settings.extensions.Items.Contains(rule) Then
                                    settings.extensions.Items.Add(rule)
                                End If
                            End If
                        Next
                    End SyncLock
                End If
            Else
                Save_Extensioninfos()
                Load_Extensioninfos()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Save_Extensioninfos()
        If System.IO.File.Exists(path_to_config) Then
            SyncLock lock
                INIDatei.SektionLöschen("Extensions")
                INIDatei.WertSchreiben("info", "ext_count", CStr(settings.extensions.Items.Count))

                For i As Integer = 0 To settings.extensions.Items.Count - 1
                    INIDatei.WertSchreiben("Extensions", "extension" & i, settings.extensions.Items.Item(i).ToString)
                Next
            End SyncLock
        End If
    End Sub

    Private Sub BestandslisteErstellenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BestandslisteErstellenToolStripMenuItem.Click
        Collections.Bestandslisteerstellen()
    End Sub
End Class