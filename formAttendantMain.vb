Public Class formAttendantMain
    Private Sub formAttendantMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
        Dim dtAttendants As DataTable = New DataTable            ' this is the table we will load from our reader


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

        strSelect = "Select intAttendantID, strFirstName, strLastName" &
       " From TAttendants"

        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader
        dtAttendants.Load(drSourceTable)

        comboAttendant.ValueMember = "intAttendantID"
        comboAttendant.DisplayMember = "strFirstName"
        comboAttendant.DataSource = dtAttendants


    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        intAttendantID = CInt(comboAttendant.SelectedValue)


        Dim formAttendant As New formAttendant
        formAttendant.ShowDialog()
    End Sub
End Class