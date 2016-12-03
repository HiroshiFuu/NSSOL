Imports System.Xml

Public Class RecordForm
    Private Shared recordForm As RecordForm = Nothing
    Private Shared _ParentForm As MainForm
    Private config As SystemConfigInterface
    Private CompanyInfoList As List(Of CompanyInfo)
    Private SelectedCompanyInfoIndex As Integer = -1
    Private CountryList As List(Of Country)
    Private CountryTable As DataTable
    Private LockTextBoxEvent As Boolean

#Region "Form methods"
    'restricted
    Private Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Shared Function getInstance(parent As Form)
        _ParentForm = parent
        If recordForm Is Nothing Then
            recordForm = New RecordForm()
        End If
        Return recordForm
    End Function

    Private Sub RecordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        config = SystemConfig.getInstance()
        tssl_User_Name.Text = "User Name: " + config.getUser_Name()
        tssl_Version.Text = "Version: " + config.getVersion()
        tssl_Databse.Text = "Databse: " + config.getDatabase()

        Try
            LoadRecordsFromDB()
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, "Database ERROR!")
            Me.Dispose()
        End Try

        Try
            LoadCountryFromXML()
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, "Country XML ERROR!")
            Me.Dispose()
        End Try
        If CompanyInfoList.Count <> 0 Then
            CompanyInfoLoadRountineCall(NaviAction.First)
        End If

        CountryTable = New DataTable()
        CountryTable.Columns.Add("Code")
        CountryTable.Columns.Add("Name")
        For Each country As Country In CountryList
            If country.Code.CompareTo(tbCountryCode.Text) = 0 Then
                tbCountryName.Text = country.Name
            End If
            CountryTable.Rows.Add(country.Code, country.Name)
        Next
    End Sub
#End Region

#Region "Data loading methods"
    Private Sub LoadRecordsFromDB()
        Dim _db = New nssolEntities()
        Dim query As IQueryable(Of CompanyInfo) = _db.CompanyInfos
        query = From p In query Select p Order By p.Company_Code
        CompanyInfoList = New List(Of CompanyInfo)
        CompanyInfoList = query.ToList()
    End Sub

    Private Sub LoadCountryFromXML()
        Using reader As XmlReader = XmlReader.Create("./Country.xml")
            CountryList = New List(Of Country)
            While reader.Read()
                If Not reader.IsStartElement Then
                    Continue While
                End If
                If reader.Name = "Country" Then
                    reader.Read()
                    Dim code, name As String
                    code = reader.ReadElementString("Code")
                    name = reader.ReadElementString("Name")
                    Dim country As Country = New Country(code, name)
                    CountryList.Add(country)
                    reader.Read()
                End If
            End While
        End Using
    End Sub
#End Region

#Region "Methods"
    Private Sub LoadCompanyInfoDataToControls(companyinfo As CompanyInfo)
        LockTextBoxEvent = True
        If companyinfo Is Nothing Then

            Return
        End If
        tbCompanyCode.Text = companyinfo.Company_Code
        tbCompanyCode.BackColor = SystemColors.Window
        tbCompanyName.Text = companyinfo.Company_Name
        tbCompanyName.BackColor = SystemColors.Window
        tbAddress1.Text = companyinfo.Address_Line_1
        tbAddress1.BackColor = SystemColors.Window
        tbAddress2.Text = companyinfo.Address_Line_2
        tbAddress2.BackColor = SystemColors.Window
        tbAddress3.Text = companyinfo.Address_Line_3
        tbAddress3.BackColor = SystemColors.Window
        tbCompanyRegNo.Text = companyinfo.Company_Reg_No
        tbCompanyRegNo.BackColor = SystemColors.Window
        tbName1.Text = companyinfo.Authorized_Signer_Name_1
        tbName1.BackColor = SystemColors.Window
        tbName2.Text = companyinfo.Authorized_Signer_Name_2
        tbName2.BackColor = SystemColors.Window
        tbName3.Text = companyinfo.Authorized_Signer_Name_3
        tbName3.BackColor = SystemColors.Window
        tbTitle1.Text = companyinfo.Authorized_Signer_Title_1
        tbTitle1.BackColor = SystemColors.Window
        tbTitle2.Text = companyinfo.Authorized_Signer_Title_2
        tbTitle2.BackColor = SystemColors.Window
        tbTitle3.Text = companyinfo.Authorized_Signer_Title_3
        tbTitle3.BackColor = SystemColors.Window
        tbCountryCode.Text = companyinfo.Country
        tbCountryCode.BackColor = SystemColors.Window
        tbTel.Text = companyinfo.Tel
        tbTel.BackColor = SystemColors.Window
        tbFax.Text = companyinfo.Fax
        tbFax.BackColor = SystemColors.Window
        tbEmail.Text = companyinfo.Email
        tbEmail.BackColor = SystemColors.Window
        tbWebsite.Text = companyinfo.Website
        tbWebsite.BackColor = SystemColors.Window
        tbTaxRegNo.Text = companyinfo.Tax_Registration_No
        tbTaxRegNo.BackColor = SystemColors.Window
        tbCreatedBy.Text = companyinfo.CreatedBy
        tbCreatedBy.BackColor = SystemColors.Window
        tbCreatedOn.Text = companyinfo.CreatedOn
        tbCreatedOn.BackColor = SystemColors.Window
        tbUpdatedBy.Text = companyinfo.UpdatedBy
        tbUpdatedBy.BackColor = SystemColors.Window
        tbUpdatedOn.Text = companyinfo.UpdatedOn
        tbUpdatedOn.BackColor = SystemColors.Window
        LockTextBoxEvent = False
    End Sub

    Private Sub SetNaviControls(SelectedIndex As Integer)
        If SelectedIndex = -1 Then
            TSBtn_First.Enabled = False
            TSBtn_Previous.Enabled = False
            TSBtn_Last.Enabled = False
            TSBtn_Next.Enabled = False
            Return
        End If
        If SelectedCompanyInfoIndex = 0 Then
            TSBtn_First.Enabled = False
            TSBtn_Previous.Enabled = False
        Else
            TSBtn_First.Enabled = True
            TSBtn_Previous.Enabled = True
        End If
        If SelectedCompanyInfoIndex = CompanyInfoList.Count - 1 Then
            TSBtn_Last.Enabled = False
            TSBtn_Next.Enabled = False
        Else
            TSBtn_Last.Enabled = True
            TSBtn_Next.Enabled = True
        End If
    End Sub

    Private Sub CompanyInfoLoadRountineCall(action As Integer)
        Dim companyinfo As CompanyInfo
        If action <> NaviAction.Reload Then
            Select Case action
                Case NaviAction.First : SelectedCompanyInfoIndex = 0
                Case NaviAction.Previous : SelectedCompanyInfoIndex -= 1
                Case NaviAction.Next : SelectedCompanyInfoIndex += 1
                Case NaviAction.Last : SelectedCompanyInfoIndex = CompanyInfoList.Count - 1
            End Select
            companyinfo = CompanyInfoList(SelectedCompanyInfoIndex)
            TSBtn_Delete.Enabled = True
        Else
            companyinfo = Nothing
            TSBtn_Delete.Enabled = False
        End If
        SetNaviControls(SelectedCompanyInfoIndex)
        LoadCompanyInfoDataToControls(companyinfo)
    End Sub
#End Region

#Region "Controls' events"
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
        _ParentForm.Dispose()
    End Sub

    Private Sub TSBtn_Logoff_Click(sender As Object, e As EventArgs) Handles TSBtn_Logoff.Click
        Me.Dispose()
    End Sub

    Private Sub TSBtn_First_Click(sender As Object, e As EventArgs) Handles TSBtn_First.Click
        CompanyInfoLoadRountineCall(NaviAction.First)
    End Sub

    Private Sub TSBtn_Previous_Click(sender As Object, e As EventArgs) Handles TSBtn_Previous.Click
        CompanyInfoLoadRountineCall(NaviAction.Previous)
    End Sub

    Private Sub TSBtn_Next_Click(sender As Object, e As EventArgs) Handles TSBtn_Next.Click
        CompanyInfoLoadRountineCall(NaviAction.Next)
    End Sub

    Private Sub TSBtn_Last_Click(sender As Object, e As EventArgs) Handles TSBtn_Last.Click
        CompanyInfoLoadRountineCall(NaviAction.Last)
    End Sub

    Private Sub btnCountry_Click(sender As Object, e As EventArgs) Handles btnCountry.Click
        Dim fm = New CountryForm()
        Dim SelectedIndex As Integer = -1
        For i As Integer = 0 To CountryList.Count Step 1
            If CountryList(i).Code.CompareTo(tbCountryCode.Text) = 0 Then
                SelectedIndex = i
                Exit For
            End If
        Next
        fm.BindData(CountryTable, SelectedIndex)
        Dim result As DialogResult
        result = fm.ShowDialog()
        If result = DialogResult.OK Then
            tbCountryCode.Text = fm.dgv_Country.CurrentRow.Cells(0).Value
            tbCountryName.Text = fm.dgv_Country.CurrentRow.Cells(1).Value
        End If
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles tbCompanyCode.TextChanged, tbCompanyName.TextChanged, tbAddress1.TextChanged, tbAddress2.TextChanged, tbAddress3.TextChanged, tbName1.TextChanged, tbName2.TextChanged, tbName3.TextChanged, tbTitle1.TextChanged, tbTitle2.TextChanged, tbTitle3.TextChanged, tbCountryCode.TextChanged, tbTel.TextChanged, tbFax.TextChanged, tbEmail.TextChanged, tbWebsite.TextChanged, tbTaxRegNo.TextChanged
        If LockTextBoxEvent Then
            Return
        End If
        Dim textbox As TextBox = sender
        textbox.BackColor = Color.Yellow
        TSBtn_Delete.Enabled = False
        TSBtn_Save.Enabled = True
        TSBtn_Cancel.Enabled = True
    End Sub

    Private Sub TSBtn_Add_Click(sender As Object, e As EventArgs) Handles TSBtn_Add.Click

    End Sub

    Private Sub TSBtn_Save_Click(sender As Object, e As EventArgs) Handles TSBtn_Save.Click

    End Sub

    Private Sub TSBtn_Delete_Click(sender As Object, e As EventArgs) Handles TSBtn_Delete.Click

    End Sub

    Private Sub TSBtn_Cancel_Click(sender As Object, e As EventArgs) Handles TSBtn_Cancel.Click
        CompanyInfoLoadRountineCall(NaviAction.Reload)
    End Sub
#End Region
End Class