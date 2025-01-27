using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.ProductsServicesFolder
{
    public static class PropertyGetter<T>
    {
        public static List<MyPropertyInfo> GetProperties(T myObject, List<string>propertiesList)
        {
            List<MyPropertyInfo> properties = new List<MyPropertyInfo>();
            var propertyList = "Ports";
            foreach (var property in typeof(Computer).GetProperties())
            {
                if (propertiesList.Contains(property.Name))
                {
                    object? value = property.GetValue(myObject);
                    if (property.Name == propertyList && value is List<string> stringList)
                    {
                        string stringValue = string.Join(",", stringList);
                        properties.Add(new MyPropertyInfo
                        {
                            Name = property.Name,
                            Value = stringValue
                        });
                    }
                    else
                    {
                        properties.Add(new MyPropertyInfo
                        {
                            Name = property.Name,
                            Value = property.GetValue(myObject)
                        });
                    }
                }
            }
            return properties;
        }
    }
}
