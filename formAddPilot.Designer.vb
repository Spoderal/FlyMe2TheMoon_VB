<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAddPilot
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
        Me.txtDateTermination = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.txtDateHire = New System.Windows.Forms.TextBox()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.txtDateLicense = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblDateLicense = New System.Windows.Forms.Label()
        Me.lblDateTermination = New System.Windows.Forms.Label()
        Me.lblDateHire = New System.Windows.Forms.Label()
        Me.lblEmployeeID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtLoginID = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtDateTermination
        '
        Me.txtDateTermination.Location = New System.Drawing.Point(154, 137)
        Me.txtDateTermination.Name = "txtDateTermination"
        Me.txtDateTermination.Size = New System.Drawing.Size(208, 20)
        Me.txtDateTermination.TabIndex = 99
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(259, 266)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(103, 47)
        Me.btnExit.TabIndex = 98
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(12, 266)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(103, 47)
        Me.btnSubmit.TabIndex = 97
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtDateHire
        '
        Me.txtDateHire.Location = New System.Drawing.Point(154, 108)
        Me.txtDateHire.Name = "txtDateHire"
        Me.txtDateHire.Size = New System.Drawing.Size(208, 20)
        Me.txtDateHire.TabIndex = 96
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(154, 78)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(208, 20)
        Me.txtEmployeeID.TabIndex = 94
        '
        'txtDateLicense
        '
        Me.txtDateLicense.Location = New System.Drawing.Point(154, 163)
        Me.txtDateLicense.Name = "txtDateLicense"
        Me.txtDateLicense.Size = New System.Drawing.Size(208, 20)
        Me.txtDateLicense.TabIndex = 95
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(154, 49)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(208, 20)
        Me.txtLastName.TabIndex = 93
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(154, 19)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(208, 20)
        Me.txtFirstName.TabIndex = 92
        '
        'lblDateLicense
        '
        Me.lblDateLicense.AutoSize = True
        Me.lblDateLicense.Location = New System.Drawing.Point(12, 166)
        Me.lblDateLicense.Name = "lblDateLicense"
        Me.lblDateLicense.Size = New System.Drawing.Size(87, 13)
        Me.lblDateLicense.TabIndex = 91
        Me.lblDateLicense.Text = "Date Of License:"
        '
        'lblDateTermination
        '
        Me.lblDateTermination.AutoSize = True
        Me.lblDateTermination.Location = New System.Drawing.Point(12, 137)
        Me.lblDateTermination.Name = "lblDateTermination"
        Me.lblDateTermination.Size = New System.Drawing.Size(105, 13)
        Me.lblDateTermination.TabIndex = 90
        Me.lblDateTermination.Text = "Date Of Termination:"
        '
        'lblDateHire
        '
        Me.lblDateHire.AutoSize = True
        Me.lblDateHire.Location = New System.Drawing.Point(13, 108)
        Me.lblDateHire.Name = "lblDateHire"
        Me.lblDateHire.Size = New System.Drawing.Size(69, 13)
        Me.lblDateHire.TabIndex = 89
        Me.lblDateHire.Text = "Date Of Hire:"
        '
        'lblEmployeeID
        '
        Me.lblEmployeeID.AutoSize = True
        Me.lblEmployeeID.Location = New System.Drawing.Point(12, 79)
        Me.lblEmployeeID.Name = "lblEmployeeID"
        Me.lblEmployeeID.Size = New System.Drawing.Size(70, 13)
        Me.lblEmployeeID.TabIndex = 88
        Me.lblEmployeeID.Text = "Employee ID:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Last Name:"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(13, 22)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(60, 13)
        Me.lblFirstName.TabIndex = 86
        Me.lblFirstName.Text = "First Name:"
        '
        'txtLoginID
        '
        Me.txtLoginID.Location = New System.Drawing.Point(155, 192)
        Me.txtLoginID.Name = "txtLoginID"
        Me.txtLoginID.Size = New System.Drawing.Size(208, 20)
        Me.txtLoginID.TabIndex = 103
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(155, 218)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(208, 20)
        Me.txtPassword.TabIndex = 102
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 221)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Login Password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Login ID:"
        '
        'formAddPilot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 325)
        Me.Controls.Add(Me.txtLoginID)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDateTermination)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtDateHire)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.txtDateLicense)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.lblDateLicense)
        Me.Controls.Add(Me.lblDateTermination)
        Me.Controls.Add(Me.lblDateHire)
        Me.Controls.Add(Me.lblEmployeeID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFirstName)
        Me.Name = "formAddPilot"
        Me.Text = "Add Pilot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDateTermination As TextBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents txtDateHire As TextBox
    Friend WithEvents txtEmployeeID As TextBox
    Friend WithEvents txtDateLicense As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents lblDateLicense As Label
    Friend WithEvents lblDateTermination As Label
    Friend WithEvents lblDateHire As Label
    Friend WithEvents lblEmployeeID As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents txtLoginID As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
