Public Class formPilot
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim frmPilotUpdate As New formPilotUpdate

        frmPilotUpdate.ShowDialog()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        Dim frmPilotPastFlights As New formPilotPastFlights

        frmPilotPastFlights.ShowDialog()
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        Dim frmPilotFutureFlights As New formPilotFutureFlights

        frmPilotFutureFlights.ShowDialog()
    End Sub
End Class