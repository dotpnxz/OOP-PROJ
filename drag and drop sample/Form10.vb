Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Form10
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAppointments()
        LoadCounselors()
    End Sub

    Private Sub LoadCounselors()
        Try
            ComboBoxCounselor.DropDownStyle = ComboBoxStyle.DropDownList
            conn.Open()

            ' Query to get all counselor usernames and IDs from the users table
            Dim cmd As New MySqlCommand("SELECT id, username FROM users WHERE role = 'counselor'", conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ' Clear existing items in ComboBox before adding new ones
            ComboBoxCounselor.Items.Clear()

            ' Add items to ComboBox with counselor ID as Tag and username as Text
            While reader.Read()
                Dim counselorId As Integer = Convert.ToInt32(reader("id"))
                Dim username As String = reader("username").ToString()

                ' Add username and set the counselor ID as the Tag
                ComboBoxCounselor.Items.Add(New With {Key .Id = counselorId, Key .Username = username})
            End While

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading counselors: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnAssignCounselor_Click(sender As Object, e As EventArgs) Handles btnAssignCounselor.Click
        ' Check if a row is selected
        If dgvUsers.SelectedRows.Count > 0 Then
            ' Get the selected appointment_id from the DataGridView
            Dim appointmentId As Integer = dgvUsers.SelectedRows(0).Cells("appointment_id").Value

            ' Get the selected counselor object from the ComboBox
            Dim selectedCounselor = CType(ComboBoxCounselor.SelectedItem, Object)
            If selectedCounselor Is Nothing Then
                MessageBox.Show("Please select a counselor.")
                Return
            End If

            Dim selectedCounselorUsername As String = selectedCounselor.Username
            Dim selectedCounselorId As Integer = selectedCounselor.Id

            ' Update the assigned_counselor and counselor_id columns in the appointments table
            Try
                conn.Open()

                ' Prepare the SQL UPDATE command
                Dim cmd As New MySqlCommand("UPDATE appointments SET assigned_counselor = @assigned_counselor, counselor_id = @counselor_id WHERE appointment_id = @appointment_id", conn)
                cmd.Parameters.AddWithValue("@assigned_counselor", selectedCounselorUsername)
                cmd.Parameters.AddWithValue("@counselor_id", selectedCounselorId)
                cmd.Parameters.AddWithValue("@appointment_id", appointmentId)

                ' Execute the update command
                cmd.ExecuteNonQuery()
                MessageBox.Show("Counselor assigned successfully.")

                ' Optionally, update the DataGridView to reflect the changes
                dgvUsers.SelectedRows(0).Cells("assigned_counselor").Value = selectedCounselorUsername
                dgvUsers.SelectedRows(0).Cells("counselor_id").Value = selectedCounselorId

            Catch ex As Exception
                MessageBox.Show("Error assigning counselor: " & ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MessageBox.Show("Please select a row to assign a counselor.")
        End If
    End Sub

    Private Sub LoadAppointments()
        Try
            conn.Open()

            ' Fetch all appointments
            Dim cmd As New MySqlCommand("SELECT appointment_id, user_id, full_name, appointment_date, description, status, assigned_counselor,counselor_id FROM appointments", conn)
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
        Form7.Show() 'back to director's tab
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