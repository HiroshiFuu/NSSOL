<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CountryForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgv_Country = New System.Windows.Forms.DataGridView()
        Me.tbnCancel = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        CType(Me.dgv_Country, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Country
        '
        Me.dgv_Country.AllowUserToAddRows = False
        Me.dgv_Country.AllowUserToDeleteRows = False
        Me.dgv_Country.AllowUserToResizeColumns = False
        Me.dgv_Country.AllowUserToResizeRows = False
        Me.dgv_Country.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Country.ColumnHeadersVisible = False
        Me.dgv_Country.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgv_Country.Location = New System.Drawing.Point(0, 0)
        Me.dgv_Country.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.dgv_Country.MultiSelect = False
        Me.dgv_Country.Name = "dgv_Country"
        Me.dgv_Country.ReadOnly = True
        Me.dgv_Country.RowHeadersVisible = False
        Me.dgv_Country.RowHeadersWidth = 21
        Me.dgv_Country.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv_Country.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgv_Country.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Country.ShowEditingIcon = False
        Me.dgv_Country.Size = New System.Drawing.Size(317, 440)
        Me.dgv_Country.StandardTab = True
        Me.dgv_Country.TabIndex = 0
        '
        'tbnCancel
        '
        Me.tbnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.tbnCancel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tbnCancel.Location = New System.Drawing.Point(0, 463)
        Me.tbnCancel.Name = "tbnCancel"
        Me.tbnCancel.Size = New System.Drawing.Size(317, 23)
        Me.tbnCancel.TabIndex = 1
        Me.tbnCancel.Text = "Cancel"
        Me.tbnCancel.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSelect.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSelect.Location = New System.Drawing.Point(0, 440)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(317, 23)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'CountryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(317, 486)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.tbnCancel)
        Me.Controls.Add(Me.dgv_Country)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CountryForm"
        Me.Text = "Select Country"
        Me.TopMost = True
        CType(Me.dgv_Country, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_Country As DataGridView
    Friend WithEvents tbnCancel As Button
    Friend WithEvents btnSelect As Button
End Class
