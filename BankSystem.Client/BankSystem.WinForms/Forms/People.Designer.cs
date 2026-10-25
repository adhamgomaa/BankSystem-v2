namespace BankSystem.WinForms.Forms
{
    partial class People
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
            btnUpdate = new Button();
            editBirthDate = new DateTimePicker();
            editFemale = new RadioButton();
            editMale = new RadioButton();
            label10 = new Label();
            label11 = new Label();
            editPhone = new TextBox();
            label12 = new Label();
            editEmail = new TextBox();
            label13 = new Label();
            editLastName = new TextBox();
            label14 = new Label();
            editSecondName = new TextBox();
            label15 = new Label();
            editFirstName = new TextBox();
            label16 = new Label();
            boxPersonId = new ComboBox();
            label9 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tbShow.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShow).BeginInit();
            contextMenuStrip1.SuspendLayout();
            tbAdd.SuspendLayout();
            tbEdit.SuspendLayout();
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
            panel1.Size = new Size(314, 673);
            panel1.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(52, 248);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(261, 107);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome:";
            // 
            // lblDateTime
            // 
            lblDateTime.Dock = DockStyle.Bottom;
            lblDateTime.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateTime.ForeColor = Color.White;
            lblDateTime.Location = new Point(0, 551);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(314, 122);
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
            tabControl1.Dock = DockStyle.Right;
            tabControl1.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(319, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(796, 673);
            tabControl1.TabIndex = 3;
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
            tbShow.Size = new Size(788, 634);
            tbShow.TabIndex = 0;
            tbShow.Text = "Show People";
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
            lblCount.Location = new Point(29, 201);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(171, 28);
            lblCount.TabIndex = 9;
            lblCount.Text = "Person(s) Found";
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
            dgvShow.Size = new Size(782, 382);
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
            label2.Location = new Point(29, 55);
            label2.Name = "label2";
            label2.Size = new Size(180, 28);
            label2.TabIndex = 6;
            label2.Text = "Search Person ID";
            // 
            // tbAdd
            // 
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
            tbAdd.Size = new Size(788, 634);
            tbAdd.TabIndex = 1;
            tbAdd.Text = "Add Person";
            tbAdd.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.WhiteSmoke;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.SteelBlue;
            btnAdd.Location = new Point(480, 489);
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
            dtBirthDate.Format = DateTimePickerFormat.Short;
            dtBirthDate.Location = new Point(86, 513);
            dtBirthDate.Name = "dtBirthDate";
            dtBirthDate.Size = new Size(200, 33);
            dtBirthDate.TabIndex = 24;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Cursor = Cursors.Hand;
            rbFemale.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbFemale.Location = new Point(573, 378);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(74, 24);
            rbFemale.TabIndex = 23;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Checked = true;
            rbMale.Cursor = Cursors.Hand;
            rbMale.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbMale.Location = new Point(494, 378);
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
            label8.Location = new Point(83, 472);
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
            label7.Location = new Point(494, 337);
            label7.Name = "label7";
            label7.Size = new Size(87, 28);
            label7.TabIndex = 18;
            label7.Text = "Gender";
            // 
            // txtPhone
            // 
            txtPhone.CharacterCasing = CharacterCasing.Lower;
            txtPhone.Cursor = Cursors.IBeam;
            txtPhone.Location = new Point(83, 378);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(212, 33);
            txtPhone.TabIndex = 17;
            txtPhone.Validating += txtBox_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.SteelBlue;
            label6.Location = new Point(83, 337);
            label6.Name = "label6";
            label6.Size = new Size(76, 28);
            label6.TabIndex = 16;
            label6.Text = "Phone";
            // 
            // txtEmail
            // 
            txtEmail.CharacterCasing = CharacterCasing.Lower;
            txtEmail.Cursor = Cursors.IBeam;
            txtEmail.Location = new Point(494, 237);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(212, 33);
            txtEmail.TabIndex = 15;
            txtEmail.Validating += txtBox_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.SteelBlue;
            label5.Location = new Point(494, 196);
            label5.Name = "label5";
            label5.Size = new Size(69, 28);
            label5.TabIndex = 14;
            label5.Text = "Email";
            // 
            // txtLastName
            // 
            txtLastName.CharacterCasing = CharacterCasing.Lower;
            txtLastName.Cursor = Cursors.IBeam;
            txtLastName.Location = new Point(83, 237);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(212, 33);
            txtLastName.TabIndex = 13;
            txtLastName.Validating += txtBox_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.SteelBlue;
            label4.Location = new Point(83, 196);
            label4.Name = "label4";
            label4.Size = new Size(116, 28);
            label4.TabIndex = 12;
            label4.Text = "Last Name";
            // 
            // txtSecondName
            // 
            txtSecondName.CharacterCasing = CharacterCasing.Lower;
            txtSecondName.Cursor = Cursors.IBeam;
            txtSecondName.Location = new Point(494, 94);
            txtSecondName.Name = "txtSecondName";
            txtSecondName.Size = new Size(212, 33);
            txtSecondName.TabIndex = 11;
            txtSecondName.Validating += txtBox_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.SteelBlue;
            label3.Location = new Point(494, 53);
            label3.Name = "label3";
            label3.Size = new Size(149, 28);
            label3.TabIndex = 10;
            label3.Text = "Second Name";
            // 
            // txtFirstName
            // 
            txtFirstName.CharacterCasing = CharacterCasing.Lower;
            txtFirstName.Cursor = Cursors.IBeam;
            txtFirstName.Location = new Point(83, 94);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(212, 33);
            txtFirstName.TabIndex = 9;
            txtFirstName.Validating += txtBox_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(83, 53);
            label1.Name = "label1";
            label1.Size = new Size(119, 28);
            label1.TabIndex = 8;
            label1.Text = "First Name";
            // 
            // tbEdit
            // 
            tbEdit.Controls.Add(btnUpdate);
            tbEdit.Controls.Add(editBirthDate);
            tbEdit.Controls.Add(editFemale);
            tbEdit.Controls.Add(editMale);
            tbEdit.Controls.Add(label10);
            tbEdit.Controls.Add(label11);
            tbEdit.Controls.Add(editPhone);
            tbEdit.Controls.Add(label12);
            tbEdit.Controls.Add(editEmail);
            tbEdit.Controls.Add(label13);
            tbEdit.Controls.Add(editLastName);
            tbEdit.Controls.Add(label14);
            tbEdit.Controls.Add(editSecondName);
            tbEdit.Controls.Add(label15);
            tbEdit.Controls.Add(editFirstName);
            tbEdit.Controls.Add(label16);
            tbEdit.Controls.Add(boxPersonId);
            tbEdit.Controls.Add(label9);
            tbEdit.Location = new Point(4, 35);
            tbEdit.Name = "tbEdit";
            tbEdit.Padding = new Padding(3);
            tbEdit.Size = new Size(788, 634);
            tbEdit.TabIndex = 2;
            tbEdit.Text = "Edit Person";
            tbEdit.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.WhiteSmoke;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.SteelBlue;
            btnUpdate.Location = new Point(480, 540);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(226, 57);
            btnUpdate.TabIndex = 41;
            btnUpdate.Tag = "1";
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // editBirthDate
            // 
            editBirthDate.Cursor = Cursors.Hand;
            editBirthDate.Format = DateTimePickerFormat.Short;
            editBirthDate.Location = new Point(86, 564);
            editBirthDate.Name = "editBirthDate";
            editBirthDate.Size = new Size(200, 33);
            editBirthDate.TabIndex = 40;
            // 
            // editFemale
            // 
            editFemale.AutoSize = true;
            editFemale.Cursor = Cursors.Hand;
            editFemale.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editFemale.Location = new Point(573, 429);
            editFemale.Name = "editFemale";
            editFemale.Size = new Size(74, 24);
            editFemale.TabIndex = 39;
            editFemale.TabStop = true;
            editFemale.Text = "Female";
            editFemale.UseVisualStyleBackColor = true;
            // 
            // editMale
            // 
            editMale.AutoSize = true;
            editMale.Cursor = Cursors.Hand;
            editMale.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editMale.Location = new Point(494, 429);
            editMale.Name = "editMale";
            editMale.Size = new Size(60, 24);
            editMale.TabIndex = 38;
            editMale.TabStop = true;
            editMale.Text = "Male";
            editMale.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.SteelBlue;
            label10.Location = new Point(83, 523);
            label10.Name = "label10";
            label10.Size = new Size(113, 28);
            label10.TabIndex = 37;
            label10.Text = "Birth Date";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.SteelBlue;
            label11.Location = new Point(494, 388);
            label11.Name = "label11";
            label11.Size = new Size(87, 28);
            label11.TabIndex = 36;
            label11.Text = "Gender";
            // 
            // editPhone
            // 
            editPhone.CharacterCasing = CharacterCasing.Lower;
            editPhone.Cursor = Cursors.IBeam;
            editPhone.Location = new Point(83, 429);
            editPhone.Name = "editPhone";
            editPhone.Size = new Size(212, 33);
            editPhone.TabIndex = 35;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.SteelBlue;
            label12.Location = new Point(83, 388);
            label12.Name = "label12";
            label12.Size = new Size(76, 28);
            label12.TabIndex = 34;
            label12.Text = "Phone";
            // 
            // editEmail
            // 
            editEmail.CharacterCasing = CharacterCasing.Lower;
            editEmail.Cursor = Cursors.IBeam;
            editEmail.Location = new Point(494, 288);
            editEmail.Name = "editEmail";
            editEmail.Size = new Size(212, 33);
            editEmail.TabIndex = 33;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.SteelBlue;
            label13.Location = new Point(494, 247);
            label13.Name = "label13";
            label13.Size = new Size(69, 28);
            label13.TabIndex = 32;
            label13.Text = "Email";
            // 
            // editLastName
            // 
            editLastName.CharacterCasing = CharacterCasing.Lower;
            editLastName.Cursor = Cursors.IBeam;
            editLastName.Location = new Point(83, 288);
            editLastName.Name = "editLastName";
            editLastName.Size = new Size(212, 33);
            editLastName.TabIndex = 31;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.SteelBlue;
            label14.Location = new Point(83, 247);
            label14.Name = "label14";
            label14.Size = new Size(116, 28);
            label14.TabIndex = 30;
            label14.Text = "Last Name";
            // 
            // editSecondName
            // 
            editSecondName.CharacterCasing = CharacterCasing.Lower;
            editSecondName.Cursor = Cursors.IBeam;
            editSecondName.Location = new Point(494, 145);
            editSecondName.Name = "editSecondName";
            editSecondName.Size = new Size(212, 33);
            editSecondName.TabIndex = 29;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.SteelBlue;
            label15.Location = new Point(494, 104);
            label15.Name = "label15";
            label15.Size = new Size(149, 28);
            label15.TabIndex = 28;
            label15.Text = "Second Name";
            // 
            // editFirstName
            // 
            editFirstName.CharacterCasing = CharacterCasing.Lower;
            editFirstName.Cursor = Cursors.IBeam;
            editFirstName.Location = new Point(83, 145);
            editFirstName.Name = "editFirstName";
            editFirstName.Size = new Size(212, 33);
            editFirstName.TabIndex = 27;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.SteelBlue;
            label16.Location = new Point(83, 104);
            label16.Name = "label16";
            label16.Size = new Size(119, 28);
            label16.TabIndex = 26;
            label16.Text = "First Name";
            // 
            // boxPersonId
            // 
            boxPersonId.DropDownStyle = ComboBoxStyle.DropDownList;
            boxPersonId.FormattingEnabled = true;
            boxPersonId.Location = new Point(306, 62);
            boxPersonId.Name = "boxPersonId";
            boxPersonId.Size = new Size(177, 34);
            boxPersonId.TabIndex = 12;
            boxPersonId.SelectedIndexChanged += boxPersonId_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.SteelBlue;
            label9.Location = new Point(306, 22);
            label9.Name = "label9";
            label9.Size = new Size(108, 28);
            label9.TabIndex = 10;
            label9.Text = "Person ID";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // People
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 673);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "People";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "People";
            Load += People_Load;
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
            tbEdit.ResumeLayout(false);
            tbEdit.PerformLayout();
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
        private TabPage tbAdd;
        private TabPage tbEdit;
        private DataGridView dgvShow;
        private TextBox txtSearch;
        private Label label2;
        private GroupBox groupBox1;
        private RadioButton rbDesc;
        private RadioButton rbAsc;
        private Label lblCount;
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
        private DateTimePicker dtBirthDate;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private Button btnAdd;
        private Button btnUpdate;
        private DateTimePicker editBirthDate;
        private RadioButton editFemale;
        private RadioButton editMale;
        private Label label10;
        private Label label11;
        private TextBox editPhone;
        private Label label12;
        private TextBox editEmail;
        private Label label13;
        private TextBox editLastName;
        private Label label14;
        private TextBox editSecondName;
        private Label label15;
        private TextBox editFirstName;
        private Label label16;
        private ComboBox boxPersonId;
        private Label label9;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private ErrorProvider errorProvider1;
    }
}