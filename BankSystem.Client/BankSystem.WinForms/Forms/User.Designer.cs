namespace BankSystem.WinForms.Forms
{
    partial class User
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            lblWelcome = new Label();
            lblDateTime = new Label();
            pictureBox1 = new PictureBox();
            tabControl1 = new TabControl();
            tbShow = new TabPage();
            groupBox1 = new GroupBox();
            rbDesc = new RadioButton();
            rbAsc = new RadioButton();
            lblCount = new Label();
            dgvShow = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            txtSearch = new TextBox();
            label2 = new Label();
            tbAdd = new TabPage();
            groupBox3 = new GroupBox();
            cbUser = new CheckBox();
            cbTransaction = new CheckBox();
            cbClients = new CheckBox();
            cbPeople = new CheckBox();
            rbNo = new RadioButton();
            rbYes = new RadioButton();
            label20 = new Label();
            txtPass = new TextBox();
            label19 = new Label();
            txtUsername = new TextBox();
            label18 = new Label();
            boxPersonId = new ComboBox();
            label17 = new Label();
            btnAdd = new Button();
            dtBirthDate = new DateTimePicker();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            label8 = new Label();
            label7 = new Label();
            txtPhone = new TextBox();
            label6 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            txtLastName = new TextBox();
            label4 = new Label();
            txtSecondName = new TextBox();
            label3 = new Label();
            txtFirstName = new TextBox();
            label1 = new Label();
            tbEdit = new TabPage();
            editNoActive = new RadioButton();
            editYesActive = new RadioButton();
            label25 = new Label();
            editPersonId = new TextBox();
            label24 = new Label();
            groupBox4 = new GroupBox();
            editUsers = new CheckBox();
            editTransaction = new CheckBox();
            editClients = new CheckBox();
            editPeople = new CheckBox();
            editNoAccess = new RadioButton();
            editYseAccess = new RadioButton();
            label9 = new Label();
            editPassword = new TextBox();
            label10 = new Label();
            editUsername = new TextBox();
            label11 = new Label();
            boxUserId = new ComboBox();
            label12 = new Label();
            btnUpdate = new Button();
            editBirthDate = new DateTimePicker();
            editFemale = new RadioButton();
            editMale = new RadioButton();
            label13 = new Label();
            label14 = new Label();
            editPhone = new TextBox();
            label15 = new Label();
            editEmail = new TextBox();
            label16 = new Label();
            editLastName = new TextBox();
            label21 = new Label();
            editSecondName = new TextBox();
            label22 = new Label();
            editFirstName = new TextBox();
            label23 = new Label();
            tpRegister = new TabPage();
            groupBox2 = new GroupBox();
            rbRegisterDesc = new RadioButton();
            rbRegisterAsc = new RadioButton();
            lblCountRegisters = new Label();
            dgvRegisters = new DataGridView();
            txtSearchUserId = new TextBox();
            label26 = new Label();
            errorProvider1 = new ErrorProvider(components);
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tbShow.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShow).BeginInit();
            contextMenuStrip1.SuspendLayout();
            tbAdd.SuspendLayout();
            groupBox3.SuspendLayout();
            tbEdit.SuspendLayout();
            groupBox4.SuspendLayout();
            tpRegister.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegisters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSeaGreen;
            panel1.Controls.Add(lblWelcome);
            panel1.Controls.Add(lblDateTime);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(303, 986);
            panel1.TabIndex = 4;
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(52, 248);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(251, 107);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome:";
            // 
            // lblDateTime
            // 
            lblDateTime.Dock = DockStyle.Bottom;
            lblDateTime.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateTime.ForeColor = Color.White;
            lblDateTime.Location = new Point(0, 864);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(303, 122);
            lblDateTime.TabIndex = 1;
            lblDateTime.Text = "DateTime";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bank;
            pictureBox1.Location = new Point(53, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(208, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbShow);
            tabControl1.Controls.Add(tbAdd);
            tabControl1.Controls.Add(tbEdit);
            tabControl1.Controls.Add(tpRegister);
            tabControl1.Dock = DockStyle.Right;
            tabControl1.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(304, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(796, 986);
            tabControl1.TabIndex = 5;
            // 
            // tbShow
            // 
            tbShow.Controls.Add(groupBox1);
            tbShow.Controls.Add(lblCount);
            tbShow.Controls.Add(dgvShow);
            tbShow.Controls.Add(txtSearch);
            tbShow.Controls.Add(label2);
            tbShow.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbShow.Location = new Point(4, 35);
            tbShow.Name = "tbShow";
            tbShow.Padding = new Padding(3);
            tbShow.Size = new Size(788, 947);
            tbShow.TabIndex = 0;
            tbShow.Text = "Show Users";
            tbShow.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbDesc);
            groupBox1.Controls.Add(rbAsc);
            groupBox1.Location = new Point(615, 167);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(165, 76);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sorting";
            // 
            // rbDesc
            // 
            rbDesc.AutoSize = true;
            rbDesc.Cursor = Cursors.Hand;
            rbDesc.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbDesc.Location = new Point(88, 38);
            rbDesc.Name = "rbDesc";
            rbDesc.Size = new Size(68, 24);
            rbDesc.TabIndex = 1;
            rbDesc.TabStop = true;
            rbDesc.Text = "DESC";
            rbDesc.UseVisualStyleBackColor = true;
            rbDesc.CheckedChanged += rbDesc_CheckedChanged;
            // 
            // rbAsc
            // 
            rbAsc.AutoSize = true;
            rbAsc.Cursor = Cursors.Hand;
            rbAsc.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbAsc.Location = new Point(9, 38);
            rbAsc.Name = "rbAsc";
            rbAsc.Size = new Size(58, 24);
            rbAsc.TabIndex = 0;
            rbAsc.TabStop = true;
            rbAsc.Text = "ASC";
            rbAsc.UseVisualStyleBackColor = true;
            rbAsc.CheckedChanged += rbAsc_CheckedChanged;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCount.ForeColor = Color.SteelBlue;
            lblCount.Location = new Point(35, 207);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(149, 28);
            lblCount.TabIndex = 9;
            lblCount.Text = "User(s) Found";
            // 
            // dgvShow
            // 
            dgvShow.AllowUserToAddRows = false;
            dgvShow.AllowUserToDeleteRows = false;
            dgvShow.AllowUserToOrderColumns = true;
            dgvShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShow.ContextMenuStrip = contextMenuStrip1;
            dgvShow.Dock = DockStyle.Bottom;
            dgvShow.Location = new Point(3, 249);
            dgvShow.Name = "dgvShow";
            dgvShow.ReadOnly = true;
            dgvShow.Size = new Size(782, 695);
            dgvShow.TabIndex = 8;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // txtSearch
            // 
            txtSearch.CharacterCasing = CharacterCasing.Lower;
            txtSearch.Location = new Point(29, 96);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(212, 29);
            txtSearch.TabIndex = 7;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SteelBlue;
            label2.Location = new Point(35, 61);
            label2.Name = "label2";
            label2.Size = new Size(158, 28);
            label2.TabIndex = 6;
            label2.Text = "Search User ID";
            // 
            // tbAdd
            // 
            tbAdd.Controls.Add(groupBox3);
            tbAdd.Controls.Add(txtPass);
            tbAdd.Controls.Add(label19);
            tbAdd.Controls.Add(txtUsername);
            tbAdd.Controls.Add(label18);
            tbAdd.Controls.Add(boxPersonId);
            tbAdd.Controls.Add(label17);
            tbAdd.Controls.Add(btnAdd);
            tbAdd.Controls.Add(dtBirthDate);
            tbAdd.Controls.Add(rbFemale);
            tbAdd.Controls.Add(rbMale);
            tbAdd.Controls.Add(label8);
            tbAdd.Controls.Add(label7);
            tbAdd.Controls.Add(txtPhone);
            tbAdd.Controls.Add(label6);
            tbAdd.Controls.Add(txtEmail);
            tbAdd.Controls.Add(label5);
            tbAdd.Controls.Add(txtLastName);
            tbAdd.Controls.Add(label4);
            tbAdd.Controls.Add(txtSecondName);
            tbAdd.Controls.Add(label3);
            tbAdd.Controls.Add(txtFirstName);
            tbAdd.Controls.Add(label1);
            tbAdd.Location = new Point(4, 35);
            tbAdd.Name = "tbAdd";
            tbAdd.Padding = new Padding(3);
            tbAdd.Size = new Size(788, 947);
            tbAdd.TabIndex = 1;
            tbAdd.Text = "Add User";
            tbAdd.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbUser);
            groupBox3.Controls.Add(cbTransaction);
            groupBox3.Controls.Add(cbClients);
            groupBox3.Controls.Add(cbPeople);
            groupBox3.Controls.Add(rbNo);
            groupBox3.Controls.Add(rbYes);
            groupBox3.Controls.Add(label20);
            groupBox3.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.SteelBlue;
            groupBox3.Location = new Point(72, 630);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(653, 220);
            groupBox3.TabIndex = 32;
            groupBox3.TabStop = false;
            groupBox3.Text = "Permissions";
            // 
            // cbUser
            // 
            cbUser.AutoSize = true;
            cbUser.Enabled = false;
            cbUser.Location = new Point(248, 177);
            cbUser.Name = "cbUser";
            cbUser.Size = new Size(157, 30);
            cbUser.TabIndex = 35;
            cbUser.Tag = "8";
            cbUser.Text = "Manage Users";
            cbUser.UseVisualStyleBackColor = true;
            cbUser.CheckedChanged += checkBox_CheckedChanged;
            // 
            // cbTransaction
            // 
            cbTransaction.AutoSize = true;
            cbTransaction.Enabled = false;
            cbTransaction.Location = new Point(487, 132);
            cbTransaction.Name = "cbTransaction";
            cbTransaction.Size = new Size(144, 30);
            cbTransaction.TabIndex = 34;
            cbTransaction.Tag = "4";
            cbTransaction.Text = "Transactions";
            cbTransaction.UseVisualStyleBackColor = true;
            cbTransaction.CheckedChanged += checkBox_CheckedChanged;
            // 
            // cbClients
            // 
            cbClients.AutoSize = true;
            cbClients.Enabled = false;
            cbClients.Location = new Point(250, 132);
            cbClients.Name = "cbClients";
            cbClients.Size = new Size(171, 30);
            cbClients.TabIndex = 33;
            cbClients.Tag = "2";
            cbClients.Text = "Manage Clients";
            cbClients.UseVisualStyleBackColor = true;
            cbClients.CheckedChanged += checkBox_CheckedChanged;
            // 
            // cbPeople
            // 
            cbPeople.AutoSize = true;
            cbPeople.Enabled = false;
            cbPeople.Location = new Point(21, 132);
            cbPeople.Name = "cbPeople";
            cbPeople.Size = new Size(168, 30);
            cbPeople.TabIndex = 32;
            cbPeople.Tag = "1";
            cbPeople.Text = "Manage People";
            cbPeople.UseVisualStyleBackColor = true;
            cbPeople.CheckedChanged += checkBox_CheckedChanged;
            // 
            // rbNo
            // 
            rbNo.AutoSize = true;
            rbNo.Cursor = Cursors.Hand;
            rbNo.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbNo.Location = new Point(342, 88);
            rbNo.Name = "rbNo";
            rbNo.Size = new Size(47, 24);
            rbNo.TabIndex = 31;
            rbNo.Text = "No";
            rbNo.UseVisualStyleBackColor = true;
            rbNo.CheckedChanged += rbNo_CheckedChanged;
            // 
            // rbYes
            // 
            rbYes.AutoSize = true;
            rbYes.Checked = true;
            rbYes.Cursor = Cursors.Hand;
            rbYes.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbYes.Location = new Point(263, 87);
            rbYes.Name = "rbYes";
            rbYes.Size = new Size(48, 24);
            rbYes.TabIndex = 30;
            rbYes.TabStop = true;
            rbYes.Text = "Yes";
            rbYes.UseVisualStyleBackColor = true;
            rbYes.CheckedChanged += rbYes_CheckedChanged;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.SteelBlue;
            label20.Location = new Point(235, 50);
            label20.Name = "label20";
            label20.Size = new Size(183, 28);
            label20.TabIndex = 29;
            label20.Text = "Give Full Access?";
            // 
            // txtPass
            // 
            txtPass.CharacterCasing = CharacterCasing.Lower;
            txtPass.Cursor = Cursors.IBeam;
            txtPass.Location = new Point(488, 553);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(212, 33);
            txtPass.TabIndex = 31;
            txtPass.UseSystemPasswordChar = true;
            txtPass.Validating += txtBox_Validating;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.SteelBlue;
            label19.Location = new Point(494, 518);
            label19.Name = "label19";
            label19.Size = new Size(104, 28);
            label19.TabIndex = 30;
            label19.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.CharacterCasing = CharacterCasing.Lower;
            txtUsername.Cursor = Cursors.IBeam;
            txtUsername.Location = new Point(83, 553);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(212, 33);
            txtUsername.TabIndex = 29;
            txtUsername.Validating += txtBox_Validating;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.SteelBlue;
            label18.Location = new Point(89, 518);
            label18.Name = "label18";
            label18.Size = new Size(115, 28);
            label18.TabIndex = 28;
            label18.Text = "UserName";
            // 
            // boxPersonId
            // 
            boxPersonId.DropDownStyle = ComboBoxStyle.DropDownList;
            boxPersonId.FormattingEnabled = true;
            boxPersonId.Location = new Point(306, 57);
            boxPersonId.Name = "boxPersonId";
            boxPersonId.Size = new Size(177, 34);
            boxPersonId.TabIndex = 27;
            boxPersonId.SelectedIndexChanged += boxPersonId_SelectedIndexChanged;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.SteelBlue;
            label17.Location = new Point(312, 23);
            label17.Name = "label17";
            label17.Size = new Size(108, 28);
            label17.TabIndex = 26;
            label17.Text = "Person ID";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.WhiteSmoke;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.SteelBlue;
            btnAdd.Location = new Point(554, 882);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(226, 57);
            btnAdd.TabIndex = 25;
            btnAdd.Tag = "1";
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dtBirthDate
            // 
            dtBirthDate.Cursor = Cursors.Hand;
            dtBirthDate.Enabled = false;
            dtBirthDate.Format = DateTimePickerFormat.Short;
            dtBirthDate.Location = new Point(86, 454);
            dtBirthDate.Name = "dtBirthDate";
            dtBirthDate.Size = new Size(200, 33);
            dtBirthDate.TabIndex = 24;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Cursor = Cursors.Hand;
            rbFemale.Enabled = false;
            rbFemale.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbFemale.Location = new Point(576, 366);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(74, 24);
            rbFemale.TabIndex = 23;
            rbFemale.TabStop = true;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Cursor = Cursors.Hand;
            rbMale.Enabled = false;
            rbMale.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbMale.Location = new Point(497, 365);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(60, 24);
            rbMale.TabIndex = 22;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.SteelBlue;
            label8.Location = new Point(89, 419);
            label8.Name = "label8";
            label8.Size = new Size(113, 28);
            label8.TabIndex = 20;
            label8.Text = "Birth Date";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.SteelBlue;
            label7.Location = new Point(497, 324);
            label7.Name = "label7";
            label7.Size = new Size(87, 28);
            label7.TabIndex = 18;
            label7.Text = "Gender";
            // 
            // txtPhone
            // 
            txtPhone.CharacterCasing = CharacterCasing.Lower;
            txtPhone.Cursor = Cursors.IBeam;
            txtPhone.Enabled = false;
            txtPhone.Location = new Point(83, 355);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(212, 33);
            txtPhone.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.SteelBlue;
            label6.Location = new Point(89, 320);
            label6.Name = "label6";
            label6.Size = new Size(76, 28);
            label6.TabIndex = 16;
            label6.Text = "Phone";
            // 
            // txtEmail
            // 
            txtEmail.CharacterCasing = CharacterCasing.Lower;
            txtEmail.Cursor = Cursors.IBeam;
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(494, 259);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(212, 33);
            txtEmail.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.SteelBlue;
            label5.Location = new Point(500, 224);
            label5.Name = "label5";
            label5.Size = new Size(69, 28);
            label5.TabIndex = 14;
            label5.Text = "Email";
            // 
            // txtLastName
            // 
            txtLastName.CharacterCasing = CharacterCasing.Lower;
            txtLastName.Cursor = Cursors.IBeam;
            txtLastName.Enabled = false;
            txtLastName.Location = new Point(83, 259);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(212, 33);
            txtLastName.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.SteelBlue;
            label4.Location = new Point(89, 224);
            label4.Name = "label4";
            label4.Size = new Size(116, 28);
            label4.TabIndex = 12;
            label4.Text = "Last Name";
            // 
            // txtSecondName
            // 
            txtSecondName.CharacterCasing = CharacterCasing.Lower;
            txtSecondName.Cursor = Cursors.IBeam;
            txtSecondName.Enabled = false;
            txtSecondName.Location = new Point(494, 153);
            txtSecondName.Name = "txtSecondName";
            txtSecondName.Size = new Size(212, 33);
            txtSecondName.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.SteelBlue;
            label3.Location = new Point(500, 118);
            label3.Name = "label3";
            label3.Size = new Size(149, 28);
            label3.TabIndex = 10;
            label3.Text = "Second Name";
            // 
            // txtFirstName
            // 
            txtFirstName.CharacterCasing = CharacterCasing.Lower;
            txtFirstName.Cursor = Cursors.IBeam;
            txtFirstName.Enabled = false;
            txtFirstName.Location = new Point(83, 153);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(212, 33);
            txtFirstName.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(89, 118);
            label1.Name = "label1";
            label1.Size = new Size(119, 28);
            label1.TabIndex = 8;
            label1.Text = "First Name";
            // 
            // tbEdit
            // 
            tbEdit.Controls.Add(editNoActive);
            tbEdit.Controls.Add(editYesActive);
            tbEdit.Controls.Add(label25);
            tbEdit.Controls.Add(editPersonId);
            tbEdit.Controls.Add(label24);
            tbEdit.Controls.Add(groupBox4);
            tbEdit.Controls.Add(editPassword);
            tbEdit.Controls.Add(label10);
            tbEdit.Controls.Add(editUsername);
            tbEdit.Controls.Add(label11);
            tbEdit.Controls.Add(boxUserId);
            tbEdit.Controls.Add(label12);
            tbEdit.Controls.Add(btnUpdate);
            tbEdit.Controls.Add(editBirthDate);
            tbEdit.Controls.Add(editFemale);
            tbEdit.Controls.Add(editMale);
            tbEdit.Controls.Add(label13);
            tbEdit.Controls.Add(label14);
            tbEdit.Controls.Add(editPhone);
            tbEdit.Controls.Add(label15);
            tbEdit.Controls.Add(editEmail);
            tbEdit.Controls.Add(label16);
            tbEdit.Controls.Add(editLastName);
            tbEdit.Controls.Add(label21);
            tbEdit.Controls.Add(editSecondName);
            tbEdit.Controls.Add(label22);
            tbEdit.Controls.Add(editFirstName);
            tbEdit.Controls.Add(label23);
            tbEdit.Location = new Point(4, 35);
            tbEdit.Name = "tbEdit";
            tbEdit.Padding = new Padding(3);
            tbEdit.Size = new Size(788, 947);
            tbEdit.TabIndex = 2;
            tbEdit.Text = "Edit User";
            tbEdit.UseVisualStyleBackColor = true;
            // 
            // editNoActive
            // 
            editNoActive.AutoSize = true;
            editNoActive.Cursor = Cursors.Hand;
            editNoActive.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editNoActive.Location = new Point(579, 453);
            editNoActive.Name = "editNoActive";
            editNoActive.Size = new Size(47, 24);
            editNoActive.TabIndex = 60;
            editNoActive.TabStop = true;
            editNoActive.Text = "No";
            editNoActive.UseVisualStyleBackColor = true;
            // 
            // editYesActive
            // 
            editYesActive.AutoSize = true;
            editYesActive.Cursor = Cursors.Hand;
            editYesActive.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editYesActive.Location = new Point(500, 452);
            editYesActive.Name = "editYesActive";
            editYesActive.Size = new Size(48, 24);
            editYesActive.TabIndex = 59;
            editYesActive.TabStop = true;
            editYesActive.Text = "Yes";
            editYesActive.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label25.ForeColor = Color.SteelBlue;
            label25.Location = new Point(500, 411);
            label25.Name = "label25";
            label25.Size = new Size(96, 28);
            label25.TabIndex = 58;
            label25.Text = "Is Active";
            // 
            // editPersonId
            // 
            editPersonId.CharacterCasing = CharacterCasing.Lower;
            editPersonId.Cursor = Cursors.IBeam;
            editPersonId.Enabled = false;
            editPersonId.Location = new Point(494, 59);
            editPersonId.Name = "editPersonId";
            editPersonId.Size = new Size(212, 33);
            editPersonId.TabIndex = 57;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.ForeColor = Color.SteelBlue;
            label24.Location = new Point(500, 24);
            label24.Name = "label24";
            label24.Size = new Size(108, 28);
            label24.TabIndex = 56;
            label24.Text = "Person ID";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(editUsers);
            groupBox4.Controls.Add(editTransaction);
            groupBox4.Controls.Add(editClients);
            groupBox4.Controls.Add(editPeople);
            groupBox4.Controls.Add(editNoAccess);
            groupBox4.Controls.Add(editYseAccess);
            groupBox4.Controls.Add(label9);
            groupBox4.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.ForeColor = Color.SteelBlue;
            groupBox4.Location = new Point(68, 622);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(653, 220);
            groupBox4.TabIndex = 55;
            groupBox4.TabStop = false;
            groupBox4.Text = "Permissions";
            // 
            // editUsers
            // 
            editUsers.AutoSize = true;
            editUsers.Enabled = false;
            editUsers.Location = new Point(248, 177);
            editUsers.Name = "editUsers";
            editUsers.Size = new Size(157, 30);
            editUsers.TabIndex = 35;
            editUsers.Tag = "8";
            editUsers.Text = "Manage Users";
            editUsers.UseVisualStyleBackColor = true;
            editUsers.CheckedChanged += checkBox_CheckedChanged;
            // 
            // editTransaction
            // 
            editTransaction.AutoSize = true;
            editTransaction.Enabled = false;
            editTransaction.Location = new Point(487, 132);
            editTransaction.Name = "editTransaction";
            editTransaction.Size = new Size(144, 30);
            editTransaction.TabIndex = 34;
            editTransaction.Tag = "4";
            editTransaction.Text = "Transactions";
            editTransaction.UseVisualStyleBackColor = true;
            editTransaction.CheckedChanged += checkBox_CheckedChanged;
            // 
            // editClients
            // 
            editClients.AutoSize = true;
            editClients.Enabled = false;
            editClients.Location = new Point(250, 132);
            editClients.Name = "editClients";
            editClients.Size = new Size(171, 30);
            editClients.TabIndex = 33;
            editClients.Tag = "2";
            editClients.Text = "Manage Clients";
            editClients.UseVisualStyleBackColor = true;
            editClients.CheckedChanged += checkBox_CheckedChanged;
            // 
            // editPeople
            // 
            editPeople.AutoSize = true;
            editPeople.Enabled = false;
            editPeople.Location = new Point(21, 132);
            editPeople.Name = "editPeople";
            editPeople.Size = new Size(168, 30);
            editPeople.TabIndex = 32;
            editPeople.Tag = "1";
            editPeople.Text = "Manage People";
            editPeople.UseVisualStyleBackColor = true;
            editPeople.CheckedChanged += checkBox_CheckedChanged;
            // 
            // editNoAccess
            // 
            editNoAccess.AutoSize = true;
            editNoAccess.Cursor = Cursors.Hand;
            editNoAccess.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editNoAccess.Location = new Point(342, 88);
            editNoAccess.Name = "editNoAccess";
            editNoAccess.Size = new Size(47, 24);
            editNoAccess.TabIndex = 31;
            editNoAccess.Text = "No";
            editNoAccess.UseVisualStyleBackColor = true;
            editNoAccess.CheckedChanged += editNoAccess_CheckedChanged;
            // 
            // editYseAccess
            // 
            editYseAccess.AutoSize = true;
            editYseAccess.Checked = true;
            editYseAccess.Cursor = Cursors.Hand;
            editYseAccess.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editYseAccess.Location = new Point(263, 87);
            editYseAccess.Name = "editYseAccess";
            editYseAccess.Size = new Size(48, 24);
            editYseAccess.TabIndex = 30;
            editYseAccess.TabStop = true;
            editYseAccess.Text = "Yes";
            editYseAccess.UseVisualStyleBackColor = true;
            editYseAccess.CheckedChanged += editYseAccess_CheckedChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.SteelBlue;
            label9.Location = new Point(235, 50);
            label9.Name = "label9";
            label9.Size = new Size(183, 28);
            label9.TabIndex = 29;
            label9.Text = "Give Full Access?";
            // 
            // editPassword
            // 
            editPassword.CharacterCasing = CharacterCasing.Lower;
            editPassword.Cursor = Cursors.IBeam;
            editPassword.Location = new Point(488, 545);
            editPassword.Name = "editPassword";
            editPassword.Size = new Size(212, 33);
            editPassword.TabIndex = 54;
            editPassword.UseSystemPasswordChar = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.SteelBlue;
            label10.Location = new Point(494, 510);
            label10.Name = "label10";
            label10.Size = new Size(104, 28);
            label10.TabIndex = 53;
            label10.Text = "Password";
            // 
            // editUsername
            // 
            editUsername.CharacterCasing = CharacterCasing.Lower;
            editUsername.Cursor = Cursors.IBeam;
            editUsername.Location = new Point(83, 545);
            editUsername.Name = "editUsername";
            editUsername.Size = new Size(212, 33);
            editUsername.TabIndex = 52;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.SteelBlue;
            label11.Location = new Point(89, 510);
            label11.Name = "label11";
            label11.Size = new Size(115, 28);
            label11.TabIndex = 51;
            label11.Text = "UserName";
            // 
            // boxUserId
            // 
            boxUserId.DropDownStyle = ComboBoxStyle.DropDownList;
            boxUserId.FormattingEnabled = true;
            boxUserId.Location = new Point(83, 58);
            boxUserId.Name = "boxUserId";
            boxUserId.Size = new Size(177, 34);
            boxUserId.TabIndex = 50;
            boxUserId.SelectedIndexChanged += boxUserId_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.SteelBlue;
            label12.Location = new Point(89, 24);
            label12.Name = "label12";
            label12.Size = new Size(86, 28);
            label12.TabIndex = 49;
            label12.Text = "User ID";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.WhiteSmoke;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.SteelBlue;
            btnUpdate.Location = new Point(522, 874);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(226, 57);
            btnUpdate.TabIndex = 48;
            btnUpdate.Tag = "1";
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // editBirthDate
            // 
            editBirthDate.Cursor = Cursors.Hand;
            editBirthDate.Enabled = false;
            editBirthDate.Format = DateTimePickerFormat.Short;
            editBirthDate.Location = new Point(86, 446);
            editBirthDate.Name = "editBirthDate";
            editBirthDate.Size = new Size(200, 33);
            editBirthDate.TabIndex = 47;
            // 
            // editFemale
            // 
            editFemale.AutoSize = true;
            editFemale.Cursor = Cursors.Hand;
            editFemale.Enabled = false;
            editFemale.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editFemale.Location = new Point(576, 358);
            editFemale.Name = "editFemale";
            editFemale.Size = new Size(74, 24);
            editFemale.TabIndex = 46;
            editFemale.TabStop = true;
            editFemale.Text = "Female";
            editFemale.UseVisualStyleBackColor = true;
            // 
            // editMale
            // 
            editMale.AutoSize = true;
            editMale.Cursor = Cursors.Hand;
            editMale.Enabled = false;
            editMale.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editMale.Location = new Point(497, 357);
            editMale.Name = "editMale";
            editMale.Size = new Size(60, 24);
            editMale.TabIndex = 45;
            editMale.TabStop = true;
            editMale.Text = "Male";
            editMale.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.SteelBlue;
            label13.Location = new Point(89, 411);
            label13.Name = "label13";
            label13.Size = new Size(113, 28);
            label13.TabIndex = 44;
            label13.Text = "Birth Date";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.SteelBlue;
            label14.Location = new Point(497, 316);
            label14.Name = "label14";
            label14.Size = new Size(87, 28);
            label14.TabIndex = 43;
            label14.Text = "Gender";
            // 
            // editPhone
            // 
            editPhone.CharacterCasing = CharacterCasing.Lower;
            editPhone.Cursor = Cursors.IBeam;
            editPhone.Enabled = false;
            editPhone.Location = new Point(83, 347);
            editPhone.Name = "editPhone";
            editPhone.Size = new Size(212, 33);
            editPhone.TabIndex = 42;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.SteelBlue;
            label15.Location = new Point(89, 312);
            label15.Name = "label15";
            label15.Size = new Size(76, 28);
            label15.TabIndex = 41;
            label15.Text = "Phone";
            // 
            // editEmail
            // 
            editEmail.CharacterCasing = CharacterCasing.Lower;
            editEmail.Cursor = Cursors.IBeam;
            editEmail.Enabled = false;
            editEmail.Location = new Point(494, 251);
            editEmail.Name = "editEmail";
            editEmail.Size = new Size(212, 33);
            editEmail.TabIndex = 40;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.SteelBlue;
            label16.Location = new Point(500, 216);
            label16.Name = "label16";
            label16.Size = new Size(69, 28);
            label16.TabIndex = 39;
            label16.Text = "Email";
            // 
            // editLastName
            // 
            editLastName.CharacterCasing = CharacterCasing.Lower;
            editLastName.Cursor = Cursors.IBeam;
            editLastName.Enabled = false;
            editLastName.Location = new Point(83, 251);
            editLastName.Name = "editLastName";
            editLastName.Size = new Size(212, 33);
            editLastName.TabIndex = 38;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.SteelBlue;
            label21.Location = new Point(89, 216);
            label21.Name = "label21";
            label21.Size = new Size(116, 28);
            label21.TabIndex = 37;
            label21.Text = "Last Name";
            // 
            // editSecondName
            // 
            editSecondName.CharacterCasing = CharacterCasing.Lower;
            editSecondName.Cursor = Cursors.IBeam;
            editSecondName.Enabled = false;
            editSecondName.Location = new Point(494, 145);
            editSecondName.Name = "editSecondName";
            editSecondName.Size = new Size(212, 33);
            editSecondName.TabIndex = 36;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.SteelBlue;
            label22.Location = new Point(500, 110);
            label22.Name = "label22";
            label22.Size = new Size(149, 28);
            label22.TabIndex = 35;
            label22.Text = "Second Name";
            // 
            // editFirstName
            // 
            editFirstName.CharacterCasing = CharacterCasing.Lower;
            editFirstName.Cursor = Cursors.IBeam;
            editFirstName.Enabled = false;
            editFirstName.Location = new Point(83, 145);
            editFirstName.Name = "editFirstName";
            editFirstName.Size = new Size(212, 33);
            editFirstName.TabIndex = 34;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.ForeColor = Color.SteelBlue;
            label23.Location = new Point(89, 110);
            label23.Name = "label23";
            label23.Size = new Size(119, 28);
            label23.TabIndex = 33;
            label23.Text = "First Name";
            // 
            // tpRegister
            // 
            tpRegister.Controls.Add(groupBox2);
            tpRegister.Controls.Add(lblCountRegisters);
            tpRegister.Controls.Add(dgvRegisters);
            tpRegister.Controls.Add(txtSearchUserId);
            tpRegister.Controls.Add(label26);
            tpRegister.Location = new Point(4, 35);
            tpRegister.Name = "tpRegister";
            tpRegister.Padding = new Padding(3);
            tpRegister.Size = new Size(788, 947);
            tpRegister.TabIndex = 3;
            tpRegister.Text = "Login Register";
            tpRegister.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbRegisterDesc);
            groupBox2.Controls.Add(rbRegisterAsc);
            groupBox2.Location = new Point(615, 164);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(165, 76);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sorting";
            // 
            // rbRegisterDesc
            // 
            rbRegisterDesc.AutoSize = true;
            rbRegisterDesc.Cursor = Cursors.Hand;
            rbRegisterDesc.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbRegisterDesc.Location = new Point(88, 38);
            rbRegisterDesc.Name = "rbRegisterDesc";
            rbRegisterDesc.Size = new Size(68, 24);
            rbRegisterDesc.TabIndex = 1;
            rbRegisterDesc.TabStop = true;
            rbRegisterDesc.Text = "DESC";
            rbRegisterDesc.UseVisualStyleBackColor = true;
            rbRegisterDesc.CheckedChanged += rbRegisterDesc_CheckedChanged;
            // 
            // rbRegisterAsc
            // 
            rbRegisterAsc.AutoSize = true;
            rbRegisterAsc.Cursor = Cursors.Hand;
            rbRegisterAsc.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbRegisterAsc.Location = new Point(9, 38);
            rbRegisterAsc.Name = "rbRegisterAsc";
            rbRegisterAsc.Size = new Size(58, 24);
            rbRegisterAsc.TabIndex = 0;
            rbRegisterAsc.TabStop = true;
            rbRegisterAsc.Text = "ASC";
            rbRegisterAsc.UseVisualStyleBackColor = true;
            rbRegisterAsc.CheckedChanged += rbRegisterAsc_CheckedChanged;
            // 
            // lblCountRegisters
            // 
            lblCountRegisters.AutoSize = true;
            lblCountRegisters.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCountRegisters.ForeColor = Color.SteelBlue;
            lblCountRegisters.Location = new Point(35, 204);
            lblCountRegisters.Name = "lblCountRegisters";
            lblCountRegisters.Size = new Size(185, 28);
            lblCountRegisters.TabIndex = 14;
            lblCountRegisters.Text = "Register(s) Found";
            // 
            // dgvRegisters
            // 
            dgvRegisters.AllowUserToAddRows = false;
            dgvRegisters.AllowUserToDeleteRows = false;
            dgvRegisters.AllowUserToOrderColumns = true;
            dgvRegisters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvRegisters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegisters.ContextMenuStrip = contextMenuStrip1;
            dgvRegisters.Dock = DockStyle.Bottom;
            dgvRegisters.Location = new Point(3, 246);
            dgvRegisters.Name = "dgvRegisters";
            dgvRegisters.ReadOnly = true;
            dgvRegisters.Size = new Size(782, 698);
            dgvRegisters.TabIndex = 13;
            // 
            // txtSearchUserId
            // 
            txtSearchUserId.CharacterCasing = CharacterCasing.Lower;
            txtSearchUserId.Location = new Point(29, 87);
            txtSearchUserId.Name = "txtSearchUserId";
            txtSearchUserId.Size = new Size(212, 33);
            txtSearchUserId.TabIndex = 12;
            txtSearchUserId.TextChanged += txtSearchUserId_TextChanged;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.ForeColor = Color.SteelBlue;
            label26.Location = new Point(35, 52);
            label26.Name = "label26";
            label26.Size = new Size(158, 28);
            label26.TabIndex = 11;
            label26.Text = "Search User ID";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // User
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 986);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "User";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User";
            Load += User_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tbShow.ResumeLayout(false);
            tbShow.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShow).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            tbAdd.ResumeLayout(false);
            tbAdd.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tbEdit.ResumeLayout(false);
            tbEdit.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tpRegister.ResumeLayout(false);
            tpRegister.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegisters).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblWelcome;
        private Label lblDateTime;
        private PictureBox pictureBox1;
        private TabControl tabControl1;
        private TabPage tbShow;
        private GroupBox groupBox1;
        private RadioButton rbDesc;
        private RadioButton rbAsc;
        private Label lblCount;
        private DataGridView dgvShow;
        private TextBox txtSearch;
        private Label label2;
        private TabPage tbAdd;
        private TextBox txtPass;
        private Label label19;
        private TextBox txtUsername;
        private Label label18;
        private ComboBox boxPersonId;
        private Label label17;
        private Button btnAdd;
        private DateTimePicker dtBirthDate;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private Label label8;
        private Label label7;
        private TextBox txtPhone;
        private Label label6;
        private TextBox txtEmail;
        private Label label5;
        private TextBox txtLastName;
        private Label label4;
        private TextBox txtSecondName;
        private Label label3;
        private TextBox txtFirstName;
        private Label label1;
        private TabPage tbEdit;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private TabPage tpRegister;
        private GroupBox groupBox2;
        private RadioButton rbRegisterDesc;
        private RadioButton rbRegisterAsc;
        private Label lblCountRegisters;
        private DataGridView dgvRegisters;
        private TextBox txtSearchUserId;
        private Label label26;
        private ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox3;
        private CheckBox cbUser;
        private CheckBox cbTransaction;
        private CheckBox cbClients;
        private CheckBox cbPeople;
        private RadioButton rbNo;
        private RadioButton rbYes;
        private Label label20;
        private TextBox editPersonId;
        private Label label24;
        private GroupBox groupBox4;
        private CheckBox editUsers;
        private CheckBox editTransaction;
        private CheckBox editClients;
        private CheckBox editPeople;
        private RadioButton editNoAccess;
        private RadioButton editYseAccess;
        private Label label9;
        private TextBox editPassword;
        private Label label10;
        private TextBox editUsername;
        private Label label11;
        private ComboBox boxUserId;
        private Label label12;
        private Button btnUpdate;
        private DateTimePicker editBirthDate;
        private RadioButton editFemale;
        private RadioButton editMale;
        private Label label13;
        private Label label14;
        private TextBox editPhone;
        private Label label15;
        private TextBox editEmail;
        private Label label16;
        private TextBox editLastName;
        private Label label21;
        private TextBox editSecondName;
        private Label label22;
        private TextBox editFirstName;
        private Label label23;
        private RadioButton editNoActive;
        private RadioButton editYesActive;
        private Label label25;
    }
}