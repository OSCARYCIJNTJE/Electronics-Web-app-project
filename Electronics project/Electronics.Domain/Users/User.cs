using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Domain.Users
{
    public class User
    {
        private int id { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string email { get; set; }
        private string userName { get; set; }
        private string password { get; set; }

        public User() { }

        public User(string firstName, string lastName, string email, string userName, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.userName = userName;
            this.password = password;
        }

        public User(int id, string firstName, string lastName, string email, string userName, string password)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.userName = userName;
            this.password = password;
        }
    }
}
