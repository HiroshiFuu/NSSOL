Public Class CompanyInfoDAL

    Public Sub AddCompanyInfo(companyinfo As CompanyInfo)
        Dim entities As nssolEntities = New nssolEntities()
        entities.CompanyInfos.Add(companyinfo)
        entities.Entry(companyinfo).State = EntityState.Added
        entities.SaveChanges()
    End Sub

    Public Function UpdateCompanyInfo(companyinfo As CompanyInfo)
        Dim entities As nssolEntities = New nssolEntities()
        Dim oldcompanyinfo As CompanyInfo = entities.CompanyInfos.First(Function(c) c.Company_Code = companyinfo.Company_Code)
        oldcompanyinfo.Company_Name = companyinfo.Company_Name
        oldcompanyinfo.Address_Line_1 = companyinfo.Address_Line_1
        oldcompanyinfo.Address_Line_2 = companyinfo.Address_Line_2
        oldcompanyinfo.Address_Line_3 = companyinfo.Address_Line_3
        oldcompanyinfo.Company_Reg_No = companyinfo.Company_Reg_No
        oldcompanyinfo.Authorized_Signer_Name_1 = companyinfo.Authorized_Signer_Name_1
        oldcompanyinfo.Authorized_Signer_Name_2 = companyinfo.Authorized_Signer_Name_2
        oldcompanyinfo.Authorized_Signer_Name_3 = companyinfo.Authorized_Signer_Name_3
        oldcompanyinfo.Authorized_Signer_Title_1 = companyinfo.Authorized_Signer_Title_1
        oldcompanyinfo.Authorized_Signer_Title_2 = companyinfo.Authorized_Signer_Title_2
        oldcompanyinfo.Authorized_Signer_Title_3 = companyinfo.Authorized_Signer_Title_3
        oldcompanyinfo.Country = companyinfo.Country
        oldcompanyinfo.Tel = companyinfo.Tel
        oldcompanyinfo.Fax = companyinfo.Fax
        oldcompanyinfo.Email = companyinfo.Email
        oldcompanyinfo.Website = companyinfo.Website
        oldcompanyinfo.Tax_Registration_No = companyinfo.Tax_Registration_No
        oldcompanyinfo.CreatedBy = companyinfo.CreatedBy
        oldcompanyinfo.UpdatedBy = companyinfo.UpdatedBy
        oldcompanyinfo.UpdatedOn = companyinfo.UpdatedOn
        If entities.SaveChanges() = 1 Then
            Return True
        End If
        Return False
    End Function

    Public Function DelectCompanyInfo(companycode As String)
        Dim entities As nssolEntities = New nssolEntities()
        Dim companyinfo As CompanyInfo = entities.CompanyInfos.First(Function(c) c.Company_Code = companycode)
        entities.CompanyInfos.Remove(companyinfo)
        entities.Entry(companyinfo).State = EntityState.Deleted
        If entities.SaveChanges() = 1 Then
            Return True
        End If
        Return False
    End Function

End Class
