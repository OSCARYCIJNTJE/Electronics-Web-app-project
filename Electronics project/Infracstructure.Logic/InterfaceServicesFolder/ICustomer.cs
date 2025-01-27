using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.InterfaceServicesFolder
{
    public interface ICustomer
    {
        public void RegisterCustomer(Customer customer);
        public Customer GetCustomerById(int id);
        public void EditCustomer(Customer customer);
        public void DeleteCustomer(Customer customer);
        public Customer GetCustomerByUserNameAndPassword(string username, string password);
        /*public void ChangePassword(string username, string email);*/
        public void SaveFavorites(Customer customer);
        public List<Electronic> GetFavorites(Customer customer);
    }
}
