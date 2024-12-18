Public Class formLogin
    Private Sub btnPassengerLogin_Click(sender As Object, e As EventArgs) Handles btnPassengerLogin.Click
        Dim frmLoginPassenger As New formLoginPassenger

        frmLoginPassenger.ShowDialog()
    End Sub

    Private Sub btnEmployeeLogin_Click(sender As Object, e As EventArgs) Handles btnEmployeeLogin.Click
        Dim frmLoginEmployee As New formLoginEmployee

        frmLoginEmployee.ShowDialog()
    End Sub
End Class