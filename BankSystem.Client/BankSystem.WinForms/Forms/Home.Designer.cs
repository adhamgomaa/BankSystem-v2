namespace BankSystem.WinForms.Forms
{
    partial class Home
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
            lblDateTime = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            lblWelcome = new Label();
            panel2 = new Panel();
            btnLogout = new Button();
            btnUsers = new Button();
            btnTransaction = new Button();
            btnClients = new Button();
            btnPeople = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblDateTime
            // 
            lblDateTime.Dock = DockStyle.Bottom;
            lblDateTime.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateTime.ForeColor = Color.White;
            lblDateTime.Location = new Point(0, 525);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(314, 108);
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
            // panel1
            // 
            panel1.BackColor = Color.LightSeaGreen;
            panel1.Controls.Add(lblWelcome);
            panel1.Controls.Add(lblDateTime);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(314, 633);
            panel1.TabIndex = 1;
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(52, 231);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(261, 94);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome:";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnLogout);
            panel2.Controls.Add(btnUsers);
            panel2.Controls.Add(btnTransaction);
            panel2.Controls.Add(btnClients);
            panel2.Controls.Add(btnPeople);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(316, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(484, 633);
            panel2.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.WhiteSmoke;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.OrangeRed;
            btnLogout.Location = new Point(129, 525);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(226, 57);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.WhiteSmoke;
            btnUsers.Cursor = Cursors.Hand;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsers.ForeColor = Color.SteelBlue;
            btnUsers.Location = new Point(129, 364);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(226, 57);
            btnUsers.TabIndex = 3;
            btnUsers.Tag = "8";
            btnUsers.Text = "Manage Users";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnTransaction
            // 
            btnTransaction.BackColor = Color.WhiteSmoke;
            btnTransaction.Cursor = Cursors.Hand;
            btnTransaction.FlatStyle = FlatStyle.Flat;
            btnTransaction.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTransaction.ForeColor = Color.SteelBlue;
            btnTransaction.Location = new Point(129, 268);
            btnTransaction.Name = "btnTransaction";
            btnTransaction.Size = new Size(226, 57);
            btnTransaction.TabIndex = 2;
            btnTransaction.Tag = "4";
            btnTransaction.Text = "Transactions";
            btnTransaction.UseVisualStyleBackColor = false;
            btnTransaction.Click += btnTransaction_Click;
            // 
            // btnClients
            // 
            btnClients.BackColor = Color.WhiteSmoke;
            btnClients.Cursor = Cursors.Hand;
            btnClients.FlatStyle = FlatStyle.Flat;
            btnClients.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClients.ForeColor = Color.SteelBlue;
            btnClients.Location = new Point(129, 172);
            btnClients.Name = "btnClients";
            btnClients.Size = new Size(226, 57);
            btnClients.TabIndex = 1;
            btnClients.Tag = "2";
            btnClients.Text = "Manage Clients";
            btnClients.UseVisualStyleBackColor = false;
            btnClients.Click += btnClients_Click;
            // 
            // btnPeople
            // 
            btnPeople.BackColor = Color.WhiteSmoke;
            btnPeople.Cursor = Cursors.Hand;
            btnPeople.FlatStyle = FlatStyle.Flat;
            btnPeople.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPeople.ForeColor = Color.SteelBlue;
            btnPeople.Location = new Point(129, 76);
            btnPeople.Name = "btnPeople";
            btnPeople.Size = new Size(226, 57);
            btnPeople.TabIndex = 0;
            btnPeople.Tag = "1";
            btnPeople.Text = "Manage People";
            btnPeople.UseVisualStyleBackColor = false;
            btnPeople.Click += btnPeople_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 633);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            Load += Home_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblDateTime;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel2;
        private Button btnPeople;
        private Button btnLogout;
        private Button btnUsers;
        private Button btnTransaction;
        private Button btnClients;
        private Label lblWelcome;
        private System.Windows.Forms.Timer timer1;
    }
}