Public Class formAddFlight
    Const intBaseCost = 250
    Const intReservedSeatCost = 375


    Private Sub formAddFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtFlights As DataTable = New DataTable            ' this is the table we will load from our reader

        ' Open the DB
        If OpenDatabaseConnectionSQLServer() = False Then
            ' No, warn the user ...
            MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Close the form/application
            Me.Close()
        End If


        strSelect = "SELECT intFlightID, dtmFlightDate, strFlightNumber FROM TFlights " &
                    "WHERE dtmFlightDate > ?"

        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        cmdSelect.Parameters.AddWithValue("?", DateTime.Now)
        drSourceTable = cmdSelect.ExecuteReader
        dtFlights.Load(drSourceTable)

        dtFlights.Columns.Add("DisplayColumn", GetType(String))
        For Each row As DataRow In dtFlights.Rows
            row("DisplayColumn") = row("dtmFlightDate").ToString() & " - " & row("strFlightNumber")
        Next

        comboFlights.ValueMember = "intFlightID"
        comboFlights.DisplayMember = "DisplayColumn"
        comboFlights.DataSource = dtFlights

        comboFlights.SelectedIndex = -1

    End Sub

    Private Sub comboFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboFlights.SelectedIndexChanged
        If comboFlights.SelectedIndex <> -1 Then
            ' Get the selected flight ID
            Dim flightID As Integer = CInt(comboFlights.SelectedValue)

            ' Assume passengerID is available (set this according to your logic)
            Dim passengerID As Integer = intCustomerID

            ' Calculate costs for both seat types
            Dim costDesignatedSeat As Decimal = CalculateTotalCost(flightID, passengerID, False) ' False = Designated Seat
            Dim costReservedSeat As Decimal = CalculateTotalCost(flightID, passengerID, True) ' True = Reserved Seat

            ' Update RadioButton text with the calculated costs
            radDesignatedSeat.Text = $"Designated Seat At Check-In: ${costDesignatedSeat:F2}"
            radReservedSeat.Text = $"Reserved Seat: ${costReservedSeat:F2}"

            ' Show the RadioButtons
            radDesignatedSeat.Visible = True
            radReservedSeat.Visible = True
        Else
            ' Hide the RadioButtons if no selection
            radDesignatedSeat.Visible = False
            radReservedSeat.Visible = False
        End If


    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strInsert As String = ""
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPassengers As DataTable = New DataTable
        Dim result As DialogResult
        Dim intRowsAffected As Integer
        Dim intNextPrimaryKey As Integer
        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            result = MessageBox.Show("Are you sure you want to book this flight?", "Confirm Booking", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes
                    strSelect = "SELECT MAX(intFlightPassengerID) + 1 AS intNextPrimaryKey FROM TFlightPassengers"

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader

                    drSourceTable.Read()

                    If drSourceTable.IsDBNull(0) = True Then
                        intNextPrimaryKey = 1

                    Else
                        intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))
                    End If

                    Dim dblCost As Decimal

                    If radDesignatedSeat.Checked Then
                        ' Calculate cost for designated seat
                        dblCost = CalculateTotalCost(CInt(comboFlights.SelectedValue), intCustomerID, isReservedSeat:=False)
                    ElseIf radReservedSeat.Checked Then
                        ' Calculate cost for reserved seat
                        dblCost = CalculateTotalCost(CInt(comboFlights.SelectedValue), intCustomerID, isReservedSeat:=True)
                    Else
                        MessageBox.Show("Please select a seat type.")
                        Return
                    End If

                    Dim formattedCost As String = dblCost.ToString("F2")


                    strInsert = "INSERT INTO TFlightPassengers (intFlightPassengerID, intFlightID, intPassengerID, strSeat, strCost) " &
           "VALUES (" & intNextPrimaryKey & ", " & CInt(comboFlights.SelectedValue) & ", " & intCustomerID & ", '1A', '" & formattedCost & "')"



                    Console.WriteLine(strInsert)


                    cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                    intRowsAffected = cmdInsert.ExecuteNonQuery()

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Flight booked")

                        Me.Close()
                    End If

                    CloseDatabaseConnection()
                    Close()


            End Select


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Function CalculateTotalCost(flightID As Integer, passengerID As Integer, isReservedSeat As Boolean) As Decimal
        Dim totalCost As Decimal = 0
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim planeType As String = ""
        Dim miles As Integer = 0
        Dim seatCost As Decimal = If(isReservedSeat, intReservedSeatCost, intBaseCost)
        Dim totalPassengerCount As Integer = 0
        Dim age As Integer = 0

        Try
            ' Open the database connection
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return 0 ' Exit if the connection fails
            End If

            ' Join TFlights and TPlaneTypes to get plane type and other details
            strSelect = "SELECT f.dtmFlightDate, f.intFlightID, pl.intPlaneTypeID, p.strPlaneType, pl.strPlaneNumber, f.intMilesFlown " &
            "FROM TFlights f " &
            "INNER JOIN TPlanes pl ON f.intPlaneID = pl.intPlaneID " &
            "INNER JOIN TPlaneTypes p ON pl.intPlaneTypeID = p.intPlaneTypeID " &
            "WHERE f.intFlightID = ?"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            cmdSelect.Parameters.AddWithValue("?", flightID)
            drSourceTable = cmdSelect.ExecuteReader

            If drSourceTable.Read() Then
                planeType = drSourceTable("strPlaneType").ToString()
                miles = CInt(drSourceTable("intMilesFlown"))
            End If

            ' Apply cost adjustments based on flight details
            If miles > 750 Then
                totalCost += 50 ' Add $50 if miles are greater than 750
            End If

            ' Calculate the total number of passengers that have reserved a seat
            strSelect = "SELECT COUNT(*) FROM TFlightPassengers WHERE intFlightID = ? AND strSeat IS NOT NULL"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            cmdSelect.Parameters.AddWithValue("?", flightID)
            totalPassengerCount = CInt(cmdSelect.ExecuteScalar())

            ' Apply cost adjustments based on passenger count
            If totalPassengerCount > 8 Then
                totalCost += 100 ' Add $100 if more than 8 passengers have reserved a seat
            ElseIf totalPassengerCount < 4 Then
                totalCost -= 50 ' Deduct $50 if less than 4 passengers have reserved a seat
            End If

            Console.WriteLine($"Plane Type: {planeType}")

            ' Apply plane type specific cost adjustments
            If planeType = "Airbus A350" Then
                totalCost += 35 ' Add $35 if the plane type is Airbus A350
            ElseIf planeType = "Boeing 747-8" Then
                totalCost -= 25 ' Deduct $25 if the plane type is Boeing 747-8
            End If

            ' Apply additional flight-specific costs based on the destination
            strSelect = "SELECT strAirportCode FROM TAirports WHERE strAirportCode = 'MIA'"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            Dim airportCode As String = cmdSelect.ExecuteScalar()?.ToString()

            If airportCode = "MIA" Then
                totalCost += 15 ' Add $15 if landing in MIA
            End If

            ' Add the base seat cost (Designated or Reserved)
            totalCost += seatCost

            ' Retrieve passenger age and apply discount
            strSelect = "SELECT dtmDateOfBirth FROM TPassengers WHERE intPassengerID = ?"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            cmdSelect.Parameters.AddWithValue("?", passengerID)
            drSourceTable = cmdSelect.ExecuteReader

            If drSourceTable.Read() Then
                Dim dob As DateTime = CDate(drSourceTable("dtmDateOfBirth"))
                age = CalculateAge(dob)
            End If

            ' Apply age-based discounts
            If age >= 65 Then
                totalCost *= 0.8D ' Deduct 20% if age is 65 or older
            ElseIf age <= 5 Then
                totalCost *= 0.35D ' Deduct 65% if age is 5 or younger
            End If

            ' Apply loyalty discounts based on previous flights
            strSelect = "SELECT COUNT(*) " &
            "FROM TFlightPassengers fp " &
            "INNER JOIN TFlights f ON fp.intFlightID = f.intFlightID " &
            "WHERE fp.intPassengerID = ? " &
            "AND f.dtmFlightDate < ?"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            cmdSelect.Parameters.AddWithValue("?", passengerID)
            cmdSelect.Parameters.AddWithValue("?", DateTime.Now)
            Dim previousFlights As Integer = CInt(cmdSelect.ExecuteScalar())

            If previousFlights > 10 Then
                totalCost *= 0.8D ' Deduct 20% if more than 10 flights
            ElseIf previousFlights > 5 Then
                totalCost *= 0.9D ' Deduct 10% if more than 5 flights
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return 0 ' Return 0 if an error occurs
        End Try

        ' Return the final calculated cost
        Return totalCost
    End Function


    Private Function CalculateAge(dob As DateTime) As Integer
        Dim age As Integer
        Dim today As DateTime = DateTime.Now

        ' Calculate the age
        age = today.Year - dob.Year

        ' Check if the birthday has already occurred this year
        If today.Month < dob.Month Or (today.Month = dob.Month And today.Day < dob.Day) Then
            age -= 1 ' Subtract 1 if the birthday hasn't occurred yet this year
        End If

        Return age
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class