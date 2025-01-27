using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.DomainClasses.Users
{
    public class User
    {
        public int Id { get; init; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string UserName { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;

        public User(int id, string email, string userName, string password)
        {
            Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}
