<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formCreateFlight
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.txtLandingTime = New System.Windows.Forms.TextBox()
        Me.txtDepartureTime = New System.Windows.Forms.TextBox()
        Me.txtFlightNumber = New System.Windows.Forms.TextBox()
        Me.txtFlightDate = New System.Windows.Forms.TextBox()
        Me.lblLandingTime = New System.Windows.Forms.Label()
        Me.lblDepartureTime = New System.Windows.Forms.Label()
        Me.lblFlightNumber = New System.Windows.Forms.Label()
        Me.lblFlightDate = New System.Windows.Forms.Label()
        Me.comboFromAirport = New System.Windows.Forms.ComboBox()
        Me.lblFromAirport = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comboToAirport = New System.Windows.Forms.ComboBox()
        Me.lblPlane = New System.Windows.Forms.Label()
        Me.comboPlane = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(259, 256)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(103, 47)
        Me.btnExit.TabIndex = 114
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(12, 256)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(103, 47)
        Me.btnSubmit.TabIndex = 113
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtLandingTime
        '
        Me.txtLandingTime.Location = New System.Drawing.Point(154, 104)
        Me.txtLandingTime.Name = "txtLandingTime"
        Me.txtLandingTime.Size = New System.Drawing.Size(208, 20)
        Me.txtLandingTime.TabIndex = 112
        '
        'txtDepartureTime
        '
        Me.txtDepartureTime.Location = New System.Drawing.Point(154, 74)
        Me.txtDepartureTime.Name = "txtDepartureTime"
        Me.txtDepartureTime.Size = New System.Drawing.Size(208, 20)
        Me.txtDepartureTime.TabIndex = 111
        '
        'txtFlightNumber
        '
        Me.txtFlightNumber.Location = New System.Drawing.Point(154, 45)
        Me.txtFlightNumber.Name = "txtFlightNumber"
        Me.txtFlightNumber.Size = New System.Drawing.Size(208, 20)
        Me.txtFlightNumber.TabIndex = 110
        '
        'txtFlightDate
        '
        Me.txtFlightDate.Location = New System.Drawing.Point(154, 15)
        Me.txtFlightDate.Name = "txtFlightDate"
        Me.txtFlightDate.Size = New System.Drawing.Size(208, 20)
        Me.txtFlightDate.TabIndex = 109
        '
        'lblLandingTime
        '
        Me.lblLandingTime.AutoSize = True
        Me.lblLandingTime.Location = New System.Drawing.Point(13, 104)
        Me.lblLandingTime.Name = "lblLandingTime"
        Me.lblLandingTime.Size = New System.Drawing.Size(74, 13)
        Me.lblLandingTime.TabIndex = 107
        Me.lblLandingTime.Text = "Landing Time:"
        '
        'lblDepartureTime
        '
        Me.lblDepartureTime.AutoSize = True
        Me.lblDepartureTime.Location = New System.Drawing.Point(12, 75)
        Me.lblDepartureTime.Name = "lblDepartureTime"
        Me.lblDepartureTime.Size = New System.Drawing.Size(83, 13)
        Me.lblDepartureTime.TabIndex = 106
        Me.lblDepartureTime.Text = "Departure Time:"
        Me.lblDepartureTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFlightNumber
        '
        Me.lblFlightNumber.AutoSize = True
        Me.lblFlightNumber.Location = New System.Drawing.Point(12, 48)
        Me.lblFlightNumber.Name = "lblFlightNumber"
        Me.lblFlightNumber.Size = New System.Drawing.Size(75, 13)
        Me.lblFlightNumber.TabIndex = 105
        Me.lblFlightNumber.Text = "Flight Number:"
        '
        'lblFlightDate
        '
        Me.lblFlightDate.AutoSize = True
        Me.lblFlightDate.Location = New System.Drawing.Point(13, 18)
        Me.lblFlightDate.Name = "lblFlightDate"
        Me.lblFlightDate.Size = New System.Drawing.Size(58, 13)
        Me.lblFlightDate.TabIndex = 104
        Me.lblFlightDate.Text = "Flight Date"
        '
        'comboFromAirport
        '
        Me.comboFromAirport.FormattingEnabled = True
        Me.comboFromAirport.Location = New System.Drawing.Point(154, 140)
        Me.comboFromAirport.Name = "comboFromAirport"
        Me.comboFromAirport.Size = New System.Drawing.Size(208, 21)
        Me.comboFromAirport.TabIndex = 115
        '
        'lblFromAirport
        '
        Me.lblFromAirport.AutoSize = True
        Me.lblFromAirport.Location = New System.Drawing.Point(13, 143)
        Me.lblFromAirport.Name = "lblFromAirport"
        Me.lblFromAirport.Size = New System.Drawing.Size(66, 13)
        Me.lblFromAirport.TabIndex = 116
        Me.lblFromAirport.Text = "From Airport:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "To Airport:"
        '
        'comboToAirport
        '
        Me.comboToAirport.FormattingEnabled = True
        Me.comboToAirport.Location = New System.Drawing.Point(154, 176)
        Me.comboToAirport.Name = "comboToAirport"
        Me.comboToAirport.Size = New System.Drawing.Size(208, 21)
        Me.comboToAirport.TabIndex = 117
        '
        'lblPlane
        '
        Me.lblPlane.AutoSize = True
        Me.lblPlane.Location = New System.Drawing.Point(13, 215)
        Me.lblPlane.Name = "lblPlane"
        Me.lblPlane.Size = New System.Drawing.Size(37, 13)
        Me.lblPlane.TabIndex = 120
        Me.lblPlane.Text = "Plane:"
        '
        'comboPlane
        '
        Me.comboPlane.FormattingEnabled = True
        Me.comboPlane.Location = New System.Drawing.Point(154, 212)
        Me.comboPlane.Name = "comboPlane"
        Me.comboPlane.Size = New System.Drawing.Size(208, 21)
        Me.comboPlane.TabIndex = 119
        '
        'formCreateFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 315)
        Me.Controls.Add(Me.lblPlane)
        Me.Controls.Add(Me.comboPlane)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboToAirport)
        Me.Controls.Add(Me.lblFromAirport)
        Me.Controls.Add(Me.comboFromAirport)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtLandingTime)
        Me.Controls.Add(Me.txtDepartureTime)
        Me.Controls.Add(Me.txtFlightNumber)
        Me.Controls.Add(Me.txtFlightDate)
        Me.Controls.Add(Me.lblLandingTime)
        Me.Controls.Add(Me.lblDepartureTime)
        Me.Controls.Add(Me.lblFlightNumber)
        Me.Controls.Add(Me.lblFlightDate)
        Me.Name = "formCreateFlight"
        Me.Text = "Create Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents txtLandingTime As TextBox
    Friend WithEvents txtDepartureTime As TextBox
    Friend WithEvents txtFlightNumber As TextBox
    Friend WithEvents txtFlightDate As TextBox
    Friend WithEvents lblLandingTime As Label
    Friend WithEvents lblDepartureTime As Label
    Friend WithEvents lblFlightNumber As Label
    Friend WithEvents lblFlightDate As Label
    Friend WithEvents comboFromAirport As ComboBox
    Friend WithEvents lblFromAirport As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents comboToAirport As ComboBox
    Friend WithEvents lblPlane As Label
    Friend WithEvents comboPlane As ComboBox
End Class
