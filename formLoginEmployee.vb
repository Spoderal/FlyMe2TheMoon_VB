Public Class formLoginEmployee
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim strEmployeeID As String
        Dim strPassword As String
        Dim blnValidated As Boolean = True

        Get_Validate_Input(strEmployeeID, strPassword, blnValidated)

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

                ' Define the query with conditional joins
                strSelect = "SELECT E.intEmployeeID, E.strEmployeeRole, " &
                "P.intPilotID, A.intAttendantID, AD.intAdminID " &
                "FROM TEmployees E " &
                "LEFT JOIN TPilots P ON E.intEmployeeID = P.intPilotID AND E.strEmployeeRole = 'Pilot' " &
                "LEFT JOIN TAttendants A ON E.intEmployeeID = A.intAttendantID AND E.strEmployeeRole = 'Attendant' " &
                "LEFT JOIN TAdmins AD ON E.intEmployeeID = AD.intAdminID AND E.strEmployeeRole = 'Admin' " &
                "WHERE E.strEmployeeLoginID = ? AND E.strEmployeePassword = ?"

                ' Initialize the command with the query and connection
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                ' Add parameters in the correct order
                cmdSelect.Parameters.Add(New OleDb.OleDbParameter("strEmployeeLoginID", OleDb.OleDbType.VarChar)).Value = strEmployeeID
                cmdSelect.Parameters.Add(New OleDb.OleDbParameter("strEmployeePassword", OleDb.OleDbType.VarChar)).Value = strPassword

                ' Execute the query and retrieve the result
                drSourceTable = cmdSelect.ExecuteReader()

                If drSourceTable.Read() Then
                    ' Login successful - Set global variables
                    Dim intEmployeeID As Integer = CInt(drSourceTable("intEmployeeID"))
                    Dim strRole As String = drSourceTable("strEmployeeRole").ToString()
                    Dim newIntPilotID As Integer? = If(IsDBNull(drSourceTable("intPilotID")), Nothing, CInt(drSourceTable("intPilotID")))
                    Dim newIntAttendantID As Integer? = If(IsDBNull(drSourceTable("intAttendantID")), Nothing, CInt(drSourceTable("intAttendantID")))
                    Dim newIntAdminID As Integer? = If(IsDBNull(drSourceTable("intAdminID")), Nothing, CInt(drSourceTable("intAdminID")))

                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Navigate to the appropriate form based on the role
                    If strRole.ToLower() = "pilot" Then
                        Dim pilotForm As New formPilot()
                        intPilotID = newIntPilotID
                        pilotForm.ShowDialog()
                    ElseIf strRole.ToLower() = "attendant" Then
                        Dim attendantForm As New formAttendant()
                        intAttendantID = newIntAttendantID
                        attendantForm.ShowDialog()
                    ElseIf strRole.ToLower() = "admin" Then
                        Dim adminForm As New formAdministration()
                        intAdminID = newIntAttendantID
                        adminForm.ShowDialog()
                    Else
                        MessageBox.Show("Unknown role. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' Close the current form
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
        strPassengerID = txtEmployeeID.Text
        If strPassengerID = "" Then
            MessageBox.Show("Employee ID must exist.")
            txtEmployeeID.Focus()
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
End Class