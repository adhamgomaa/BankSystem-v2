using BankSystem.DTOs.Registerations;
using BankSystem.DTOs.Users;
using BankSystem.WinForms.Helpers;
using BankSystem.WinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.WinForms.Forms
{
    public partial class Login : Form
    {
        private const string path = "remember.txt";
        private short attempt = 3;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            timer1.Start();
            if (File.Exists(path))
            {
                List<string> lines = File.ReadLines(path).ToList();
                if (lines.Count >= 2)
                {
                    txtUserName.Text = lines[0];
                    txtPassword.Text = lines[1];
                    cbRemember.Checked = true;
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
            UserApiService service = new();
            LoginRequestDTO requestDTO = new()
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text
            };

            LoginUserDTO? loggedUser = await service.LoginAsync(requestDTO);
            if (loggedUser != null)
            {
                if (loggedUser.isActive)
                {
                    attempt = 3;
                    lblAttempt.Visible = false;
                    lblInvalid.Visible = false;
                    CurrentUser.User = loggedUser;
                    RegistrationApiService registeration = new();
                    CreateRegisterDTO createRegister = new()
                    {
                        UserID = loggedUser.userId
                    };
                    bool register = await registeration.AddRegistrationAsync(createRegister);
                    if (register)
                    {
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
                }
                else
                {
                    MessageBox.Show("Your account is deactivated, please contact your admin", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                attempt--;
                lblInvalid.Visible = true;
                lblAttempt.Visible = true;
                if (attempt == 0)
                {
                    btnLogin.Enabled = false;
                    lblInvalid.Text = "You Are Locked After 3 Faild Trails!!";
                    lblAttempt.Text = "Contact System Adminstrator To Unlock Your Account";
                    return;
                }
                lblAttempt.Text = "You have " + attempt + " attempts before lock your account";
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Enter All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            if (cbRemember.Checked)
            {
                File.WriteAllText(path, $"{username}\n{password}");
            }
            else
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            await CheckLogin();
        }
    }
}
