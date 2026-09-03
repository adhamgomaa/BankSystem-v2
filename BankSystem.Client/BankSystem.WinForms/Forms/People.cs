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
    public partial class People : Form
    {
        private PersonApiService _personService = new();
        private List<PeopleViewDTO>? _allPeople = new();
        public People()
        {
            InitializeComponent();
        }

        private async Task _LoadPersonData()
        {
            _allPeople = await _personService.GetAllPeopleAsync();
            dgvShow.DataSource = _allPeople;
            lblCount.Text = dgvShow.RowCount.ToString() + " Person(s) Found";
        }

        private void _ApplyFilters()
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvShow.DataSource = _allPeople;
                return;
            }

            var filterdPeople = _allPeople?.Where(p => p.PersonId.ToString().Contains(keyword)).ToList();
            dgvShow.DataSource = filterdPeople;
        }

        private async void People_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblWelcome.Text = "Welcome: " + CurrentUser.User?.username;
            dtBirthDate.MaxDate = DateTime.Today.AddYears(-21);
            dtBirthDate.MinDate = DateTime.Today.AddYears(-80);
            await _LoadPersonData();
            _fillAllPersonIdInComboBox();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilters();
        }

        private void rbAsc_CheckedChanged(object sender, EventArgs e)
        {
            _allPeople = _allPeople?.OrderBy(p => p.PersonId).ToList();
            dgvShow.DataSource = _allPeople;
        }

        private void rbDesc_CheckedChanged(object sender, EventArgs e)
        {
            _allPeople = _allPeople?.OrderByDescending(p => p.PersonId).ToList();
            dgvShow.DataSource = _allPeople;
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
            if (box == txtEmail)
            {
                if (!IsValidEmail(box.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(box, "Invalid email, include an '@' in the email address");
                }
            }
        }
        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            Box_Validating((TextBox)sender, e);
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void Reset_TextBoxs()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtSecondName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Complete All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show($"Are you sure to add person?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                CreatePersonDTO createPerson = new()
                {
                    firstName = txtFirstName.Text,
                    secondName = txtSecondName.Text,
                    lastName = txtLastName.Text,
                    email = txtEmail.Text,
                    phone = txtPhone.Text,
                    gender = rbMale.Checked ? Convert.ToByte(0) : Convert.ToByte(1),
                    birthDate = dtBirthDate.Value
                };
                bool result = await _personService.AddPersonAsync(createPerson);
                if (result)
                {
                    MessageBox.Show($"Person Added Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadPersonData();
                    _fillAllPersonIdInComboBox();
                }
                else
                {
                    MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Reset_TextBoxs();

        }

        private void _fillAllPersonIdInComboBox()
        {
            boxPersonId.Items.Clear();
            foreach (var person in _allPeople!)
            {
                boxPersonId.Items.Add(person.PersonId);
            }
        }

        private async void boxPersonId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxPersonId.SelectedIndex == -1)
            {
                return;
            }

            GetPersonDTO? person = await _personService.GetPersonByIdAsync(Convert.ToInt32(boxPersonId.Text));
            if (person != null)
            {
                btnUpdate.Enabled = true;
                editFirstName.Text = person.FirstName;
                editSecondName.Text = person.SecondName;
                editLastName.Text = person.LastName;
                editEmail.Text = person.Email;
                editPhone.Text = person.Phone;
                if (person.Gender == 0)
                    editMale.Checked = true;
                else
                    editFemale.Checked = true;
                editBirthDate.Value = person.BirthDate;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (boxPersonId.SelectedIndex == -1)
            {
                return;
            }

            GetPersonDTO? person = await _personService.GetPersonByIdAsync(Convert.ToInt32(boxPersonId.Text));
            if (person != null)
            {
                UpdatePersonDTO updatePerson = new()
                {
                    firstName = editFirstName.Text,
                    secondName = editSecondName.Text,
                    lastName = editLastName.Text,
                    email = editEmail.Text,
                    phone = editPhone.Text,
                    gender = editMale.Checked ? Convert.ToByte(0) : Convert.ToByte(1),
                    birthDate = editBirthDate.Value
                };
                if (MessageBox.Show($"Are you sure to update person?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    bool result = await _personService.UpdatePersonAsync(Convert.ToInt32(boxPersonId.Text), updatePerson);
                    if (result)
                    {
                        MessageBox.Show($"Person with ID = [{boxPersonId.Text}] updated Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await _LoadPersonData();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                btnUpdate.Enabled = false;
                boxPersonId.SelectedIndex = -1;
                editFirstName.Text = "";
                editSecondName.Text = "";
                editLastName.Text = "";
                editEmail.Text = "";
                editPhone.Text = "";
            }
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure to Delete this person [{dgvShow.CurrentRow.Cells[1].Value}]?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                bool result = await _personService.DeletePersonAsync((int)dgvShow.CurrentRow.Cells[0].Value);
                if (result)
                {
                    MessageBox.Show($"Person [{dgvShow.CurrentRow.Cells[1].Value}] Deleted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadPersonData();
                    _fillAllPersonIdInComboBox();
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
    }
}
