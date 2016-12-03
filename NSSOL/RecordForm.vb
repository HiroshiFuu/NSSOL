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
        tbCountryName.Text = "Unknown"
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
            For Each ctrl As Control In gbCompanyInfo.Controls
                If ctrl.GetType() Is GetType(TextBox) Then
                    Dim textbox As TextBox = ctrl
                    textbox.Text = ""
                End If
            Next
        Else
            tbCompanyCode.Text = companyinfo.Company_Code
            tbCompanyName.Text = companyinfo.Company_Name
            tbAddress1.Text = companyinfo.Address_Line_1
            tbAddress2.Text = companyinfo.Address_Line_2
            tbAddress3.Text = companyinfo.Address_Line_3
            tbCompanyRegNo.Text = companyinfo.Company_Reg_No
            tbName1.Text = companyinfo.Authorized_Signer_Name_1
            tbName2.Text = companyinfo.Authorized_Signer_Name_2
            tbName3.Text = companyinfo.Authorized_Signer_Name_3
            tbTitle1.Text = companyinfo.Authorized_Signer_Title_1
            tbTitle2.Text = companyinfo.Authorized_Signer_Title_2
            tbTitle3.Text = companyinfo.Authorized_Signer_Title_3
            tbCountryCode.Text = companyinfo.Country
            tbTel.Text = companyinfo.Tel
            tbFax.Text = companyinfo.Fax
            tbEmail.Text = companyinfo.Email
            tbWebsite.Text = companyinfo.Website
            tbTaxRegNo.Text = companyinfo.Tax_Registration_No
            tbCreatedBy.Text = companyinfo.CreatedBy
            tbCreatedOn.Text = companyinfo.CreatedOn
            tbUpdatedBy.Text = companyinfo.UpdatedBy
            tbUpdatedOn.Text = companyinfo.UpdatedOn
        End If
        For Each ctrl As Control In gbCompanyInfo.Controls
            If ctrl.GetType() Is GetType(TextBox) Then
                Dim textbox As TextBox = ctrl
                textbox.BackColor = SystemColors.Window
            End If
        Next
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

    Private Sub SetActionBtns(state As Integer)
        Select Case state
            Case ActionBtnState.Load
                TSBtn_Add.Enabled = False
                TSBtn_Save.Enabled = False
                TSBtn_Delete.Enabled = True
                TSBtn_Cancel.Enabled = False
            Case ActionBtnState.Modified
                TSBtn_Add.Enabled = True
                TSBtn_Save.Enabled = True
                TSBtn_Delete.Enabled = False
                TSBtn_Cancel.Enabled = True
            Case ActionBtnState.Empty
                TSBtn_Add.Enabled = False
                TSBtn_Save.Enabled = False
                TSBtn_Delete.Enabled = False
                TSBtn_Cancel.Enabled = False
            Case ActionBtnState.New
                TSBtn_Add.Enabled = True
                TSBtn_Save.Enabled = False
                TSBtn_Delete.Enabled = False
                TSBtn_Cancel.Enabled = False
        End Select
    End Sub

    Private Sub CompanyInfoLoadRountineCall(action As Integer)
        Dim companyinfo As CompanyInfo = Nothing
        Dim state As Integer = -1
        If action <> NaviAction.Unload Then
            If action <> NaviAction.Reload Then
                Select Case action
                    Case NaviAction.First : SelectedCompanyInfoIndex = 0
                    Case NaviAction.Previous : SelectedCompanyInfoIndex -= 1
                    Case NaviAction.Next : SelectedCompanyInfoIndex += 1
                    Case NaviAction.Last : SelectedCompanyInfoIndex = CompanyInfoList.Count - 1
                End Select
            End If
            companyinfo = CompanyInfoList(SelectedCompanyInfoIndex)
            state = ActionBtnState.Load
        Else
            SelectedCompanyInfoIndex = -1
            companyinfo = Nothing
            state = ActionBtnState.Empty
        End If
        'Console.WriteLine("Current Index " + SelectedCompanyInfoIndex.ToString())
        SetNaviControls(SelectedCompanyInfoIndex)
        SetActionBtns(state)
        LoadCompanyInfoDataToControls(companyinfo)
    End Sub

    Public Function ValidateCompanyInfoDataFromControls()
        Dim ErrorMsg As String = ""
        If tbCompanyCode.Text.Length = 0 Then
            ErrorMsg += "Please Enter Company Code" & vbCrLf
            tbCompanyCode.BackColor = Color.Red
        End If
        If tbCompanyName.Text.Length = 0 Then
            ErrorMsg += "Please Enter Company Name" & vbCrLf
            tbCompanyName.BackColor = Color.Red
        End If
        If tbAddress1.Text.Length = 0 And tbAddress2.Text.Length = 0 And tbAddress3.Text.Length = 0 Then
            ErrorMsg += "Please Enter Address" & vbCrLf
            tbAddress1.BackColor = Color.Red
            tbAddress2.BackColor = Color.Red
            tbAddress3.BackColor = Color.Red
        End If
        If tbCountryCode.Text.Length = 0 Then
            ErrorMsg += "Please Enter Or Select Country Code" & vbCrLf
            tbCountryCode.BackColor = Color.Red
        End If
        If ErrorMsg.Length = 0 Then
            Return True
        End If
        MsgBox(ErrorMsg)
        Return False
    End Function

    Public Function LoadCompanyInfoDataFromControls(IsAdd As Boolean, UserName As String)
        Dim companyinfo As CompanyInfo = New CompanyInfo()
        companyinfo.Company_Code = tbCompanyCode.Text
        companyinfo.Company_Name = tbCompanyName.Text
        companyinfo.Address_Line_1 = tbAddress1.Text
        companyinfo.Address_Line_2 = tbAddress2.Text
        companyinfo.Address_Line_3 = tbAddress3.Text
        companyinfo.Company_Reg_No = tbCompanyRegNo.Text
        companyinfo.Authorized_Signer_Name_1 = tbName1.Text
        companyinfo.Authorized_Signer_Name_2 = tbName2.Text
        companyinfo.Authorized_Signer_Name_3 = tbName3.Text
        companyinfo.Authorized_Signer_Title_1 = tbTitle1.Text
        companyinfo.Authorized_Signer_Title_2 = tbTitle2.Text
        companyinfo.Authorized_Signer_Title_3 = tbTitle3.Text
        companyinfo.Country = tbCountryCode.Text
        companyinfo.Tel = tbTel.Text
        companyinfo.Fax = tbFax.Text
        companyinfo.Email = tbEmail.Text
        companyinfo.Website = tbWebsite.Text
        companyinfo.Tax_Registration_No = tbTaxRegNo.Text
        If IsAdd Then
            companyinfo.CreatedBy = UserName
            companyinfo.CreatedOn = DateTime.Now.ToString("dd-MM-yyyy") + " " + DateTime.Now.ToString("T")
        Else
            companyinfo.CreatedBy = tbCreatedBy.Text
            companyinfo.CreatedOn = tbCreatedOn.Text
        End If
        companyinfo.UpdatedBy = tbUpdatedBy.Text
        companyinfo.UpdatedOn = DateTime.Now.ToString("dd-MM-yyyy") + " " + DateTime.Now.ToString("T")
        companyinfo.Domestic_Currency_Code = "SGD"
        companyinfo.Tax_Currency_Code = "SGD"
        Return companyinfo
    End Function
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
        Dim textbox As TextBox = sender
        If textbox.Name.CompareTo(tbCountryCode.Name) = 0 Then
            tbCountryName.Text = "Unknown"
            For Each country As Country In CountryList
                If country.Code.CompareTo(tbCountryCode.Text) = 0 Then
                    tbCountryName.Text = country.Name
                End If
            Next
        End If
        If LockTextBoxEvent Then
            Return
        End If
        textbox.BackColor = Color.Yellow
        If textbox.Name.CompareTo(tbCompanyCode.Name) = 0 Then
            SetActionBtns(ActionBtnState.New)
            SetNaviControls(-1)
            LockTextBoxEvent = True
        Else
            SetActionBtns(ActionBtnState.Modified)
        End If
    End Sub

    Private Sub TSBtn_Add_Click(sender As Object, e As EventArgs) Handles TSBtn_Add.Click
        If Not ValidateCompanyInfoDataFromControls() Then
            Return
        End If
        Dim companyinfoDAL As CompanyInfoDAL = New CompanyInfoDAL()
        Dim companyinfo As CompanyInfo = LoadCompanyInfoDataFromControls(True, "ADMIN")
        Try
            companyinfoDAL.AddCompanyInfo(companyinfo)
            CompanyInfoList.Add(companyinfo)
            CompanyInfoLoadRountineCall(NaviAction.Last)
        Catch ex As Exception
            MsgBox("This Company Code already exists!")
            tbCompanyCode.BackColor = Color.Red
            tbCompanyCode.Focus()
            tbCompanyCode.SelectAll()
        End Try
    End Sub

    Private Sub TSBtn_Save_Click(sender As Object, e As EventArgs) Handles TSBtn_Save.Click
        If Not ValidateCompanyInfoDataFromControls() Then
            Return
        End If
        Dim companyinfoDAL As CompanyInfoDAL = New CompanyInfoDAL()
        Dim companyinfo As CompanyInfo = LoadCompanyInfoDataFromControls(False, "")
        If companyinfoDAL.UpdateCompanyInfo(companyinfo) Then
            CompanyInfoList(SelectedCompanyInfoIndex) = companyinfo
            CompanyInfoLoadRountineCall(NaviAction.Reload)
        Else
            MsgBox("Wired Error")
        End If
    End Sub

    Private Sub TSBtn_Delete_Click(sender As Object, e As EventArgs) Handles TSBtn_Delete.Click
        Dim result As DialogResult = MessageBox.Show("Do you really want to delete this record?", "Caution", MessageBoxButtons.OKCancel)
        If result = DialogResult.OK Then
            Dim companyinfoDAL As CompanyInfoDAL = New CompanyInfoDAL()
            Dim companyinfo As CompanyInfo = CompanyInfoList(SelectedCompanyInfoIndex)
            If companyinfoDAL.DelectCompanyInfo(companyinfo.Company_Code) Then
                CompanyInfoList.RemoveAt(SelectedCompanyInfoIndex)
                CompanyInfoLoadRountineCall(NaviAction.First)
                MsgBox("This record has been successfully removed.")
            Else
                MsgBox("Wired Error")
            End If
        End If
    End Sub

    Private Sub TSBtn_Cancel_Click(sender As Object, e As EventArgs) Handles TSBtn_Cancel.Click
        CompanyInfoLoadRountineCall(NaviAction.Reload)
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        CompanyInfoLoadRountineCall(NaviAction.Unload)
    End Sub

    Private Sub Load1stRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Load1stRecordToolStripMenuItem.Click
        CompanyInfoLoadRountineCall(NaviAction.First)
    End Sub
#End Region
End Class