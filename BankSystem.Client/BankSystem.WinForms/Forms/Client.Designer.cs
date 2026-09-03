namespace BankSystem.WinForms.Forms
{
    partial class Client
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
            txtSearch = new TextBox();
            label2 = new Label();
            tbAdd = new TabPage();
            numBalance = new NumericUpDown();
            label20 = new Label();
            txtAccNum = new TextBox();
            label19 = new Label();
            txtCode = new TextBox();
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
            editPersonId = new TextBox();
            label24 = new Label();
            editBalance = new NumericUpDown();
            label9 = new Label();
            editAccNum = new TextBox();
            label10 = new Label();
            editCode = new TextBox();
            label11 = new Label();
            boxClientId = new ComboBox();
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
            contextMenuStrip1 = new ContextMenuStrip(components);
            depositToolStripMenuItem = new ToolStripMenuItem();
            withdrawToolStripMenuItem = new ToolStripMenuItem();
            transferToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            errorProvider1 = new ErrorProvider(components);
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tbShow.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShow).BeginInit();
            tbAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBalance).BeginInit();
            tbEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editBalance).BeginInit();
            contextMenuStrip1.SuspendLayout();
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
            panel1.Size = new Size(303, 743);
            panel1.TabIndex = 3;
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
            lblDateTime.Location = new Point(0, 621);
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
            tabControl1.Dock = DockStyle.Right;
            tabControl1.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(302, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(796, 743);
            tabControl1.TabIndex = 4;
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
            tbShow.Size = new Size(788, 704);
            tbShow.TabIndex = 0;
            tbShow.Text = "Show Clients";
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
            lblCount.Location = new Point(32, 204);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(166, 28);
            lblCount.TabIndex = 9;
            lblCount.Text = "Client(s) Found";
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
            dgvShow.Location = new Point(3, 264);
            dgvShow.Name = "dgvShow";
            dgvShow.ReadOnly = true;
            dgvShow.Size = new Size(782, 437);
            dgvShow.TabIndex = 8;
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
            label2.Location = new Point(32, 58);
            label2.Name = "label2";
            label2.Size = new Size(254, 28);
            label2.TabIndex = 6;
            label2.Text = "Search Account Number";
            // 
            // tbAdd
            // 
            tbAdd.Controls.Add(numBalance);
            tbAdd.Controls.Add(label20);
            tbAdd.Controls.Add(txtAccNum);
            tbAdd.Controls.Add(label19);
            tbAdd.Controls.Add(txtCode);
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
            tbAdd.Size = new Size(788, 704);
            tbAdd.TabIndex = 1;
            tbAdd.Text = "Add Client";
            tbAdd.UseVisualStyleBackColor = true;
            // 
            // numBalance
            // 
            numBalance.Location = new Point(497, 562);
            numBalance.Maximum = new decimal(new int[] { 1316134912, 2328, 0, 0 });
            numBalance.Name = "numBalance";
            numBalance.Size = new Size(120, 33);
            numBalance.TabIndex = 34;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.SteelBlue;
            label20.Location = new Point(494, 523);
            label20.Name = "label20";
            label20.Size = new Size(90, 28);
            label20.TabIndex = 32;
            label20.Text = "Balance";
            // 
            // txtAccNum
            // 
            txtAccNum.CharacterCasing = CharacterCasing.Lower;
            txtAccNum.Cursor = Cursors.IBeam;
            txtAccNum.Location = new Point(83, 561);
            txtAccNum.Name = "txtAccNum";
            txtAccNum.Size = new Size(212, 33);
            txtAccNum.TabIndex = 31;
            txtAccNum.Validating += txtBox_Validating;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.SteelBlue;
            label19.Location = new Point(86, 523);
            label19.Name = "label19";
            label19.Size = new Size(183, 28);
            label19.TabIndex = 30;
            label19.Text = "Account Number";
            // 
            // txtCode
            // 
            txtCode.CharacterCasing = CharacterCasing.Lower;
            txtCode.Cursor = Cursors.IBeam;
            txtCode.Location = new Point(491, 454);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(212, 33);
            txtCode.TabIndex = 29;
            txtCode.Validating += txtBox_Validating;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.SteelBlue;
            label18.Location = new Point(494, 416);
            label18.Name = "label18";
            label18.Size = new Size(102, 28);
            label18.TabIndex = 28;
            label18.Text = "Pin Code";
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
            label17.Location = new Point(309, 20);
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
            btnAdd.Location = new Point(545, 629);
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
            rbFemale.Location = new Point(573, 363);
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
            rbMale.Location = new Point(494, 362);
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
            label8.Location = new Point(86, 416);
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
            label7.Location = new Point(494, 321);
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
            label6.Location = new Point(86, 317);
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
            label5.Location = new Point(497, 221);
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
            label4.Location = new Point(86, 221);
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
            label3.Location = new Point(497, 115);
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
            label1.Location = new Point(86, 115);
            label1.Name = "label1";
            label1.Size = new Size(119, 28);
            label1.TabIndex = 8;
            label1.Text = "First Name";
            // 
            // tbEdit
            // 
            tbEdit.Controls.Add(editPersonId);
            tbEdit.Controls.Add(label24);
            tbEdit.Controls.Add(editBalance);
            tbEdit.Controls.Add(label9);
            tbEdit.Controls.Add(editAccNum);
            tbEdit.Controls.Add(label10);
            tbEdit.Controls.Add(editCode);
            tbEdit.Controls.Add(label11);
            tbEdit.Controls.Add(boxClientId);
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
            tbEdit.Size = new Size(788, 704);
            tbEdit.TabIndex = 2;
            tbEdit.Text = "Edit Client";
            tbEdit.UseVisualStyleBackColor = true;
            // 
            // editPersonId
            // 
            editPersonId.CharacterCasing = CharacterCasing.Lower;
            editPersonId.Cursor = Cursors.IBeam;
            editPersonId.Enabled = false;
            editPersonId.Location = new Point(455, 57);
            editPersonId.Name = "editPersonId";
            editPersonId.Size = new Size(212, 33);
            editPersonId.TabIndex = 60;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.ForeColor = Color.SteelBlue;
            label24.Location = new Point(458, 19);
            label24.Name = "label24";
            label24.Size = new Size(108, 28);
            label24.TabIndex = 59;
            label24.Text = "Person ID";
            // 
            // editBalance
            // 
            editBalance.Location = new Point(464, 561);
            editBalance.Maximum = new decimal(new int[] { 1316134912, 2328, 0, 0 });
            editBalance.Name = "editBalance";
            editBalance.Size = new Size(120, 33);
            editBalance.TabIndex = 58;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.SteelBlue;
            label9.Location = new Point(461, 522);
            label9.Name = "label9";
            label9.Size = new Size(90, 28);
            label9.TabIndex = 57;
            label9.Text = "Balance";
            // 
            // editAccNum
            // 
            editAccNum.CharacterCasing = CharacterCasing.Lower;
            editAccNum.Cursor = Cursors.IBeam;
            editAccNum.Location = new Point(50, 560);
            editAccNum.Name = "editAccNum";
            editAccNum.Size = new Size(212, 33);
            editAccNum.TabIndex = 56;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.SteelBlue;
            label10.Location = new Point(53, 522);
            label10.Name = "label10";
            label10.Size = new Size(183, 28);
            label10.TabIndex = 55;
            label10.Text = "Account Number";
            // 
            // editCode
            // 
            editCode.CharacterCasing = CharacterCasing.Lower;
            editCode.Cursor = Cursors.IBeam;
            editCode.Location = new Point(458, 453);
            editCode.Name = "editCode";
            editCode.Size = new Size(212, 33);
            editCode.TabIndex = 54;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.SteelBlue;
            label11.Location = new Point(461, 415);
            label11.Name = "label11";
            label11.Size = new Size(102, 28);
            label11.TabIndex = 53;
            label11.Text = "Pin Code";
            // 
            // boxClientId
            // 
            boxClientId.DropDownStyle = ComboBoxStyle.DropDownList;
            boxClientId.FormattingEnabled = true;
            boxClientId.Location = new Point(50, 56);
            boxClientId.Name = "boxClientId";
            boxClientId.Size = new Size(177, 34);
            boxClientId.TabIndex = 52;
            boxClientId.SelectedIndexChanged += boxClientId_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.SteelBlue;
            label12.Location = new Point(53, 19);
            label12.Name = "label12";
            label12.Size = new Size(103, 28);
            label12.TabIndex = 51;
            label12.Text = "Client ID";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.WhiteSmoke;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.SteelBlue;
            btnUpdate.Location = new Point(512, 628);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(226, 57);
            btnUpdate.TabIndex = 50;
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
            editBirthDate.Location = new Point(53, 453);
            editBirthDate.Name = "editBirthDate";
            editBirthDate.Size = new Size(200, 33);
            editBirthDate.TabIndex = 49;
            // 
            // editFemale
            // 
            editFemale.AutoSize = true;
            editFemale.Cursor = Cursors.Hand;
            editFemale.Enabled = false;
            editFemale.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editFemale.Location = new Point(540, 362);
            editFemale.Name = "editFemale";
            editFemale.Size = new Size(74, 24);
            editFemale.TabIndex = 48;
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
            editMale.Location = new Point(461, 361);
            editMale.Name = "editMale";
            editMale.Size = new Size(60, 24);
            editMale.TabIndex = 47;
            editMale.TabStop = true;
            editMale.Text = "Male";
            editMale.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.SteelBlue;
            label13.Location = new Point(53, 415);
            label13.Name = "label13";
            label13.Size = new Size(113, 28);
            label13.TabIndex = 46;
            label13.Text = "Birth Date";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.SteelBlue;
            label14.Location = new Point(461, 320);
            label14.Name = "label14";
            label14.Size = new Size(87, 28);
            label14.TabIndex = 45;
            label14.Text = "Gender";
            // 
            // editPhone
            // 
            editPhone.CharacterCasing = CharacterCasing.Lower;
            editPhone.Cursor = Cursors.IBeam;
            editPhone.Enabled = false;
            editPhone.Location = new Point(50, 354);
            editPhone.Name = "editPhone";
            editPhone.Size = new Size(212, 33);
            editPhone.TabIndex = 44;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.SteelBlue;
            label15.Location = new Point(53, 316);
            label15.Name = "label15";
            label15.Size = new Size(76, 28);
            label15.TabIndex = 43;
            label15.Text = "Phone";
            // 
            // editEmail
            // 
            editEmail.CharacterCasing = CharacterCasing.Lower;
            editEmail.Cursor = Cursors.IBeam;
            editEmail.Enabled = false;
            editEmail.Location = new Point(461, 258);
            editEmail.Name = "editEmail";
            editEmail.Size = new Size(212, 33);
            editEmail.TabIndex = 42;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.SteelBlue;
            label16.Location = new Point(464, 220);
            label16.Name = "label16";
            label16.Size = new Size(69, 28);
            label16.TabIndex = 41;
            label16.Text = "Email";
            // 
            // editLastName
            // 
            editLastName.CharacterCasing = CharacterCasing.Lower;
            editLastName.Cursor = Cursors.IBeam;
            editLastName.Enabled = false;
            editLastName.Location = new Point(50, 258);
            editLastName.Name = "editLastName";
            editLastName.Size = new Size(212, 33);
            editLastName.TabIndex = 40;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.SteelBlue;
            label21.Location = new Point(53, 220);
            label21.Name = "label21";
            label21.Size = new Size(116, 28);
            label21.TabIndex = 39;
            label21.Text = "Last Name";
            // 
            // editSecondName
            // 
            editSecondName.CharacterCasing = CharacterCasing.Lower;
            editSecondName.Cursor = Cursors.IBeam;
            editSecondName.Enabled = false;
            editSecondName.Location = new Point(461, 152);
            editSecondName.Name = "editSecondName";
            editSecondName.Size = new Size(212, 33);
            editSecondName.TabIndex = 38;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.SteelBlue;
            label22.Location = new Point(464, 114);
            label22.Name = "label22";
            label22.Size = new Size(149, 28);
            label22.TabIndex = 37;
            label22.Text = "Second Name";
            // 
            // editFirstName
            // 
            editFirstName.CharacterCasing = CharacterCasing.Lower;
            editFirstName.Cursor = Cursors.IBeam;
            editFirstName.Enabled = false;
            editFirstName.Location = new Point(50, 152);
            editFirstName.Name = "editFirstName";
            editFirstName.Size = new Size(212, 33);
            editFirstName.TabIndex = 36;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.ForeColor = Color.SteelBlue;
            label23.Location = new Point(53, 114);
            label23.Name = "label23";
            label23.Size = new Size(119, 28);
            label23.TabIndex = 35;
            label23.Text = "First Name";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { depositToolStripMenuItem, withdrawToolStripMenuItem, transferToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(126, 92);
            // 
            // depositToolStripMenuItem
            // 
            depositToolStripMenuItem.Name = "depositToolStripMenuItem";
            depositToolStripMenuItem.Size = new Size(125, 22);
            depositToolStripMenuItem.Text = "Deposit";
            depositToolStripMenuItem.Click += depositToolStripMenuItem_Click;
            // 
            // withdrawToolStripMenuItem
            // 
            withdrawToolStripMenuItem.Name = "withdrawToolStripMenuItem";
            withdrawToolStripMenuItem.Size = new Size(125, 22);
            withdrawToolStripMenuItem.Text = "Withdraw";
            withdrawToolStripMenuItem.Click += withdrawToolStripMenuItem_Click;
            // 
            // transferToolStripMenuItem
            // 
            transferToolStripMenuItem.Name = "transferToolStripMenuItem";
            transferToolStripMenuItem.Size = new Size(125, 22);
            transferToolStripMenuItem.Text = "Transfer";
            transferToolStripMenuItem.Click += transferToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(125, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 743);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "Client";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client";
            Load += Client_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tbShow.ResumeLayout(false);
            tbShow.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShow).EndInit();
            tbAdd.ResumeLayout(false);
            tbAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBalance).EndInit();
            tbEdit.ResumeLayout(false);
            tbEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)editBalance).EndInit();
            contextMenuStrip1.ResumeLayout(false);
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
        private Label label20;
        private TextBox txtAccNum;
        private Label label19;
        private TextBox txtCode;
        private Label label18;
        private NumericUpDown numBalance;
        private TextBox editPersonId;
        private Label label24;
        private NumericUpDown editBalance;
        private Label label9;
        private TextBox editAccNum;
        private Label label10;
        private TextBox editCode;
        private Label label11;
        private ComboBox boxClientId;
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
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem depositToolStripMenuItem;
        private ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem withdrawToolStripMenuItem;
        private ToolStripMenuItem transferToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}