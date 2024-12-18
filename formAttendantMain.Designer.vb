<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAttendantMain
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
        Me.lblPilot = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.comboAttendant = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblPilot
        '
        Me.lblPilot.AutoSize = True
        Me.lblPilot.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPilot.Location = New System.Drawing.Point(77, 9)
        Me.lblPilot.Name = "lblPilot"
        Me.lblPilot.Size = New System.Drawing.Size(114, 18)
        Me.lblPilot.TabIndex = 7
        Me.lblPilot.Text = "Select Attendant"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(97, 81)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 6
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'comboAttendant
        '
        Me.comboAttendant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAttendant.FormattingEnabled = True
        Me.comboAttendant.Location = New System.Drawing.Point(32, 44)
        Me.comboAttendant.Name = "comboAttendant"
        Me.comboAttendant.Size = New System.Drawing.Size(201, 21)
        Me.comboAttendant.TabIndex = 5
        '
        'formAttendantMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(264, 115)
        Me.Controls.Add(Me.lblPilot)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.comboAttendant)
        Me.Name = "formAttendantMain"
        Me.Text = "Attendant"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPilot As Label
    Friend WithEvents btnSubmit As Button
    Friend WithEvents comboAttendant As ComboBox
End Class
