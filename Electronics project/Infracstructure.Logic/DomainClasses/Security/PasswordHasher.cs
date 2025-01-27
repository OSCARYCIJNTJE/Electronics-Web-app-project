using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.DomainClasses.Security
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            bool checkPassword = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return checkPassword;
        }
    }
}
