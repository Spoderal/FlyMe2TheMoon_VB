Public Class formDeleteAttendant
    Private Sub formDeleteAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtAttendants As DataTable = New DataTable            ' this is the table we will load from our reader


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

        strSelect = "Select intAttendantID, strFirstName, strLastName" &
       " From TAttendants"

        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader
        dtAttendants.Load(drSourceTable)

        comboAttendant.ValueMember = "intAttendantID"
        comboAttendant.DisplayMember = "strFirstName"
        comboAttendant.DataSource = dtAttendants
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strDelete As String = ""
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim cmdDelete As OleDb.OleDbCommand
        Dim cmdDelete2 As OleDb.OleDbCommand

        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtAttendants As DataTable = New DataTable
        Dim result As DialogResult
        Dim intRowsAffected As Integer
        Dim objParam As OleDb.OleDbParameter

        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            result = MessageBox.Show("Are you sure you want to Delete Attendant: " & comboAttendant.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes



                    strDelete = "DELETE FROM TAttendantFlights WHERE intAttendantID = " & comboAttendant.SelectedValue.ToString()

                    Dim intAttendantID As Integer = CInt(comboAttendant.SelectedValue)

                    Dim cmdDeleteFlights As New OleDb.OleDbCommand("uspDeleteAttendantFlights", m_conAdministrator)
                    cmdDeleteFlights.CommandType = CommandType.StoredProcedure
                    cmdDeleteFlights.Parameters.Add("@intAttendantID", OleDb.OleDbType.Integer).Value = intAttendantID
                    cmdDeleteFlights.ExecuteNonQuery()

                    Dim cmdDeleteAttendant As New OleDb.OleDbCommand("uspDeleteAttendant", m_conAdministrator)
                    cmdDeleteAttendant.CommandType = CommandType.StoredProcedure
                    cmdDeleteAttendant.Parameters.Add("@intAttendantID", OleDb.OleDbType.Integer).Value = intAttendantID



                    intRowsAffected = cmdDeleteAttendant.ExecuteNonQuery()

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