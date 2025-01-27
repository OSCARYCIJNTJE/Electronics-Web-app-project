using Electronics.DTO;
using Electronics.DTO.ProductsDTO;
using Electronics.Logic.DomainClasses.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.Converters
{
    public static class PhoneConverter
    {
        public static Phone ConvertToPhone(PhoneDTO phoneDTO)
        {
            var context = new ValidationContext(phoneDTO);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(phoneDTO, context, results, true);
            if (results.Count == 0)
            {
                Phone phone = new Phone(0, phoneDTO.SerialNumber);
                DtoToDomainConverter.Convert(phoneDTO, phone);
                return phone;
            }
            else
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}
