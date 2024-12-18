Public Class formCreateFlight


    Private Sub formCreateFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtFromAirports As DataTable = New DataTable            ' this is the table we will load from our reader
        Dim dtToAirports As DataTable = New DataTable            ' this is the table we will load from our reader

        Dim dtPlanes As DataTable = New DataTable
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
        cmdSelect = New OleDb.OleDbCommand("uspListPlanes", m_conAdministrator)
        cmdSelect.CommandType = CommandType.StoredProcedure
        drSourceTable = cmdSelect.ExecuteReader
        dtPlanes.Load(drSourceTable)

        comboPlane.ValueMember = "intPlaneID"
        comboPlane.DisplayMember = "strPlaneNumber"
        comboPlane.DataSource = dtPlanes

        cmdSelect = New OleDb.OleDbCommand("uspListAirports", m_conAdministrator)
        cmdSelect.CommandType = CommandType.StoredProcedure
        drSourceTable = cmdSelect.ExecuteReader
        dtToAirports.Load(drSourceTable)

        comboToAirport.ValueMember = "intAirportID"
        comboToAirport.DisplayMember = "strAirportCode"
        comboToAirport.DataSource = dtToAirports

        cmdSelect = New OleDb.OleDbCommand("uspListAirports", m_conAdministrator)
        cmdSelect.CommandType = CommandType.StoredProcedure
        drSourceTable = cmdSelect.ExecuteReader
        dtFromAirports.Load(drSourceTable)

        comboFromAirport.ValueMember = "intAirportID"
        comboFromAirport.DisplayMember = "strAirportCode"
        comboFromAirport.DataSource = dtFromAirports

    End Sub

    Private Sub Get_Validate_Input(ByRef strFlightDate As String, ByRef strFlightNumber As String, ByRef strDepartureTime As String, ByRef strLandingTime As String, ByRef intFromAirportID As Integer, ByRef intToAirportID As Integer, ByRef intPlaneID As Integer, ByRef blnValidated As Boolean)
        Get_Validate_FlightDate(strFlightDate, blnValidated)
        If blnValidated Then
            Get_Validate_FlightNumber(strFlightNumber, blnValidated)
            If blnValidated Then
                Get_Validate_DepartureTime(strDepartureTime, blnValidated)
                If blnValidated Then
                    Get_Validate_LandingTime(strLandingTime, blnValidated)
                    If blnValidated Then
                        Get_Validate_FromAirport(intFromAirportID, blnValidated)
                        If blnValidated Then
                            Get_Validate_ToAirport(intToAirportID, blnValidated)
                            If blnValidated Then
                                Get_Validate_Plane(intPlaneID, blnValidated)

                            End If

                        End If
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub Get_Validate_FlightDate(ByRef strFlightDate As String, ByRef blnValidated As Boolean)
        strFlightDate = txtFlightDate.Text

        If String.IsNullOrWhiteSpace(strFlightDate) Then
            MessageBox.Show("Flight Date must exist.")
            txtFlightDate.Focus()
            blnValidated = False
            Return
        End If

        Dim flightDate As DateTime
        If Not DateTime.TryParse(strFlightDate, flightDate) Then
            MessageBox.Show("Invalid Flight Date. Please enter a valid date in the format MM/DD/YYYY.")
            txtFlightDate.Focus()
            blnValidated = False
            Return
        End If

        If flightDate <= DateTime.Now.Date Then
            MessageBox.Show("Flight Date must be in the future.")
            txtFlightDate.Focus()
            blnValidated = False
            Return
        End If
    End Sub

    Private Sub Get_Validate_FlightNumber(ByRef strFlightNumber As String, ByRef blnValidated As Boolean)
        strFlightNumber = txtFlightNumber.Text
        If strFlightNumber = "" Then
            MessageBox.Show("Flight Number must exist.")
            txtFlightNumber.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_DepartureTime(ByRef strDepartureTime As String, ByRef blnValidated As Boolean)
        strDepartureTime = txtDepartureTime.Text
        If strDepartureTime = "" Then
            MessageBox.Show("Departure Time must exist.")
            txtDepartureTime.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_LandingTime(ByRef strLandingTime As String, ByRef blnValidated As Boolean)
        strLandingTime = txtLandingTime.Text
        If strLandingTime = "" Then
            MessageBox.Show("Landing Time must exist.")
            txtLandingTime.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_FromAirport(ByRef intFromAirportID As Integer, ByRef blnValidated As Boolean)
        intFromAirportID = comboFromAirport.SelectedValue
        If comboFromAirport.Text = "" Then
            MessageBox.Show("From Airport must exist.")
            comboFromAirport.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_ToAirport(ByRef intToAirportID As Integer, ByRef blnValidated As Boolean)
        intToAirportID = comboToAirport.SelectedValue
        If comboToAirport.Text = "" Then
            MessageBox.Show("To Airport must exist.")
            comboToAirport.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub Get_Validate_Plane(ByRef intPlaneID As Integer, ByRef blnValidated As Boolean)
        intPlaneID = comboPlane.SelectedValue
        If comboPlane.Text = "" Then
            MessageBox.Show("Plane must exist.")
            comboPlane.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFlightDate As String
        Dim strFlightNumber As String
        Dim strDepartureTime As String
        Dim strLandingTime As String
        Dim intFromAirportID As Integer
        Dim intToAirportID As Integer
        Dim intPlaneID As Integer
        Dim blnValidated As Boolean = True

        Dim departureTime As TimeSpan
        Dim landingTime As TimeSpan

        Get_Validate_Input(strFlightDate, strFlightNumber, strDepartureTime, strLandingTime, intFromAirportID, intToAirportID, intPlaneID, blnValidated)

        If Not blnValidated Then
            Return
        End If

        ' Validate and convert the departure time
        If Not TimeSpan.TryParse(strDepartureTime, departureTime) Then
            MessageBox.Show("Invalid departure time. Please use a valid time format (e.g., HH:mm).")
            txtDepartureTime.Focus()
            Return
        End If

        ' Validate and convert the landing time
        If Not TimeSpan.TryParse(strLandingTime, landingTime) Then
            MessageBox.Show("Invalid landing time. Please use a valid time format (e.g., HH:mm).")
            txtLandingTime.Focus()
            Return
        End If

        If blnValidated Then
            Try
                If OpenDatabaseConnectionSQLServer() = False Then
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If

                ' Generate next primary key
                Dim cmdSelect As New OleDb.OleDbCommand("SELECT MAX(intFlightID) + 1 AS intNextPrimaryKey FROM TFlights", m_conAdministrator)
                Dim drSourceTable As OleDb.OleDbDataReader = cmdSelect.ExecuteReader()
                drSourceTable.Read()

                Dim intNextPrimaryKey As Integer = If(drSourceTable.IsDBNull(0), 1, CInt(drSourceTable("intNextPrimaryKey")))
                drSourceTable.Close()

                ' Insert the new flight
                Dim cmdInsert As New OleDb.OleDbCommand("uspCreateFlight", m_conAdministrator) With {.CommandType = CommandType.StoredProcedure}
                cmdInsert.Parameters.Add("@flight_id", OleDb.OleDbType.Integer).Value = intNextPrimaryKey
                cmdInsert.Parameters.Add("@flight_date", OleDb.OleDbType.Date).Value = strFlightDate
                cmdInsert.Parameters.Add("@flight_number", OleDb.OleDbType.VarChar).Value = strFlightNumber
                cmdInsert.Parameters.Add("@departure_time", OleDb.OleDbType.DBTime).Value = departureTime
                cmdInsert.Parameters.Add("@landing_time", OleDb.OleDbType.DBTime).Value = landingTime
                cmdInsert.Parameters.Add("@from_airport", OleDb.OleDbType.Integer).Value = intFromAirportID
                cmdInsert.Parameters.Add("@to_airport", OleDb.OleDbType.Integer).Value = intToAirportID
                cmdInsert.Parameters.Add("@plane_id", OleDb.OleDbType.Integer).Value = intPlaneID

                Dim intRowsAffected As Integer = cmdInsert.ExecuteNonQuery()

                If intRowsAffected > 0 Then
                    MessageBox.Show("Flight added successfully.")
                    Me.Close()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                CloseDatabaseConnection()
            End Try
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class