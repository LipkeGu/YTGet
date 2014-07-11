Imports System.Net
Imports System.IO

Public Class ytWeb
    Public Function create_HTTP_request(ByVal url As Uri, ByVal ua As String) As HttpWebResponse
        Try
            Dim request As HttpWebRequest = CType(HttpWebRequest.Create(url), HttpWebRequest)

            With request
                If ua.Length > 1 Then
                    .UserAgent = ua
                End If

                .Method = WebRequestMethods.Http.Get
            End With

            Return CType(request.GetResponse, HttpWebResponse)
        Catch ex As WebException
            Return CType(ex.Response, HttpWebResponse)
        End Try

    End Function

    Public Function Get_HTTP_Response(_Response As HttpWebResponse) As HttpWebResponse
        If _Response IsNot Nothing Then
            Dim response As HttpWebResponse = _Response

            If response.StatusCode = HttpStatusCode.OK Then
                Return response
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Public Function ConvertContentLength(ByVal length As Long) As String
        Dim size As String = ""

        If length > 0 Then
            size = Math.Round(length / 1024 / 1024, 2).ToString
        Else
            size = "0"
        End If

        Return size
    End Function
End Class
