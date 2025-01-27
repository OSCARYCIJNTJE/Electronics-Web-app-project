namespace ElectronicsPanel
{
    partial class Homepanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homepanel));
            ComputerPanelBtn = new Button();
            PhonePanelBtn = new Button();
            StatisticsPanelBtn = new Button();
            label1 = new Label();
            UsernameLabel = new Label();
            RoleLabel = new Label();
            EmployeePanelBtn = new Button();
            SuspendLayout();
            // 
            // ComputerPanelBtn
            // 
            ComputerPanelBtn.Location = new Point(94, 88);
            ComputerPanelBtn.Name = "ComputerPanelBtn";
            ComputerPanelBtn.Size = new Size(143, 59);
            ComputerPanelBtn.TabIndex = 0;
            ComputerPanelBtn.Text = "Computers";
            ComputerPanelBtn.UseVisualStyleBackColor = true;
            ComputerPanelBtn.Click += ComputerPanelBtn_Click;
            // 
            // PhonePanelBtn
            // 
            PhonePanelBtn.Location = new Point(94, 170);
            PhonePanelBtn.Name = "PhonePanelBtn";
            PhonePanelBtn.Size = new Size(143, 59);
            PhonePanelBtn.TabIndex = 1;
            PhonePanelBtn.Text = "Phones";
            PhonePanelBtn.UseVisualStyleBackColor = true;
            PhonePanelBtn.Click += PhonePanelBtn_Click;
            // 
            // StatisticsPanelBtn
            // 
            StatisticsPanelBtn.Location = new Point(94, 252);
            StatisticsPanelBtn.Name = "StatisticsPanelBtn";
            StatisticsPanelBtn.Size = new Size(143, 59);
            StatisticsPanelBtn.TabIndex = 2;
            StatisticsPanelBtn.Text = "Statistics";
            StatisticsPanelBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(428, 88);
            label1.Name = "label1";
            label1.Size = new Size(220, 62);
            label1.TabIndex = 4;
            label1.Text = "Welcome";
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(451, 173);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(111, 20);
            UsernameLabel.TabIndex = 5;
            UsernameLabel.Text = "UsernameLabel";
            // 
            // RoleLabel
            // 
            RoleLabel.AutoSize = true;
            RoleLabel.Location = new Point(451, 223);
            RoleLabel.Name = "RoleLabel";
            RoleLabel.Size = new Size(75, 20);
            RoleLabel.TabIndex = 6;
            RoleLabel.Text = "RoleLabel";
            // 
            // EmployeePanelBtn
            // 
            EmployeePanelBtn.Location = new Point(94, 331);
            EmployeePanelBtn.Name = "EmployeePanelBtn";
            EmployeePanelBtn.Size = new Size(143, 59);
            EmployeePanelBtn.TabIndex = 7;
            EmployeePanelBtn.Text = "Employees";
            EmployeePanelBtn.UseVisualStyleBackColor = true;
            EmployeePanelBtn.Click += EmployeePanelBtn_Click;
            // 
            // Homepanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(EmployeePanelBtn);
            Controls.Add(RoleLabel);
            Controls.Add(UsernameLabel);
            Controls.Add(label1);
            Controls.Add(StatisticsPanelBtn);
            Controls.Add(PhonePanelBtn);
            Controls.Add(ComputerPanelBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Homepanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Homepanel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ComputerPanelBtn;
        private Button PhonePanelBtn;
        private Button StatisticsPanelBtn;
        private Label label1;
        private Label UsernameLabel;
        private Label RoleLabel;
        private Button EmployeePanelBtn;
    }
}