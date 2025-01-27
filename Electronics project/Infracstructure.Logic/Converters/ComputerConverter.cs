using Electronics.DTO;
using Electronics.DTO.ProductsDTO;
using Electronics.Logic.DomainClasses.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.Converters
{
    public static class ComputerConverter
    {
        public static Computer ConvertToComputer(ComputerDTO computerDTO)
        {
            var context = new ValidationContext(computerDTO);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(computerDTO, context, results, true);
            if (results.Count == 0)
            {
                Computer computer = new Computer(0, computerDTO.SerialNumber);
                DtoToDomainConverter.Convert(computerDTO, computer);
                return computer;
            }
            else
            {
                
            }
            throw new Exception("Invalid");
        }
    }
}
