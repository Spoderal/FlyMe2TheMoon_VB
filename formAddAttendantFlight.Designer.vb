<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAddAttendantFlight
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.lblFlight = New System.Windows.Forms.Label()
        Me.lblAttendant = New System.Windows.Forms.Label()
        Me.comboFlight = New System.Windows.Forms.ComboBox()
        Me.comboAttendant = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(134, 159)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(13, 159)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 10
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblFlight
        '
        Me.lblFlight.AutoSize = True
        Me.lblFlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlight.Location = New System.Drawing.Point(88, 83)
        Me.lblFlight.Name = "lblFlight"
        Me.lblFlight.Size = New System.Drawing.Size(40, 16)
        Me.lblFlight.TabIndex = 9
        Me.lblFlight.Text = "Flight"
        '
        'lblAttendant
        '
        Me.lblAttendant.AutoSize = True
        Me.lblAttendant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttendant.Location = New System.Drawing.Point(74, 19)
        Me.lblAttendant.Name = "lblAttendant"
        Me.lblAttendant.Size = New System.Drawing.Size(64, 16)
        Me.lblAttendant.TabIndex = 8
        Me.lblAttendant.Text = "Attendant"
        '
        'comboFlight
        '
        Me.comboFlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboFlight.FormattingEnabled = True
        Me.comboFlight.Location = New System.Drawing.Point(13, 112)
        Me.comboFlight.Name = "comboFlight"
        Me.comboFlight.Size = New System.Drawing.Size(196, 21)
        Me.comboFlight.TabIndex = 7
        '
        'comboAttendant
        '
        Me.comboAttendant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAttendant.FormattingEnabled = True
        Me.comboAttendant.Location = New System.Drawing.Point(13, 48)
        Me.comboAttendant.Name = "comboAttendant"
        Me.comboAttendant.Size = New System.Drawing.Size(196, 21)
        Me.comboAttendant.TabIndex = 6
        '
        'formAddAttendantFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(223, 203)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.lblFlight)
        Me.Controls.Add(Me.lblAttendant)
        Me.Controls.Add(Me.comboFlight)
        Me.Controls.Add(Me.comboAttendant)
        Me.Name = "formAddAttendantFlight"
        Me.Text = "Attendant to Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents lblFlight As Label
    Friend WithEvents lblAttendant As Label
    Friend WithEvents comboFlight As ComboBox
    Friend WithEvents comboAttendant As ComboBox
End Class
