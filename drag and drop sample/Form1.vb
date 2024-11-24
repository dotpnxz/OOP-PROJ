Imports System.Runtime.CompilerServices
Imports MySql.Data.MySqlClient

Public Class Form1
    ' Declare a shared variable to store the logged-in user ID
    Public Shared LoggedInUserId As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module1.DbConnect() ' Initiate the database connection once when the form loads
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Validate user input
        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both username and password.")
            Return
        End If

        ' Prepare SQL command to fetch user details, including the user_id
        Dim cmd As MySqlCommand = New MySqlCommand("SELECT id, role FROM users WHERE username=@username AND password=@password", conn)
        cmd.Parameters.AddWithValue("@username", username)
        cmd.Parameters.AddWithValue("@password", password)

        Try
            ' Execute the query and fetch the id and role
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read() ' Read the first record (assuming unique username/password)
                    LoggedInUserId = Convert.ToInt32(reader("id")) ' Store the user_id (which is actually "id" here)
                    Dim role As String = Convert.ToString(reader("role"))

                    ' Redirect based on role
                    Select Case role.ToLower()
                        Case "admin"
                            Dim form5 As New Form5()
                            form5.Show()
                        Case "student"
                            Dim form4 As New Form4()
                            form4.Show()
                        Case "counselor"
                            Dim form6 As New Form6()
                            form6.Show()
                        Case "director"
                            Dim form7 As New Form7()
                            form7.Show()
                        Case Else
                            MessageBox.Show("Unknown role.")
                    End Select

                    Me.Hide() ' Hide the login form after successful login
                Else
                    MessageBox.Show("Invalid username or password.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            conn.Close() ' Ensure the connection is closed after use
        End Try
    End Sub

    ' Placeholder and formatting for Username TextBox
    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus
        If txtUsername.Text = "Username" Then
            txtUsername.Text = ""
            txtUsername.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus
        If txtUsername.Text = "" Then
            txtUsername.Text = "Username"
            txtUsername.ForeColor = Color.DimGray
        End If
    End Sub

    ' Placeholder and formatting for Password TextBox
    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Password" Then
            txtPassword.Text = ""
            txtPassword.ForeColor = Color.Black
            txtPassword.PasswordChar = "*" ' Hide password input
        End If
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        If txtPassword.Text = "" Then
            txtPassword.PasswordChar = ""
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.DimGray
        End If
    End Sub
End Class
