using Electronics.DTO;
using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.InterfaceServicesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.UserServicesFolder
{
    public class CustomerServices
    {
        private readonly ICustomer InterFaceCustomer;

        public CustomerServices (ICustomer InterfaceCustomer)
        {
            InterFaceCustomer = InterfaceCustomer;
        }
        public bool RegisterNewCustomer(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }
            InterFaceCustomer.RegisterCustomer(customer);
            return true;
        }
        public void EditCustomer(Customer customer)
        {
            InterFaceCustomer.EditCustomer(customer);
        }
        public Customer GetCustomerById(int id)
        {
            return InterFaceCustomer.GetCustomerById(id);
        }
        public Customer? CheckUsernameAndPassword(string username, string password)
        {
            if (InterFaceCustomer.GetCustomerByUserNameAndPassword(username, password) != null)
            {
                return InterFaceCustomer.GetCustomerByUserNameAndPassword(username, password);
            }
            return null;
        }

        public List<MyPropertyInfo> GetCustomerProperties(Customer customer)
        {
            List<MyPropertyInfo> properties = new List<MyPropertyInfo>();
            var excludedProperties = new List<string> { "Id" };
            foreach (var property in typeof(Customer).GetProperties())
            {
                if (!excludedProperties.Contains(property.Name))
                {
                    object? value = property.GetValue(customer);
                    properties.Add(new MyPropertyInfo
                    {
                         Name = property.Name,
                         Value = property.GetValue(customer)
                    });
                }
            }
            return properties;
        }

        public void SetRegisterDTOFiller(Customer customer, CustomerRegistrationDTO credentialsDTO)
        {
            List<MyPropertyInfo> MyProperties = GetCustomerProperties(customer);
            foreach (var property in MyProperties)
            {
                FillRegisterDTO(property, credentialsDTO);
            }
        }

        private void FillRegisterDTO(MyPropertyInfo property, CustomerRegistrationDTO credentialsDTO)
        {
            PropertyInfo? dtoProperty = typeof(RegisterCredentialsDTO).GetProperty(property.Name);

            if (dtoProperty != null)
            {
                dtoProperty.SetValue(credentialsDTO, property.Value);
            }
        }

        public IReadOnlyCollection<Electronic> GetFavorites(Customer customer)
        {
            return InterFaceCustomer.GetFavorites(customer);
        }
    }
}
