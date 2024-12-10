Imports MySql.Data.MySqlClient

Public Class Form12
    Private loggedInUserId As Integer
    Private conn As MySqlConnection
    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserId = userId ' Store the logged-in user's ID
        ' Initialize MySQL connection here to avoid re-initialization in every method
        conn = New MySqlConnection("Server=127.0.0.1;Database=accounts;Uid=root;Pwd=admin;")
    End Sub
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadHistory()
    End Sub

    Public Sub LoadHistory()
        Try
            conn.Open()

            ' Query to retrieve completed or cancelled appointments filtered by counselor_id
            Dim query As String = "SELECT appointment_id, user_id, full_name, appointment_date, description, status, counselor_id " &
                              "FROM appointments " &
                              "WHERE status IN ('Completed', 'Cancelled') AND counselor_id = @counselor_id"

            ' Use the logged-in counselor's ID for filtering
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@counselor_id", loggedInUserId) ' Use the logged-in counselor's ID

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)

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
        Form6.Show() 'back to counselor tab
    End Sub
End Class