Public Class formAddPilotFlight
    Private Sub formAddPilotFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtPilots As DataTable = New DataTable            ' this is the table we will load from our reader
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

        strSelect = "Select intPilotID, strFirstName, strLastName" &
       " From TPilots"

        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader
        dtPilots.Load(drSourceTable)

        comboPilot.ValueMember = "intPilotID"
        comboPilot.DisplayMember = "strFirstName"
        comboPilot.DataSource = dtPilots

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

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strInsert As String = ""
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPilots As DataTable = New DataTable
        Dim result As DialogResult
        Dim intRowsAffected As Integer
        Dim intNextPrimaryKey As Integer

        Dim intPilotID As String
        Dim intFlightID As String
        Dim blnValidated As Boolean = True

        Get_Validate_Input(intPilotID, intFlightID, blnValidated)


        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            result = MessageBox.Show("Are you sure you want to add the pilot to this flight?", "Confirm Addition", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes
                    strSelect = "SELECT MAX(intPilotFlightID) + 1 AS intNextPrimaryKey FROM TPilotFlights"

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    drSourceTable.Read()

                    If drSourceTable.IsDBNull(0) = True Then
                        intNextPrimaryKey = 1

                    Else
                        intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))
                    End If

                    strInsert = "INSERT INTO TPilotFlights (intPilotFlightID, intPilotID, intFlightID) " &
            "VALUES (" & intNextPrimaryKey & ", " & intPilotID & ", " & intFlightID & ")"


                    Console.WriteLine(strInsert)


                    cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                    intRowsAffected = cmdInsert.ExecuteNonQuery()

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Pilot Added to Flight")

                        Me.Close()
                    End If

                    CloseDatabaseConnection()
                    Close()


            End Select


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub


    Private Sub Get_Validate_Input(ByRef intPilotID As String, ByRef intFlightID As String, ByRef blnValidated As Boolean)
        Get_Validate_Pilot(intPilotID, blnValidated)
        If blnValidated Then
            Get_Validate_Flight(intFlightID, blnValidated)
        End If
    End Sub

    Private Sub Get_Validate_Pilot(ByRef intPilotID As String, ByRef blnValidated As Boolean)
        intPilotID = CInt(comboPilot.SelectedValue)
        If intPilotID = "" Then
            MessageBox.Show("Pilot must exist.")
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