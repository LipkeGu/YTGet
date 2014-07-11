Imports System.Windows.Forms

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ImportTo_Collection.Importer.filestoread = CInt(NumericUpDown1.Value)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NumericUpDown1.Maximum = ImportTo_Collection.filcount
        NumericUpDown1.Value = NumericUpDown1.Maximum
        NumericUpDown1.Minimum = 1
    End Sub
End Class
