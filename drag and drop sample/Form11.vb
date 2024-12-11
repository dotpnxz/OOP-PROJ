Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Form11
    Private loggedInUserId As Integer
    Private conn As MySqlConnection

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAppointments()
        LoadStatus()
    End Sub
    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserId = userId ' Store the logged-in user's ID
        ' Initialize MySQL connection here to avoid re-initialization in every method
        conn = New MySqlConnection("Server=127.0.0.1;Database=accounts;Uid=root;Pwd=admin;")
    End Sub

    Private Sub LoadStatus()
        Try
            ' Set the ComboBox to DropDownList mode to prevent manual input
            ComboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList

            ' Clear any existing items in the ComboBox
            ComboBoxStatus.Items.Clear()

            ' Add predefined status options
            ComboBoxStatus.Items.Add("Cancelled")
            ComboBoxStatus.Items.Add("Completed")

            ' Optionally, set a default selection
            If ComboBoxStatus.Items.Count > 0 Then
                ComboBoxStatus.SelectedIndex = 0 ' Set the first item as the default
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading status: " & ex.Message)
        End Try
    End Sub
    Private Sub btnStatus_Click(sender As Object, e As EventArgs) Handles btnStatus.Click
        Try
            ' Ensure a status is selected in the ComboBox
            If ComboBoxStatus.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a status before updating.")
                Return
            End If

            ' Retrieve the selected status
            Dim selectedStatus As String = ComboBoxStatus.SelectedItem.ToString()

            ' Retrieve the appointment_id of the selected row in the DataGridView
            If dgvUsers.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select an appointment from the list.")
                Return
            End If

            ' Assuming the appointment_id is in the first column of the selected row
            Dim selectedAppointmentId As Integer = Convert.ToInt32(dgvUsers.SelectedRows(0).Cells("appointment_id").Value)

            ' Update the database
            Dim query As String = "UPDATE appointments SET status = @status WHERE appointment_id = @appointment_id"
            Using conn As New MySqlConnection("Server=127.0.0.1;Port=3306;Database=accounts;Uid=root;Pwd=admin;")
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@status", selectedStatus)
                    cmd.Parameters.AddWithValue("@appointment_id", selectedAppointmentId)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Status updated successfully.")
                        ' Optionally reload the DataGridView to reflect changes
                        LoadAppointments()
                    Else
                        MessageBox.Show("Failed to update the status.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message)
        End Try
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

            ' Query to fetch appointments where the counselor's ID matches the logged-in user ID
            Dim query As String = "SELECT appointment_id, user_id, full_name, appointment_date, description, status, counselor_id " &
                      "FROM appointments " &
                      "WHERE counselor_id = @counselor_id " &
                      "AND status NOT IN ('Completed', 'Cancelled')"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@counselor_id", loggedInUserId) ' Use the logged-in counselor's ID
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            ' Fill the DataTable with the results of the query
            adapter.Fill(table)
            dgvUsers.DataSource = table ' Bind the DataTable to the DataGridView

            ' Make specific columns editable
            dgvUsers.ReadOnly = False
            For Each column As DataGridViewColumn In dgvUsers.Columns
                If column.Name = "appointment_date" Then
                    column.ReadOnly = False ' Allow editing appointment date
                Else
                    column.ReadOnly = True ' Make other columns read-only
                End If
            Next

            dgvUsers.AutoGenerateColumns = True ' Automatically generate columns for the DataGridView
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


End Class
