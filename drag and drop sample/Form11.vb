Imports MySql.Data.MySqlClient

Public Class Form11
    Private loggedInUserId As Integer
    Private conn As MySqlConnection

    ' Constructor to initialize form with logged-in user's ID
    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserId = userId ' Store the logged-in user's ID
        ' Initialize MySQL connection here to avoid re-initialization in every method
        conn = New MySqlConnection("Server=127.0.0.1;Database=accounts;Uid=root;Pwd=admin;")
    End Sub

    ' Button1 Click event - Go back to Form6
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form6.Show() ' Go back to counselor's tab
    End Sub

    ' Refresh Button Click event
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadAppointments() ' Reload the appointments
    End Sub

    ' DataGridView Cell Value Changed event - Update appointment date in the database
    Private Sub dgvUsers_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellValueChanged
        If dgvUsers.Columns(e.ColumnIndex).Name = "appointment_date" Then
            Try
                conn.Open()

                Dim appointmentId As Integer = dgvUsers.Rows(e.RowIndex).Cells("appointment_id").Value
                Dim newDateRaw As String = dgvUsers.Rows(e.RowIndex).Cells("appointment_date").Value.ToString()

                ' Convert the raw string to a DateTime object
                Dim newDate As DateTime
                If DateTime.TryParse(newDateRaw, newDate) Then
                    ' Convert the DateTime object to MySQL DATETIME format
                    Dim formattedDate As String = newDate.ToString("yyyy-MM-dd HH:mm:ss")

                    ' Prepare the SQL UPDATE command
                    Dim cmd As New MySqlCommand("UPDATE appointments SET appointment_date = @appointment_date WHERE appointment_id = @appointment_id", conn)
                    cmd.Parameters.AddWithValue("@appointment_date", formattedDate)
                    cmd.Parameters.AddWithValue("@appointment_id", appointmentId)

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Appointment date updated successfully.")
                Else
                    MessageBox.Show("Invalid date format. Please use a valid datetime format.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error updating appointment date: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    ' Method to load appointments for the logged-in counselor
    Private Sub LoadAppointments()
        Try
            conn.Open()

            ' Query to fetch appointments where the assigned counselor's ID matches the logged-in user ID
            Dim query As String = "SELECT appointment_id, user_id, appointment_date, description, status, assigned_counselor  FROM appointments WHERE counselor_id = @counselor_id"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@counselor_id", loggedInUserId)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)
            dgvUsers.DataSource = table

            ' Make specific columns editable
            dgvUsers.ReadOnly = False
            For Each column As DataGridViewColumn In dgvUsers.Columns
                If column.Name = "appointment_date" Then
                    column.ReadOnly = False ' Allow editing appointment date
                Else
                    column.ReadOnly = True ' Make other columns read-only
                End If
            Next

            dgvUsers.AutoGenerateColumns = True
        Catch ex As Exception
            MessageBox.Show("Error loading appointments: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Method to fetch username by ID (Not currently used, but may be useful in the future)
    Private Function GetUsernameById(userId As Integer) As String
        Try
            conn.Open()

            Dim query As String = "SELECT username FROM users WHERE id = @user_id"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@user_id", userId)

            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                Return result.ToString()
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show("Error fetching username: " & ex.Message)
            Return String.Empty
        Finally
            conn.Close()
        End Try
    End Function

    ' Delete Button Click event - Delete selected appointment
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim selectedAppointmentId As Integer = dgvUsers.SelectedRows(0).Cells("appointment_id").Value
            Dim confirmResult As DialogResult = MessageBox.Show("Are you sure to delete this appointment with ID: " & selectedAppointmentId & "?", "Confirm Delete", MessageBoxButtons.YesNo)

            If confirmResult = DialogResult.Yes Then
                Try
                    conn.Open()
                    ' Modify query to delete the appointment with the selected appointment_id
                    Dim cmd As New MySqlCommand("DELETE FROM appointments WHERE appointment_id = @appointment_id", conn)
                    cmd.Parameters.AddWithValue("@appointment_id", selectedAppointmentId)

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Appointment deleted successfully.")

                    ' Reload appointments after deletion
                    LoadAppointments()
                Catch ex As Exception
                    MessageBox.Show("Error deleting appointment: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End If
        Else
            MessageBox.Show("Please select an appointment to delete.")
        End If
    End Sub

    ' Form Load event - Load appointments when the form is loaded
    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAppointments()
    End Sub
End Class
