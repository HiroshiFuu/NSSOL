<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CodeNamePairForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgv_CodeNamePair = New System.Windows.Forms.DataGridView()
        Me.tbnCancel = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        CType(Me.dgv_CodeNamePair, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_CodeNamePair
        '
        Me.dgv_CodeNamePair.AllowUserToAddRows = False
        Me.dgv_CodeNamePair.AllowUserToDeleteRows = False
        Me.dgv_CodeNamePair.AllowUserToResizeColumns = False
        Me.dgv_CodeNamePair.AllowUserToResizeRows = False
        Me.dgv_CodeNamePair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_CodeNamePair.ColumnHeadersVisible = False
        Me.dgv_CodeNamePair.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgv_CodeNamePair.Location = New System.Drawing.Point(0, 0)
        Me.dgv_CodeNamePair.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.dgv_CodeNamePair.MultiSelect = False
        Me.dgv_CodeNamePair.Name = "dgv_CodeNamePair"
        Me.dgv_CodeNamePair.ReadOnly = True
        Me.dgv_CodeNamePair.RowHeadersVisible = False
        Me.dgv_CodeNamePair.RowHeadersWidth = 21
        Me.dgv_CodeNamePair.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv_CodeNamePair.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgv_CodeNamePair.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_CodeNamePair.ShowEditingIcon = False
        Me.dgv_CodeNamePair.Size = New System.Drawing.Size(317, 440)
        Me.dgv_CodeNamePair.StandardTab = True
        Me.dgv_CodeNamePair.TabIndex = 0
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
        'CodeNamePairForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(317, 486)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.tbnCancel)
        Me.Controls.Add(Me.dgv_CodeNamePair)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CodeNamePairForm"
        Me.Text = "Select"
        Me.TopMost = True
        CType(Me.dgv_CodeNamePair, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_CodeNamePair As DataGridView
    Friend WithEvents tbnCancel As Button
    Friend WithEvents btnSelect As Button
End Class
