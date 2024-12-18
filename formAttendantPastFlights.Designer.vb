<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAttendantPastFlights
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
        Me.lblMiles = New System.Windows.Forms.Label()
        Me.listFlights = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lblMiles
        '
        Me.lblMiles.AutoSize = True
        Me.lblMiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMiles.Location = New System.Drawing.Point(12, 14)
        Me.lblMiles.Name = "lblMiles"
        Me.lblMiles.Size = New System.Drawing.Size(81, 16)
        Me.lblMiles.TabIndex = 3
        Me.lblMiles.Text = "Miles Flown:"
        '
        'listFlights
        '
        Me.listFlights.FormattingEnabled = True
        Me.listFlights.Location = New System.Drawing.Point(175, 14)
        Me.listFlights.Name = "listFlights"
        Me.listFlights.Size = New System.Drawing.Size(300, 329)
        Me.listFlights.TabIndex = 2
        '
        'formAttendantPastFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 357)
        Me.Controls.Add(Me.lblMiles)
        Me.Controls.Add(Me.listFlights)
        Me.Name = "formAttendantPastFlights"
        Me.Text = "Past Flights"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMiles As Label
    Friend WithEvents listFlights As ListBox
End Class
