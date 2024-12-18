Public Class formUpdateAttendant
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim strDateHire As String
        Dim strDateTermination As String
        Dim strLoginID As String
        Dim strPassword As String
        Dim strRole As String = "Attendant"
        Dim blnValidated As Boolean = True


        Get_Validate_Input(strFirstName, strLastName, strEmployeeID, strDateHire, strDateTermination, strLoginID, strPassword, blnValidated)

        If blnValidated = True Then
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim cmdUpdate As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dtPilots As DataTable = New DataTable
            Dim intNextPrimaryKey As Integer
            Dim intRowsAffected As Integer

            Try
                If OpenDatabaseConnectionSQLServer() = False Then
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If

                strSelect = "SELECT *" &
                    " FROM TAttendants WHERE intAttendantID = " & intAttendantID

                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                drSourceTable.Read()

                strSelect = "UPDATE TAttendants SET " &
            "strFirstName = '" & strFirstName & "', " &
            "strLastName = '" & strLastName & "', " &
            "strEmployeeID = '" & strEmployeeID & "', " &
            "dtmDateofHire = '" & strDateHire & "', " &
            "dtmDateofTermination = '" & strDateTermination & "' " &
            "WHERE intAttendantID = " & intAttendantID

                cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                strSelect = "UPDATE TEmployees SET " &
            "strEmployeeLoginID = '" & strLoginID & "', " &
            "strEmployeePassword = '" & strPassword & "' " &
            "WHERE intEmployeeID = " & intAttendantID & " AND strEmployeeRole = '" & strRole & "'"

                cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                MessageBox.Show("Updated")


                CloseDatabaseConnection()
                Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try


        End If
    End Sub

    Private Sub formUpdateAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtAttendants As DataTable = New DataTable            ' this is the table we will load from our reader
        Dim objParam As OleDb.OleDbParameter

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

        Console.WriteLine(intPilotID)
        ' Build the select statement

        strSelect = "Select intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination" &
       " From TAttendants" & " WHERE intAttendantID = " & intAttendantID
        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader
        drSourceTable.Read()

        txtFirstName.Text = drSourceTable("strFirstName")
        txtLastName.Text = drSourceTable("strLastName")
        txtEmployeeID.Text = drSourceTable("strEmployeeID")
        txtDateHire.Text = drSourceTable("dtmDateofHire")
        txtDateTermination.Text = drSourceTable("dtmDateofTermination")

        cmdSelect = New OleDb.OleDbCommand("uspFindEmployee", m_conAdministrator)
        cmdSelect.CommandType = CommandType.StoredProcedure

        objParam = cmdSelect.Parameters.Add("@employee_id", OleDb.OleDbType.Integer)
        objParam.Direction = ParameterDirection.Input
        objParam.Value = intAttendantID

        objParam = cmdSelect.Parameters.Add("@role", OleDb.OleDbType.VarChar)
        objParam.Direction = ParameterDirection.Input
        objParam.Value = "Attendant"

        drSourceTable = cmdSelect.ExecuteReader
        drSourceTable.Read()

        txtLoginID.Text = drSourceTable("strEmployeeLoginID")
        txtPassword.Text = drSourceTable("strEmployeePassword")
    End Sub

    Private Sub Get_Validate_Input(ByRef strFirstName As String, ByRef strLastName As String, ByRef strEmployeeID As String, ByRef strDateHire As String, ByRef strDateTermination As String, ByRef strLoginID As String, ByRef strPassword As String, ByRef blnValidated As Boolean)
        Get_Validate_FirstName(strFirstName, blnValidated)
        If blnValidated Then
            Get_Validate_LastName(strLastName, blnValidated)
            If blnValidated Then
                Get_Validate_EmployeeID(strEmployeeID, blnValidated)
                If blnValidated Then
                    Get_Validate_DateHire(strDateHire, blnValidated)
                    If blnValidated Then
                        Get_Validate_DateTermination(strDateTermination, blnValidated)

                    End If
                    If blnValidated Then
                        Get_Validate_LoginID(strLoginID, blnValidated)
                        If blnValidated Then
                            Get_Validate_Password(strPassword, blnValidated)

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