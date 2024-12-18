Public Class formManagePilots
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frmPilotAdd As New formAddPilot

        frmPilotAdd.ShowDialog()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim frmPilotDelete As New formDeletePilot

        frmPilotDelete.ShowDialog()
    End Sub

    Private Sub btnAddToFlight_Click(sender As Object, e As EventArgs) Handles btnAddToFlight.Click
        Dim frmPilotFlight As New formAddPilotFlight

        frmPilotFlight.ShowDialog()
    End Sub
End Class