Public Class formAdministration
    Private Sub btnManagePilots_Click(sender As Object, e As EventArgs) Handles btnManagePilots.Click
        Dim frmManagePilots As New formManagePilots

        frmManagePilots.ShowDialog()
    End Sub

    Private Sub btnManageAttendants_Click(sender As Object, e As EventArgs) Handles btnManageAttendants.Click
        Dim frmManageAttendants As New formManageAttendants

        frmManageAttendants.ShowDialog()
    End Sub

    Private Sub btnStats_Click(sender As Object, e As EventArgs) Handles btnStats.Click
        Dim frmStatistics As New formStatistics

        frmStatistics.ShowDialog()
    End Sub

    Private Sub btnCreateFlight_Click(sender As Object, e As EventArgs) Handles btnCreateFlight.Click
        Dim frmCreateFlight As New formCreateFlight

        frmCreateFlight.ShowDialog()
    End Sub
End Class