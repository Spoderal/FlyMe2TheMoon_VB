Public Class formManageAttendants
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frmAddAttendants As New formAddAttendants

        frmAddAttendants.ShowDialog()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim frmDeleteAttendants As New formDeleteAttendant

        frmDeleteAttendants.ShowDialog()
    End Sub

    Private Sub btnAddToFlight_Click(sender As Object, e As EventArgs) Handles btnAddToFlight.Click
        Dim frmAddAttendantFlight As New formAddAttendantFlight

        frmAddAttendantFlight.ShowDialog()
    End Sub
End Class