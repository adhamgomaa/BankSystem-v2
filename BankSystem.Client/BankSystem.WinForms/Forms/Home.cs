using BankSystem.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.WinForms.Forms
{
    public partial class Home : Form
    {
        public bool Logout { get; set; } = false;
        public Home()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            Logout = true;
            this.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblWelcome.Text = "Welcome: " + CurrentUser.User?.username;
            CheckPermissions();
        }

        private void CheckPermissions()
        {
            List<Button> buttonList = panel2.Controls.OfType<Button>().ToList();
            if (CurrentUser.User?.permissions == -1)
            {
                btnClients.Visible = true;
                btnTransaction.Visible = true;
                btnUsers.Visible = true;
                btnPeople.Visible = true;
            }
            else
            {
                foreach (Button button in buttonList)
                {
                    if (Convert.ToBoolean(CurrentUser.User?.permissions & Convert.ToInt16(button.Tag)))
                    {
                        button.Visible = true;
                    }
                    else
                    {
                        button.Visible = false;
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("F");
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            People people = new();
            people.ShowDialog();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            Client client = new();
            client.ShowDialog();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            Transaction transaction = new();
            transaction.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            User user = new();
            user.ShowDialog();
        }
    }
}
