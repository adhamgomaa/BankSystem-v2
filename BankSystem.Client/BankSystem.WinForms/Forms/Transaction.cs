using BankSystem.DTOs.Clients;
using BankSystem.DTOs.Transfer;
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
using static BankSystem.WinForms.Helpers.ApiRoutes;

namespace BankSystem.WinForms.Forms
{
    public partial class Transaction : Form
    {
        private TransferApiService _trasnferService = new();
        private ClientApiService _clientSerivce = new();
        private List<TransferDTO>? _allTransfers = new();
        private List<ClientViewDTO>? _allClients = new();

        private int _accNum = 0;

        public Transaction(int AccNum)
        {
            InitializeComponent();
            _accNum = AccNum;
        }

        public Transaction()
        {
            InitializeComponent();
        }

        public int SelectedTabIndex
        {
            set
            {
                if (value >= 0 && value < tabControl1.TabCount)
                {
                    tabControl1.SelectedIndex = value;
                }
            }

            get
            {
                return tabControl1.SelectedIndex;
            }
        }

        private void _SelectClient()
        {
            if (this.SelectedTabIndex == 0)
            {
                if (boxAccNumDeposit.Items.Contains(_accNum))
                {
                    boxAccNumDeposit.SelectedIndex = boxAccNumDeposit.FindString(_accNum.ToString());
                }
            }

            if (this.SelectedTabIndex == 1)
            {
                if (boxAccNumWithdraw.Items.Contains(_accNum))
                {
                    boxAccNumWithdraw.SelectedIndex = boxAccNumWithdraw.FindString(_accNum.ToString());
                }
            }

            if (this.SelectedTabIndex == 3)
            {
                if (boxFromAccNum.Items.Contains(_accNum))
                {
                    boxFromAccNum.SelectedIndex = boxFromAccNum.FindString(_accNum.ToString());
                }
            }
        }

        private async Task _LoadData()
        {
            _allTransfers = await _trasnferService.GetAllTransfersAsync();
            dgvTrasnferLog.DataSource = _allTransfers;
            lblCountTransfer.Text = dgvTrasnferLog.Rows.Count.ToString() + " Transfer(s) Found";
            _allClients = await _clientSerivce.GetAllClientAsync();
            dgvShow.DataSource = _allClients;
            lblTotal.Text = "Total Balance is: ($" + await _clientSerivce.GetAllBalancesAsync() + ")";
            lblCount.Text = dgvShow.RowCount.ToString() + " Client(s) Found";
        }

        private void _fillAllAccountNumberInComboBox()
        {
            if (_allClients?.Count == 0)
            {
                MessageBox.Show("Please Add some clients to open this window", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            boxAccNumDeposit.Items.Clear();
            boxAccNumWithdraw.Items.Clear();
            boxFromAccNum.Items.Clear();

            foreach (var client in _allClients!)
            {
                boxAccNumDeposit.Items.Add(client.accountNumber);
                boxAccNumWithdraw.Items.Add(client.accountNumber);
                boxFromAccNum.Items.Add(client.accountNumber);
            }
        }

        private void _ApplyFilters()
        {
            string keyword = txtSearchTransfer.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvTrasnferLog.DataSource = _allTransfers;
                return;
            }

            var filterdTransfers = _allTransfers?.Where(t => t.senderAccount.ToString().Contains(keyword)).ToList();
            dgvTrasnferLog.DataSource = filterdTransfers;
        }

        private void _ApplyFiltersOnTotalBalances()
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvShow.DataSource = _allClients;
                return;
            }

            var filterdClients = _allClients?.Where(c => c.accountNumber.ToString().Contains(keyword)).ToList();
            dgvShow.DataSource = filterdClients;
        }

        private void txtSearchTransfer_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilters();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFiltersOnTotalBalances();
        }

        private void rbAsc_CheckedChanged(object sender, EventArgs e)
        {
            _allClients = _allClients?.OrderBy(c => c.clientId).ToList();
            dgvShow.DataSource = _allClients;
        }

        private void rbDesc_CheckedChanged(object sender, EventArgs e)
        {
            _allClients = _allClients?.OrderByDescending(c => c.clientId).ToList();
            dgvShow.DataSource = _allClients;
        }

        private void rbTransferAsc_CheckedChanged(object sender, EventArgs e)
        {
            _allTransfers = _allTransfers?.OrderBy(t => t.transferId).ToList();
            dgvTrasnferLog.DataSource = _allTransfers;
        }

        private void rbTransferDesc_CheckedChanged(object sender, EventArgs e)
        {
            _allTransfers = _allTransfers?.OrderByDescending(t => t.transferId).ToList();
            dgvTrasnferLog.DataSource = _allTransfers;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("F");
        }

        private async void Transaction_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblWelcome.Text = "Welcome: " + CurrentUser.User?.username;
            await _LoadData();
            _fillAllAccountNumberInComboBox();
            _SelectClient();
        }

        private async void boxAccNumDeposit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxAccNumDeposit.SelectedIndex == -1)
            {
                lblBalanceDeposit.Visible = false;
                return;
            }
            decimal balance = await _clientSerivce.GetBalanceAsync(Convert.ToInt32(boxAccNumDeposit.Text));
            lblBalanceDeposit.Text = "Current Balance is: $" + balance.ToString();
            lblBalanceDeposit.Visible = true;
        }

        private async void btnDeposit_Click(object sender, EventArgs e)
        {
            if (boxAccNumDeposit.SelectedIndex == -1)
            {
                return;
            }
            if (MessageBox.Show($"Are you sure to preform this transaction?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                DepositWithdrawDTO depositDto = new()
                {
                    AccNum = Convert.ToInt32(boxAccNumDeposit.Text),
                    Amount = numAmountDeposit.Value
                };
                string result = await _clientSerivce.DepositAsync(depositDto);
                MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await _LoadData();
            }
            boxAccNumDeposit.SelectedIndex = -1;
            numAmountDeposit.Value = 0;
        }

        private async void boxAccNumWithdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxAccNumWithdraw.SelectedIndex == -1)
            {
                lblBalanceWithdraw.Visible = false;
                return;
            }
            decimal balance = await _clientSerivce.GetBalanceAsync(Convert.ToInt32(boxAccNumWithdraw.Text));
            lblBalanceWithdraw.Text = "Current Balance is: $" + balance.ToString();
            lblBalanceWithdraw.Visible = true;
        }

        private async void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (boxAccNumWithdraw.SelectedIndex == -1)
            {
                return;
            }
            if (MessageBox.Show($"Are you sure to preform this transaction?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                DepositWithdrawDTO withdrawDTO = new()
                {
                    AccNum = Convert.ToInt32(boxAccNumWithdraw.Text),
                    Amount = numAmountWithdraw.Value
                };
                string result = await _clientSerivce.WithdrawAsync(withdrawDTO);
                MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await _LoadData();
            }
            boxAccNumWithdraw.SelectedIndex = -1;
            numAmountWithdraw.Value = 0;
        }

        private async void boxFromAccNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxFromAccNum.SelectedIndex == -1)
            {
                boxToAccNum.SelectedIndex = -1;
                boxToAccNum.Enabled = false;
                lblFromCurrent.Visible = false;
                return;
            }
            decimal balanceFrom = await _clientSerivce.GetBalanceAsync(Convert.ToInt32(boxFromAccNum.Text));
            if ((int)balanceFrom == 0)
            {
                MessageBox.Show($"Cannot Transfer From Account Number ({boxFromAccNum.Text}) Balance is $0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                boxFromAccNum.SelectedIndex = -1;
                return;
            }

            lblFromCurrent.Text = "Current Balance is: $" + balanceFrom.ToString();
            lblToCurrent.Visible = false;
            boxToAccNum.Enabled = true;
            lblFromCurrent.Visible = true;
            boxToAccNum.Items.Clear();
            for (int i = 0; i < boxFromAccNum.Items.Count; i++)
            {
                if (boxFromAccNum.SelectedIndex != i)
                {
                    boxToAccNum.Items.Add(boxFromAccNum.Items[i]!);
                }
            }
        }

        private async void boxToAccNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxToAccNum.SelectedIndex == -1)
            {
                lblToCurrent.Visible = false;
                return;
            }
            decimal balanceTo = await _clientSerivce.GetBalanceAsync(Convert.ToInt32(boxToAccNum.Text));
            lblToCurrent.Text = "Current Balance is: $" + balanceTo.ToString();
            lblToCurrent.Visible = true;
        }

        private async void btnTransfer_Click(object sender, EventArgs e)
        {
            if (boxFromAccNum.SelectedIndex == -1 || boxToAccNum.SelectedIndex == -1)
            {
                return;
            }
            if (MessageBox.Show($"Are you sure to preform this transaction?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                CreateTransferDTO transferDTO = new()
                {
                    senderAccount = Convert.ToInt32(boxFromAccNum.Text),
                    receiverAccount = Convert.ToInt32(boxToAccNum.Text),
                    amount = numTransferAmount.Value,
                    userId = CurrentUser.User!.userId
                };
                bool result = await _trasnferService.AddTransferAsync(transferDTO);
                if (result)
                {
                    MessageBox.Show($"Transfer Done Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadData();
                }
                else
                {
                    MessageBox.Show("Insufficient balance, your balance is lower than the amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            boxFromAccNum.SelectedIndex = -1;
            numTransferAmount.Value = 0;
        }
    }
}
