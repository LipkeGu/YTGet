Public Class ruleeditor
    Dim cr As New CleanReplace

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" AndAlso ComboBox1.Text <> "" Then
            cr.AddNewRule(TextBox1.Text, TextBox2.Text, CStr(ComboBox1.SelectedItem))
        End If

        Me.Close()
    End Sub
End Class