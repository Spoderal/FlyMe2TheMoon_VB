Public Class formAddPilot
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim strDateHire As String
        Dim strDateTermination As String
        Dim strDateLicense As String
        Dim strLoginID As String
        Dim strPassword As String
        Dim blnValidated As Boolean = True


        Get_Validate_Input(strFirstName, strLastName, strEmployeeID, strDateHire, strDateTermination, strDateLicense, strLoginID, strPassword, blnValidated)

        If blnValidated = True Then
            Dim strSelect As String = ""
            Dim strInsert As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim cmdInsert As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dtPilots As DataTable = New DataTable
            Dim intNextPrimaryKey As Integer
            Dim intRowsAffected As Integer
            Dim cmdUpdate As OleDb.OleDbCommand
            Dim objParam As OleDb.OleDbParameter
            Dim intNextEmployeeKey As Integer

            Try
                If OpenDatabaseConnectionSQLServer() = False Then
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If

                strSelect = "SELECT MAX(intPilotID) + 1 AS intNextPrimaryKey" &
                    " FROM TPilots"

                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                drSourceTable.Read()

                If drSourceTable.IsDBNull(0) = True Then
                    intNextPrimaryKey = 1

                Else
                    intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))
                End If

                cmdInsert = New OleDb.OleDbCommand("uspAddPilot", m_conAdministrator)
                cmdInsert.CommandType = CommandType.StoredProcedure


                objParam = cmdInsert.Parameters.Add("@intPilotID", OleDb.OleDbType.Integer)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = intNextPrimaryKey


                objParam = cmdInsert.Parameters.Add("@strFirstName", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strFirstName

                objParam = cmdInsert.Parameters.Add("@strLastName", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strLastName

                objParam = cmdInsert.Parameters.Add("@strEmployeeID", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strEmployeeID

                objParam = cmdInsert.Parameters.Add("@dtmDateofHire", OleDb.OleDbType.Date)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strDateHire

                objParam = cmdInsert.Parameters.Add("@dtmDateofTermination", OleDb.OleDbType.Date)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strDateTermination

                objParam = cmdInsert.Parameters.Add("@dtmDateofLicense", OleDb.OleDbType.Date)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strDateLicense

                objParam = cmdInsert.Parameters.Add("@intPilotRoleID", OleDb.OleDbType.Integer)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = 1



                intRowsAffected = cmdInsert.ExecuteNonQuery()

                If intRowsAffected > 0 Then

                    strSelect = "SELECT MAX(intEmployeesID) + 1 AS intNextEmployeeKey" &
                    " FROM TEmployees"

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    drSourceTable.Read()

                    If drSourceTable.IsDBNull(0) = True Then
                        intNextEmployeeKey = 1

                    Else
                        intNextEmployeeKey = CInt(drSourceTable("intNextEmployeeKey"))
                    End If

                    Dim cmdInsertEmployee = New OleDb.OleDbCommand("uspAddEmployee", m_conAdministrator)
                    cmdInsertEmployee.CommandType = CommandType.StoredProcedure

                    objParam = cmdInsertEmployee.Parameters.Add("@intEmployeesID", OleDb.OleDbType.Integer)
                    objParam.Direction = ParameterDirection.Input
                    objParam.Value = intNextEmployeeKey


                    objParam = cmdInsertEmployee.Parameters.Add("@strLoginID", OleDb.OleDbType.VarChar)
                    objParam.Direction = ParameterDirection.Input
                    objParam.Value = strLoginID

                    objParam = cmdInsertEmployee.Parameters.Add("@strPassword", OleDb.OleDbType.VarChar)
                    objParam.Direction = ParameterDirection.Input
                    objParam.Value = strPassword

                    objParam = cmdInsertEmployee.Parameters.Add("@strEmployeeRole", OleDb.OleDbType.VarChar)
                    objParam.Direction = ParameterDirection.Input
                    objParam.Value = "Pilot"

                    objParam = cmdInsertEmployee.Parameters.Add("@intEmployeeID", OleDb.OleDbType.Integer)
                    objParam.Direction = ParameterDirection.Input
                    objParam.Value = intNextPrimaryKey

                    intRowsAffected = cmdInsertEmployee.ExecuteNonQuery()

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Pilot and Employee added successfully.")
                        Me.Close()
                    End If
                End If

                CloseDatabaseConnection()
                Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try


        End If
    End Sub

    Private Sub Get_Validate_Input(ByRef strFirstName As String, ByRef strLastName As String, ByRef strEmployeeID As String, ByRef strDateHire As String, ByRef strDateTermination As String, ByRef strDateLicense As String, ByRef strLoginID As String, ByRef strPassword As String, ByRef blnValidated As Boolean)
        Get_Validate_FirstName(strFirstName, blnValidated)
        If blnValidated Then
            Get_Validate_LastName(strLastName, blnValidated)
            If blnValidated Then
                Get_Validate_EmployeeID(strEmployeeID, blnValidated)
                If blnValidated Then
                    Get_Validate_DateHire(strDateHire, blnValidated)
                    If blnValidated Then
                        Get_Validate_DateTermination(strDateTermination, blnValidated)
                        If blnValidated Then
                            Get_Validate_DateLicense(strDateLicense, blnValidated)
                            If blnValidated Then
                                Get_Validate_LoginID(strLoginID, blnValidated)
                                If blnValidated Then
                                    Get_Validate_Password(strPassword, blnValidated)


                                End If

                            End If

                        End If
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub Get_Validate_FirstName(ByRef strFirstName As String, ByRef blnValidated As Boolean)
        strFirstName = txtFirstName.Text
        If strFirstName = "" Then
            MessageBox.Show("First Name must exist.")
            txtFirstName.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_LastName(ByRef strLastName As String, ByRef blnValidated As Boolean)
        strLastName = txtLastName.Text
        If strLastName = "" Then
            MessageBox.Show("Last Name must exist.")
            txtLastName.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_EmployeeID(ByRef strEmployeeID As String, ByRef blnValidated As Boolean)
        strEmployeeID = txtEmployeeID.Text
        If strEmployeeID = "" Then
            MessageBox.Show("Employee ID must exist.")
            txtEmployeeID.Focus()
            blnValidated = False
        End If
    End Sub
    Private Sub Get_Validate_DateHire(ByRef strDateHire As String, ByRef blnValidated As Boolean)
        strDateHire = txtDateHire.Text
        If strDateHire = "" Then
            MessageBox.Show("Date Of Hire must exist.")
            txtDateHire.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_DateTermination(ByRef strDateTermination As String, ByRef blnValidated As Boolean)
        strDateTermination = txtDateTermination.Text
        If strDateTermination = "" Then
            MessageBox.Show("Date Of Termination must exist.")
            txtDateTermination.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_DateLicense(ByRef strDateLicense As String, ByRef blnValidated As Boolean)
        strDateLicense = txtDateLicense.Text
        If strDateLicense = "" Then
            MessageBox.Show("Date Of License must exist.")
            txtDateLicense.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_LoginID(ByRef strLoginID As String, ByRef blnValidated As Boolean)
        strLoginID = txtLoginID.Text
        If strLoginID = "" Then
            MessageBox.Show("Login ID must exist.")
            txtLoginID.Focus()
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class