Public Class NSSOL_DAL
    Public Function AddNSSOL(companinfo As CompanyInfo)
        Dim entities As nssolEntities = New nssolEntities()
        entities.CompanyInfos.Add(companinfo)
        If entities.SaveChanges() = 1 Then
            Return True
        End If
        Return False
    End Function
End Class
