Imports NSSOL

Public Class SystemConfig
    Implements SystemConfigInterface

    Private Shared config As SystemConfig = Nothing

    '  Private Company_Code As String
    '  Private Company_Name varchar(255),
    'Private Address_Line_1 varchar(255) Default NULL,
    'Private Address_Line_2 varchar(255),
    'Private Address_Line_3 varchar(50) Default NULL,
    'Private Company_Reg_No varchar(11) Default NULL,
    'Private Country varchar(255) Default NULL,
    'Private Tel varchar(100) Default NULL,
    'Private Fax varchar(100) Default NULL,
    'Private Email varchar(255) Default NULL,
    'Private Website TEXT Default NULL,
    'Private Tax_Registration_No varchar(13) Default NULL,
    'Private Authorized_Signer_1 varchar(255) Default NULL,
    'Private Authorized_Signer_2 varchar(255) Default NULL,
    'Private Authorized_Signer_3 varchar(255) Default NULL,
    'Private Title_1 varchar(255) Default NULL,
    'Private Title_2 varchar(255) Default NULL,
    'Private Title_3 varchar(255) Default NULL,
    'Private Domestic_Currency_Code varchar(255) Default NULL,
    'Private Tax_Currency_Code varchar(255) Default NULL,

    Private Property User_Name As String
    Private Property Version As String
    Private Property Database As String
    Private Property Fiscal_Year As String
    Private Property Current_Period As String
    Private Property Year_Period As String
    Private Property Year_Period_To As String
    Private Property Previous_Year_Close As String
    Private Property Status As String
    Private Property Petty_Cash_Currency As String

    'restricted
    Private Sub New()
    End Sub

    Public Shared Function getInstance()
        If config Is Nothing Then
            config = New SystemConfig()
        End If
        Return config
    End Function

    Public Sub setUser_Name(value As String)
        User_Name = value
    End Sub

    Public Sub setVersion(value As String)
        Version = value
    End Sub

    Public Sub setDatabase(value As String)
        Database = value
    End Sub

    Public Sub setFiscal_Year(value As String)
        Fiscal_Year = value
    End Sub

    Public Sub setCurrent_Period(value As String)
        Current_Period = value
    End Sub

    Public Sub setYear_Period(value As String)
        Year_Period = value
    End Sub

    Public Sub setYear_Period_To(value As String)
        Year_Period_To = value
    End Sub

    Public Sub setPrevious_Year_Close(value As String)
        Previous_Year_Close = value
    End Sub

    Public Sub setStatus(value As String)
        Status = value
    End Sub

    Public Function setPetty_Cash_Currency(value As String)
        Return Petty_Cash_Currency
    End Function

    Public Function getUser_Name() As Object Implements SystemConfigInterface.getUser_Name
        Return User_Name
    End Function

    Public Function getVersion() As Object Implements SystemConfigInterface.getVersion
        Return Version
    End Function

    Public Function getDatabase() As Object Implements SystemConfigInterface.getDatabase
        Return Database
    End Function

    Public Function getFiscal_Year() As Object Implements SystemConfigInterface.getFiscal_Year
        Return Fiscal_Year
    End Function

    Public Function getCurrent_Period() As Object Implements SystemConfigInterface.getCurrent_Period
        Return Current_Period
    End Function

    Public Function getYear_Period() As Object Implements SystemConfigInterface.getYear_Period
        Return Year_Period
    End Function

    Public Function getYear_Period_To() As Object Implements SystemConfigInterface.getYear_Period_To
        Return Year_Period_To
    End Function

    Public Function getPrevious_Year_Close() As Object Implements SystemConfigInterface.getPrevious_Year_Close
        Return Previous_Year_Close
    End Function

    Public Function getStatus() As Object Implements SystemConfigInterface.getStatus
        Return Status
    End Function

    Public Function getPetty_Cash_Currency() As Object Implements SystemConfigInterface.getPetty_Cash_Currency
        Return Petty_Cash_Currency
    End Function
End Class
