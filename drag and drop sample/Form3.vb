Imports MySql.Data.MySqlClient

Public Class Form3
    Private conn As New MySqlConnection("server=127.0.0.1;uid=root;pwd=admin;database=accounts;")

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT full_name, username, role, password FROM users", conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)
            dgvUsers.DataSource = table

            ' Optionally auto-generate columns
            dgvUsers.AutoGenerateColumns = True
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim selectedUser As String = dgvUsers.SelectedRows(0).Cells("full_name").Value.ToString() ' Adjust as per your column name
            Dim confirmResult As DialogResult = MessageBox.Show("Are you sure to delete this user: " & selectedUser & "?", "Confirm Delete", MessageBoxButtons.YesNo)

            If confirmResult = DialogResult.Yes Then
                Dim conn As New MySqlConnection("Server=127.0.0.1;Database=accounts;Uid=root;Pwd=admin;")
                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand("DELETE FROM users WHERE full_name = @fullName", conn)
                    cmd.Parameters.AddWithValue("@fullName", selectedUser)

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("User deleted successfully.")

                    ' Reload users after deletion
                    LoadUsers()
                Catch ex As Exception
                    MessageBox.Show("Error deleting user: " & ex.Message)
                Finally
                    If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Try
            End If
        Else
            MessageBox.Show("Please select a user to delete.")
        End If
    End Sub


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadUsers() ' Reload users
    End Sub

    ' Save changes to the database when a cell is edited
    Private Sub dgvUsers_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellEndEdit
        If e.RowIndex >= 0 Then
            Dim username As String = dgvUsers.Rows(e.RowIndex).Cells("username").Value.ToString()
            Dim updatedColumnName As String = dgvUsers.Columns(e.ColumnIndex).Name
            Dim updatedValue As String = dgvUsers.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()

            Try
                conn.Open()
                Dim cmd As New MySqlCommand($"UPDATE users SET {updatedColumnName}=@updatedValue WHERE username=@username", conn)
                cmd.Parameters.AddWithValue("@updatedValue", updatedValue)
                cmd.Parameters.AddWithValue("@username", username)

                cmd.ExecuteNonQuery()
                MessageBox.Show("User details updated successfully.")
            Catch ex As Exception
                MessageBox.Show("Error updating user: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub
End Class
