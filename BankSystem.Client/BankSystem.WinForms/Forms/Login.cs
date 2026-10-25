using BankSystem.DTOs.Auth;
using BankSystem.WinForms.Helpers;
using BankSystem.WinForms.Services;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace BankSystem.WinForms.Forms
{
    public partial class Login : Form
    {
        private const string path = "remember.txt";
        private readonly AuthApiService _authService = new();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            timer1.Start();
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                if (lines.Length > 0 && !string.IsNullOrWhiteSpace(lines[0]))
                {
                    txtUserName.Text = lines[0];
                    cbRemember.Checked = true;
                    if (lines.Length > 1)
                        File.WriteAllText(path, lines[0]);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("F");
        }

        private void Box_Validating(TextBox box, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(box, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(box, "");
            }
        }

        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            Box_Validating((TextBox)sender, e);
        }

        private async Task CheckLogin()
        {
            LoginRequestDTO requestDTO = new()
            {
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Text
            };

            try
            {
                LoginResponseDTO? tokens = await _authService.LoginAsync(requestDTO);
                if (tokens is not null)
                {
                    lblAttempt.Visible = false;
                    lblInvalid.Visible = false;
                    CurrentUser.SignIn(tokens, requestDTO.UserName);
                    Home home = new();
                    home.Show();
                    this.Hide();
                    home.FormClosed += (s, arg) =>
                    {
                        if (home.Logout)
                            this.Show();
                        else
                            Application.Exit();
                    };
                }
                else
                {
                    lblInvalid.Text = "Invalid username or password";
                    lblInvalid.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unable to sign in: {ex.Message}",
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Enter All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string username = txtUserName.Text.Trim();
            if (cbRemember.Checked)
            {
                File.WriteAllText(path, username);
            }
            else
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            btnLogin.Enabled = false;
            try
            {
                await CheckLogin();
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}
