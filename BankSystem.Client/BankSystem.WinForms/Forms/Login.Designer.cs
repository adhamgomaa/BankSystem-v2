namespace BankSystem.WinForms.Forms
{
    partial class Login
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
            lblDateTime = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            lblAttempt = new Label();
            lblInvalid = new Label();
            groupBox1 = new GroupBox();
            btnLogin = new Button();
            cbRemember = new CheckBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSeaGreen;
            panel1.Controls.Add(lblDateTime);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(314, 636);
            panel1.TabIndex = 0;
            // 
            // lblDateTime
            // 
            lblDateTime.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateTime.ForeColor = Color.White;
            lblDateTime.Location = new Point(3, 517);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(308, 108);
            lblDateTime.TabIndex = 1;
            lblDateTime.Text = "DateTime";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bank;
            pictureBox1.Location = new Point(53, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(208, 173);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(126, 33);
            label1.Name = "label1";
            label1.Size = new Size(235, 28);
            label1.TabIndex = 2;
            label1.Text = "Welcome To Our Bank";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(lblAttempt);
            panel2.Controls.Add(lblInvalid);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(313, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(486, 636);
            panel2.TabIndex = 1;
            // 
            // lblAttempt
            // 
            lblAttempt.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAttempt.ForeColor = Color.OrangeRed;
            lblAttempt.Location = new Point(98, 567);
            lblAttempt.Name = "lblAttempt";
            lblAttempt.Size = new Size(350, 59);
            lblAttempt.TabIndex = 5;
            lblAttempt.Text = "You have 3 attempts before lock your account";
            lblAttempt.Visible = false;
            // 
            // lblInvalid
            // 
            lblInvalid.AutoSize = true;
            lblInvalid.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInvalid.ForeColor = Color.OrangeRed;
            lblInvalid.Location = new Point(98, 545);
            lblInvalid.Name = "lblInvalid";
            lblInvalid.Size = new Size(252, 22);
            lblInvalid.TabIndex = 4;
            lblInvalid.Text = "Invalid UserName Or Password!!";
            lblInvalid.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(cbRemember);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(75, 96);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(366, 410);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login To Your Account";
            // 
            // btnLogin
            // 
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.SteelBlue;
            btnLogin.Location = new Point(23, 348);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(317, 43);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // cbRemember
            // 
            cbRemember.AutoSize = true;
            cbRemember.Location = new Point(23, 273);
            cbRemember.Name = "cbRemember";
            cbRemember.Size = new Size(154, 30);
            cbRemember.TabIndex = 7;
            cbRemember.Text = "Remember me";
            cbRemember.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(23, 209);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(317, 33);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Validating += txtBox_Validating;
            // 
            // txtUserName
            // 
            txtUserName.CharacterCasing = CharacterCasing.Lower;
            txtUserName.Location = new Point(23, 112);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(317, 33);
            txtUserName.TabIndex = 5;
            txtUserName.Validating += txtBox_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.SteelBlue;
            label3.Location = new Point(23, 169);
            label3.Name = "label3";
            label3.Size = new Size(104, 28);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SteelBlue;
            label2.Location = new Point(23, 71);
            label2.Name = "label2";
            label2.Size = new Size(115, 28);
            label2.TabIndex = 3;
            label2.Text = "UserName";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 637);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblDateTime;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel2;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Button btnLogin;
        private CheckBox cbRemember;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label lblAttempt;
        private Label lblInvalid;
        private System.Windows.Forms.Timer timer1;
        private ErrorProvider errorProvider1;
    }
}