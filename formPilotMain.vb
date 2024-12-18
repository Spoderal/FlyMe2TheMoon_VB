Public Class formPilotMain
    Private Sub formPilotMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtPilots As DataTable = New DataTable            ' this is the table we will load from our reader


        ' open the DB
        If OpenDatabaseConnectionSQLServer() = False Then

            ' No, warn the user ...
            MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' and close the form/application
            Me.Close()

        End If

        ' Build the select statement

        strSelect = "Select intPilotID, strFirstName, strLastName" &
       " From TPilots"

        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader
        dtPilots.Load(drSourceTable)

        comboPilot.ValueMember = "intPilotID"
        comboPilot.DisplayMember = "strFirstName"
        comboPilot.DataSource = dtPilots


    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        intPilotID = CInt(comboPilot.SelectedValue)


        Dim formPilot As New formPilot
        formPilot.ShowDialog()
    End Sub
End Class