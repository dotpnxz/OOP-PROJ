<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnPreviousMonth = New System.Windows.Forms.Button()
        Me.btnNextMonth = New System.Windows.Forms.Button()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.comboBoxTimeSelection = New System.Windows.Forms.ComboBox()
        Me.btnBookAppointment = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(200, 102)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.Size = New System.Drawing.Size(1119, 540)
        Me.DataGridView1.TabIndex = 0
        '
        'btnPreviousMonth
        '
        Me.btnPreviousMonth.BackColor = System.Drawing.Color.White
        Me.btnPreviousMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviousMonth.Location = New System.Drawing.Point(196, 55)
        Me.btnPreviousMonth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPreviousMonth.Name = "btnPreviousMonth"
        Me.btnPreviousMonth.Size = New System.Drawing.Size(147, 35)
        Me.btnPreviousMonth.TabIndex = 2
        Me.btnPreviousMonth.Text = "Previous Month"
        Me.btnPreviousMonth.UseVisualStyleBackColor = False
        '
        'btnNextMonth
        '
        Me.btnNextMonth.BackColor = System.Drawing.Color.White
        Me.btnNextMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextMonth.Location = New System.Drawing.Point(352, 55)
        Me.btnNextMonth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNextMonth.Name = "btnNextMonth"
        Me.btnNextMonth.Size = New System.Drawing.Size(147, 35)
        Me.btnNextMonth.TabIndex = 3
        Me.btnNextMonth.Text = "Next Month"
        Me.btnNextMonth.UseVisualStyleBackColor = False
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.Location = New System.Drawing.Point(818, 49)
        Me.lblMonth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(111, 37)
        Me.lblMonth.TabIndex = 5
        Me.lblMonth.Text = "Month"
        '
        'comboBoxTimeSelection
        '
        Me.comboBoxTimeSelection.FormattingEnabled = True
        Me.comboBoxTimeSelection.Location = New System.Drawing.Point(16, 102)
        Me.comboBoxTimeSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.comboBoxTimeSelection.Name = "comboBoxTimeSelection"
        Me.comboBoxTimeSelection.Size = New System.Drawing.Size(180, 28)
        Me.comboBoxTimeSelection.TabIndex = 6
        '
        'btnBookAppointment
        '
        Me.btnBookAppointment.BackColor = System.Drawing.Color.White
        Me.btnBookAppointment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBookAppointment.Location = New System.Drawing.Point(16, 145)
        Me.btnBookAppointment.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBookAppointment.Name = "btnBookAppointment"
        Me.btnBookAppointment.Size = New System.Drawing.Size(176, 35)
        Me.btnBookAppointment.TabIndex = 7
        Me.btnBookAppointment.Text = "Book Appointment"
        Me.btnBookAppointment.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1172, 5)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(147, 35)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Sign Out"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(16, 189)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(176, 68)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "View My Appointments"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1324, 651)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnBookAppointment)
        Me.Controls.Add(Me.comboBoxTimeSelection)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.btnNextMonth)
        Me.Controls.Add(Me.btnPreviousMonth)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Student Tab"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnPreviousMonth As Button
    Friend WithEvents btnNextMonth As Button
    Friend WithEvents lblMonth As Label
    Friend WithEvents comboBoxTimeSelection As ComboBox
    Friend WithEvents btnBookAppointment As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
End Class
