using Electronics.DTO;
using Electronics.DTO.ProductsDTO;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.Converters
{
    public static class CustomerConverter
    {
        public static Customer ConvertToCustomer(CustomerRegistrationDTO register)
        {
            var context = new ValidationContext(register);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(register, context, results, true);
            if (results.Count == 0)
            {
                Customer customer = new Customer(0, register.Email, register.UserName, register.Password);
                DtoToDomainConverter.Convert(register, customer);
                return customer;
            }
            throw new Exception("Invalid");
        }
    }
}
