Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Form9
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAppointments()
    End Sub
    Private Sub LoadAppointments()
        Try
            conn.Open()

            ' Fetch all appointments
            Dim cmd As New MySqlCommand("SELECT appointment_id, full_name, user_id, appointment_date, description, status FROM appointments", conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)
            dgvUsers.DataSource = table

            ' Allow editing only for the appointment_date column
            dgvUsers.ReadOnly = False
            For Each column As DataGridViewColumn In dgvUsers.Columns
                If column.Name = "appointment_date" Then
                    column.ReadOnly = False
                Else
                    column.ReadOnly = True
                End If
            Next

            ' Optionally auto-generate columns
            dgvUsers.AutoGenerateColumns = True

        Catch ex As Exception
            MessageBox.Show("Error loading appointments: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

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


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadAppointments()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim selectedAppointmentId As String = dgvUsers.SelectedRows(0).Cells("appointment_id").Value.ToString()
            Dim confirmResult As DialogResult = MessageBox.Show("Are you sure to delete this appointment with ID: " & selectedAppointmentId & "?", "Confirm Delete", MessageBoxButtons.YesNo)

            If confirmResult = DialogResult.Yes Then
                Dim conn As New MySqlConnection("Server=127.0.0.1;Database=accounts;Uid=root;Pwd=admin;")
                Try
                    conn.Open()
                    ' Modify query to delete all appointments with the given appointment_id
                    Dim cmd As New MySqlCommand("DELETE FROM appointments WHERE appointment_id = @appointment_id", conn)
                    cmd.Parameters.AddWithValue("@appointment_id", selectedAppointmentId)

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Appointment deleted successfully.")

                    ' Reload appointments after deletion (optional, depending on your needs)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form5.Show()
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        Form15.Show() 'Load form3
        Dim report As New ReportDocument
        'load cyrsttal report
        report.Load("D:\Project-OOP\drag and drop sample\Appointments.rpt")
        Form15.CrystalReportViewer1.ReportSource = report
        Form15.CrystalReportViewer1.Refresh()
    End Sub
End Class