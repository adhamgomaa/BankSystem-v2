using BankSystem.DTOs.People;
using BankSystem.DTOs.Registerations;
using BankSystem.DTOs.Users;
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
    public partial class User : Form
    {
        private short _permission = 0;
        private UserApiService _userService = new();
        private RegistrationApiService _registerationService = new();
        private List<RegistrationViewDTO>? _allRegisters = new();
        private List<UserViewDTO>? _allUsers = new();
        public User()
        {
            InitializeComponent();
        }

        private async Task _LoadData()
        {
            _allUsers = await _userService.GetAllUserAsync();
            dgvShow.DataSource = _allUsers;
            lblCount.Text = dgvShow.RowCount.ToString() + " User(s) Found";
            _allRegisters = await _registerationService.GetAllRegistrsAsync();
            dgvRegisters.DataSource = _allRegisters;
            lblCountRegisters.Text = dgvRegisters.RowCount.ToString() + " Register(s) Found";
        }

        private void _ApplyFilters()
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvShow.DataSource = _allUsers;
                return;
            }

            var filterdUser = _allUsers?.Where(p => p.userId.ToString().Contains(keyword)).ToList();
            dgvShow.DataSource = filterdUser;
        }

        private void _ApplyFiltersRegisters()
        {
            string keyword = txtSearchUserId.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvRegisters.DataSource = _allRegisters;
                return;
            }

            var filterdRegisters = _allRegisters?.Where(p => p.userId.ToString().Contains(keyword)).ToList();
            dgvRegisters.DataSource = filterdRegisters;
        }

        private async void User_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblWelcome.Text = "Welcome: " + CurrentUser.User?.username;
            dtBirthDate.MaxDate = DateTime.Today.AddYears(-21);
            dtBirthDate.MinDate = DateTime.Today.AddYears(-80);
            await _LoadData();
            _fillInComboBox();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilters();
        }

        private void rbAsc_CheckedChanged(object sender, EventArgs e)
        {
            _allUsers = _allUsers?.OrderBy(p => p.userId).ToList();
            dgvShow.DataSource = _allUsers;
        }

        private void rbDesc_CheckedChanged(object sender, EventArgs e)
        {
            _allUsers = _allUsers?.OrderByDescending(p => p.userId).ToList();
            dgvShow.DataSource = _allUsers;
        }

        private async void Box_Validating(TextBox box, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                e.Cancel = true;
                box.Focus();
                errorProvider1.SetError(box, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(box, "");
            }

            UserDTO? isExist = await _userService.GetUserByUsernameAsync(txtUsername.Text.Trim());
            if (isExist != null)
            {
                e.Cancel = true;
                box.Focus();
                errorProvider1.SetError(box, "This username is already exist");
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

        private void _ResetAll()
        {
            txtUsername.Text = "";
            txtPass.Text = "";
            _permission = 0;
            rbYes.Checked = true;
            rbNo.Checked = false;
            cbPeople.Enabled = false;
            cbClients.Enabled = false;
            cbTransaction.Enabled = false;
            cbUser.Enabled = false;
            cbClients.Checked = false;
            cbTransaction.Checked = false;
            cbUser.Checked = false;
            cbPeople.Checked = false;
            boxUserId.SelectedIndex = -1;
            editPassword.Text = "";
            editUsername.Text = "";
            editYseAccess.Checked = false;
            editNoAccess.Checked = false;
            editClients.Enabled = false;
            editPeople.Enabled = false;
            editTransaction.Enabled = false;
            editUsers.Enabled = false;
            editClients.Checked = false;
            editPeople.Checked = false;
            editTransaction.Checked = false;
            editUsers.Checked = false;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Enter All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show($"Are you sure to add user?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                CreateUserDTO createUser = new()
                {
                    username = txtUsername.Text,
                    password = txtPass.Text,
                    permissions = _permission,
                    personId = Convert.ToInt32(boxPersonId.Text),
                    isActive = true
                };
                bool result = await _userService.AddUserAsync(createUser);
                if (result)
                {
                    MessageBox.Show($"User Added Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadData();
                    _fillInComboBox();
                }
                else
                {
                    MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _ResetAll();
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            cbPeople.Enabled = false;
            cbClients.Enabled = false;
            cbTransaction.Enabled = false;
            cbUser.Enabled = false;
            _permission = -1;
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            cbPeople.Enabled = true;
            cbClients.Enabled = true;
            cbTransaction.Enabled = true;
            cbUser.Enabled = true;
            _permission = 0;
        }

        private void editYseAccess_CheckedChanged(object sender, EventArgs e)
        {
            editClients.Enabled = false;
            editPeople.Enabled = false;
            editTransaction.Enabled = false;
            editUsers.Enabled = false;
            _permission = -1;
        }

        private void editNoAccess_CheckedChanged(object sender, EventArgs e)
        {
            editClients.Enabled = true;
            editPeople.Enabled = true;
            editTransaction.Enabled = true;
            editUsers.Enabled = true;
            _permission = 0;
        }

        private void permissionCheckBoxes(CheckBox box, EventArgs e)
        {
            if (box.Checked)
                _permission += Convert.ToInt16(box.Tag);
            else
                _permission -= Convert.ToInt16(box.Tag);
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            permissionCheckBoxes((CheckBox)sender, e);
        }

        private async void _fillInComboBox()
        {
            var allPeople = await new PersonApiService().GetAllPeopleAsync();
            boxPersonId.Items.Clear();
            boxUserId.Items.Clear();

            foreach (var person in allPeople!)
            {
                boxPersonId.Items.Add(person.PersonId);
            }

            foreach (var user in _allUsers!)
            {
                boxUserId.Items.Add(user.userId);
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

        private async void boxUserId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxUserId.SelectedIndex == -1)
                return;
            GetUserDTO? user = await _userService.GetUserByIdAsync(Convert.ToInt32(boxUserId.Text));
            if (user != null)
            {
                GetPersonDTO? person = await new PersonApiService().GetPersonByIdAsync(user.personId);
                btnUpdate.Enabled = true;
                editPersonId.Text = user.personId.ToString();
                editUsername.Text = user.username;
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

                if (user.isActive)
                    editYesActive.Checked = true;
                else
                    editNoActive.Checked = true;

                if (user.permissions == -1)
                    editYseAccess.Checked = true;
                else
                    editNoAccess.Checked = true;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (boxUserId.SelectedIndex == -1)
                return;
            GetUserDTO? user = await _userService.GetUserByIdAsync(Convert.ToInt32(boxUserId.Text));
            if (user != null)
            {
                UpdateUserDTO updateUser = new()
                {
                    username = editUsername.Text,
                    personId = Convert.ToInt32(editPersonId.Text),
                    password = editPassword.Text,
                    permissions = _permission,
                    isActive = editYesActive.Checked,
                };
                if (MessageBox.Show($"Are you sure to update user [{updateUser.username}]?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    bool result = await _userService.UpdateUserAsync(Convert.ToInt32(boxUserId.Text), updateUser);
                    if (result)
                    {
                        MessageBox.Show($"User [{updateUser.username}] updated Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await _LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            _ResetAll();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure to Delete this user [{dgvShow.CurrentRow.Cells[2].Value}]?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                bool result = await _userService.DeleteUserAsync((int)dgvShow.CurrentRow.Cells[0].Value);
                if (result)
                {
                    MessageBox.Show($"User [{dgvShow.CurrentRow.Cells[2].Value}] Deleted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadData();
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

        private void txtSearchUserId_TextChanged(object sender, EventArgs e)
        {
            _ApplyFiltersRegisters();
        }

        private void rbRegisterAsc_CheckedChanged(object sender, EventArgs e)
        {
            _allRegisters = _allRegisters?.OrderBy(p => p.registerId).ToList();
            dgvRegisters.DataSource = _allRegisters;
        }

        private void rbRegisterDesc_CheckedChanged(object sender, EventArgs e)
        {
            _allRegisters = _allRegisters?.OrderByDescending(p => p.registerId).ToList();
            dgvRegisters.DataSource = _allRegisters;
        }
    }
}
