Public Class formAddAttendantFlight
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strInsert As String = ""
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtAttendants As DataTable = New DataTable
        Dim result As DialogResult
        Dim intRowsAffected As Integer
        Dim intNextPrimaryKey As Integer

        Dim intAttendantID As String
        Dim intFlightID As String
        Dim blnValidated As Boolean = True

        Get_Validate_Input(intAttendantID, intFlightID, blnValidated)


        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            result = MessageBox.Show("Are you sure you want to add the attendant to this flight?", "Confirm Addition", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes
                    strSelect = "SELECT MAX(intAttendantFlightID) + 1 AS intNextPrimaryKey FROM TAttendantFlights"

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    drSourceTable.Read()

                    If drSourceTable.IsDBNull(0) = True Then
                        intNextPrimaryKey = 1

                    Else
                        intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))
                    End If

                    strInsert = "INSERT INTO TAttendantFlights (intAttendantFlightID, intAttendantID, intFlightID) " &
            "VALUES (" & intNextPrimaryKey & ", " & intAttendantID & ", " & intFlightID & ")"


                    Console.WriteLine(strInsert)


                    cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                    intRowsAffected = cmdInsert.ExecuteNonQuery()

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Attendant Added to Flight")

                        Me.Close()
                    End If

                    CloseDatabaseConnection()
                    Close()


            End Select


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub formAddAttendantFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtAttendants As DataTable = New DataTable            ' this is the table we will load from our reader
        Dim dtFlights As DataTable = New DataTable            ' this is the table we will load from our reader


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

        strSelect = "SELECT intFlightID, strFlightNumber " &
            "FROM TFlights " &
            "WHERE TFlights.dtmFlightDate > ?"


        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        cmdSelect.Parameters.AddWithValue("?", DateTime.Now)

        drSourceTable = cmdSelect.ExecuteReader
        dtFlights.Load(drSourceTable)

        comboFlight.ValueMember = "intFlightID"
        comboFlight.DisplayMember = "strFlightNumber"
        comboFlight.DataSource = dtFlights
    End Sub

    Private Sub Get_Validate_Input(ByRef intAttendantID As String, ByRef intFlightID As String, ByRef blnValidated As Boolean)
        Get_Validate_Attendant(intAttendantID, blnValidated)
        If blnValidated Then
            Get_Validate_Flight(intFlightID, blnValidated)
        End If
    End Sub

    Private Sub Get_Validate_Attendant(ByRef intAttendantID As String, ByRef blnValidated As Boolean)
        intAttendantID = CInt(comboAttendant.SelectedValue)
        If intAttendantID = "" Then
            MessageBox.Show("Attendant must exist.")
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_Flight(ByRef intFlightID As String, ByRef blnValidated As Boolean)
        intFlightID = CInt(comboFlight.SelectedValue)
        If intFlightID = "" Then
            MessageBox.Show("Flight must exist.")
            blnValidated = False
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class