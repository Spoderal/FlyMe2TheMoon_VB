Public Class formStatistics
    Private Sub formStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Check if database connection opens successfully
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                "The application will now close.",
                Me.Text + " Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            ' Query for total passengers
            Dim cmdSelect = New OleDb.OleDbCommand("uspCountPassengers", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            Dim intTotalPassengers As Integer = CInt(cmdSelect.ExecuteScalar())
            lblCustomers.Text = "Total Customers: " & intTotalPassengers.ToString()

            Dim strSelect = "SELECT COUNT(*) AS TotalFlights FROM TFlightPassengers"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            Dim intTotalFlights As Integer = CInt(cmdSelect.ExecuteScalar())
            lblFlights.Text = "Total Flights: " + intTotalFlights.ToString()


            cmdSelect = New OleDb.OleDbCommand("uspAverageMiles", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            Dim intAvgMiles As Integer = CInt(cmdSelect.ExecuteScalar())
            lblMiles.Text = "Average Miles: " + intAvgMiles.ToString()



            cmdSelect = New OleDb.OleDbCommand("uspTotalPilotMiles", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            Dim reader As OleDb.OleDbDataReader = cmdSelect.ExecuteReader()

            listPilots.Items.Clear()
            While reader.Read()
                Dim strPilotName As String = reader("PilotName").ToString()
                Dim intPilotTotalMiles As Integer = 0
                If Not IsDBNull(reader("TotalMiles")) Then
                    intPilotTotalMiles = Convert.ToInt32(reader("TotalMiles"))
                End If
                listPilots.Items.Add(strPilotName & " - " & intPilotTotalMiles & " miles")
            End While
            reader.Close()


            cmdSelect = New OleDb.OleDbCommand("uspTotalAttendantMiles", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            reader = cmdSelect.ExecuteReader()

            listAttendants.Items.Clear()
            While reader.Read()
                Dim strAttendantName As String = reader("AttendantName").ToString()
                Dim intAttendantTotalMiles As Integer = 0
                If Not IsDBNull(reader("TotalMiles")) Then
                    intAttendantTotalMiles = Convert.ToInt32(reader("TotalMiles"))
                End If
                listAttendants.Items.Add(strAttendantName & " - " & intAttendantTotalMiles & " miles")
            End While
            reader.Close()

            CloseDatabaseConnection()

        Catch ex As Exception
            ' Log and display error message
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class