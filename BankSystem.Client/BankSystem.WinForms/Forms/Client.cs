using BankSystem.DTOs.Clients;
using BankSystem.DTOs.People;
using BankSystem.WinForms.Helpers;
using BankSystem.WinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.WinForms.Forms
{
    public partial class Client : Form
    {
        private ClientApiService _clientService = new();
        private List<ClientViewDTO>? _allClients = new();
        public Client()
        {
            InitializeComponent();
        }

        private async Task _LoadClientData()
        {
            _allClients = await _clientService.GetAllClientAsync();
            dgvShow.DataSource = _allClients;
            lblCount.Text = dgvShow.RowCount.ToString() + " Client(s) Found";
        }

        private void _ApplyFilters()
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvShow.DataSource = _allClients;
                return;
            }

            var filterdClients = _allClients?.Where(p => p.accountNumber.ToString().Contains(keyword)).ToList();
            dgvShow.DataSource = filterdClients;
        }

        private async void Client_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblWelcome.Text = "Welcome: " + CurrentUser.User?.username;
            dtBirthDate.MaxDate = DateTime.Today.AddYears(-21);
            dtBirthDate.MinDate = DateTime.Today.AddYears(-80);
            await _LoadClientData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilters();
        }

        private void rbAsc_CheckedChanged(object sender, EventArgs e)
        {
            _allClients = _allClients?.OrderBy(p => p.clientId).ToList();
            dgvShow.DataSource = _allClients;
        }

        private void rbDesc_CheckedChanged(object sender, EventArgs e)
        {
            _allClients = _allClients?.OrderByDescending(p => p.clientId).ToList();
            dgvShow.DataSource = _allClients;
        }

        private void Box_Validating(TextBox box, CancelEventArgs e)
        {
            if (!int.TryParse(box.Text, out int result))
            {
                e.Cancel = true;
                box.Focus();
                errorProvider1.SetError(box, "Please enter only numbers");
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

        private void Reset_TextBoxs()
        {
            txtAccNum.Text = "";
            txtCode.Text = "";
            numBalance.Value = 0;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (boxPersonId.SelectedIndex == -1)
            {
                return;
            }
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Enter All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show($"Are you sure to add a new client?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                CreateClientDTO createClient = new CreateClientDTO
                {
                    accountNumber = Convert.ToInt32(txtAccNum.Text),
                    personId = Convert.ToInt32(boxPersonId.Text),
                    pinCode = Convert.ToInt32(txtCode.Text),
                    balance = numBalance.Value
                };
                bool result = await _clientService.AddClientAsync(createClient);
                if (result)
                {
                    MessageBox.Show($"A Client Added Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadClientData();
                    _fillInComboBox();
                }
                else
                {
                    MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Reset_TextBoxs();
        }

        private async void _fillInComboBox()
        {
            var allPeople = await new PersonApiService().GetAllPeopleAsync();
            boxPersonId.Items.Clear();
            boxClientId.Items.Clear();

            foreach (var person in allPeople!)
            {
                boxPersonId.Items.Add(person.PersonId);
            }

            foreach (var client in _allClients!)
            {
                boxClientId.Items.Add(client.clientId);
            }
        }

        private async void boxClientId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxClientId.SelectedIndex == -1)
                return;

            ClientDTO? client = await _clientService.GetClientByIdAsync(Convert.ToInt32(boxClientId.Text));
            if (client != null)
            {
                GetPersonDTO? person = await new PersonApiService().GetPersonByIdAsync(client.personId);
                btnUpdate.Enabled = true;
                editPersonId.Text = client.personId.ToString();
                editFirstName.Text = person?.FirstName;
                editSecondName.Text = person?.SecondName;
                editLastName.Text = person?.LastName;
                editEmail.Text = person?.Email;
                editPhone.Text = person?.Phone;
                editBirthDate.Value = person!.BirthDate;

                if (person.Gender == 0)
                    editMale.Checked = true;
                else
                    editFemale.Checked = true;
                editCode.Text = client.pinCode.ToString();
                editAccNum.Text = client.accountNumber.ToString();
                editBalance.Value = client.balance;
            }

        }

        private async void boxPersonId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxPersonId.SelectedIndex == -1)
            {
                return;
            }
            GetPersonDTO? person = await new PersonApiService().GetPersonByIdAsync(Convert.ToInt32(boxPersonId.Text));
            if (person != null)
            {
                txtFirstName.Text = person.FirstName;
                txtSecondName.Text = person.SecondName;
                txtLastName.Text = person.LastName;
                txtEmail.Text = person.Email;
                txtPhone.Text = person.Phone;
                dtBirthDate.Value = person.BirthDate;
                if (person.Gender == 0)
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (boxClientId.SelectedIndex == -1)
            {
                return;
            }
            ClientDTO? client = await _clientService.GetClientByIdAsync(Convert.ToInt32(boxClientId.Text));
            if (client != null)
            {
                UpdateClientDTO updateClient = new()
                {
                    accountNumber = Convert.ToInt32(editAccNum.Text),
                    pinCode = Convert.ToInt32(editCode.Text),
                    balance = editBalance.Value,
                };
                if (MessageBox.Show($"Are you sure to update the client?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    bool result = await _clientService.UpdateClientAsync(Convert.ToInt32(boxClientId.Text), updateClient);
                    if (result)
                    {
                        MessageBox.Show($"The Client with ID = [{boxClientId.Text}] updated Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await _LoadClientData();
                        _fillInComboBox();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                btnUpdate.Enabled = false;
                boxClientId.SelectedIndex = -1;
                editAccNum.Text = "";
                editCode.Text = "";
                editBalance.Value = 0;
            }
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure to Delete this client?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                bool result = await _clientService.DeleteClientAsync((int)dgvShow.CurrentRow.Cells[0].Value);
                if (result)
                {
                    MessageBox.Show($"Client with ID = [{dgvShow.CurrentRow.Cells[0].Value}] Deleted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadClientData();
                    _fillInComboBox();
                }
                else
                {
                    MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("F");
        }

        private async void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction frm = new((int)dgvShow.CurrentRow.Cells[1].Value)
            {
                SelectedTabIndex = 0
            };
            frm.ShowDialog();
            await _LoadClientData();
        }

        private async void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction frm = new((int)dgvShow.CurrentRow.Cells[1].Value)
            {
                SelectedTabIndex = 1
            };
            frm.ShowDialog();
            await _LoadClientData();
        }

        private async void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction frm = new((int)dgvShow.CurrentRow.Cells[1].Value)
            {
                SelectedTabIndex = 3
            };
            frm.ShowDialog();
            await _LoadClientData();
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                