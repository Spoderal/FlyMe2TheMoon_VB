Public Class formPilotFutureFlights
    Private Sub formPilotFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Check if database connection opens successfully
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                        "The application will now close.",
                        Me.Text + " Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
            Dim objParam As OleDb.OleDbParameter

            ' Build SQL query with parameters


            ' Prepare command and add parameter
            Dim cmdSelect As New OleDb.OleDbCommand("uspPilotFutureFlights", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@pilot_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intPilotID


            objParam = cmdSelect.Parameters.Add("@date", OleDb.OleDbType.Date)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = DateTime.Now

            ' Execute command
            Dim drSourceTable As OleDb.OleDbDataReader = cmdSelect.ExecuteReader()

            ' Clear and add headers to list box
            listFlights.Items.Clear()
            listFlights.Items.Add("List Of Future Flights")
            listFlights.Items.Add("=============================")

            ' Initialize total miles counter for all flights
            Dim intTotalMilesFlown As Integer = 0

            ' Loop through result set and add items to list
            While drSourceTable.Read()
                ' Get the miles flown for this flight and add to total
                Dim milesFlown As Integer = Convert.ToInt32(drSourceTable("intMilesFlown"))
                intTotalMilesFlown += milesFlown

                listFlights.Items.Add(" ")
                listFlights.Items.Add("Flight Number: " & vbTab & vbTab & drSourceTable("strFlightNumber"))
                listFlights.Items.Add("Flight Date: " & vbTab & vbTab & drSourceTable("dtmFlightDate"))
                listFlights.Items.Add("Departure Time: " & vbTab & vbTab & drSourceTable("dtmTimeofDeparture"))
                listFlights.Items.Add("Arrival Time: " & vbTab & vbTab & drSourceTable("dtmTimeOfLanding"))
                listFlights.Items.Add("Miles Flown: " & vbTab & vbTab & milesFlown)
                listFlights.Items.Add(" ")
                listFlights.Items.Add("=============================")
            End While

            lblMiles.Text = "Miles Flown: " + intTotalMilesFlown.ToString()

            ' Clean up
            drSourceTable.Close()

            ' Close database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            ' Log and display error message
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class