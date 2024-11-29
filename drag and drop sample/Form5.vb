Imports MySql.Data.MySqlClient

Public Class Form5
    Private currentMonth As Integer = DateTime.Now.Month
    Private currentYear As Integer = DateTime.Now.Year
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup the DataGridView to display calendar days
        SetupCalendar()
        LoadMonthCalendar(currentMonth, currentYear)
    End Sub

    Private Sub LoadMonthCalendar(month As Integer, year As Integer)
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(6) ' Add 6 rows for all weeks in the month

        Dim firstDay As New DateTime(year, month, 1)
        Dim daysInMonth As Integer = DateTime.DaysInMonth(year, month)
        Dim startDayOfWeek As Integer = CInt(firstDay.DayOfWeek)

        Dim currentDay As Integer = 1
        For row As Integer = 0 To 5
            For col As Integer = 0 To 6
                If row = 0 And col < startDayOfWeek Then
                    DataGridView1(col, row).Value = ""
                    DataGridView1(col, row).ReadOnly = True
                ElseIf currentDay <= daysInMonth Then
                    DataGridView1(col, row).Value = currentDay
                    DataGridView1(col, row).ReadOnly = True ' Prevent typing in cells
                    currentDay += 1
                Else
                    DataGridView1(col, row).Value = ""
                    DataGridView1(col, row).ReadOnly = True
                End If
            Next
        Next
    End Sub


    Private Sub SetupCalendar()
        DataGridView1.ColumnCount = 7
        DataGridView1.Columns(0).Name = "Sun"
        DataGridView1.Columns(1).Name = "Mon"
        DataGridView1.Columns(2).Name = "Tue"
        DataGridView1.Columns(3).Name = "Wed"
        DataGridView1.Columns(4).Name = "Thu"
        DataGridView1.Columns(5).Name = "Fri"
        DataGridView1.Columns(6).Name = "Sat"

        DataGridView1.RowTemplate.Height = 50
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.RowCount = 6
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.ReadOnly = True ' Make the entire grid non-editable
        DataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect ' Allow cell selection
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue ' Optional: Highlight selected cell
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black ' Optional: Maintain text visibility
    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        form2.Show()
        Me.Hide()
    End Sub

    Private Sub btnSignOut_Click(sender As Object, e As EventArgs) Handles btnSignOut.Click
        CloseConnections()
        Me.Hide()
        Dim form1 As New Form1()
        form1.Show()
    End Sub
    Private Sub CloseConnections()
        Dim connection As New MySqlConnection("Server=127.0.0.1;Port=3306;Database=accounts;Uid=root;Pwd=admin;")
        connection.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form9.Show()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedDay As String = DataGridView1(e.ColumnIndex, e.RowIndex).Value?.ToString().Trim()

            ' Check if the selected cell contains a valid day
            If Not String.IsNullOrEmpty(selectedDay) AndAlso IsNumeric(selectedDay) Then
                Dim selectedDate As New DateTime(currentYear, currentMonth, CInt(selectedDay))
                lblMonth.Text = selectedDate.ToString("MMMM d, yyyy") ' Update the label with the full date
            Else
                lblMonth.Text = New DateTime(currentYear, currentMonth, 1).ToString("MMMM yyyy") ' Default to month and year
            End If
        End If
        DataGridView1.ClearSelection()
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            DataGridView1(e.ColumnIndex, e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub lblSelectedDate_Click(sender As Object, e As EventArgs) Handles lblMonth.Click
        lblMonth.Text = DateTime.Now.ToString("MMMM d, yyyy")  ' Month and Year
    End Sub

    Private Sub btnPreviousMonth_Click(sender As Object, e As EventArgs) Handles btnPreviousMonth.Click
        If currentMonth = 1 Then
            currentMonth = 12
            currentYear -= 1
        Else
            currentMonth -= 1
        End If
        LoadMonthCalendar(currentMonth, currentYear)
        lblMonth.Text = New DateTime(currentYear, currentMonth, 1).ToString("MMMM yyyy")
    End Sub

    Private Sub btnNextMonth_Click(sender As Object, e As EventArgs) Handles btnNextMonth.Click
        If currentMonth = 12 Then
            currentMonth = 1
            currentYear += 1
        Else
            currentMonth += 1
        End If

        ' Update the calendar and label
        LoadMonthCalendar(currentMonth, currentYear)
        lblMonth.Text = New DateTime(currentYear, currentMonth, 1).ToString("MMMM yyyy")
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Me.Hide()
        Form13.Show()
    End Sub
End Class