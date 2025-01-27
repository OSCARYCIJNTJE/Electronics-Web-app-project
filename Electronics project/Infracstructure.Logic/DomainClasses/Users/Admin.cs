using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.DomainClasses.Users
{
    public class Admin : User
    {
        public Department Department { get; set; }
        public string BSN { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }

        public Admin(int id, string email, string userName, string password)
            : base(id, email, userName, password)
        {
            this.Department = Department;
            this.BSN = BSN;
            this.PhoneNumber = PhoneNumber;
        }
    }
}
