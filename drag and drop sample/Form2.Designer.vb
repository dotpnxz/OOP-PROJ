<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form2))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.btnCreateUser = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.txtFullname = New System.Windows.Forms.TextBox()
        Me.rbtnStudent = New System.Windows.Forms.RadioButton()
        Me.rbtnCounselor = New System.Windows.Forms.RadioButton()
        Me.rbtnDirector = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(286, 117)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 40)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Sign Up"
        '
        'txtUsername
        '
        Me.txtUsername.ForeColor = System.Drawing.Color.DimGray
        Me.txtUsername.Location = New System.Drawing.Point(356, 200)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(180, 26)
        Me.txtUsername.TabIndex = 6
        Me.txtUsername.Text = "Username"
        '
        'btnCreateUser
        '
        Me.btnCreateUser.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCreateUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateUser.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnCreateUser.Location = New System.Drawing.Point(225, 340)
        Me.btnCreateUser.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCreateUser.Name = "btnCreateUser"
        Me.btnCreateUser.Size = New System.Drawing.Size(252, 37)
        Me.btnCreateUser.TabIndex = 10
        Me.btnCreateUser.Text = "Create Account"
        Me.btnCreateUser.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.ForeColor = System.Drawing.Color.DimGray
        Me.txtPassword.Location = New System.Drawing.Point(165, 240)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(180, 26)
        Me.txtPassword.TabIndex = 11
        Me.txtPassword.Text = "Password"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.ForeColor = System.Drawing.Color.DimGray
        Me.txtConfirmPassword.Location = New System.Drawing.Point(356, 240)
        Me.txtConfirmPassword.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(182, 26)
        Me.txtConfirmPassword.TabIndex = 12
        Me.txtConfirmPassword.Text = "Confirm Password"
        '
        'txtFullname
        '
        Me.txtFullname.ForeColor = System.Drawing.Color.DimGray
        Me.txtFullname.Location = New System.Drawing.Point(165, 200)
        Me.txtFullname.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFullname.Name = "txtFullname"
        Me.txtFullname.Size = New System.Drawing.Size(180, 26)
        Me.txtFullname.TabIndex = 15
        Me.txtFullname.Text = "Full Name"
        '
        'rbtnStudent
        '
        Me.rbtnStudent.AutoSize = True
        Me.rbtnStudent.BackColor = System.Drawing.Color.White
        Me.rbtnStudent.Location = New System.Drawing.Point(198, 289)
        Me.rbtnStudent.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtnStudent.Name = "rbtnStudent"
        Me.rbtnStudent.Size = New System.Drawing.Size(91, 24)
        Me.rbtnStudent.TabIndex = 16
        Me.rbtnStudent.TabStop = True
        Me.rbtnStudent.Text = "Student"
        Me.rbtnStudent.UseVisualStyleBackColor = False
        '
        'rbtnCounselor
        '
        Me.rbtnCounselor.AutoSize = True
        Me.rbtnCounselor.BackColor = System.Drawing.Color.White
        Me.rbtnCounselor.Location = New System.Drawing.Point(300, 289)
        Me.rbtnCounselor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtnCounselor.Name = "rbtnCounselor"
        Me.rbtnCounselor.Size = New System.Drawing.Size(106, 24)
        Me.rbtnCounselor.TabIndex = 17
        Me.rbtnCounselor.TabStop = True
        Me.rbtnCounselor.Text = "Counselor"
        Me.rbtnCounselor.UseVisualStyleBackColor = False
        '
        'rbtnDirector
        '
        Me.rbtnDirector.AutoSize = True
        Me.rbtnDirector.BackColor = System.Drawing.Color.White
        Me.rbtnDirector.Location = New System.Drawing.Point(417, 289)
        Me.rbtnDirector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbtnDirector.Name = "rbtnDirector"
        Me.rbtnDirector.Size = New System.Drawing.Size(90, 24)
        Me.rbtnDirector.TabIndex = 18
        Me.rbtnDirector.TabStop = True
        Me.rbtnDirector.Text = "Director"
        Me.rbtnDirector.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(9, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 31)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'form2
        '
        Me.AccessibleDescription = ""
        Me.AccessibleName = ""
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(717, 523)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rbtnDirector)
        Me.Controls.Add(Me.rbtnCounselor)
        Me.Controls.Add(Me.rbtnStudent)
        Me.Controls.Add(Me.txtFullname)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.btnCreateUser)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label2)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Signup "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents btnCreateUser As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents txtFullname As TextBox
    Friend WithEvents rbtnStudent As RadioButton
    Friend WithEvents rbtnCounselor As RadioButton
    Friend WithEvents rbtnDirector As RadioButton
    Friend WithEvents Button1 As Button
End Class
