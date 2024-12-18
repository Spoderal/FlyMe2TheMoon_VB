<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formStatistics
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
        Me.lblCustomers = New System.Windows.Forms.Label()
        Me.lblFlights = New System.Windows.Forms.Label()
        Me.lblMiles = New System.Windows.Forms.Label()
        Me.listPilots = New System.Windows.Forms.ListBox()
        Me.listAttendants = New System.Windows.Forms.ListBox()
        Me.lblPilots = New System.Windows.Forms.Label()
        Me.lblAttendants = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblCustomers
        '
        Me.lblCustomers.AutoSize = True
        Me.lblCustomers.Location = New System.Drawing.Point(12, 20)
        Me.lblCustomers.Name = "lblCustomers"
        Me.lblCustomers.Size = New System.Drawing.Size(86, 13)
        Me.lblCustomers.TabIndex = 0
        Me.lblCustomers.Text = "Total Customers:"
        '
        'lblFlights
        '
        Me.lblFlights.AutoSize = True
        Me.lblFlights.Location = New System.Drawing.Point(12, 58)
        Me.lblFlights.Name = "lblFlights"
        Me.lblFlights.Size = New System.Drawing.Size(67, 13)
        Me.lblFlights.TabIndex = 1
        Me.lblFlights.Text = "Total Flights:"
        '
        'lblMiles
        '
        Me.lblMiles.AutoSize = True
        Me.lblMiles.Location = New System.Drawing.Point(12, 94)
        Me.lblMiles.Name = "lblMiles"
        Me.lblMiles.Size = New System.Drawing.Size(77, 13)
        Me.lblMiles.TabIndex = 2
        Me.lblMiles.Text = "Average Miles:"
        '
        'listPilots
        '
        Me.listPilots.FormattingEnabled = True
        Me.listPilots.Location = New System.Drawing.Point(17, 189)
        Me.listPilots.Name = "listPilots"
        Me.listPilots.Size = New System.Drawing.Size(256, 277)
        Me.listPilots.TabIndex = 3
        '
        'listAttendants
        '
        Me.listAttendants.FormattingEnabled = True
        Me.listAttendants.Location = New System.Drawing.Point(326, 189)
        Me.listAttendants.Name = "listAttendants"
        Me.listAttendants.Size = New System.Drawing.Size(256, 277)
        Me.listAttendants.TabIndex = 4
        '
        'lblPilots
        '
        Me.lblPilots.AutoSize = True
        Me.lblPilots.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPilots.Location = New System.Drawing.Point(102, 156)
        Me.lblPilots.Name = "lblPilots"
        Me.lblPilots.Size = New System.Drawing.Size(47, 20)
        Me.lblPilots.TabIndex = 5
        Me.lblPilots.Text = "Pilots"
        '
        'lblAttendants
        '
        Me.lblAttendants.AutoSize = True
        Me.lblAttendants.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttendants.Location = New System.Drawing.Point(416, 156)
        Me.lblAttendants.Name = "lblAttendants"
        Me.lblAttendants.Size = New System.Drawing.Size(88, 20)
        Me.lblAttendants.TabIndex = 6
        Me.lblAttendants.Text = "Attendants"
        '
        'formStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 478)
        Me.Controls.Add(Me.lblAttendants)
        Me.Controls.Add(Me.lblPilots)
        Me.Controls.Add(Me.listAttendants)
        Me.Controls.Add(Me.listPilots)
        Me.Controls.Add(Me.lblMiles)
        Me.Controls.Add(Me.lblFlights)
        Me.Controls.Add(Me.lblCustomers)
        Me.Name = "formStatistics"
        Me.Text = "Statistics"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCustomers As Label
    Friend WithEvents lblFlights As Label
    Friend WithEvents lblMiles As Label
    Friend WithEvents listPilots As ListBox
    Friend WithEvents listAttendants As ListBox
    Friend WithEvents lblPilots As Label
    Friend WithEvents lblAttendants As Label
End Class
