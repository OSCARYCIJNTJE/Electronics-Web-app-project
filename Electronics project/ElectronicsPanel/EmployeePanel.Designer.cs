namespace ElectronicsPanel
{
    partial class EmployeePanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeePanel));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            tabPage2 = new TabPage();
            BtnAddEmployee = new Button();
            LblPhone = new Label();
            LblBSN = new Label();
            LblDepartment = new Label();
            LblPassword = new Label();
            LblUsername = new Label();
            LblEmail = new Label();
            LblLastName = new Label();
            LblFirstName = new Label();
            CmBxDepartment = new ComboBox();
            TxtBxPhoneNumber = new TextBox();
            TxtBxBsn = new TextBox();
            TxtBxPassword = new TextBox();
            TxtBxUsername = new TextBox();
            TxtBxEmail = new TextBox();
            TxtBxLastName = new TextBox();
            TxtBxFirstName = new TextBox();
            tabPage3 = new TabPage();
            groupBox1 = new GroupBox();
            BackToHomePanelBtn = new Button();
            BtnBack = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(168, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(904, 501);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(896, 468);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "View Employees";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(646, 318);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(BtnAddEmployee);
            tabPage2.Controls.Add(LblPhone);
            tabPage2.Controls.Add(LblBSN);
            tabPage2.Controls.Add(LblDepartment);
            tabPage2.Controls.Add(LblPassword);
            tabPage2.Controls.Add(LblUsername);
            tabPage2.Controls.Add(LblEmail);
            tabPage2.Controls.Add(LblLastName);
            tabPage2.Controls.Add(LblFirstName);
            tabPage2.Controls.Add(CmBxDepartment);
            tabPage2.Controls.Add(TxtBxPhoneNumber);
            tabPage2.Controls.Add(TxtBxBsn);
            tabPage2.Controls.Add(TxtBxPassword);
            tabPage2.Controls.Add(TxtBxUsername);
            tabPage2.Controls.Add(TxtBxEmail);
            tabPage2.Controls.Add(TxtBxLastName);
            tabPage2.Controls.Add(TxtBxFirstName);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(896, 468);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "AddEmployee";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnAddEmployee
            // 
            BtnAddEmployee.Location = new Point(304, 342);
            BtnAddEmployee.Name = "BtnAddEmployee";
            BtnAddEmployee.Size = new Size(231, 61);
            BtnAddEmployee.TabIndex = 17;
            BtnAddEmployee.Text = "Add employee";
            BtnAddEmployee.UseVisualStyleBackColor = true;
            BtnAddEmployee.Click += BtnAddEmployee_Click;
            // 
            // LblPhone
            // 
            LblPhone.AutoSize = true;
            LblPhone.Location = new Point(334, 158);
            LblPhone.Name = "LblPhone";
            LblPhone.Size = new Size(104, 20);
            LblPhone.TabIndex = 16;
            LblPhone.Text = "PhoneNumber";
            // 
            // LblBSN
            // 
            LblBSN.AutoSize = true;
            LblBSN.Location = new Point(334, 116);
            LblBSN.Name = "LblBSN";
            LblBSN.Size = new Size(37, 20);
            LblBSN.TabIndex = 15;
            LblBSN.Text = "BSN";
            // 
            // LblDepartment
            // 
            LblDepartment.AutoSize = true;
            LblDepartment.Location = new Point(334, 74);
            LblDepartment.Name = "LblDepartment";
            LblDepartment.Size = new Size(89, 20);
            LblDepartment.TabIndex = 14;
            LblDepartment.Text = "Department";
            // 
            // LblPassword
            // 
            LblPassword.AutoSize = true;
            LblPassword.Location = new Point(6, 261);
            LblPassword.Name = "LblPassword";
            LblPassword.Size = new Size(70, 20);
            LblPassword.TabIndex = 13;
            LblPassword.Text = "Password";
            // 
            // LblUsername
            // 
            LblUsername.AutoSize = true;
            LblUsername.Location = new Point(6, 210);
            LblUsername.Name = "LblUsername";
            LblUsername.Size = new Size(75, 20);
            LblUsername.TabIndex = 12;
            LblUsername.Text = "Username";
            // 
            // LblEmail
            // 
            LblEmail.AutoSize = true;
            LblEmail.Location = new Point(6, 158);
            LblEmail.Name = "LblEmail";
            LblEmail.Size = new Size(46, 20);
            LblEmail.TabIndex = 11;
            LblEmail.Text = "Email";
            // 
            // LblLastName
            // 
            LblLastName.AutoSize = true;
            LblLastName.Location = new Point(6, 112);
            LblLastName.Name = "LblLastName";
            LblLastName.Size = new Size(75, 20);
            LblLastName.TabIndex = 10;
            LblLastName.Text = "LastName";
            // 
            // LblFirstName
            // 
            LblFirstName.AutoSize = true;
            LblFirstName.Location = new Point(6, 69);
            LblFirstName.Name = "LblFirstName";
            LblFirstName.Size = new Size(76, 20);
            LblFirstName.TabIndex = 9;
            LblFirstName.Text = "FirstName";
            // 
            // CmBxDepartment
            // 
            CmBxDepartment.FormattingEnabled = true;
            CmBxDepartment.Location = new Point(444, 66);
            CmBxDepartment.Name = "CmBxDepartment";
            CmBxDepartment.Size = new Size(204, 28);
            CmBxDepartment.TabIndex = 8;
            // 
            // TxtBxPhoneNumber
            // 
            TxtBxPhoneNumber.Location = new Point(444, 155);
            TxtBxPhoneNumber.Name = "TxtBxPhoneNumber";
            TxtBxPhoneNumber.Size = new Size(204, 27);
            TxtBxPhoneNumber.TabIndex = 7;
            // 
            // TxtBxBsn
            // 
            TxtBxBsn.Location = new Point(444, 109);
            TxtBxBsn.Name = "TxtBxBsn";
            TxtBxBsn.Size = new Size(204, 27);
            TxtBxBsn.TabIndex = 6;
            // 
            // TxtBxPassword
            // 
            TxtBxPassword.Location = new Point(113, 254);
            TxtBxPassword.Name = "TxtBxPassword";
            TxtBxPassword.Size = new Size(204, 27);
            TxtBxPassword.TabIndex = 4;
            // 
            // TxtBxUsername
            // 
            TxtBxUsername.Location = new Point(113, 203);
            TxtBxUsername.Name = "TxtBxUsername";
            TxtBxUsername.Size = new Size(204, 27);
            TxtBxUsername.TabIndex = 3;
            // 
            // TxtBxEmail
            // 
            TxtBxEmail.Location = new Point(113, 155);
            TxtBxEmail.Name = "TxtBxEmail";
            TxtBxEmail.Size = new Size(204, 27);
            TxtBxEmail.TabIndex = 2;
            // 
            // TxtBxLastName
            // 
            TxtBxLastName.Location = new Point(113, 109);
            TxtBxLastName.Name = "TxtBxLastName";
            TxtBxLastName.Size = new Size(204, 27);
            TxtBxLastName.TabIndex = 1;
            // 
            // TxtBxFirstName
            // 
            TxtBxFirstName.Location = new Point(113, 66);
            TxtBxFirstName.Name = "TxtBxFirstName";
            TxtBxFirstName.Size = new Size(204, 27);
            TxtBxFirstName.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(896, 468);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Edit Employee";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BackToHomePanelBtn);
            groupBox1.Controls.Add(BtnBack);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(150, 497);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // BackToHomePanelBtn
            // 
            BackToHomePanelBtn.Location = new Point(6, 29);
            BackToHomePanelBtn.Name = "BackToHomePanelBtn";
            BackToHomePanelBtn.Size = new Size(138, 62);
            BackToHomePanelBtn.TabIndex = 1;
            BackToHomePanelBtn.Text = "HomePanel";
            BackToHomePanelBtn.UseVisualStyleBackColor = true;
            // 
            // BtnBack
            // 
            BtnBack.Location = new Point(6, 565);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(139, 59);
            BtnBack.TabIndex = 0;
            BtnBack.Text = "Back";
            BtnBack.UseVisualStyleBackColor = true;
            // 
            // EmployeePanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 517);
            Controls.Add(groupBox1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmployeePanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeePanel";
            Load += EmployeePanel_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private GroupBox groupBox1;
        private Button BtnBack;
        private Button BackToHomePanelBtn;
        private DataGridView dataGridView1;
        private ComboBox CmBxDepartment;
        private TextBox TxtBxPhoneNumber;
        private TextBox TxtBxBsn;
        private TextBox TxtBxPassword;
        private TextBox TxtBxUsername;
        private TextBox TxtBxEmail;
        private TextBox TxtBxLastName;
        private TextBox TxtBxFirstName;
        private Label LblPhone;
        private Label LblBSN;
        private Label LblDepartment;
        private Label LblPassword;
        private Label LblUsername;
        private Label LblEmail;
        private Label LblLastName;
        private Label LblFirstName;
        private Button BtnAddEmployee;
    }
}