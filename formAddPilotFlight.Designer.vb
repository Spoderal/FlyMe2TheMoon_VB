<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAddPilotFlight
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
        Me.comboPilot = New System.Windows.Forms.ComboBox()
        Me.comboFlight = New System.Windows.Forms.ComboBox()
        Me.lblPilot = New System.Windows.Forms.Label()
        Me.lblFlight = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'comboPilot
        '
        Me.comboPilot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboPilot.FormattingEnabled = True
        Me.comboPilot.Location = New System.Drawing.Point(12, 37)
        Me.comboPilot.Name = "comboPilot"
        Me.comboPilot.Size = New System.Drawing.Size(196, 21)
        Me.comboPilot.TabIndex = 0
        '
        'comboFlight
        '
        Me.comboFlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboFlight.FormattingEnabled = True
        Me.comboFlight.Location = New System.Drawing.Point(12, 101)
        Me.comboFlight.Name = "comboFlight"
        Me.comboFlight.Size = New System.Drawing.Size(196, 21)
        Me.comboFlight.TabIndex = 1
        '
        'lblPilot
        '
        Me.lblPilot.AutoSize = True
        Me.lblPilot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPilot.Location = New System.Drawing.Point(87, 9)
        Me.lblPilot.Name = "lblPilot"
        Me.lblPilot.Size = New System.Drawing.Size(34, 16)
        Me.lblPilot.TabIndex = 2
        Me.lblPilot.Text = "Pilot"
        '
        'lblFlight
        '
        Me.lblFlight.AutoSize = True
        Me.lblFlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlight.Location = New System.Drawing.Point(87, 72)
        Me.lblFlight.Name = "lblFlight"
        Me.lblFlight.Size = New System.Drawing.Size(40, 16)
        Me.lblFlight.TabIndex = 3
        Me.lblFlight.Text = "Flight"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(12, 148)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 4
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(133, 148)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'formAddPilotFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(223, 203)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.lblFlight)
        Me.Controls.Add(Me.lblPilot)
        Me.Controls.Add(Me.comboFlight)
        Me.Controls.Add(Me.comboPilot)
        Me.Name = "formAddPilotFlight"
        Me.Text = "Pilot to Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents comboPilot As ComboBox
    Friend WithEvents comboFlight As ComboBox
    Friend WithEvents lblPilot As Label
    Friend WithEvents lblFlight As Label
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
End Class
