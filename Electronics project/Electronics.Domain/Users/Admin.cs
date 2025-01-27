using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Domain.Users
{
    public class Admin : User
    {
        private Department department {  get; set; }
        private string bSn {  get; set; }

        public Admin() { }

        public Admin (int id, string firstName, string lastName, string email, string userName, string password, Department department, string bSn)
            : base(id, firstName, lastName, email, userName, password)
        {
            this.department = department;
            this.bSn = bSn;
        }

        public Admin(string firstName, string lastName, string email, string userName, string password, Department department, string bSn)
            : base(firstName, lastName, email, userName, password)
        {
            this.department = department;
            this.bSn = bSn;
        }
    }
}
