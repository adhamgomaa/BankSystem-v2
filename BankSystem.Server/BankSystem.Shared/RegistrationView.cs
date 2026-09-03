using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Shared
{
    public class RegistrationView
    {
        public int registerId {  get; set; }
        public int userId { get; set; }
        public string username { get; set; }
        public int permissions { get; set; }
        public DateTime registerationDate { get; set; }

        public RegistrationView()
        {
            registerId = -1;
            userId = -1;
            username = string.Empty;
            permissions = 0;
            registerationDate = DateTime.Now;
        }

        public RegistrationView(int registerId, int userId, string username, int permissions, DateTime registerationDate)
        {
            this.registerId = registerId;
            this.userId = userId;
            this.username = username;
            this.permissions = permissions;
            this.registerationDate = registerationDate;
        }
    }
}
