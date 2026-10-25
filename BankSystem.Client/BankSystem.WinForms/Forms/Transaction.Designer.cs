namespace BankSystem.WinForms.Forms
{
    partial class Transaction
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
            tbDeposit = new TabPage();
            btnDeposit = new Button();
            lblBalanceDeposit = new Label();
            numAmountDeposit = new NumericUpDown();
            label25 = new Label();
            boxAccNumDeposit = new ComboBox();
            label2 = new Label();
            tbWithdraw = new TabPage();
            btnWithdraw = new Button();
            lblBalanceWithdraw = new Label();
            numAmountWithdraw = new NumericUpDown();
            label3 = new Label();
            boxAccNumWithdraw = new ComboBox();
            label4 = new Label();
            tbEdit = new TabPage();
            panel2 = new Panel();
            lblTotal = new Label();
            groupBox1 = new GroupBox();
            rbDesc = new RadioButton();
            rbAsc = new RadioButton();
            lblCount = new Label();
            dgvShow = new DataGridView();
            txtSearch = new TextBox();
            label1 = new Label();
            tbTransfer = new TabPage();
            btnTransfer = new Button();
            numTransferAmount = new NumericUpDown();
            label5 = new Label();
            lblToCurrent = new Label();
            boxToAccNum = new ComboBox();
            label8 = new Label();
            lblFromCurrent = new Label();
            boxFromAccNum = new ComboBox();
            label6 = new Label();
            tbLog = new TabPage();
            groupBox2 = new GroupBox();
            rbTransferDesc = new RadioButton();
            rbTransferAsc = new RadioButton();
            lblCountTransfer = new Label();
            dgvTrasnferLog = new DataGridView();
            txtSearchTransfer = new TextBox();
            label9 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tbDeposit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAmountDeposit).BeginInit();
            tbWithdraw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAmountWithdraw).BeginInit();
            tbEdit.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShow).BeginInit();
            tbTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTransferAmount).BeginInit();
            tbLog.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrasnferLog).BeginInit();
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
            panel1.Size = new Size(303, 592);
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
            lblDateTime.Location = new Point(0, 470);
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
            tabControl1.Controls.Add(tbDeposit);
            tabControl1.Controls.Add(tbWithdraw);
            tabControl1.Controls.Add(tbEdit);
            tabControl1.Controls.Add(tbTransfer);
            tabControl1.Controls.Add(tbLog);
            tabControl1.Dock = DockStyle.Right;
            tabControl1.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(303, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(613, 592);
            tabControl1.TabIndex = 5;
            // 
            // tbDeposit
            // 
            tbDeposit.Controls.Add(btnDeposit);
            tbDeposit.Controls.Add(lblBalanceDeposit);
            tbDeposit.Controls.Add(numAmountDeposit);
            tbDeposit.Controls.Add(label25);
            tbDeposit.Controls.Add(boxAccNumDeposit);
            tbDeposit.Controls.Add(label2);
            tbDeposit.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbDeposit.Location = new Point(4, 35);
            tbDeposit.Name = "tbDeposit";
            tbDeposit.Padding = new Padding(3);
            tbDeposit.Size = new Size(605, 553);
            tbDeposit.TabIndex = 0;
            tbDeposit.Text = "Deposit";
            tbDeposit.UseVisualStyleBackColor = true;
            // 
            // btnDeposit
            // 
            btnDeposit.BackColor = Color.WhiteSmoke;
            btnDeposit.Cursor = Cursors.Hand;
            btnDeposit.FlatStyle = FlatStyle.Flat;
            btnDeposit.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeposit.ForeColor = Color.SteelBlue;
            btnDeposit.Location = new Point(192, 250);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(226, 57);
            btnDeposit.TabIndex = 38;
            btnDeposit.Tag = "1";
            btnDeposit.Text = "Deposit";
            btnDeposit.UseVisualStyleBackColor = false;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // lblBalanceDeposit
            // 
            lblBalanceDeposit.AutoSize = true;
            lblBalanceDeposit.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBalanceDeposit.ForeColor = Color.SteelBlue;
            lblBalanceDeposit.Location = new Point(102, 134);
            lblBalanceDeposit.Name = "lblBalanceDeposit";
            lblBalanceDeposit.Size = new Size(198, 28);
            lblBalanceDeposit.TabIndex = 37;
            lblBalanceDeposit.Text = "Current Balance is:";
            // 
            // numAmountDeposit
            // 
            numAmountDeposit.Location = new Point(389, 73);
            numAmountDeposit.Maximum = new decimal(new int[] { 1316134912, 2328, 0, 0 });
            numAmountDeposit.Name = "numAmountDeposit";
            numAmountDeposit.Size = new Size(120, 29);
            numAmountDeposit.TabIndex = 36;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label25.ForeColor = Color.SteelBlue;
            label25.Location = new Point(389, 37);
            label25.Name = "label25";
            label25.Size = new Size(94, 28);
            label25.TabIndex = 35;
            label25.Text = "Amount";
            // 
            // boxAccNumDeposit
            // 
            boxAccNumDeposit.Cursor = Cursors.Hand;
            boxAccNumDeposit.DropDownStyle = ComboBoxStyle.DropDownList;
            boxAccNumDeposit.FormattingEnabled = true;
            boxAccNumDeposit.Location = new Point(96, 71);
            boxAccNumDeposit.Name = "boxAccNumDeposit";
            boxAccNumDeposit.Size = new Size(177, 30);
            boxAccNumDeposit.TabIndex = 29;
            boxAccNumDeposit.SelectedIndexChanged += boxAccNumDeposit_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SteelBlue;
            label2.Location = new Point(96, 37);
            label2.Name = "label2";
            label2.Size = new Size(183, 28);
            label2.TabIndex = 28;
            label2.Text = "Account Number";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbWithdraw
            // 
            tbWithdraw.Controls.Add(btnWithdraw);
            tbWithdraw.Controls.Add(lblBalanceWithdraw);
            tbWithdraw.Controls.Add(numAmountWithdraw);
            tbWithdraw.Controls.Add(label3);
            tbWithdraw.Controls.Add(boxAccNumWithdraw);
            tbWithdraw.Controls.Add(label4);
            tbWithdraw.Location = new Point(4, 35);
            tbWithdraw.Name = "tbWithdraw";
            tbWithdraw.Padding = new Padding(3);
            tbWithdraw.Size = new Size(605, 553);
            tbWithdraw.TabIndex = 1;
            tbWithdraw.Text = "Withdraw";
            tbWithdraw.UseVisualStyleBackColor = true;
            // 
            // btnWithdraw
            // 
            btnWithdraw.BackColor = Color.WhiteSmoke;
            btnWithdraw.Cursor = Cursors.Hand;
            btnWithdraw.FlatStyle = FlatStyle.Flat;
            btnWithdraw.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWithdraw.ForeColor = Color.SteelBlue;
            btnWithdraw.Location = new Point(192, 251);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(226, 57);
            btnWithdraw.TabIndex = 44;
            btnWithdraw.Tag = "1";
            btnWithdraw.Text = "Withdraw";
            btnWithdraw.UseVisualStyleBackColor = false;
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // lblBalanceWithdraw
            // 
            lblBalanceWithdraw.AutoSize = true;
            lblBalanceWithdraw.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBalanceWithdraw.ForeColor = Color.SteelBlue;
            lblBalanceWithdraw.Location = new Point(102, 135);
            lblBalanceWithdraw.Name = "lblBalanceWithdraw";
            lblBalanceWithdraw.Size = new Size(198, 28);
            lblBalanceWithdraw.TabIndex = 43;
            lblBalanceWithdraw.Text = "Current Balance is:";
            // 
            // numAmountWithdraw
            // 
            numAmountWithdraw.Location = new Point(389, 74);
            numAmountWithdraw.Maximum = new decimal(new int[] { 1316134912, 2328, 0, 0 });
            numAmountWithdraw.Name = "numAmountWithdraw";
            numAmountWithdraw.Size = new Size(120, 33);
            numAmountWithdraw.TabIndex = 42;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.SteelBlue;
            label3.Location = new Point(389, 38);
            label3.Name = "label3";
            label3.Size = new Size(94, 28);
            label3.TabIndex = 41;
            label3.Text = "Amount";
            // 
            // boxAccNumWithdraw
            // 
            boxAccNumWithdraw.Cursor = Cursors.Hand;
            boxAccNumWithdraw.DropDownStyle = ComboBoxStyle.DropDownList;
            boxAccNumWithdraw.FormattingEnabled = true;
            boxAccNumWithdraw.Location = new Point(96, 72);
            boxAccNumWithdraw.Name = "boxAccNumWithdraw";
            boxAccNumWithdraw.Size = new Size(177, 34);
            boxAccNumWithdraw.TabIndex = 40;
            boxAccNumWithdraw.SelectedIndexChanged += boxAccNumWithdraw_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.SteelBlue;
            label4.Location = new Point(96, 38);
            label4.Name = "label4";
            label4.Size = new Size(183, 28);
            label4.TabIndex = 39;
            label4.Text = "Account Number";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbEdit
            // 
            tbEdit.Controls.Add(panel2);
            tbEdit.Controls.Add(groupBox1);
            tbEdit.Controls.Add(lblCount);
            tbEdit.Controls.Add(dgvShow);
            tbEdit.Controls.Add(txtSearch);
            tbEdit.Controls.Add(label1);
            tbEdit.Location = new Point(4, 35);
            tbEdit.Name = "tbEdit";
            tbEdit.Padding = new Padding(3);
            tbEdit.Size = new Size(605, 553);
            tbEdit.TabIndex = 2;
            tbEdit.Text = "Total Balances";
            tbEdit.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(lblTotal);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(599, 80);
            panel2.TabIndex = 16;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(17, 23);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(177, 28);
            lblTotal.TabIndex = 12;
            lblTotal.Text = "Total Balance is: ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbDesc);
            groupBox1.Controls.Add(rbAsc);
            groupBox1.Location = new Point(432, 213);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(165, 76);
            groupBox1.TabIndex = 15;
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
            lblCount.Location = new Point(6, 261);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(166, 28);
            lblCount.TabIndex = 14;
            lblCount.Text = "Client(s) Found";
            // 
            // dgvShow
            // 
            dgvShow.AllowUserToAddRows = false;
            dgvShow.AllowUserToDeleteRows = false;
            dgvShow.AllowUserToOrderColumns = true;
            dgvShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShow.Dock = DockStyle.Bottom;
            dgvShow.Location = new Point(3, 305);
            dgvShow.Name = "dgvShow";
            dgvShow.ReadOnly = true;
            dgvShow.Size = new Size(599, 245);
            dgvShow.TabIndex = 13;
            // 
            // txtSearch
            // 
            txtSearch.CharacterCasing = CharacterCasing.Lower;
            txtSearch.Location = new Point(17, 170);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(212, 33);
            txtSearch.TabIndex = 12;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(20, 132);
            label1.Name = "label1";
            label1.Size = new Size(254, 28);
            label1.TabIndex = 11;
            label1.Text = "Search Account Number";
            // 
            // tbTransfer
            // 
            tbTransfer.Controls.Add(btnTransfer);
            tbTransfer.Controls.Add(numTransferAmount);
            tbTransfer.Controls.Add(label5);
            tbTransfer.Controls.Add(lblToCurrent);
            tbTransfer.Controls.Add(boxToAccNum);
            tbTransfer.Controls.Add(label8);
            tbTransfer.Controls.Add(lblFromCurrent);
            tbTransfer.Controls.Add(boxFromAccNum);
            tbTransfer.Controls.Add(label6);
            tbTransfer.Location = new Point(4, 35);
            tbTransfer.Name = "tbTransfer";
            tbTransfer.Padding = new Padding(3);
            tbTransfer.Size = new Size(605, 553);
            tbTransfer.TabIndex = 3;
            tbTransfer.Text = "Transfer";
            tbTransfer.UseVisualStyleBackColor = true;
            // 
            // btnTransfer
            // 
            btnTransfer.BackColor = Color.WhiteSmoke;
            btnTransfer.Cursor = Cursors.Hand;
            btnTransfer.FlatStyle = FlatStyle.Flat;
            btnTransfer.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTransfer.ForeColor = Color.SteelBlue;
            btnTransfer.Location = new Point(325, 249);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(226, 57);
            btnTransfer.TabIndex = 46;
            btnTransfer.Tag = "1";
            btnTransfer.Text = "Transfer";
            btnTransfer.UseVisualStyleBackColor = false;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // numTransferAmount
            // 
            numTransferAmount.Location = new Point(26, 249);
            numTransferAmount.Maximum = new decimal(new int[] { 1316134912, 2328, 0, 0 });
            numTransferAmount.Name = "numTransferAmount";
            numTransferAmount.Size = new Size(120, 33);
            numTransferAmount.TabIndex = 45;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.SteelBlue;
            label5.Location = new Point(26, 213);
            label5.Name = "label5";
            label5.Size = new Size(94, 28);
            label5.TabIndex = 44;
            label5.Text = "Amount";
            // 
            // lblToCurrent
            // 
            lblToCurrent.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblToCurrent.ForeColor = Color.SteelBlue;
            lblToCurrent.Location = new Point(325, 125);
            lblToCurrent.Name = "lblToCurrent";
            lblToCurrent.Size = new Size(272, 72);
            lblToCurrent.TabIndex = 43;
            lblToCurrent.Text = "Current Balance is:";
            lblToCurrent.Visible = false;
            // 
            // boxToAccNum
            // 
            boxToAccNum.Cursor = Cursors.Hand;
            boxToAccNum.DropDownStyle = ComboBoxStyle.DropDownList;
            boxToAccNum.FormattingEnabled = true;
            boxToAccNum.Location = new Point(325, 62);
            boxToAccNum.Name = "boxToAccNum";
            boxToAccNum.Size = new Size(177, 34);
            boxToAccNum.TabIndex = 42;
            boxToAccNum.SelectedIndexChanged += boxToAccNum_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.SteelBlue;
            label8.Location = new Point(319, 28);
            label8.Name = "label8";
            label8.Size = new Size(213, 28);
            label8.TabIndex = 41;
            label8.Text = "To Account Number";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFromCurrent
            // 
            lblFromCurrent.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFromCurrent.ForeColor = Color.SteelBlue;
            lblFromCurrent.Location = new Point(26, 125);
            lblFromCurrent.Name = "lblFromCurrent";
            lblFromCurrent.Size = new Size(275, 72);
            lblFromCurrent.TabIndex = 40;
            lblFromCurrent.Text = "Current Balance is:";
            lblFromCurrent.Visible = false;
            // 
            // boxFromAccNum
            // 
            boxFromAccNum.Cursor = Cursors.Hand;
            boxFromAccNum.DropDownStyle = ComboBoxStyle.DropDownList;
            boxFromAccNum.FormattingEnabled = true;
            boxFromAccNum.Location = new Point(26, 62);
            boxFromAccNum.Name = "boxFromAccNum";
            boxFromAccNum.Size = new Size(177, 34);
            boxFromAccNum.TabIndex = 39;
            boxFromAccNum.SelectedIndexChanged += boxFromAccNum_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.SteelBlue;
            label6.Location = new Point(20, 28);
            label6.Name = "label6";
            label6.Size = new Size(238, 28);
            label6.TabIndex = 38;
            label6.Text = "From Account Number";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbLog
            // 
            tbLog.Controls.Add(groupBox2);
            tbLog.Controls.Add(lblCountTransfer);
            tbLog.Controls.Add(dgvTrasnferLog);
            tbLog.Controls.Add(txtSearchTransfer);
            tbLog.Controls.Add(label9);
            tbLog.Location = new Point(4, 35);
            tbLog.Name = "tbLog";
            tbLog.Padding = new Padding(3);
            tbLog.Size = new Size(605, 553);
            tbLog.TabIndex = 4;
            tbLog.Text = "Tranfer Log";
            tbLog.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbTransferDesc);
            groupBox2.Controls.Add(rbTransferAsc);
            groupBox2.Location = new Point(432, 218);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(165, 76);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sorting";
            // 
            // rbTransferDesc
            // 
            rbTransferDesc.AutoSize = true;
            rbTransferDesc.Cursor = Cursors.Hand;
            rbTransferDesc.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbTransferDesc.Location = new Point(88, 38);
            rbTransferDesc.Name = "rbTransferDesc";
            rbTransferDesc.Size = new Size(68, 24);
            rbTransferDesc.TabIndex = 1;
            rbTransferDesc.TabStop = true;
            rbTransferDesc.Text = "DESC";
            rbTransferDesc.UseVisualStyleBackColor = true;
            rbTransferDesc.CheckedChanged += rbTransferDesc_CheckedChanged;
            // 
            // rbTransferAsc
            // 
            rbTransferAsc.AutoSize = true;
            rbTransferAsc.Cursor = Cursors.Hand;
            rbTransferAsc.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbTransferAsc.Location = new Point(9, 38);
            rbTransferAsc.Name = "rbTransferAsc";
            rbTransferAsc.Size = new Size(58, 24);
            rbTransferAsc.TabIndex = 0;
            rbTransferAsc.TabStop = true;
            rbTransferAsc.Text = "ASC";
            rbTransferAsc.UseVisualStyleBackColor = true;
            rbTransferAsc.CheckedChanged += rbTransferAsc_CheckedChanged;
            // 
            // lblCountTransfer
            // 
            lblCountTransfer.AutoSize = true;
            lblCountTransfer.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCountTransfer.ForeColor = Color.SteelBlue;
            lblCountTransfer.Location = new Point(6, 264);
            lblCountTransfer.Name = "lblCountTransfer";
            lblCountTransfer.Size = new Size(188, 28);
            lblCountTransfer.TabIndex = 19;
            lblCountTransfer.Text = "Transfer(s) Found";
            // 
            // dgvTrasnferLog
            // 
            dgvTrasnferLog.AllowUserToAddRows = false;
            dgvTrasnferLog.AllowUserToDeleteRows = false;
            dgvTrasnferLog.AllowUserToOrderColumns = true;
            dgvTrasnferLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvTrasnferLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrasnferLog.Dock = DockStyle.Bottom;
            dgvTrasnferLog.Location = new Point(3, 305);
            dgvTrasnferLog.Name = "dgvTrasnferLog";
            dgvTrasnferLog.ReadOnly = true;
            dgvTrasnferLog.Size = new Size(599, 245);
            dgvTrasnferLog.TabIndex = 18;
            // 
            // txtSearchTransfer
            // 
            txtSearchTransfer.CharacterCasing = CharacterCasing.Lower;
            txtSearchTransfer.Location = new Point(17, 105);
            txtSearchTransfer.Name = "txtSearchTransfer";
            txtSearchTransfer.Size = new Size(212, 33);
            txtSearchTransfer.TabIndex = 17;
            txtSearchTransfer.TextChanged += txtSearchTransfer_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.SteelBlue;
            label9.Location = new Point(20, 67);
            label9.Name = "label9";
            label9.Size = new Size(254, 28);
            label9.TabIndex = 16;
            label9.Text = "Search Account Number";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Transaction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 592);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "Transaction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transaction";
            Load += Transaction_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tbDeposit.ResumeLayout(false);
            tbDeposit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAmountDeposit).EndInit();
            tbWithdraw.ResumeLayout(false);
            tbWithdraw.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAmountWithdraw).EndInit();
            tbEdit.ResumeLayout(false);
            tbEdit.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShow).EndInit();
            tbTransfer.ResumeLayout(false);
            tbTransfer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTransferAmount).EndInit();
            tbLog.ResumeLayout(false);
            tbLog.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrasnferLog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblWelcome;
        private Label lblDateTime;
        private PictureBox pictureBox1;
        private TabControl tabControl1;
        private TabPage tbDeposit;
        private ComboBox boxAccNumDeposit;
        private Label label2;
        private TabPage tbWithdraw;
        private NumericUpDown numBalance;
        private Label label20;
        private TextBox txtAccNum;
        private Label label19;
        private TextBox txtCode;
        private Label label18;
        private ComboBox boxPersonId;
        private Label label17;
        private Button btnAdd;
        private DateTimePicker dtBirthDate;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private TextBox txtSecondName;
        private TextBox txtFirstName;
        private TabPage tbEdit;
        private TabPage tbTransfer;
        private TabPage tbLog;
        private Label lblBalanceDeposit;
        private NumericUpDown numAmountDeposit;
        private Label label25;
        private Button btnDeposit;
        private Button btnWithdraw;
        private Label lblBalanceWithdraw;
        private NumericUpDown numAmountWithdraw;
        private Label label3;
        private ComboBox boxAccNumWithdraw;
        private Label label4;
        private Panel panel2;
        private Label lblTotal;
        private GroupBox groupBox1;
        private RadioButton rbDesc;
        private RadioButton rbAsc;
        private Label lblCount;
        private DataGridView dgvShow;
        private TextBox txtSearch;
        private Label label1;
        private Label lblToCurrent;
        private ComboBox boxToAccNum;
        private Label label8;
        private Label lblFromCurrent;
        private ComboBox boxFromAccNum;
        private Label label6;
        private Button btnTransfer;
        private NumericUpDown numTransferAmount;
        private Label label5;
        private GroupBox groupBox2;
        private RadioButton rbTransferDesc;
        private RadioButton rbTransferAsc;
        private Label lblCountTransfer;
        private DataGridView dgvTrasnferLog;
        private TextBox txtSearchTransfer;
        private Label label9;
        private System.Windows.Forms.Timer timer1;
    }
}