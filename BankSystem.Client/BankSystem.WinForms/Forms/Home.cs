using BankSystem.WinForms.Helpers;
using BankSystem.WinForms.Services;
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

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            btnLogout.Enabled = false;
            try
            {
                await new AuthApiService().LogoutAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"You have been signed out locally, but the server could not revoke your refresh token: {ex.Message}",
                    "Logout Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                CurrentUser.Clear();
            }

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
            btnLogout.Visible = true;
            foreach (Button button in panel2.Controls.OfType<Button>().Where(button => button != btnLogout))
            {
                button.Visible = int.TryParse(button.Tag?.ToString(), out int permission) &&
                    CurrentUser.HasPermission((BankPermission)permission);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("F");
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.HasPermission(BankPermission.People))
                return;

            People people = new();
            people.ShowDialog();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.HasPermission(BankPermission.Client))
                return;

            Client client = new();
            client.ShowDialog();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.HasPermission(BankPermission.Transfer))
                return;

            Transaction transaction = new();
            transaction.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.HasPermission(BankPermission.User))
                return;

            User user = new();
            user.ShowDialog();
        }
    }
}
