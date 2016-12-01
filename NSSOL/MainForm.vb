Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fm = New RecordForm
        fm.Show()
        fm.MdiParent = Me
        fm.Dock = DockStyle.Fill
        fm.WindowState = FormWindowState.Maximized
        fm.WindowState = FormWindowState.Normal
        fm.Dock = DockStyle.Fill
        fm._ParentForm = Me
    End Sub
End Class
