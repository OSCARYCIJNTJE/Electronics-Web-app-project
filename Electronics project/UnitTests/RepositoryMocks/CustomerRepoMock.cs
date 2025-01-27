using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.InterfaceServicesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RepositoryMocks
{
    public class CustomerRepoMock : ICustomer
    {
        private Customer Customer { get; set; }
        public CustomerRepoMock()
        {
            Customer = new Customer(1, "customer@gmail.com", "Customer1", "123");
        }

        public Customer GetCustomer()
        {
            return Customer;
        }

        public void RegisterCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            if (Customer.Id == id)
            {
                return Customer;
            }
            return new Customer(0, "fail@gmail", "fail", "fail");
        }

        public void EditCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByUserNameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void SaveFavorites(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Electronic> GetFavorites(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
