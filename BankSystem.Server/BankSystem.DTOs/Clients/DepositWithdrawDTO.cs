using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Clients
{
    public class DepositWithdrawDTO
    {
        public int AccNum { get; set; }
        public decimal Amount { get; set; }

        public DepositWithdrawDTO()
        {
            AccNum = 0;
            Amount = 0;
        }
    }
}
