
Imports MySql.Data.MySqlClient

Module Module1
    Public conn As New MySqlConnection

    Public Sub DbConnect()
        Dim dbname As String = "accounts"
        Dim username As String = "root"
        Dim password As String = "admin" ' MySQL server password
        Dim server As String = "127.0.0.1" ' PC IP address

        ' Build the connection string
        Dim connectionString As String = $"Server={server};Database={dbname};Uid={username};Pwd={password};"

        ' Initialize the MySqlConnection with the connection string
        conn = New MySqlConnection(connectionString)

        Try
            ' Open the connection
            conn.Open()
        Catch ex As MySqlException
            ' Handle any errors that might occur during the connection attempt
            MessageBox.Show("Database connection failed: " & ex.Message)
        End Try
    End Sub
End Module


