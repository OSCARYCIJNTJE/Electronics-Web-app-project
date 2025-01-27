namespace ElectronicsPanel
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            label2 = new Label();
            UsernameTxtBx = new TextBox();
            PasswordTxtBx = new TextBox();
            LoginBtn = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(267, 242);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(267, 306);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // UsernameTxtBx
            // 
            UsernameTxtBx.Location = new Point(348, 239);
            UsernameTxtBx.Name = "UsernameTxtBx";
            UsernameTxtBx.Size = new Size(205, 27);
            UsernameTxtBx.TabIndex = 2;
            // 
            // PasswordTxtBx
            // 
            PasswordTxtBx.Location = new Point(348, 299);
            PasswordTxtBx.Name = "PasswordTxtBx";
            PasswordTxtBx.Size = new Size(205, 27);
            PasswordTxtBx.TabIndex = 3;
            // 
            // LoginBtn
            // 
            LoginBtn.Location = new Point(315, 363);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(190, 53);
            LoginBtn.TabIndex = 4;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.computer_shop_icon;
            pictureBox1.Location = new Point(267, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(286, 184);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(LoginBtn);
            Controls.Add(PasswordTxtBx);
            Controls.Add(UsernameTxtBx);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox UsernameTxtBx;
        private TextBox PasswordTxtBx;
        private Button LoginBtn;
        private PictureBox pictureBox1;
    }
}