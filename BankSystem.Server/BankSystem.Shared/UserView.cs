using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Shared
{
    public class UserView
    {
        public int userId { get; set; }
        public int personId { get; set; }
        public string username { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int permissions { get; set; }
        public bool isActive { get; set; }

        public UserView()
        {
            userId = -1;
            personId = -1;
            username = string.Empty;
            fullName = string.Empty;
            email = string.Empty;
            phone = string.Empty;
            permissions = 0;
            isActive = false;
        }

        public UserView(int userId, int personId, string username, string fullName, string email, string phone, int permissions, bool isActive)
        {
            this.userId = userId;
            this.personId = personId;
            this.username = username;
            this.fullName = fullName;
            this.email = email;
            this.phone = phone;
            this.permissions = permissions;
            this.isActive = isActive;
        }
    }
}
