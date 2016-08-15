namespace CSProject
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.UsernameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.PasswordLabel = new MaterialSkin.Controls.MaterialLabel();
            this.UsernameField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PasswordField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.LoginButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.CheckTokenButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.GameStartButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.console = new System.Windows.Forms.TextBox();
            this.arguCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.arguments = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.javaDir = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.javaCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UsernameLabel.Depth = 0;
            this.UsernameLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.UsernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UsernameLabel.Location = new System.Drawing.Point(76, 72);
            this.UsernameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(76, 18);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PasswordLabel.Depth = 0;
            this.PasswordLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.PasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PasswordLabel.Location = new System.Drawing.Point(76, 102);
            this.PasswordLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(74, 18);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameField
            // 
            this.UsernameField.Depth = 0;
            this.UsernameField.Hint = "";
            this.UsernameField.Location = new System.Drawing.Point(158, 72);
            this.UsernameField.MouseState = MaterialSkin.MouseState.HOVER;
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.PasswordChar = '\0';
            this.UsernameField.SelectedText = "";
            this.UsernameField.SelectionLength = 0;
            this.UsernameField.SelectionStart = 0;
            this.UsernameField.Size = new System.Drawing.Size(193, 23);
            this.UsernameField.TabIndex = 2;
            this.UsernameField.UseSystemPasswordChar = false;
            // 
            // PasswordField
            // 
            this.PasswordField.Depth = 0;
            this.PasswordField.Hint = "";
            this.PasswordField.Location = new System.Drawing.Point(158, 101);
            this.PasswordField.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '\0';
            this.PasswordField.SelectedText = "";
            this.PasswordField.SelectionLength = 0;
            this.PasswordField.SelectionStart = 0;
            this.PasswordField.Size = new System.Drawing.Size(193, 23);
            this.PasswordField.TabIndex = 3;
            this.PasswordField.UseSystemPasswordChar = false;
            // 
            // LoginButton
            // 
            this.LoginButton.AutoSize = true;
            this.LoginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoginButton.Depth = 0;
            this.LoginButton.Location = new System.Drawing.Point(372, 80);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LoginButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Primary = false;
            this.LoginButton.Size = new System.Drawing.Size(52, 36);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click_1);
            // 
            // CheckTokenButton
            // 
            this.CheckTokenButton.AutoSize = true;
            this.CheckTokenButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CheckTokenButton.Depth = 0;
            this.CheckTokenButton.Location = new System.Drawing.Point(13, 133);
            this.CheckTokenButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CheckTokenButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckTokenButton.Name = "CheckTokenButton";
            this.CheckTokenButton.Primary = false;
            this.CheckTokenButton.Size = new System.Drawing.Size(203, 36);
            this.CheckTokenButton.TabIndex = 5;
            this.CheckTokenButton.Text = "AccessToken Information";
            this.CheckTokenButton.UseVisualStyleBackColor = true;
            // 
            // GameStartButton
            // 
            this.GameStartButton.AutoSize = true;
            this.GameStartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GameStartButton.Depth = 0;
            this.GameStartButton.Location = new System.Drawing.Point(224, 133);
            this.GameStartButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GameStartButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.GameStartButton.Name = "GameStartButton";
            this.GameStartButton.Primary = false;
            this.GameStartButton.Size = new System.Drawing.Size(91, 36);
            this.GameStartButton.TabIndex = 6;
            this.GameStartButton.Text = "Link Start!";
            this.GameStartButton.UseVisualStyleBackColor = true;
            this.GameStartButton.Click += new System.EventHandler(this.GameStartButton_Click);
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.console.Location = new System.Drawing.Point(12, 249);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.console.Size = new System.Drawing.Size(476, 89);
            this.console.TabIndex = 8;
            // 
            // arguCheckBox
            // 
            this.arguCheckBox.AutoSize = true;
            this.arguCheckBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.arguCheckBox.Depth = 0;
            this.arguCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.arguCheckBox.Location = new System.Drawing.Point(9, 206);
            this.arguCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.arguCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.arguCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.arguCheckBox.Name = "arguCheckBox";
            this.arguCheckBox.Ripple = true;
            this.arguCheckBox.Size = new System.Drawing.Size(130, 30);
            this.arguCheckBox.TabIndex = 11;
            this.arguCheckBox.Text = "JVM Arguments";
            this.arguCheckBox.UseVisualStyleBackColor = false;
            this.arguCheckBox.CheckedChanged += new System.EventHandler(this.arguCheckBox_CheckedChanged_1);
            // 
            // arguments
            // 
            this.arguments.Depth = 0;
            this.arguments.Hint = "";
            this.arguments.Location = new System.Drawing.Point(158, 210);
            this.arguments.MouseState = MaterialSkin.MouseState.HOVER;
            this.arguments.Name = "arguments";
            this.arguments.PasswordChar = '\0';
            this.arguments.SelectedText = "";
            this.arguments.SelectionLength = 0;
            this.arguments.SelectionStart = 0;
            this.arguments.Size = new System.Drawing.Size(330, 23);
            this.arguments.TabIndex = 12;
            this.arguments.Text = "-Xmx1G -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy" +
    " -Xmn128M";
            this.arguments.UseSystemPasswordChar = false;
            // 
            // javaDir
            // 
            this.javaDir.Depth = 0;
            this.javaDir.Hint = "";
            this.javaDir.Location = new System.Drawing.Point(158, 178);
            this.javaDir.MouseState = MaterialSkin.MouseState.HOVER;
            this.javaDir.Name = "javaDir";
            this.javaDir.PasswordChar = '\0';
            this.javaDir.SelectedText = "";
            this.javaDir.SelectionLength = 0;
            this.javaDir.SelectionStart = 0;
            this.javaDir.Size = new System.Drawing.Size(330, 23);
            this.javaDir.TabIndex = 14;
            this.javaDir.UseSystemPasswordChar = false;
            // 
            // javaCheckBox
            // 
            this.javaCheckBox.AutoSize = true;
            this.javaCheckBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.javaCheckBox.Depth = 0;
            this.javaCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.javaCheckBox.Location = new System.Drawing.Point(9, 174);
            this.javaCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.javaCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.javaCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.javaCheckBox.Name = "javaCheckBox";
            this.javaCheckBox.Ripple = true;
            this.javaCheckBox.Size = new System.Drawing.Size(97, 30);
            this.javaCheckBox.TabIndex = 13;
            this.javaCheckBox.Text = "Executable";
            this.javaCheckBox.UseVisualStyleBackColor = false;
            this.javaCheckBox.CheckedChanged += new System.EventHandler(this.javaCheckBox_CheckedChanged_1);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.javaDir);
            this.Controls.Add(this.javaCheckBox);
            this.Controls.Add(this.arguments);
            this.Controls.Add(this.arguCheckBox);
            this.Controls.Add(this.console);
            this.Controls.Add(this.GameStartButton);
            this.Controls.Add(this.CheckTokenButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.UsernameField);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.MaximumSize = new System.Drawing.Size(500, 350);
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "Main";
            this.Text = "TeamCroatia Client";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel UsernameLabel;
        private MaterialSkin.Controls.MaterialLabel PasswordLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField UsernameField;
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordField;
        private MaterialSkin.Controls.MaterialFlatButton LoginButton;
        private MaterialSkin.Controls.MaterialFlatButton CheckTokenButton;
        private MaterialSkin.Controls.MaterialFlatButton GameStartButton;
        private System.Windows.Forms.TextBox console;
        private MaterialSkin.Controls.MaterialCheckBox arguCheckBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField arguments;
        private MaterialSkin.Controls.MaterialSingleLineTextField javaDir;
        private MaterialSkin.Controls.MaterialCheckBox javaCheckBox;
    }
}

