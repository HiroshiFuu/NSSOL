Public Class CodeNamePairForm

    Public Sub New(Title As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = "Select " + Title
    End Sub

    Public Sub BindData(CountryTable As DataTable, SelectedIndex As Integer)
        dgv_CodeNamePair.Columns.Clear()
        dgv_CodeNamePair.DataSource = CountryTable
        dgv_CodeNamePair.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgv_CodeNamePair.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv_CodeNamePair.ClearSelection()
        If SelectedIndex <> -1 Then
            dgv_CodeNamePair.CurrentCell = dgv_CodeNamePair.Rows(SelectedIndex).Cells(0)
            dgv_CodeNamePair.Rows(SelectedIndex).Selected = True
        End If
    End Sub
End Class