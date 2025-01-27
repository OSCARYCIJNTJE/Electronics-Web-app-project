using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.InterfaceServicesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Infracstructure.UsersRepo
{
    public class AdminsRepo : IAdmin
    {
        private DatabaseCon con = new DatabaseCon();

        public void AddNewAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(string username, string email)
        {
            throw new NotImplementedException();
        }

        public void EditAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetAdminById(int id)
        {
            throw new NotImplementedException();
        }

        public Admin GetAdminByUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
