Public Class RecordForm
    Private Shared recordForm As RecordForm = Nothing
    Private Shared _ParentForm As Form

    'restricted
    Private Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim config As SystemConfigInterface = SystemConfig.getInstance()
        tssl_User_Name.Text = "User Name: " + config.getUser_Name()
        tssl_Version.Text = "Version: " + config.getVersion()
        tssl_Databse.Text = "Databse: " + config.getDatabase()
    End Sub

    Public Shared Function getInstance(parent As MainForm)
        _ParentForm = parent
        If recordForm Is Nothing Then
            recordForm = New RecordForm()
        End If
        Return recordForm
    End Function

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
        _ParentForm.Dispose()
    End Sub

    Private Sub TSBtn_Logoff_Click(sender As Object, e As EventArgs) Handles TSBtn_Logoff.Click
        Me.Dispose()
    End Sub
End Class