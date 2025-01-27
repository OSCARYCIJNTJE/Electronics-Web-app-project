using Electronics.DTO;
using Electronics.DTO.ProductsDTO;
using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.Converters
{
    public class ElectronicConverter
    {
        public Computer ConvertToElectronic(ElectronicDTO electronicDTO)
        {
            Computer? electronic = null;
            foreach (var property in typeof(ElectronicDTO).GetProperties())
            {
                var value = property.GetValue(electronic, null);
                var targetProperty = typeof(Computer).GetProperty(property.Name);

                if (targetProperty != null)
                {
                    targetProperty.SetValue(electronicDTO, value);
                }
            }
            return electronic;
        }
    }
}
