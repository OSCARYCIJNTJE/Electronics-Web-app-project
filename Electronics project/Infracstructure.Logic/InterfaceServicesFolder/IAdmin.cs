using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.InterfaceServicesFolder.SharedInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.InterfaceServicesFolder
{
    public interface IAdmin
    {
        public void AddNewAdmin(Admin admin);
        public void EditAdmin(Admin admin);
        public Admin GetAdminById(int id);
        public Admin GetAdminByUsernameAndPassword(string username, string password);
        public void ChangePassword(string username, string email);
    }
}
