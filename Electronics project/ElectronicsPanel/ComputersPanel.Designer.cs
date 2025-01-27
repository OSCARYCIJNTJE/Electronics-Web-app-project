namespace ElectronicsPanel
{
    partial class ComputersPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComputersPanel));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            BtnRefresh = new Button();
            TxtBxSearch = new TextBox();
            BtnDelete = new Button();
            BtnView = new Button();
            BtnEdit = new Button();
            DgVComputer = new DataGridView();
            tabPage2 = new TabPage();
            label27 = new Label();
            TxtBxModel = new TextBox();
            BtnAddImage = new Button();
            BtnGeneratePorts = new Button();
            label13 = new Label();
            TxtBxPowerSource = new TextBox();
            NupPorts = new NumericUpDown();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            TxtBxMouseType = new TextBox();
            TxtBxKeyboardType = new TextBox();
            TxtBxRam = new TextBox();
            TxtBxProcessor = new TextBox();
            TxtBxPrice = new TextBox();
            TxtBxStock = new TextBox();
            TxtBxStorageCapacity = new TextBox();
            TxtBxScreenSize = new TextBox();
            TxtBxOperatingSystem = new TextBox();
            PbxImageAdd = new PictureBox();
            label1 = new Label();
            AddBtn = new Button();
            TxtBxCompName = new TextBox();
            tabPage3 = new TabPage();
            label28 = new Label();
            TxtBxEditModel = new TextBox();
            BtnCancelEdit = new Button();
            BtnEditImage = new Button();
            NupEditPorts = new NumericUpDown();
            label25 = new Label();
            label26 = new Label();
            PbxEditImage = new PictureBox();
            BtnEditComputer = new Button();
            label14 = new Label();
            TxtBxEditPowerSource = new TextBox();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            TxtBxEditMouseType = new TextBox();
            TxtBxEditKeyboardType = new TextBox();
            TxtBxEditRam = new TextBox();
            TxtBxEditProcessor = new TextBox();
            TxtBxEditPrice = new TextBox();
            TxtBxEditStock = new TextBox();
            TxtBxEditStorage = new TextBox();
            TxtBxEditScreenSize = new TextBox();
            TxtBxEditOs = new TextBox();
            label24 = new Label();
            TxtBxEditName = new TextBox();
            groupBox1 = new GroupBox();
            BtnBack = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgVComputer).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NupPorts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbxImageAdd).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NupEditPorts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbxEditImage).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(167, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1344, 631);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(BtnRefresh);
            tabPage1.Controls.Add(TxtBxSearch);
            tabPage1.Controls.Add(BtnDelete);
            tabPage1.Controls.Add(BtnView);
            tabPage1.Controls.Add(BtnEdit);
            tabPage1.Controls.Add(DgVComputer);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1336, 598);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "View";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnRefresh
            // 
            BtnRefresh.Location = new Point(7, 504);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(250, 84);
            BtnRefresh.TabIndex = 5;
            BtnRefresh.Text = "Refresh";
            BtnRefresh.UseVisualStyleBackColor = true;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // TxtBxSearch
            // 
            TxtBxSearch.Location = new Point(1091, 432);
            TxtBxSearch.Margin = new Padding(3, 4, 3, 4);
            TxtBxSearch.Name = "TxtBxSearch";
            TxtBxSearch.Size = new Size(238, 27);
            TxtBxSearch.TabIndex = 4;
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(711, 504);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(250, 84);
            BtnDelete.TabIndex = 3;
            BtnDelete.Text = "Delete";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnView
            // 
            BtnView.Location = new Point(1091, 504);
            BtnView.Name = "BtnView";
            BtnView.Size = new Size(239, 88);
            BtnView.TabIndex = 2;
            BtnView.Text = "View";
            BtnView.UseVisualStyleBackColor = true;
            // 
            // BtnEdit
            // 
            BtnEdit.Location = new Point(365, 504);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(246, 84);
            BtnEdit.TabIndex = 1;
            BtnEdit.Text = "Edit";
            BtnEdit.UseVisualStyleBackColor = true;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // DgVComputer
            // 
            DgVComputer.AllowUserToAddRows = false;
            DgVComputer.AllowUserToDeleteRows = false;
            DgVComputer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgVComputer.Location = new Point(6, 3);
            DgVComputer.Name = "DgVComputer";
            DgVComputer.ReadOnly = true;
            DgVComputer.RowHeadersWidth = 51;
            DgVComputer.RowTemplate.Height = 29;
            DgVComputer.Size = new Size(1323, 421);
            DgVComputer.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label27);
            tabPage2.Controls.Add(TxtBxModel);
            tabPage2.Controls.Add(BtnAddImage);
            tabPage2.Controls.Add(BtnGeneratePorts);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(TxtBxPowerSource);
            tabPage2.Controls.Add(NupPorts);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(TxtBxMouseType);
            tabPage2.Controls.Add(TxtBxKeyboardType);
            tabPage2.Controls.Add(TxtBxRam);
            tabPage2.Controls.Add(TxtBxProcessor);
            tabPage2.Controls.Add(TxtBxPrice);
            tabPage2.Controls.Add(TxtBxStock);
            tabPage2.Controls.Add(TxtBxStorageCapacity);
            tabPage2.Controls.Add(TxtBxScreenSize);
            tabPage2.Controls.Add(TxtBxOperatingSystem);
            tabPage2.Controls.Add(PbxImageAdd);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(AddBtn);
            tabPage2.Controls.Add(TxtBxCompName);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1336, 598);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Add";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(8, 45);
            label27.Name = "label27";
            label27.Size = new Size(52, 20);
            label27.TabIndex = 37;
            label27.Text = "Model";
            // 
            // TxtBxModel
            // 
            TxtBxModel.Location = new Point(175, 42);
            TxtBxModel.Name = "TxtBxModel";
            TxtBxModel.Size = new Size(236, 27);
            TxtBxModel.TabIndex = 36;
            // 
            // BtnAddImage
            // 
            BtnAddImage.Location = new Point(930, 415);
            BtnAddImage.Name = "BtnAddImage";
            BtnAddImage.Size = new Size(266, 61);
            BtnAddImage.TabIndex = 35;
            BtnAddImage.Text = "Add Image";
            BtnAddImage.UseVisualStyleBackColor = true;
            BtnAddImage.Click += BtnAddImage_Click;
            // 
            // BtnGeneratePorts
            // 
            BtnGeneratePorts.Location = new Point(432, 59);
            BtnGeneratePorts.Name = "BtnGeneratePorts";
            BtnGeneratePorts.Size = new Size(199, 45);
            BtnGeneratePorts.TabIndex = 34;
            BtnGeneratePorts.Text = "Generate Port";
            BtnGeneratePorts.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(8, 405);
            label13.Name = "label13";
            label13.Size = new Size(98, 20);
            label13.TabIndex = 33;
            label13.Text = "Power Source";
            // 
            // TxtBxPowerSource
            // 
            TxtBxPowerSource.Location = new Point(175, 398);
            TxtBxPowerSource.Name = "TxtBxPowerSource";
            TxtBxPowerSource.Size = new Size(236, 27);
            TxtBxPowerSource.TabIndex = 32;
            // 
            // NupPorts
            // 
            NupPorts.Location = new Point(488, 25);
            NupPorts.Margin = new Padding(3, 4, 3, 4);
            NupPorts.Name = "NupPorts";
            NupPorts.Size = new Size(143, 27);
            NupPorts.TabIndex = 31;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(432, 29);
            label12.Name = "label12";
            label12.Size = new Size(41, 20);
            label12.TabIndex = 30;
            label12.Text = "Ports";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 369);
            label11.Name = "label11";
            label11.Size = new Size(86, 20);
            label11.TabIndex = 7;
            label11.Text = "Mouse type";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(8, 333);
            label10.Name = "label10";
            label10.Size = new Size(106, 20);
            label10.TabIndex = 29;
            label10.Text = "Keyboard type";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 297);
            label9.Name = "label9";
            label9.Size = new Size(41, 20);
            label9.TabIndex = 28;
            label9.Text = "RAM";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 261);
            label8.Name = "label8";
            label8.Size = new Size(72, 20);
            label8.TabIndex = 27;
            label8.Text = "Processor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 225);
            label7.Name = "label7";
            label7.Size = new Size(41, 20);
            label7.TabIndex = 26;
            label7.Text = "Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(762, 389);
            label6.Name = "label6";
            label6.Size = new Size(51, 20);
            label6.TabIndex = 25;
            label6.Text = "Image";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 189);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 24;
            label5.Text = "Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 153);
            label4.Name = "label4";
            label4.Size = new Size(161, 20);
            label4.TabIndex = 23;
            label4.Text = "Storage Capacity In GB";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 117);
            label3.Name = "label3";
            label3.Size = new Size(145, 20);
            label3.TabIndex = 22;
            label3.Text = "Screen Size In Inches";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 81);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 21;
            label2.Text = "Operating System";
            // 
            // TxtBxMouseType
            // 
            TxtBxMouseType.Location = new Point(175, 364);
            TxtBxMouseType.Name = "TxtBxMouseType";
            TxtBxMouseType.Size = new Size(236, 27);
            TxtBxMouseType.TabIndex = 20;
            // 
            // TxtBxKeyboardType
            // 
            TxtBxKeyboardType.Location = new Point(175, 326);
            TxtBxKeyboardType.Name = "TxtBxKeyboardType";
            TxtBxKeyboardType.Size = new Size(236, 27);
            TxtBxKeyboardType.TabIndex = 19;
            // 
            // TxtBxRam
            // 
            TxtBxRam.Location = new Point(175, 292);
            TxtBxRam.Name = "TxtBxRam";
            TxtBxRam.Size = new Size(236, 27);
            TxtBxRam.TabIndex = 18;
            // 
            // TxtBxProcessor
            // 
            TxtBxProcessor.Location = new Point(175, 254);
            TxtBxProcessor.Name = "TxtBxProcessor";
            TxtBxProcessor.Size = new Size(236, 27);
            TxtBxProcessor.TabIndex = 17;
            // 
            // TxtBxPrice
            // 
            TxtBxPrice.Location = new Point(175, 220);
            TxtBxPrice.Name = "TxtBxPrice";
            TxtBxPrice.Size = new Size(236, 27);
            TxtBxPrice.TabIndex = 16;
            // 
            // TxtBxStock
            // 
            TxtBxStock.Location = new Point(175, 182);
            TxtBxStock.Name = "TxtBxStock";
            TxtBxStock.Size = new Size(236, 27);
            TxtBxStock.TabIndex = 15;
            // 
            // TxtBxStorageCapacity
            // 
            TxtBxStorageCapacity.Location = new Point(175, 150);
            TxtBxStorageCapacity.Name = "TxtBxStorageCapacity";
            TxtBxStorageCapacity.Size = new Size(236, 27);
            TxtBxStorageCapacity.TabIndex = 14;
            // 
            // TxtBxScreenSize
            // 
            TxtBxScreenSize.Location = new Point(175, 110);
            TxtBxScreenSize.Name = "TxtBxScreenSize";
            TxtBxScreenSize.Size = new Size(236, 27);
            TxtBxScreenSize.TabIndex = 13;
            // 
            // TxtBxOperatingSystem
            // 
            TxtBxOperatingSystem.Location = new Point(175, 77);
            TxtBxOperatingSystem.Name = "TxtBxOperatingSystem";
            TxtBxOperatingSystem.Size = new Size(236, 27);
            TxtBxOperatingSystem.TabIndex = 12;
            // 
            // PbxImageAdd
            // 
            PbxImageAdd.Location = new Point(819, 59);
            PbxImageAdd.Name = "PbxImageAdd";
            PbxImageAdd.Size = new Size(489, 351);
            PbxImageAdd.SizeMode = PictureBoxSizeMode.CenterImage;
            PbxImageAdd.TabIndex = 11;
            PbxImageAdd.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 12);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 6;
            label1.Text = "Name";
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(505, 500);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(275, 92);
            AddBtn.TabIndex = 5;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // TxtBxCompName
            // 
            TxtBxCompName.Location = new Point(175, 9);
            TxtBxCompName.Name = "TxtBxCompName";
            TxtBxCompName.Size = new Size(236, 27);
            TxtBxCompName.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label28);
            tabPage3.Controls.Add(TxtBxEditModel);
            tabPage3.Controls.Add(BtnCancelEdit);
            tabPage3.Controls.Add(BtnEditImage);
            tabPage3.Controls.Add(NupEditPorts);
            tabPage3.Controls.Add(label25);
            tabPage3.Controls.Add(label26);
            tabPage3.Controls.Add(PbxEditImage);
            tabPage3.Controls.Add(BtnEditComputer);
            tabPage3.Controls.Add(label14);
            tabPage3.Controls.Add(TxtBxEditPowerSource);
            tabPage3.Controls.Add(label15);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(label17);
            tabPage3.Controls.Add(label18);
            tabPage3.Controls.Add(label19);
            tabPage3.Controls.Add(label20);
            tabPage3.Controls.Add(label21);
            tabPage3.Controls.Add(label22);
            tabPage3.Controls.Add(label23);
            tabPage3.Controls.Add(TxtBxEditMouseType);
            tabPage3.Controls.Add(TxtBxEditKeyboardType);
            tabPage3.Controls.Add(TxtBxEditRam);
            tabPage3.Controls.Add(TxtBxEditProcessor);
            tabPage3.Controls.Add(TxtBxEditPrice);
            tabPage3.Controls.Add(TxtBxEditStock);
            tabPage3.Controls.Add(TxtBxEditStorage);
            tabPage3.Controls.Add(TxtBxEditScreenSize);
            tabPage3.Controls.Add(TxtBxEditOs);
            tabPage3.Controls.Add(label24);
            tabPage3.Controls.Add(TxtBxEditName);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 4, 3, 4);
            tabPage3.Size = new Size(1336, 598);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Edit";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(13, 48);
            label28.Name = "label28";
            label28.Size = new Size(52, 20);
            label28.TabIndex = 64;
            label28.Text = "Model";
            // 
            // TxtBxEditModel
            // 
            TxtBxEditModel.Location = new Point(180, 41);
            TxtBxEditModel.Name = "TxtBxEditModel";
            TxtBxEditModel.Size = new Size(236, 27);
            TxtBxEditModel.TabIndex = 63;
            // 
            // BtnCancelEdit
            // 
            BtnCancelEdit.Location = new Point(13, 517);
            BtnCancelEdit.Margin = new Padding(3, 4, 3, 4);
            BtnCancelEdit.Name = "BtnCancelEdit";
            BtnCancelEdit.Size = new Size(185, 68);
            BtnCancelEdit.TabIndex = 62;
            BtnCancelEdit.Text = "Cancel";
            BtnCancelEdit.UseVisualStyleBackColor = true;
            BtnCancelEdit.Click += BtnCancelEdit_Click;
            // 
            // BtnEditImage
            // 
            BtnEditImage.Location = new Point(921, 424);
            BtnEditImage.Margin = new Padding(3, 4, 3, 4);
            BtnEditImage.Name = "BtnEditImage";
            BtnEditImage.Size = new Size(274, 53);
            BtnEditImage.TabIndex = 61;
            BtnEditImage.Text = "Edit Image";
            BtnEditImage.UseVisualStyleBackColor = true;
            BtnEditImage.Click += BtnEditImage_Click;
            // 
            // NupEditPorts
            // 
            NupEditPorts.Location = new Point(512, 27);
            NupEditPorts.Margin = new Padding(3, 4, 3, 4);
            NupEditPorts.Name = "NupEditPorts";
            NupEditPorts.Size = new Size(137, 27);
            NupEditPorts.TabIndex = 60;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(456, 31);
            label25.Name = "label25";
            label25.Size = new Size(41, 20);
            label25.TabIndex = 59;
            label25.Text = "Ports";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(763, 397);
            label26.Name = "label26";
            label26.Size = new Size(51, 20);
            label26.TabIndex = 58;
            label26.Text = "Image";
            // 
            // PbxEditImage
            // 
            PbxEditImage.Location = new Point(816, 47);
            PbxEditImage.Name = "PbxEditImage";
            PbxEditImage.Size = new Size(481, 371);
            PbxEditImage.SizeMode = PictureBoxSizeMode.CenterImage;
            PbxEditImage.TabIndex = 57;
            PbxEditImage.TabStop = false;
            // 
            // BtnEditComputer
            // 
            BtnEditComputer.Location = new Point(426, 432);
            BtnEditComputer.Name = "BtnEditComputer";
            BtnEditComputer.Size = new Size(203, 63);
            BtnEditComputer.TabIndex = 56;
            BtnEditComputer.Text = "SaveChanges";
            BtnEditComputer.UseVisualStyleBackColor = true;
            BtnEditComputer.Click += BtnEditComputer_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(13, 410);
            label14.Name = "label14";
            label14.Size = new Size(98, 20);
            label14.TabIndex = 55;
            label14.Text = "Power Source";
            // 
            // TxtBxEditPowerSource
            // 
            TxtBxEditPowerSource.Location = new Point(180, 407);
            TxtBxEditPowerSource.Name = "TxtBxEditPowerSource";
            TxtBxEditPowerSource.Size = new Size(236, 27);
            TxtBxEditPowerSource.TabIndex = 54;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(13, 374);
            label15.Name = "label15";
            label15.Size = new Size(86, 20);
            label15.TabIndex = 36;
            label15.Text = "Mouse type";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(13, 338);
            label16.Name = "label16";
            label16.Size = new Size(106, 20);
            label16.TabIndex = 53;
            label16.Text = "Keyboard type";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(13, 302);
            label17.Name = "label17";
            label17.Size = new Size(41, 20);
            label17.TabIndex = 52;
            label17.Text = "RAM";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(13, 266);
            label18.Name = "label18";
            label18.Size = new Size(72, 20);
            label18.TabIndex = 51;
            label18.Text = "Processor";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(13, 230);
            label19.Name = "label19";
            label19.Size = new Size(41, 20);
            label19.TabIndex = 50;
            label19.Text = "Price";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(13, 194);
            label20.Name = "label20";
            label20.Size = new Size(45, 20);
            label20.TabIndex = 49;
            label20.Text = "Stock";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(13, 158);
            label21.Name = "label21";
            label21.Size = new Size(161, 20);
            label21.TabIndex = 48;
            label21.Text = "Storage Capacity In GB";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(13, 122);
            label22.Name = "label22";
            label22.Size = new Size(145, 20);
            label22.TabIndex = 47;
            label22.Text = "Screen Size In Inches";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(13, 86);
            label23.Name = "label23";
            label23.Size = new Size(127, 20);
            label23.TabIndex = 46;
            label23.Text = "Operating System";
            // 
            // TxtBxEditMouseType
            // 
            TxtBxEditMouseType.Location = new Point(180, 371);
            TxtBxEditMouseType.Name = "TxtBxEditMouseType";
            TxtBxEditMouseType.Size = new Size(236, 27);
            TxtBxEditMouseType.TabIndex = 45;
            // 
            // TxtBxEditKeyboardType
            // 
            TxtBxEditKeyboardType.Location = new Point(180, 335);
            TxtBxEditKeyboardType.Name = "TxtBxEditKeyboardType";
            TxtBxEditKeyboardType.Size = new Size(236, 27);
            TxtBxEditKeyboardType.TabIndex = 44;
            // 
            // TxtBxEditRam
            // 
            TxtBxEditRam.Location = new Point(180, 299);
            TxtBxEditRam.Name = "TxtBxEditRam";
            TxtBxEditRam.Size = new Size(236, 27);
            TxtBxEditRam.TabIndex = 43;
            // 
            // TxtBxEditProcessor
            // 
            TxtBxEditProcessor.Location = new Point(180, 263);
            TxtBxEditProcessor.Name = "TxtBxEditProcessor";
            TxtBxEditProcessor.Size = new Size(236, 27);
            TxtBxEditProcessor.TabIndex = 42;
            // 
            // TxtBxEditPrice
            // 
            TxtBxEditPrice.Location = new Point(180, 227);
            TxtBxEditPrice.Name = "TxtBxEditPrice";
            TxtBxEditPrice.Size = new Size(236, 27);
            TxtBxEditPrice.TabIndex = 41;
            // 
            // TxtBxEditStock
            // 
            TxtBxEditStock.Location = new Point(180, 191);
            TxtBxEditStock.Name = "TxtBxEditStock";
            TxtBxEditStock.Size = new Size(236, 27);
            TxtBxEditStock.TabIndex = 40;
            // 
            // TxtBxEditStorage
            // 
            TxtBxEditStorage.Location = new Point(180, 151);
            TxtBxEditStorage.Name = "TxtBxEditStorage";
            TxtBxEditStorage.Size = new Size(236, 27);
            TxtBxEditStorage.TabIndex = 39;
            // 
            // TxtBxEditScreenSize
            // 
            TxtBxEditScreenSize.Location = new Point(180, 119);
            TxtBxEditScreenSize.Name = "TxtBxEditScreenSize";
            TxtBxEditScreenSize.Size = new Size(236, 27);
            TxtBxEditScreenSize.TabIndex = 38;
            // 
            // TxtBxEditOs
            // 
            TxtBxEditOs.Location = new Point(180, 83);
            TxtBxEditOs.Name = "TxtBxEditOs";
            TxtBxEditOs.Size = new Size(236, 27);
            TxtBxEditOs.TabIndex = 37;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(13, 11);
            label24.Name = "label24";
            label24.Size = new Size(49, 20);
            label24.TabIndex = 35;
            label24.Text = "Name";
            // 
            // TxtBxEditName
            // 
            TxtBxEditName.Location = new Point(180, 8);
            TxtBxEditName.Name = "TxtBxEditName";
            TxtBxEditName.Size = new Size(236, 27);
            TxtBxEditName.TabIndex = 34;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnBack);
            groupBox1.Location = new Point(11, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(150, 631);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
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
            // ComputersPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1523, 655);
            Controls.Add(groupBox1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ComputersPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ComputersPanel";
            Load += ComputersPanel_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgVComputer).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NupPorts).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbxImageAdd).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NupEditPorts).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbxEditImage).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Button AddBtn;
        private TextBox TxtBxCompName;
        private Button BtnDelete;
        private Button BtnView;
        private Button BtnEdit;
        private DataGridView DgVComputer;
        private GroupBox groupBox1;
        private Button BtnBack;
        private PictureBox PbxImageAdd;
        private TabPage tabPage3;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox TxtBxMouseType;
        private TextBox TxtBxKeyboardType;
        private TextBox TxtBxRam;
        private TextBox TxtBxProcessor;
        private TextBox TxtBxPrice;
        private TextBox TxtBxStock;
        private TextBox TxtBxStorageCapacity;
        private TextBox TxtBxScreenSize;
        private TextBox TxtBxOperatingSystem;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private NumericUpDown NupPorts;
        private Label label12;
        private TextBox TxtBxPowerSource;
        private Label label13;
        private NumericUpDown NupEditPorts;
        private Label label25;
        private Label label26;
        private PictureBox PbxEditImage;
        private Button BtnEditComputer;
        private Label label14;
        private TextBox TxtBxEditPowerSource;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private TextBox TxtBxEditMouseType;
        private TextBox TxtBxEditKeyboardType;
        private TextBox TxtBxEditRam;
        private TextBox TxtBxEditProcessor;
        private TextBox TxtBxEditPrice;
        private TextBox TxtBxEditStock;
        private TextBox TxtBxEditStorage;
        private TextBox TxtBxEditScreenSize;
        private TextBox TxtBxEditOs;
        private Label label24;
        private TextBox TxtBxEditName;
        private TextBox TxtBxSearch;
        private Button BtnGeneratePorts;
        private Button BtnAddImage;
        private Button BtnEditImage;
        private Button BtnRefresh;
        private Button BtnCancelEdit;
        private Label label27;
        private TextBox TxtBxModel;
        private TextBox TxtBxEditModel;
        private Label label28;
    }
}