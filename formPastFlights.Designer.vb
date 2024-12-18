<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formPastFlights
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
        Me.listFlights = New System.Windows.Forms.ListBox()
        Me.lblMiles = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'listFlights
        '
        Me.listFlights.FormattingEnabled = True
        Me.listFlights.Location = New System.Drawing.Point(175, 12)
        Me.listFlights.Name = "listFlights"
        Me.listFlights.Size = New System.Drawing.Size(300, 329)
        Me.listFlights.TabIndex = 0
        '
        'lblMiles
        '
        Me.lblMiles.AutoSize = True
        Me.lblMiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMiles.Location = New System.Drawing.Point(12, 12)
        Me.lblMiles.Name = "lblMiles"
        Me.lblMiles.Size = New System.Drawing.Size(81, 16)
        Me.lblMiles.TabIndex = 1
        Me.lblMiles.Text = "Miles Flown:"
        '
        'formPastFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 357)
        Me.Controls.Add(Me.lblMiles)
        Me.Controls.Add(Me.listFlights)
        Me.Name = "formPastFlights"
        Me.Text = "Past Flights"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents listFlights As ListBox
    Friend WithEvents lblMiles As Label
End Class
