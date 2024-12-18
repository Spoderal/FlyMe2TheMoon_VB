Public Class formAttendant
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim frmAttendantUpdate As New formUpdateAttendant

        frmAttendantUpdate.ShowDialog()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        Dim frmAttendantPastFlights As New formAttendantPastFlights

        frmAttendantPastFlights.ShowDialog()
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        Dim frmAttendantFutureFlights As New formAttendantFutureFlights

        frmAttendantFutureFlights.ShowDialog()
    End Sub
End Class