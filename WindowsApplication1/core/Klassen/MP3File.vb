Public Class MP3File
    'FrameHeader
    Private _isVBR As Boolean = False
    Private _Bitrate As Integer = 0
    Private _duration As String = "00:00:00"
    Private _samprate As Integer = 0

    Private _exception As String = ""
    Private _error As Boolean = False
    Private _isprotected As Boolean = False
    Private _target As String = ""
    Private _interpret As String = ""
    Private _Titel As String = ""
    Private _selected As Boolean = True
    Private _source As String = ""
    Private _iscopyright As Boolean = False
    Private _FileSize As String = ""
    Private _duplicate As Boolean = False
    Private _md5duplicate As Boolean = False
    Private _hash As String = ""
    Private _protected As String = ""

    Public Property targetfilename As String
        Get
            Return _target
        End Get

        Set(value As String)
            _target = value
        End Set
    End Property

    Public ReadOnly Property BadHeader As Boolean
        Get
            Return _error
        End Get
    End Property

    Public ReadOnly Property Copyrighted As Boolean
        Get
            Return _iscopyright
        End Get
    End Property

    Public ReadOnly Property SamplingRate As Integer
        Get
            Return _samprate
        End Get
    End Property

    Public ReadOnly Property Checksum As String
        Get
            Return _hash
        End Get
    End Property

    Public ReadOnly Property Duration As String
        Get
            Return _duration
        End Get
    End Property

    Public ReadOnly Property ISVariableBitrate As Boolean
        Get
            Return _isVBR
        End Get
    End Property

    Public ReadOnly Property Bitrate As Integer
        Get
            Return _Bitrate
        End Get
    End Property

    Public ReadOnly Property Exception As String
        Get
            Return _exception
        End Get
    End Property

    Public ReadOnly Property Protection As String
        Get
            Return _protected
        End Get
    End Property

    Public ReadOnly Property isProtected As Boolean
        Get
            Return _isprotected
        End Get
    End Property

    Public Property Artist As String
        Set(value As String)
            _interpret = value
        End Set
        Get
            Return _interpret
        End Get
    End Property

    Public Property MD5Duplicate As Boolean
        Get
            Return _md5duplicate
        End Get

        Set(value As Boolean)
            _md5duplicate = value
        End Set
    End Property

    Public Property Duplicate As Boolean
        Get
            Return _duplicate
        End Get

        Set(value As Boolean)
            _duplicate = value
        End Set
    End Property

    Public Property selected As Boolean
        Get
            Return _selected
        End Get

        Set(value As Boolean)
            _selected = value
        End Set
    End Property

    Public Property Title As String
        Set(value As String)
            _Titel = value
        End Set
        Get
            Return _Titel
        End Get
    End Property

    Public Property Source As String
        Set(value As String)
            _source = value
        End Set
        Get
            Return _source
        End Get
    End Property

    Public Property Size As String
        Set(value As String)
            _FileSize = value
        End Set
        Get
            Return _FileSize
        End Get
    End Property

    Sub New(ByVal Interpret As String, ByVal Title As String, ByVal Source As String, ByVal size As String, ByVal md5duplicate As Boolean, ByVal target As String)

        If Interpret.Length > 1 Then
            _interpret = Interpret
        End If

        If Title.Length > 1 Then
            _Titel = Title
        End If

        If size.Length > 1 Then
            _FileSize = size
        End If

        If _interpret.Length > 0 AndAlso _Titel.Length > 0 Then
            _target = target & _interpret & "\" & _interpret & " - " & _Titel & ".mp3"
        End If

        If Source.Length > 1 Then
            _source = Source
        End If

        _hash = Main.FileIO.MD5FileHash(_source)

        Try
            Dim mp3info As New MP3Info(_source)

            _Bitrate = CInt((mp3info.GetBitrate() / 1000))
            _duration = mp3info.GetDurationString
            _isVBR = mp3info.IsVBR
            _samprate = mp3info.GetSamplingRateFreq

            Select Case mp3info.GetProtection
                Case YTGet.MP3Info.ProtectionType.NotProtected
                    _protected = "Nein"
                    _isprotected = False
                Case YTGet.MP3Info.ProtectionType.ProtectedByCRC
                    _protected = "Ja CRC"
                    _isprotected = True
                Case Else
                    _protected = "Unbekannter Kopierschutz!"
                    _isprotected = True
            End Select

            Select Case mp3info.GetCopyRight()
                Case YTGet.MP3Info.CopyRight.CopyRighted
                    _iscopyright = True
                Case YTGet.MP3Info.CopyRight.NotCopyRighted
                    _iscopyright = False
            End Select

        Catch ex As Exception
            _Bitrate = 0
            _duration = "Fehler!"
            _isVBR = False
            _error = True
            _isprotected = False
            _iscopyright = False
            _samprate = 0
            _exception = ex.Message
            _selected = False
        End Try

    End Sub

End Class
