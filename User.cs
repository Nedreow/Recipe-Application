using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe_Application
{
    public class User
    {
        public string UserName { get; set; }

        private string Password { get; set; }

        public User(String name, string password)
        {
            UserName = name;
            Password = password;
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (CheckPassword(oldPassword))
            {
                Password = newPassword;
            }
        }

        public bool CheckPassword(string input)
        {
            if (input == Password)
            {
                return true;
            }

            return false;
        }

        public static User GetDefaultUser()
        {
            return new User("default", "OIKFEJRFNS");
        }
    }
}
