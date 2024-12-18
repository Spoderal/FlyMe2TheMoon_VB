Public Class formLoginPassenger
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim strPassengerID As String
        Dim strPassword As String
        Dim blnValidated As Boolean = True

        Get_Validate_Input(strPassengerID, strPassword, blnValidated)

        If blnValidated = True Then
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim cmdUpdate As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dtPilots As DataTable = New DataTable
            Dim intNextPrimaryKey As Integer
            Dim intRowsAffected As Integer
            Dim objParam As OleDb.OleDbParameter


            Try
                ' Open the database connection
                If OpenDatabaseConnectionSQLServer() = False Then
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If

                ' Define the query using parameters
                strSelect = "SELECT intPassengerID FROM TPassengers WHERE strLoginID = ? AND strPassword = ?"

                ' Initialize the command with the query and connection
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                ' Add parameters in the correct order
                cmdSelect.Parameters.Add(New OleDb.OleDbParameter("strLoginID", OleDb.OleDbType.VarChar)).Value = strPassengerID
                cmdSelect.Parameters.Add(New OleDb.OleDbParameter("strPassword", OleDb.OleDbType.VarChar)).Value = strPassword

                ' Execute the query and retrieve the result
                Dim result As Object = cmdSelect.ExecuteScalar()

                If result IsNot Nothing Then
                    ' Login successful - Set global variable
                    intCustomerID = CInt(result)
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Navigate to the appropriate form or functionality
                    Dim mainForm As New formCustomerMain
                    mainForm.ShowDialog()
                    Me.Close()
                Else
                    ' Login failed
                    MessageBox.Show("ID and/or Password are not valid.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' Close the database connection
                CloseDatabaseConnection()
            Catch ex As Exception
                ' Handle exceptions
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


        End If


    End Sub

    Private Sub Get_Validate_Input(ByRef strPassengerID As String, ByRef strPassword As String, ByRef blnValidated As Boolean)
        Get_Validate_PassengerID(strPassengerID, blnValidated)
        If blnValidated Then
            Get_Validate_Password(strPassword, blnValidated)
        End If
    End Sub

    Private Sub Get_Validate_PassengerID(ByRef strPassengerID As String, ByRef blnValidated As Boolean)
        strPassengerID = txtPassengerID.Text
        If strPassengerID = "" Then
            MessageBox.Show("Passenger ID must exist.")
            txtPassengerID.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_Password(ByRef strPassword As String, ByRef blnValidated As Boolean)
        strPassword = txtPassword.Text
        If strPassword = "" Then
            MessageBox.Show("Password must exist.")
            txtPassword.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub btnNewPassenger_Click(sender As Object, e As EventArgs) Handles btnNewPassenger.Click
        Dim frmCreatePassenger As New formCreatePassenger

        frmCreatePassenger.ShowDialog()
    End Sub
End Class