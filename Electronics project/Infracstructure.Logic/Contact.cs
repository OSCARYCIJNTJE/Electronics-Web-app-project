using Electronics.Logic.DomainClasses.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic
{
    public class Contact
    {
        [Required,MinLength(8)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public Country Country { get; set; }
        [Required, MaxLength(200)]
        public string Subject {  get; set; }

        public Contact() { }

        public Contact(string name, string email, Country country, string subject)
        {
            Name = name;
            Email = email;
            Country = country;
            Subject = subject;
        }
    }
}
