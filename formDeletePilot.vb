Public Class formDeletePilot
    Private Sub formDeletePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtPilots As DataTable = New DataTable            ' this is the table we will load from our reader


        ' open the DB
        If OpenDatabaseConnectionSQLServer() = False Then

            ' No, warn the user ...
            MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' and close the form/application
            Me.Close()

        End If

        ' Build the select statement

        strSelect = "Select intPilotID, strFirstName, strLastName" &
       " From TPilots"

        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader
        dtPilots.Load(drSourceTable)

        comboPilot.ValueMember = "intPilotID"
        comboPilot.DisplayMember = "strFirstName"
        comboPilot.DataSource = dtPilots
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strDelete As String = ""
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim cmdDelete As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPilots As DataTable = New DataTable
        Dim result As DialogResult
        Dim intRowsAffected As Integer

        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            result = MessageBox.Show("Are you sure you want to Delete Pilot: " & comboPilot.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    strDelete = "DELETE FROM TPilotFlights WHERE intPilotID = " & comboPilot.SelectedValue.ToString()

                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    strDelete = "DELETE FROM TPilots WHERE intPilotID = " & comboPilot.SelectedValue.ToString()

                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Delete Successful")
                    End If

                    CloseDatabaseConnection()
                    Close()
            End Select


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class