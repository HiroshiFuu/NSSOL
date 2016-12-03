Public Class CountryForm
    Public Sub BindData(CountryTable As DataTable, SelectedIndex As Integer)
        dgv_Country.Columns.Clear()
        dgv_Country.DataSource = CountryTable
        dgv_Country.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgv_Country.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv_Country.ClearSelection()
        dgv_Country.CurrentCell = dgv_Country.Rows(SelectedIndex).Cells(0)
        dgv_Country.Rows(SelectedIndex).Selected = True
    End Sub
End Class