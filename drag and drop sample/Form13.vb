Imports MySql.Data.MySqlClient

Public Class Form13
    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadHistory()
    End Sub
    Public Sub LoadHistory()
        Try
            conn.Open()

            ' Query to retrieve completed or cancelled appointments without filtering by counselor_id
            Dim query As String = "SELECT appointment_id, user_id, full_name, appointment_date, description, status, counselor_id " &
                              "FROM appointments " &
                              "WHERE status IN ('Completed', 'Cancelled')"

            ' Create the command to execute the query
            Dim cmd As New MySqlCommand(query, conn)

            ' Use the MySqlDataAdapter to fill the data into the DataTable
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)

            ' Set the DataGridView's data source to the filled DataTable
            dgvHistory.DataSource = table
            dgvHistory.ReadOnly = True ' Ensure the history table is not editable

        Catch ex As Exception
            MessageBox.Show("Error loading history: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form5.Show() 'back to admin tab
    End Sub
End Class