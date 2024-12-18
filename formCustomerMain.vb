Public Class formCustomerMain
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim frmCustomerUpdate As New formUpdateCustomer

        frmCustomerUpdate.ShowDialog()
    End Sub

    Private Sub btnAddFlight_Click(sender As Object, e As EventArgs) Handles btnAddFlight.Click
        Dim frmAddFlight As New formAddFlight

        frmAddFlight.ShowDialog()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        Dim frmPastFlights As New formPastFlights

        frmPastFlights.ShowDialog()
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        Dim frmFutureFlights As New formFutureFlights

        frmFutureFlights.ShowDialog()
    End Sub
End Class