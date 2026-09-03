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
    public class clsUser
    {
        public static bool AddUser(User newUser)
        {
            if (string.IsNullOrEmpty(newUser.username))
                return false;
            if (newUser.password.Length < 6)
                return false;
            newUser.password = clsCryptography.Hashing(newUser.password);
            newUser.userId = clsUserData.AddNewUser(newUser);
            return newUser.userId != -1;
        }

        public static bool UpdateUser(User updatedUser)
        {
            updatedUser.password = clsCryptography.Hashing(updatedUser.password);
            return clsUserData.UpdateUser(updatedUser);
        }

        public static User? FindUser(int userId)
        {
            User? user = clsUserData.GetUser(userId);
            if (user != null)
                return user;
            return null;
        }

        public static User? FindUser(string username, string pass)
        {
            pass = clsCryptography.Hashing(pass);
            User? user = clsUserData.GetUser(username, pass);
            if (user != null)
                return user;
            return null;
        }

        public static User? FindUser(string username)
        {
            return clsUserData.GetUser(username);
        }

        public static bool DeleteUser(int userId)
        {
            return clsUserData.DeleteUser(userId);
        }

        public static List<UserView> GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static int UsersCount()
        {
            return GetAllUsers().Count;
        }

        public static bool IsUserExist(int userId)
        {
            return clsUserData.UserIsExist(userId);
        }
    }
}
