<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnNextMonth = New System.Windows.Forms.Button()
        Me.btnPreviousMonth = New System.Windows.Forms.Button()
        Me.btnSignOut = New System.Windows.Forms.Button()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.btnHistory = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(208, 87)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.Size = New System.Drawing.Size(992, 453)
        Me.DataGridView1.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(5, 87)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(195, 65)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Show All Appointment"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnNextMonth
        '
        Me.btnNextMonth.BackColor = System.Drawing.Color.White
        Me.btnNextMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextMonth.Location = New System.Drawing.Point(362, 42)
        Me.btnNextMonth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNextMonth.Name = "btnNextMonth"
        Me.btnNextMonth.Size = New System.Drawing.Size(147, 35)
        Me.btnNextMonth.TabIndex = 16
        Me.btnNextMonth.Text = "Next Month"
        Me.btnNextMonth.UseVisualStyleBackColor = False
        '
        'btnPreviousMonth
        '
        Me.btnPreviousMonth.BackColor = System.Drawing.Color.White
        Me.btnPreviousMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviousMonth.Location = New System.Drawing.Point(206, 42)
        Me.btnPreviousMonth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPreviousMonth.Name = "btnPreviousMonth"
        Me.btnPreviousMonth.Size = New System.Drawing.Size(147, 35)
        Me.btnPreviousMonth.TabIndex = 15
        Me.btnPreviousMonth.Text = "Previous Month"
        Me.btnPreviousMonth.UseVisualStyleBackColor = False
        '
        'btnSignOut
        '
        Me.btnSignOut.BackColor = System.Drawing.Color.White
        Me.btnSignOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignOut.Location = New System.Drawing.Point(1053, 4)
        Me.btnSignOut.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSignOut.Name = "btnSignOut"
        Me.btnSignOut.Size = New System.Drawing.Size(147, 35)
        Me.btnSignOut.TabIndex = 17
        Me.btnSignOut.Text = "Sign Out"
        Me.btnSignOut.UseVisualStyleBackColor = False
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.Location = New System.Drawing.Point(729, 36)
        Me.lblMonth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(111, 37)
        Me.lblMonth.TabIndex = 19
        Me.lblMonth.Text = "Month"
        '
        'btnHistory
        '
        Me.btnHistory.BackColor = System.Drawing.Color.White
        Me.btnHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistory.Location = New System.Drawing.Point(5, 161)
        Me.btnHistory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(195, 65)
        Me.btnHistory.TabIndex = 23
        Me.btnHistory.Text = "History"
        Me.btnHistory.UseVisualStyleBackColor = False
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1210, 558)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.btnSignOut)
        Me.Controls.Add(Me.btnNextMonth)
        Me.Controls.Add(Me.btnPreviousMonth)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Form7"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guidance Director Tab"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents btnNextMonth As Button
    Friend WithEvents btnPreviousMonth As Button
    Friend WithEvents btnSignOut As Button
    Friend WithEvents lblMonth As Label
    Friend WithEvents btnHistory As Button
End Class
