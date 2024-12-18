Public Class formUpdateCustomer
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim intState As Integer
        Dim strZip As String
        Dim strPhone As String
        Dim strEmail As String
        Dim strLoginID As String
        Dim strPassword As String
        Dim blnValidated As Boolean = True


        Get_Validate_Input(strFirstName, strLastName, strAddress, strCity, intState, strZip, strPhone, strEmail, strLoginID, strPassword, blnValidated)

        If blnValidated = True Then
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim cmdUpdate As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dtPassengers As DataTable = New DataTable
            Dim objParam As OleDb.OleDbParameter
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
                    " FROM TPassengers WHERE intPassengerID = " & intCustomerID

                cmdUpdate = New OleDb.OleDbCommand("uspUpdatePassenger", m_conAdministrator)
                cmdUpdate.CommandType = CommandType.StoredProcedure


                objParam = cmdUpdate.Parameters.Add("@passenger_id", OleDb.OleDbType.Integer)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = intCustomerID


                objParam = cmdUpdate.Parameters.Add("@first_name", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strFirstName

                objParam = cmdUpdate.Parameters.Add("@last_name", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strLastName

                objParam = cmdUpdate.Parameters.Add("@address", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strAddress

                objParam = cmdUpdate.Parameters.Add("@city", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strCity

                objParam = cmdUpdate.Parameters.Add("@state_id", OleDb.OleDbType.Integer)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = intState

                objParam = cmdUpdate.Parameters.Add("@zip", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strZip

                objParam = cmdUpdate.Parameters.Add("@phone_number", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strPhone

                objParam = cmdUpdate.Parameters.Add("@email", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strEmail

                objParam = cmdUpdate.Parameters.Add("@loginid", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strLoginID

                objParam = cmdUpdate.Parameters.Add("@password", OleDb.OleDbType.VarChar)
                objParam.Direction = ParameterDirection.Input
                objParam.Value = strPassword

                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                MessageBox.Show("Updated")


                CloseDatabaseConnection()
                Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try


        End If
    End Sub

    Private Sub Get_Validate_Input(ByRef strFirstName As String, ByRef strLastName As String, ByRef strAddress As String, ByRef strCity As String, ByRef intState As Integer, ByRef strZip As String, ByRef strPhone As String, ByRef strEmail As String, ByRef strLoginID As String, ByRef strPassword As String, ByRef blnValidated As Boolean)
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

    Private Sub formUpdateCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand("uspFindPassenger", m_conAdministrator)
        cmdSelect.CommandType = CommandType.StoredProcedure

        objParam = cmdSelect.Parameters.Add("@passenger_id", OleDb.OleDbType.Integer)
        objParam.Direction = ParameterDirection.Input
        objParam.Value = intCustomerID

        drSourceTable = cmdSelect.ExecuteReader
        drSourceTable.Read()

        txtFirstName.Text = drSourceTable("strFirstName")
        txtLastName.Text = drSourceTable("strLastName")
        txtAddress.Text = drSourceTable("strAddress")
        txtCity.Text = drSourceTable("strCity")
        comboState.SelectedValue = drSourceTable("intStateID")
        txtZip.Text = drSourceTable("strZip")
        txtPhone.Text = drSourceTable("strPhoneNumber")
        txtEmail.Text = drSourceTable("strEmail")
        txtLoginID.Text = drSourceTable("strLoginID")
        txtPassword.Text = drSourceTable("strPassword")


        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand("uspListStates", m_conAdministrator)
        cmdSelect.CommandType = CommandType.StoredProcedure
        drSourceTable = cmdSelect.ExecuteReader
        dtStates.Load(drSourceTable)

        comboState.ValueMember = "intStateID"
        comboState.DisplayMember = "strState"
        comboState.DataSource = dtStates
    End Sub
End Class