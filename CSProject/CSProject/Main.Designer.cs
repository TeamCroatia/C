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
            this.DataDownloadButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.DownloadInfor = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UsernameLabel.Depth = 0;
            this.UsernameLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.UsernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UsernameLabel.Location = new System.Drawing.Point(68, 82);
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
            this.PasswordLabel.Location = new System.Drawing.Point(68, 126);
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
            this.UsernameField.Location = new System.Drawing.Point(150, 82);
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
            this.PasswordField.Location = new System.Drawing.Point(150, 125);
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
            this.LoginButton.Depth = 0;
            this.LoginButton.Location = new System.Drawing.Point(368, 98);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LoginButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Primary = false;
            this.LoginButton.Size = new System.Drawing.Size(52, 36);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click_1);
            // 
            // CheckTokenButton
            // 
            this.CheckTokenButton.AutoSize = true;
            this.CheckTokenButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CheckTokenButton.Depth = 0;
            this.CheckTokenButton.Location = new System.Drawing.Point(13, 248);
            this.CheckTokenButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CheckTokenButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckTokenButton.Name = "CheckTokenButton";
            this.CheckTokenButton.Primary = false;
            this.CheckTokenButton.Size = new System.Drawing.Size(203, 36);
            this.CheckTokenButton.TabIndex = 5;
            this.CheckTokenButton.Text = "AccessToken Information";
            this.CheckTokenButton.UseVisualStyleBackColor = true;
            this.CheckTokenButton.Click += new System.EventHandler(this.CheckTokenButton_Click);
            // 
            // GameStartButton
            // 
            this.GameStartButton.AutoSize = true;
            this.GameStartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GameStartButton.Depth = 0;
            this.GameStartButton.Location = new System.Drawing.Point(188, 200);
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
            // DataDownloadButton
            // 
            this.DataDownloadButton.AutoSize = true;
            this.DataDownloadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DataDownloadButton.Depth = 0;
            this.DataDownloadButton.Location = new System.Drawing.Point(13, 200);
            this.DataDownloadButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DataDownloadButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.DataDownloadButton.Name = "DataDownloadButton";
            this.DataDownloadButton.Primary = false;
            this.DataDownloadButton.Size = new System.Drawing.Size(167, 36);
            this.DataDownloadButton.TabIndex = 7;
            this.DataDownloadButton.Text = "Resources Download";
            this.DataDownloadButton.UseVisualStyleBackColor = true;
            this.DataDownloadButton.Click += new System.EventHandler(this.DataDownloadButton_Click);
            // 
            // DownloadInfor
            // 
            this.DownloadInfor.AutoSize = true;
            this.DownloadInfor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DownloadInfor.Depth = 0;
            this.DownloadInfor.Font = new System.Drawing.Font("Roboto", 11F);
            this.DownloadInfor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DownloadInfor.Location = new System.Drawing.Point(37, 165);
            this.DownloadInfor.MouseState = MaterialSkin.MouseState.HOVER;
            this.DownloadInfor.Name = "DownloadInfor";
            this.DownloadInfor.Size = new System.Drawing.Size(103, 18);
            this.DownloadInfor.TabIndex = 8;
            this.DownloadInfor.Text = "File Download";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.DownloadInfor);
            this.Controls.Add(this.DataDownloadButton);
            this.Controls.Add(this.GameStartButton);
            this.Controls.Add(this.CheckTokenButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.UsernameField);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
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
        private MaterialSkin.Controls.MaterialFlatButton DataDownloadButton;
        private MaterialSkin.Controls.MaterialLabel DownloadInfor;
    }
}

