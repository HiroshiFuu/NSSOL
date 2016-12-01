Imports System.Collections.Specialized
Imports System.Configuration
Imports System.IO
Imports System.Reflection
Imports System.Xml

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setupConfigFile()
        Dim fm As RecordForm = RecordForm.getInstance(Me)
        fm.Show()
        fm.MdiParent = Me
        fm.Dock = DockStyle.Fill
        fm.WindowState = FormWindowState.Maximized
        fm.WindowState = FormWindowState.Normal
        fm.Dock = DockStyle.Fill
    End Sub

    Private Sub setupConfigFile()
        Dim codeBase As String = [Assembly].GetExecutingAssembly().CodeBase
        Dim codeBaseDir As String = Path.GetDirectoryName(codeBase)
        Dim configFilename As String = Path.Combine(codeBaseDir, "SystemConfig.config")
        Dim doc As XmlDocument = New XmlDocument()
        Try
            doc.Load(configFilename)
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, "Error! Cannot find SystemConfig.config file")
            Me.Dispose()
        End Try

        Try
            Dim xNode As XmlNode = doc.GetElementsByTagName("SystemConfig").Item(0)
            Dim csh As IConfigurationSectionHandler = New NameValueSectionHandler()
            Dim nvc As NameValueCollection = CType(csh.Create(Nothing, Nothing, xNode), NameValueCollection)

            Dim config As SystemConfig = SystemConfig.getInstance()
            config.setUser_Name(nvc("User Name"))
            config.setVersion(nvc("Version"))
            config.setDatabase(nvc("Database"))
            config.setFiscal_Year(nvc("Fiscal Year"))
            config.setCurrent_Period(nvc("Current Period"))
            config.setYear_Period(nvc("Year Period"))
            config.setYear_Period_To(nvc("Year Period To"))
            config.setPrevious_Year_Close(nvc("Previous Year Close"))
            config.setStatus(nvc("Status"))
            config.setPetty_Cash_Currency(nvc("Petty Cash Currency"))
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, "Error! Cannot read SystemConfig.config file")
            Me.Dispose()
        End Try

    End Sub
End Class
