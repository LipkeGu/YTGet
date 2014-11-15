Imports System.IO
Imports System.Net
Imports System.Threading

Public Class Youtube_libary
    Public Event Content(ByVal param1 As String, ByVal param2 As String, ByVal param3 As String, ByVal param4 As String, ByVal param5 As String, param6 As String)
	Public Event Report(ByVal msg As String)
    Public Event releaseButtons(action As Boolean)

	Dim _ytweb As New ytWeb
    Dim INI As New INIDatei
    Dim _CleanReplace As New CleanReplace
	Dim dltags As String = ""
    Dim video_tags As String = ""
    Dim dltries As Integer = 0

    Public sigtag As String = "signature"
    Public _useragent As String = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:19.0) Gecko/20100101 Firefox/30.0"

    Public Sub seiteAufrufen(ByVal url As String)

        Dim Tread1 As New Thread(AddressOf _ErmittelnderSeite)
        Tread1.IsBackground = True
        Tread1.Start(CObj(url))

    End Sub

    Private Function Gettags(ByVal _line As String, ByVal key As String, delimeter As String, ByVal fixed_length As Integer) As String
        If _line.Contains(key) Then
            Dim pattern As String = ""
            Dim anfang, ende, länge As Integer

            If key = "signature=" Then
                delimeter = ""
                fixed_length = 81
            ElseIf key = "algorithm=" Then
                Return "throttle-factor"
                Exit Function
            End If

            Dim _retval As String = ""
            Dim _tmp() As String

            If delimeter <> "" Then
                anfang = (InStr(_line, key) + key.Length)
                ende = InStr(anfang, _line, delimeter)
                länge = (ende - anfang)

                If länge > 81 Then länge = 81

                If ende > 0 Then
                    pattern = Mid(_line, anfang, länge)

                    If key = "ms=" Then
                        Return "au"
                    End If
                Else
                    _retval = ""
                End If
            Else
                anfang = InStr(_line, key) + key.Length
                pattern = Mid(_line, anfang, fixed_length)
            End If

            If pattern.Contains(Chr(34)) Then
                _tmp = pattern.Split(Chr(34))
                pattern = _tmp(0)
            End If

            _retval = pattern

            Return _retval
        Else
            If key = "keepalive=" Or key = "ratebypass=" Or key = "gir=" Or key = "mws" Then
                Return "yes"
            ElseIf key = "c=" Then
                Return "web"
            Else
                Download_Manager.Error_Handler.AddEvent("Download-Manager", EventType.Exception, "Konnte den " & key & " nicht finden!")
            End If
        End If
    End Function

    Private Function GetParams(ByVal line As String, proto As String) As String
        If line <> "" Then
            Dim required_sparams() As String

            Dim parameter As String = ""
            Dim server As String = Gettags(line, proto, "/videoplayback", 0)
            Dim dlink As String = server & "/videoplayback?"
            Dim __line() As String = Split(line, "url=" & proto)
            Dim _tmp As String = ""

            For i1 As Integer = __line.Length - 1 To 0 Step -1
                If __line(i1).Contains("/videoplayback?") AndAlso __line(i1).Contains("expire=") AndAlso __line(i1).Contains("source=youtube") Then
                    __line(i1) = Mid(__line(i1), 1, InStr(__line(i1), Chr(34)))

                    required_sparams = Split(Gettags(__line(i1), "sparams=", "&", 0), ",")
                    Dim tags(required_sparams.Length - 1) As String

                    parameter = Gettags(__line(i1), "sparams=", "&", 0)

                    For i As Integer = 0 To required_sparams.Length - 1 Step 1
                        tags(i) = Gettags(__line(i1), Trim(required_sparams(i)) & "=", "&", 0)
                        dlink = Trim(dlink & "&" & Trim(required_sparams(i)) & "=" & tags(i))
                    Next

                    Dim dltags(settings.ListBox1.Items.Count - 1) As String

                    For i As Integer = 0 To settings.ListBox1.Items.Count - 1 Step 1
                        If __line(i1).Contains(settings.ListBox1.Items.Item(i).ToString.ToLower & "=") Then
                            _tmp = Gettags(__line(i1), settings.ListBox1.Items.Item(i).ToString.ToLower & "=", "&", 0)

                            If _tmp.Length > 0 Then
                                dltags(i) = _tmp
                                dlink = dlink & "&" & settings.ListBox1.Items.Item(i).ToString.ToLower & "=" & dltags(i)
                            End If
                        End If
                    Next

                    dlink = dlink & "&sparams=" & parameter

                    Return Replace(_CleanReplace.replacechars(Trim(dlink), "Download-URL"), "?&", "")
                End If
            Next
        Else
            Return ""
        End If

    End Function

    Private Sub _ErmittelnderSeite(ByVal url As Object, Optional dump As Boolean = True)
        If CStr(url).Length > 9 Then
            Try
                Dim _req As HttpWebResponse = _ytweb.Get_HTTP_Response(_ytweb.create_HTTP_request(New Uri(CStr(url)), _useragent))

                If _req IsNot Nothing Then
                    If _req.StatusCode = 200 Then
                        Dim _line As String = ""
                        Dim DLlink As String = ""
                        Dim vname As String = ""
                        Dim source As String = _req.ResponseUri.Host
                        Dim quality As String = "Unbekannt"
                        Dim check As MsgBoxResult = MsgBoxResult.No

                        If _req.ContentType.Contains("text/html") Then
                            Dim sr1 As New StreamReader(_req.GetResponseStream)

                            Dim proto As String = "https://"
                            Dim _tmp As String = ""

                            While sr1.EndOfStream = False
                                _line = _CleanReplace.replacechars(Trim(sr1.ReadLine), "source_code")

                                If _line IsNot Nothing Then
                                    If _line.Length > 9 Then

                                        If _line.Contains("http") AndAlso _line.Contains("https://") Then
                                            proto = "https://"
                                        Else
                                            proto = "http://"
                                        End If

                                        If _line.StartsWith("<meta property=") Then
                                            If _line.StartsWith("<meta property=""og:site_name"" content=""") Then
                                                source = _CleanReplace.replacechars(Trim(Gettags(_line, "<meta property=""og:site_name"" content=""", ">", 0)), "Name")
                                            End If

                                            If _line.StartsWith("<meta property=""og:title"" content=""") Then
                                                vname = _CleanReplace.replacechars(Trim(Gettags(_line, "<meta property=""og:title"" content=""", """", 0)), "Name")
                                            End If
                                        End If

                                        If CStr(url).Contains("vimeo.com") Then
                                            source = "Vimeo"
                                        End If

                                        If source = "YouTube" Then
                                            If _line.Contains("<script>var ytplayer") AndAlso _line.Contains("url=") Then
                                                DLlink = proto & GetParams(Mid(_line, InStrRev(_line, "url=")), proto)
                                                GetContentinfo(DLlink, "854x480", vname, source)

                                                Exit While
                                            End If
                                        ElseIf source = "Dailymotion" Then
                                            If _line.Length > 10 AndAlso _line.Contains("video_url"":""") Then
                                                _tmp = Trim(Gettags(_line, "video_url"":""", """,", 0))
                                                DLlink = Trim(_tmp)
                                                GetContentinfo(DLlink, "[Medium]", vname, source)
                                                Exit While
                                            End If
                                        ElseIf source = "Vimeo" Then
                                            If _line.Contains("<title>") Then
                                                vname = _CleanReplace.replacechars(Trim(Gettags(_line, "<title>", "<", 0)), "Name")
                                            End If

                                            If _line.Length > 10 AndAlso _line.Contains("origin") Then
                                                _tmp = Mid(_line, InStr(_line, """hd""") + 52, (InStr(_line, "720") - 4))
                                                _tmp = Mid(_tmp, 1, InStr(_tmp, ",") - 2)

                                                DLlink = proto & _tmp

                                                Exit While
                                            End If
                                        Else
                                            If _line.Contains("<h1>Index of") Then
                                                source = "[HTTP] " & _req.ResponseUri.Host
                                            End If

                                            If _line.Contains("<a href") Then
                                                _tmp = Gettags(_line, "<a href=""", """", 0)
                                                vname = _CleanReplace.replacechars(_tmp, "Name")

                                                For i As Integer = 0 To settings.artist_pattern_list.Items.Count - 1 Step 1
                                                    If vname.ToLower.Contains(CStr(settings.artist_pattern_list.Items.Item(i)).ToLower) Then
                                                        vname = Replace(vname.ToLower, CStr(settings.artist_pattern_list.Items.Item(i)).ToLower, "")
                                                        vname = CStr(settings.artist_pattern_list.Items.Item(i)) & " - " & vname
                                                        Exit For
                                                    End If
                                                Next

                                                For i As Integer = 0 To settings.extensions.Items.Count - 1 Step 1
                                                    If _tmp.ToLower.Contains(settings.extensions.Items.Item(i).ToString.ToLower) Then
                                                        GetContentinfo(CStr(url) & _tmp, "Unbekannt", Replace(vname, settings.extensions.Items.Item(i).ToString.ToLower, ""), source)
                                                    End If
                                                Next
                                            End If
                                        End If
                                    End If
                                End If

                            End While

                            If sr1 IsNot Nothing Then
                                sr1.Close()
                            End If

                        ElseIf _req.ContentType.Contains("audio/") Then
                            vname = Replace(Mid(CStr(url), CStr(url).LastIndexOf("/") + 1), ".mp3", "")
                            GetContentinfo(CStr(url), "Unbekannt", vname, source)

                        ElseIf _req.ContentType.Contains("video/") Then
                            vname = Replace(Mid(CStr(url), CStr(url).LastIndexOf("/") + 1), ".mp3", "")
                            GetContentinfo(CStr(url), "Unbekannt", vname, source)

						Else
							vname = Mid(CStr(url), CStr(url).LastIndexOf("/") + 1)
							GetContentinfo(CStr(url), "Unbekannt", vname, source)
                        End If
                    Else
                        Download_Manager.Error_Handler.AddEvent("Download-Manager", EventType.Exception, "Server gab einen Fehler zurück: " & _req.StatusCode.ToString)
                    End If

                    _req.Close()
                Else
                    Throw New Exception("[Debug] Downloader is nothing while determaining the Parameters")
                End If
            Catch ex As Exception
                Download_Manager.Error_Handler.AddEvent("Download-Manager", EventType.Exception, ex.Message)
                RaiseEvent releaseButtons(True)
            End Try
        Else
            Download_Manager.Error_Handler.AddEvent("Download-Manager", EventType.Exception, "Link war kürzer als 10 zeichen!")
        End If

        RaiseEvent releaseButtons(True)
    End Sub

        Private Sub GetContentinfo(ByVal Downloadlink As String, quality As String, ByVal videoname As String, ByVal source As String)

        If Downloadlink.Length > 8 AndAlso Not Downloadlink.Contains("=&") AndAlso Not Downloadlink.Contains("{") Then
            Dim _req As HttpWebResponse = _ytweb.Get_HTTP_Response(_ytweb.create_HTTP_request(New Uri(CStr(Downloadlink)), _useragent))

            If _req IsNot Nothing Then
                If _req.StatusCode = HttpStatusCode.OK Then
                    Dim _t As String = _req.ContentType

                    If source = "YouTube" AndAlso _req.ContentType.Contains("application/") Then
                        _t = "video/mp4"
					End If

					_req.Close()

                    If _t.Contains("video/") Or _t.Contains("audio/") Or _t.Contains("application/") Then
                        GetMovieinfo(videoname, source, CStr(_ytweb.ConvertContentLength(_req.ContentLength)), Downloadlink, _t, quality)
                    Else
                        Download_Manager.Error_Handler.AddEvent("Download-Manager", EventType.Warning, "got Content " & _t)
                    End If
                Else
                    Download_Manager.Error_Handler.AddEvent("Download-Manager", EventType.Exception, _req.StatusCode.ToString & " : " & _req.StatusDescription)
                End If

                _req.Close()
			Else
				Download_Manager.Error_Handler.AddEvent("Download-Manager", EventType.Exception, "Downloader can not detect the Content!")
            End If
        Else
            Download_Manager.Error_Handler.AddEvent("Download-Manager", EventType.Exception, "Fehler in der URL: " & Downloadlink)
        End If

        RaiseEvent releaseButtons(True)
    End Sub

    Private Sub GetMovieinfo(ByVal videoname As String, ByVal source As String, ByVal size As String, Downloadlink As String, type As String, ByVal quality As String)
        RaiseEvent Content(videoname, source, Downloadlink, type, size & " MB", quality)
        Download_Manager.Error_Handler.AddEvent("Download-Manager", EventType.information, "Fertig!")
    End Sub
End Class
