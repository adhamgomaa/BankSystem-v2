using BankSystem.DataAccess;
using BankSystem.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Business
{
    public class clsTransfer
    {

        public static bool AddNewTransfer(Transfer newTransfer)
        {
            return clsTransferData.AddNewTransfer(newTransfer);
        }

        public static List<Transfer> GetAllTransfers()
        {
            return clsTransferData.GetAllTransfer();
        }
    }
}
