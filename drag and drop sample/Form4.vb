Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports Mysqlx

Public Class Form4
    ' Declare variables
    Private currentMonth As Integer = DateTime.Now.Month
    Private currentYear As Integer = DateTime.Now.Year
    Private eventsDict As New Dictionary(Of DateTime, String)
    Private occupiedSlots As New Dictionary(Of DateTime, List(Of String))
    ' Form Load event
    Private Sub AppointmentCalendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup the DataGridView to display calendar days
        SetupCalendar()
        LoadMonthCalendar(currentMonth, currentYear)


        ' Populate the ComboBox with time slots from 10:00 AM to 4:00 PM in 12-hour format
        comboBoxTimeSelection.Items.Clear()
        For hour As Integer = 10 To 16
            Dim formattedHour As Integer = If(hour > 12, hour - 12, hour)  ' Convert to 12-hour format
            Dim period As String = If(hour < 12, "AM", "PM")                ' Determine AM or PM

            comboBoxTimeSelection.Items.Add($"{formattedHour}:00 {period}")
        Next
    End Sub
    ' Setup the DataGridView columns and rows to represent the days of the week
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
    End Sub

    ' Load the calendar for the current month and year
    Private Sub LoadMonthCalendar(month As Integer, year As Integer)
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(6) ' Add 6 rows to accommodate all possible weeks in a month

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
                    Dim currentDate As New DateTime(year, month, currentDay)
                    Dim displayText As String = currentDay.ToString()

                    ' To avoid duplication, first check for occupied slots on the day
                    ' Display the updated text in the cell
                    DataGridView1(col, row).Value = displayText
                    DataGridView1(col, row).ReadOnly = True
                    DataGridView1(col, row).Style.WrapMode = DataGridViewTriState.True
                    DataGridView1(col, row).Style.Alignment = DataGridViewContentAlignment.TopLeft

                    currentDay += 1
                Else
                    DataGridView1(col, row).Value = ""
                    DataGridView1(col, row).ReadOnly = True
                End If
            Next
        Next
    End Sub
    ' Handle cell click event to set an appointment
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        ' Retrieve the selected cell value
        Dim selectedDay As String = DataGridView1.CurrentCell.Value?.ToString().Trim()

        ' Check if the selectedDay is not empty and remove any "BOOKed" text
        If Not String.IsNullOrEmpty(selectedDay) Then
            ' Remove "BOOKed" or any other text and trim the string to get only the numeric part
            selectedDay = selectedDay.Replace("Booked", "").Trim()

            ' Check if selectedDay is numeric to avoid errors
            If Integer.TryParse(selectedDay, Nothing) Then
                Dim originalDay As Integer = CInt(selectedDay)
                Dim selectedDate As New DateTime(currentYear, currentMonth, originalDay)

                ' Check if the selected date is Saturday or Sunday
                If selectedDate.DayOfWeek = DayOfWeek.Saturday OrElse selectedDate.DayOfWeek = DayOfWeek.Sunday Then
                    MessageBox.Show("Scheduling is not allowed on weekends.")
                    Return
                End If

                ' Update label to show the selected date
                lblMonth.Text = selectedDate.ToString("MMMM d, yyyy")
            Else
                MessageBox.Show("Invalid date selected. Please select a valid day.")
            End If
        End If
    End Sub





    ' Book appointment when the button is clicked
    Private Sub btnBookAppointment_Click(sender As Object, e As EventArgs) Handles btnBookAppointment.Click
        Dim selectedDay As String = DataGridView1.CurrentCell.Value.ToString().Trim()

        ' Check if selectedDay is not empty and contains a valid date part
        If Not String.IsNullOrEmpty(selectedDay) Then
            ' Extract day from the selectedDay string (date number before any "Booked" word)
            Dim dayPart As String = selectedDay.Split(" "c)(0) ' Get only the date number part

            ' Try to parse the extracted day part to an integer (e.g., 20 from "Date: 20")
            Dim originalDay As Integer
            If Integer.TryParse(dayPart, originalDay) Then
                ' Proceed to create a DateTime object for the selected date
                Dim selectedDate As New DateTime(currentYear, currentMonth, originalDay)

                ' Ensure an appointment time is selected
                If comboBoxTimeSelection.SelectedItem Is Nothing Then
                    MessageBox.Show("Please select an appointment time.")
                    Return
                End If

                ' Get the selected time for the appointment
                Dim appointmentTime As String = comboBoxTimeSelection.SelectedItem.ToString()
                Dim appointmentDateTime As DateTime

                ' Prompt user to input appointment details
                Dim appointmentDetails As String = InputBox("Enter appointment details for " & selectedDate.ToShortDateString() & " at " & appointmentTime, "Appointment Details")

                ' Ensure that the user has entered appointment details
                If String.IsNullOrEmpty(appointmentDetails) Then
                    MessageBox.Show("Please enter details for the appointment.")
                    Return
                End If

                ' Attempt to parse the appointment time
                If DateTime.TryParseExact(appointmentTime, {"hh:mm tt", "h:mm tt"}, Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, appointmentDateTime) Then
                    ' Combine selected date with parsed appointment time
                    appointmentDateTime = selectedDate.Date.Add(appointmentDateTime.TimeOfDay)

                    ' Check if the appointment already exists for the selected time
                    If AppointmentExists(appointmentDateTime) Then
                        MessageBox.Show("Appointment already exists for this time. Please choose a different time slot.")
                        Return
                    End If

                    ' Check if the daily appointment limit has been reached
                    If IsAppointmentLimitReached(selectedDate) Then
                        MessageBox.Show("Appointment limit for this day has been reached.")
                        Return
                    End If

                    ' Proceed with booking the appointment
                    ' Save appointment details to the dictionary (optional, depending on your use case)
                    eventsDict(appointmentDateTime) = appointmentDetails

                    ' Get the logged-in user's ID
                    Dim userId As Integer = GetLoggedInUserId()

                    ' Save the appointment to the database
                    SaveAppointmentToDatabase(appointmentDateTime, appointmentDetails, userId)

                    ' Show a confirmation message to the user
                    MessageBox.Show($"Appointment scheduled for: {appointmentDateTime}")

                    ' Update the DataGridView cell content to show "Booked" below the date number
                    MarkCellAsBooked(selectedDate, originalDay)
                Else
                    ' If the time format is invalid, show an error message
                    MessageBox.Show("Invalid time format. Please ensure the time is in 'hh:mm tt' (12-hour) or 'HH:mm' (24-hour) format.")
                End If
            Else
                MessageBox.Show("Invalid day format. Please select a valid day.")
            End If
        Else
            MessageBox.Show("Please select a valid date.")
        End If
    End Sub

    Private Sub MarkCellAsBooked(selectedDate As DateTime, originalDay As Integer)
        ' Track appointments for each day using a dictionary (you can add this at the class level)
        ' Dictionary to hold the number of appointments per day (Day -> Appointment Count)
        Static appointmentCountDict As New Dictionary(Of DateTime, Integer)

        ' Iterate through all rows and cells in the DataGridView
        For Each row As DataGridViewRow In DataGridView1.Rows
            For Each cell As DataGridViewCell In row.Cells
                ' Ensure the cell contains a numeric value for the day
                If cell.Value IsNot Nothing AndAlso IsNumeric(cell.Value) Then
                    Dim dayValue As Integer = CInt(cell.Value)

                    ' If the cell's value matches the selected day, mark it as "Booked"
                    If dayValue = originalDay Then
                        ' Increment appointment count for the selected day
                        If appointmentCountDict.ContainsKey(selectedDate) Then
                            appointmentCountDict(selectedDate) += 1
                        Else
                            appointmentCountDict.Add(selectedDate, 1)
                        End If

                        ' Check if the day is fully booked
                        If appointmentCountDict(selectedDate) = 2 Then
                            ' Fully booked, update cell tooltip and appearance
                            cell.ToolTipText = "Fully Booked"

                            cell.Style.BackColor = Color.Gray ' Change background color for fully booked
                            cell.Style.ForeColor = Color.White ' Change text color for fully booked
                        ElseIf appointmentCountDict(selectedDate) = 1 Then
                            ' 1 appointment left
                            cell.ToolTipText = "1 appointment left"

                            cell.Style.BackColor = Color.LightYellow ' Light background for partially booked
                            cell.Style.ForeColor = Color.Black ' Normal text color
                        End If

                        ' Stop once the correct cell is found and updated
                        Return
                    End If
                End If
            Next
        Next
    End Sub



    ' Function to check the number of appointments for a given day
    Private Function GetAppointmentCountForDay(selectedDate As DateTime) As Integer
        ' Your existing logic to count appointments for the selected date
        If eventsDict.ContainsKey(selectedDate) Then
            Return eventsDict(selectedDate).Count
        End If
        Return 0
    End Function
    Private Function AppointmentExists(appointmentDateTime As DateTime) As Boolean
        ' Check if an appointment already exists for the given date and time in the database
        Dim connectionString As String = "Server=127.0.0.1;Port=3306;Database=accounts;Uid=root;Pwd=admin;"
        Dim exists As Boolean = False

        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM appointments WHERE appointment_date = @appointmentDateTime"
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@appointmentDateTime", appointmentDateTime)

                ' Execute query and check if any rows are returned
                Dim result As Object = command.ExecuteScalar()
                If Convert.ToInt32(result) > 0 Then
                    exists = True
                End If
            End Using
        End Using

        Return exists
    End Function

    Private Function IsAppointmentLimitReached(selectedDate As DateTime) As Boolean
        ' Check if the appointment limit for the given day has been reached
        Dim connectionString As String = "Server=127.0.0.1;Port=3306;Database=accounts;Uid=root;Pwd=admin;"
        Dim limitReached As Boolean = False

        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM appointments WHERE DATE(appointment_date) = @selectedDate"
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@selectedDate", selectedDate.Date)

                ' Execute query and check the count of appointments for the day
                Dim result As Object = command.ExecuteScalar()
                If Convert.ToInt32(result) >= 2 Then ' Assuming a limit of 2 appointments per day
                    limitReached = True
                End If
            End Using
        End Using

        Return limitReached
    End Function



    Private Sub SaveAppointmentToDatabase(appointmentDateTime As DateTime, description As String, userId As Integer)
        ' Correct connection string for MySQL
        Dim connectionString As String = "Server=127.0.0.1;Port=3306;Database=accounts;Uid=root;Pwd=admin;"

        ' Use MySqlConnection instead of SqlConnection for MySQL
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Use MySqlCommand instead of SqlCommand for MySQL
            Dim command As New MySqlCommand("INSERT INTO appointments (user_id, appointment_date, description, status) VALUES (@userId, @date, @description, @status)", connection)

            ' Adding parameters to avoid SQL injection
            command.Parameters.AddWithValue("@userId", userId)
            command.Parameters.AddWithValue("@date", appointmentDateTime) ' Pass the full DateTime here
            command.Parameters.AddWithValue("@description", description)
            command.Parameters.AddWithValue("@status", "Booked")  ' Default status can be "Booked"

            ' Execute the query to insert the appointment
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Function GetLoggedInUserId() As Integer
        ' Return the user ID of the currently logged-in user
        Return Form1.LoggedInUserId
    End Function


    Private Sub lblSelectedDate_Click(sender As Object, e As EventArgs) Handles lblMonth.Click
        lblMonth.Text = DateTime.Now.ToString("MMMM yyyy")  ' Month and Year
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form8.Show()
        Me.Hide()
    End Sub

    Private Sub btnPreviousMonth_Click(sender As Object, e As EventArgs) Handles btnPreviousMonth.Click
        ' Decrement the month
        If currentMonth = 1 Then
            currentMonth = 12
            currentYear -= 1
        Else
            currentMonth -= 1
        End If

        ' Update the calendar and label
        LoadMonthCalendar(currentMonth, currentYear)
        lblMonth.Text = New DateTime(currentYear, currentMonth, 1).ToString("MMMM yyyy")
    End Sub

    Private Sub btnNextMonth_Click(sender As Object, e As EventArgs) Handles btnNextMonth.Click
        ' Increment the month
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CloseConnections()
        Me.Hide()
        Dim form1 As New Form1()
        form1.Show()
    End Sub
    Private Sub CloseConnections()
        Dim connection As New MySqlConnection("Server=127.0.0.1;Port=3306;Database=accounts;Uid=root;Pwd=admin;")
        connection.Close()

    End Sub
End Class
