Imports MySql.Data.MySqlClient

Public Class form2
    Private Sub btnCreateUser_Click(sender As Object, e As EventArgs) Handles btnCreateUser.Click
        Dim fullname As String = txtFullname.Text.Trim()
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim confirmPassword As String = txtConfirmPassword.Text.Trim()
        Dim role As String = GetSelectedRole() ' Get the selected role from radio buttons

        ' Input validation
        If String.IsNullOrWhiteSpace(fullname) OrElse
           String.IsNullOrWhiteSpace(username) OrElse
           String.IsNullOrWhiteSpace(password) OrElse
           String.IsNullOrWhiteSpace(confirmPassword) Then
            MessageBox.Show("Please fill in all fields.")
            Return
        End If

        If password.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters long.")
            Return
        End If

        If password <> confirmPassword Then
            MessageBox.Show("Passwords do not match.")
            Return
        End If

        ' Connect to the database
        DbConnect() ' Call your connection method from Module1

        ' Insert the new user into the database
        Dim cmd As MySqlCommand = New MySqlCommand("INSERT INTO users (full_name, username, password, role) VALUES (@fullname, @username, @password, @role)", conn)
        cmd.Parameters.AddWithValue("@fullname", fullname)
        cmd.Parameters.AddWithValue("@username", username)
        cmd.Parameters.AddWithValue("@password", password)
        cmd.Parameters.AddWithValue("@role", role)

        Try
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("User account created successfully!")
                Me.Hide()
                Form5.Show()
            Else
                MessageBox.Show("User account creation failed.")
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            conn.Close() ' Close the connection
        End Try
    End Sub

    Private Function GetSelectedRole() As String
        If rbtnStudent.Checked Then
            Return "Student"
        ElseIf rbtnCounselor.Checked Then
            Return "Counselor"
        ElseIf rbtnDirector.Checked Then
            Return "Director"
        Else
            Return String.Empty ' No role selected
        End If
    End Function

    ' Navigation back to Form1

    ' Placeholder for labels
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
    End Sub

    ' Placeholder for TextBox events
    Private Sub txtFullname_GotFocus(sender As Object, e As EventArgs) Handles txtFullname.GotFocus
        If txtFullname.Text = "Full Name" Then
            txtFullname.Text = ""
            txtFullname.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtFullname_LostFocus(sender As Object, e As EventArgs) Handles txtFullname.LostFocus
        If String.IsNullOrWhiteSpace(txtFullname.Text) Then
            txtFullname.Text = "Full Name"
            txtFullname.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub txtUsername_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus
        If txtUsername.Text = "Username" Then
            txtUsername.Text = ""
            txtUsername.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtUsername_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            txtUsername.Text = "Username"
            txtUsername.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Password" Then
            txtPassword.Text = ""
            txtPassword.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub txtConfirmPassword_GotFocus(sender As Object, e As EventArgs) Handles txtConfirmPassword.GotFocus
        If txtConfirmPassword.Text = "Confirm Password" Then
            txtConfirmPassword.Text = ""
            txtConfirmPassword.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtConfirmPassword_LostFocus(sender As Object, e As EventArgs) Handles txtConfirmPassword.LostFocus
        If String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then
            txtConfirmPassword.Text = "Confirm Password"
            txtConfirmPassword.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form5.Show()
    End Sub

    Private Sub form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
