Public Class RecordForm
    Public _ParentForm As Form

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Dispose()
        _ParentForm.Dispose()
    End Sub

    Private Sub tsmi_Close_Click(sender As Object, e As EventArgs) Handles tsmi_Close.Click
        Me.Dispose()
        _ParentForm.Dispose()
    End Sub
End Class