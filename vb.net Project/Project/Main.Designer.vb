<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits MaterialSkin.Controls.MaterialForm

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Username = New MaterialSkin.Controls.MaterialLabel()
        Me.Password = New MaterialSkin.Controls.MaterialLabel()
        Me.TextFieldUsername = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.TextFieldPasword = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.LoginButton = New MaterialSkin.Controls.MaterialFlatButton()
        Me.SuspendLayout()
        '
        'Username
        '
        Me.Username.AutoSize = True
        Me.Username.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Username.Depth = 0
        Me.Username.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.Username.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Username.Location = New System.Drawing.Point(54, 139)
        Me.Username.MouseState = MaterialSkin.MouseState.HOVER
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(76, 18)
        Me.Username.TabIndex = 0
        Me.Username.Text = "Username"
        '
        'Password
        '
        Me.Password.AutoSize = True
        Me.Password.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Password.Depth = 0
        Me.Password.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.Password.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Password.Location = New System.Drawing.Point(54, 180)
        Me.Password.MouseState = MaterialSkin.MouseState.HOVER
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(74, 18)
        Me.Password.TabIndex = 1
        Me.Password.Text = "Password"
        '
        'TextFieldUsername
        '
        Me.TextFieldUsername.Depth = 0
        Me.TextFieldUsername.Hint = ""
        Me.TextFieldUsername.Location = New System.Drawing.Point(136, 139)
        Me.TextFieldUsername.MouseState = MaterialSkin.MouseState.HOVER
        Me.TextFieldUsername.Name = "TextFieldUsername"
        Me.TextFieldUsername.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextFieldUsername.SelectedText = ""
        Me.TextFieldUsername.SelectionLength = 0
        Me.TextFieldUsername.SelectionStart = 0
        Me.TextFieldUsername.Size = New System.Drawing.Size(226, 23)
        Me.TextFieldUsername.TabIndex = 2
        Me.TextFieldUsername.UseSystemPasswordChar = False
        '
        'TextFieldPasword
        '
        Me.TextFieldPasword.Depth = 0
        Me.TextFieldPasword.Hint = ""
        Me.TextFieldPasword.Location = New System.Drawing.Point(136, 180)
        Me.TextFieldPasword.MouseState = MaterialSkin.MouseState.HOVER
        Me.TextFieldPasword.Name = "TextFieldPasword"
        Me.TextFieldPasword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextFieldPasword.SelectedText = ""
        Me.TextFieldPasword.SelectionLength = 0
        Me.TextFieldPasword.SelectionStart = 0
        Me.TextFieldPasword.Size = New System.Drawing.Size(226, 23)
        Me.TextFieldPasword.TabIndex = 3
        Me.TextFieldPasword.UseSystemPasswordChar = False
        '
        'LoginButton
        '
        Me.LoginButton.AutoSize = True
        Me.LoginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.LoginButton.Depth = 0
        Me.LoginButton.Location = New System.Drawing.Point(383, 151)
        Me.LoginButton.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.LoginButton.MouseState = MaterialSkin.MouseState.HOVER
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Primary = False
        Me.LoginButton.Size = New System.Drawing.Size(52, 36)
        Me.LoginButton.TabIndex = 4
        Me.LoginButton.Text = "Login"
        Me.LoginButton.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 300)
        Me.Controls.Add(Me.LoginButton)
        Me.Controls.Add(Me.TextFieldPasword)
        Me.Controls.Add(Me.TextFieldUsername)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.Username)
        Me.MaximumSize = New System.Drawing.Size(500, 300)
        Me.MinimumSize = New System.Drawing.Size(500, 300)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TeamCroatia Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Username As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents Password As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents TextFieldUsername As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents TextFieldPasword As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents LoginButton As MaterialSkin.Controls.MaterialFlatButton
End Class
