<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formManagePilots
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
        Me.btnAddToFlight = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddToFlight
        '
        Me.btnAddToFlight.Location = New System.Drawing.Point(67, 175)
        Me.btnAddToFlight.Name = "btnAddToFlight"
        Me.btnAddToFlight.Size = New System.Drawing.Size(124, 41)
        Me.btnAddToFlight.TabIndex = 16
        Me.btnAddToFlight.Text = "Add Pilot To Flight"
        Me.btnAddToFlight.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(67, 97)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(124, 41)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "Delete Pilots"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(67, 24)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(124, 41)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "Add Pilots"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'formManagePilots
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 236)
        Me.Controls.Add(Me.btnAddToFlight)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Name = "formManagePilots"
        Me.Text = "Manage Pilots"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddToFlight As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAdd As Button
End Class
