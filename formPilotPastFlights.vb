Public Class formPilotPastFlights
    Private Sub formPilotPastFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Check if database connection opens successfully
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                        "The application will now close.",
                        Me.Text + " Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            ' Build SQL query with parameters
            Dim strSelect As String = "SELECT TPilotFlights.intPilotFlightID, TPilotFlights.intFlightID, " &
                              "TPilotFlights.intPilotID, " &
                              "TFlights.strFlightNumber, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture, " &
                              "TFlights.dtmTimeOfLanding, TFlights.intMilesFlown " &
                              "FROM TPilotFlights " &
                              "INNER JOIN TFlights ON TPilotFlights.intFlightID = TFlights.intFlightID " &
                              "WHERE TPilotFlights.intPilotID = " & intPilotID & " " &
                              "AND TFlights.dtmFlightDate < ?"

            ' Prepare command and add parameter
            Dim cmdSelect As New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            cmdSelect.Parameters.AddWithValue("?", DateTime.Now) ' Use "?" as a positional parameter

            ' Execute command
            Dim drSourceTable As OleDb.OleDbDataReader = cmdSelect.ExecuteReader()

            ' Clear and add headers to list box
            listFlights.Items.Clear()
            listFlights.Items.Add("List Of Past Flights")
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