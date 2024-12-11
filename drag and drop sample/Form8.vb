Imports MySql.Data.MySqlClient

Public Class Form8
    ' Assuming you have a global variable or method that holds the current logged-in user's user_id
    Private loggedInUserId As Integer ' Replace with actual logic to get the logged-in user's user_id
    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserId = userId
    End Sub
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAppointments()
    End Sub

    Private Sub LoadAppointments()
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT appointment_id, user_id,full_name,appointment_date, description, status FROM appointments WHERE user_id = @user_id", conn)
            cmd.Parameters.AddWithValue("@user_id", loggedInUserId) ' Pass the user_id of the logged-in user

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)
            dgvUsers.DataSource = table

            ' Make the DataGridView read-only (no edits allowed)
            dgvUsers.ReadOnly = True

            ' Optionally auto-generate columns
            dgvUsers.AutoGenerateColumns = True
        Catch ex As Exception
            MessageBox.Show("Error loading appointments: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim selectedAppointmentId As String = dgvUsers.SelectedRows(0).Cells("appointment_id").Value.ToString()
            Dim confirmResult As DialogResult = MessageBox.Show("Are you sure to delete this appointment: " & selectedAppointmentId & "?", "Confirm Delete", MessageBoxButtons.YesNo)

            If confirmResult = DialogResult.Yes Then
                Dim conn As New MySqlConnection("Server=127.0.0.1;Database=accounts;Uid=root;Pwd=admin;")
                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand("DELETE FROM appointments WHERE appointment_id = @appointment_id AND user_id = @user_id", conn)
                    cmd.Parameters.AddWithValue("@appointment_id", selectedAppointmentId)
                    cmd.Parameters.AddWithValue("@user_id", loggedInUserId) ' Ensure the user_id matches the logged-in user

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Appointment deleted successfully.")

                    ' Reload appointments after deletion
                    LoadAppointments()
                Catch ex As Exception
                    MessageBox.Show("Error deleting appointment: " & ex.Message)
                Finally
                    If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Try
            End If
        Else
            MessageBox.Show("Please select an appointment to delete.")
        End If
    End Sub

    Private Sub dgvUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellContentClick

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadAppointments()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form4.Show()
    End Sub
End Class
