Public Class formCreatePassenger
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim intState As Integer
        Dim strZip As String
        Dim strPhone As String
        Dim strEmail As String
        Dim strDOB As String
        Dim strLoginID As String
        Dim strPassword As String
        Dim blnValidated As Boolean = True


        Get_Validate_Input(strFirstName, strLastName, strAddress, strCity, intState, strZip, strPhone, strEmail, strDOB, strPassword, strLoginID, blnValidated)

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

                cmdInsert = New OleDb.OleDbCommand("uspAddPassenger", m_conAdministrator)
                cmdInsert.CommandType = CommandType.StoredProcedure

                ' Add parameters in the exact order they are declared in the stored procedure
                objParam = cmdInsert.Parameters.Add("@passenger_id", OleDb.OleDbType.Integer)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = intNextPrimaryKey

                objParam = cmdInsert.Parameters.Add("@first_name", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strFirstName

                objParam = cmdInsert.Parameters.Add("@last_name", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strLastName

                objParam = cmdInsert.Parameters.Add("@address", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strAddress

                objParam = cmdInsert.Parameters.Add("@city", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strCity

                objParam = cmdInsert.Parameters.Add("@state_id", OleDb.OleDbType.Integer)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = intState

                objParam = cmdInsert.Parameters.Add("@zip", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strZip

                objParam = cmdInsert.Parameters.Add("@phone_number", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strPhone

                objParam = cmdInsert.Parameters.Add("@email", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strEmail

                objParam = cmdInsert.Parameters.Add("@dob", OleDb.OleDbType.Date)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strDOB

                ' Add the password parameter
                objParam = cmdInsert.Parameters.Add("@password", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strPassword

                ' Add the loginID parameter
                objParam = cmdInsert.Parameters.Add("@loginID", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strLoginID

                Console.WriteLine(strInsert)


                intRowsAffected = cmdInsert.ExecuteNonQuery()

                If intRowsAffected > 0 Then
                    MessageBox.Show("Passenger added")

                    Me.Close()
                End If



                CloseDatabaseConnection()
                Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try


        End If
    End Sub

    Private Sub Get_Validate_Input(ByRef strFirstName As String, ByRef strLastName As String, ByRef strAddress As String, ByRef strCity As String, ByRef intState As Integer, ByRef strZip As String, ByRef strPhone As String, ByRef strEmail As String, ByRef strDOB As String, ByRef strPassword As String, ByRef strLoginID As String, ByRef blnValidated As Boolean)
        Get_Validate_FirstName(strFirstName, blnValidated)
        If blnValidated Then
            Get_Validate_LastName(strLastName, blnValidated)
            If blnValidated Then
                Get_Validate_Address(strAddress, blnValidated)
                If blnValidated Then
                    Get_Validate_City(strCity, blnValidated)
                    If blnValidated Then
                        Get_Validate_State(intState, blnValidated)
                        If blnValidated Then
                            Get_Validate_Zip(strZip, blnValidated)
                            If blnValidated Then
                                Get_Validate_Phone(strPhone, blnValidated)
                                If blnValidated Then
                                    Get_Validate_Email(strEmail, blnValidated)
                                    If blnValidated Then
                                        Get_Validate_DOB(strDOB, blnValidated)
                                        If blnValidated Then
                                            Get_Validate_Password(strPassword, blnValidated)
                                            If blnValidated Then
                                                Get_Validate_LoginID(strLoginID, blnValidated)
                                            End If
                                        End If
                                    End If
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

    Private Sub Get_Validate_Address(ByRef strAddress As String, ByRef blnValidated As Boolean)
        strAddress = txtAddress.Text
        If strAddress = "" Then
            MessageBox.Show("Address must exist.")
            txtAddress.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_City(ByRef strCity As String, ByRef blnValidated As Boolean)
        strCity = txtCity.Text
        If strCity = "" Then
            MessageBox.Show("City must exist.")
            txtCity.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_State(ByRef intState As Integer, ByRef blnValidated As Boolean)
        intState = comboState.SelectedValue
        If comboState.Text = "" Then
            MessageBox.Show("State must exist.")
            comboState.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_Zip(ByRef strZip As String, ByRef blnValidated As Boolean)
        strZip = txtZip.Text
        If strZip = "" Then
            MessageBox.Show("Zip must exist.")
            txtZip.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_Phone(ByRef strPhone As String, ByRef blnValidated As Boolean)
        strPhone = txtPhone.Text
        If strPhone = "" Then
            MessageBox.Show("Phone Number must exist.")
            txtPhone.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_Email(ByRef strEmail As String, ByRef blnValidated As Boolean)
        strEmail = txtEmail.Text
        If strEmail = "" Then
            MessageBox.Show("Email must exist.")
            txtEmail.Focus()
            blnValidated = False
        ElseIf Not strEmail.Contains("@") Then
            MessageBox.Show("Email must contain '@'.")
            txtEmail.Focus()
            blnValidated = False
        Else
            blnValidated = True
        End If
    End Sub

    Private Sub Get_Validate_DOB(ByRef strDOB As String, ByRef blnValidated As Boolean)
        strDOB = txtDOB.Text
        Dim tempDOB As DateTime ' Temporary variable to store the parsed date

        If strDOB = "" Then
            MessageBox.Show("Date of Birth must exist.")
            txtDOB.Focus()
            blnValidated = False
        ElseIf Not DateTime.TryParse(strDOB, tempDOB) Then
            MessageBox.Show("Please enter a valid date in the format MM/DD/YYYY.")
            txtDOB.Focus()
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

    Private Sub formCreatePassenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtPassengers As DataTable = New DataTable            ' this is the table we will load from our reader
        Dim dtStates As DataTable = New DataTable
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


        cmdSelect = New OleDb.OleDbCommand("uspListStates", m_conAdministrator)
        cmdSelect.CommandType = CommandType.StoredProcedure
        drSourceTable = cmdSelect.ExecuteReader
        dtStates.Load(drSourceTable)

        comboState.ValueMember = "intStateID"
        comboState.DisplayMember = "strState"
        comboState.DataSource = dtStates
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class