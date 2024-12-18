<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAdministration
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
        Me.btnStats = New System.Windows.Forms.Button()
        Me.btnManageAttendants = New System.Windows.Forms.Button()
        Me.btnManagePilots = New System.Windows.Forms.Button()
        Me.btnCreateFlight = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnStats
        '
        Me.btnStats.Location = New System.Drawing.Point(67, 219)
        Me.btnStats.Name = "btnStats"
        Me.btnStats.Size = New System.Drawing.Size(124, 41)
        Me.btnStats.TabIndex = 13
        Me.btnStats.Text = "FlyMe2theMoon Statistics"
        Me.btnStats.UseVisualStyleBackColor = True
        '
        'btnManageAttendants
        '
        Me.btnManageAttendants.Location = New System.Drawing.Point(67, 97)
        Me.btnManageAttendants.Name = "btnManageAttendants"
        Me.btnManageAttendants.Size = New System.Drawing.Size(124, 41)
        Me.btnManageAttendants.TabIndex = 12
        Me.btnManageAttendants.Text = "Manage Attendants"
        Me.btnManageAttendants.UseVisualStyleBackColor = True
        '
        'btnManagePilots
        '
        Me.btnManagePilots.Location = New System.Drawing.Point(67, 24)
        Me.btnManagePilots.Name = "btnManagePilots"
        Me.btnManagePilots.Size = New System.Drawing.Size(124, 41)
        Me.btnManagePilots.TabIndex = 11
        Me.btnManagePilots.Text = "Manage Pilots"
        Me.btnManagePilots.UseVisualStyleBackColor = True
        '
        'btnCreateFlight
        '
        Me.btnCreateFlight.Location = New System.Drawing.Point(67, 155)
        Me.btnCreateFlight.Name = "btnCreateFlight"
        Me.btnCreateFlight.Size = New System.Drawing.Size(124, 41)
        Me.btnCreateFlight.TabIndex = 14
        Me.btnCreateFlight.Text = "Create Flight"
        Me.btnCreateFlight.UseVisualStyleBackColor = True
        '
        'formAdministration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 281)
        Me.Controls.Add(Me.btnCreateFlight)
        Me.Controls.Add(Me.btnStats)
        Me.Controls.Add(Me.btnManageAttendants)
        Me.Controls.Add(Me.btnManagePilots)
        Me.Name = "formAdministration"
        Me.Text = "Administration"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnStats As Button
    Friend WithEvents btnManageAttendants As Button
    Friend WithEvents btnManagePilots As Button
    Friend WithEvents btnCreateFlight As Button
End Class
