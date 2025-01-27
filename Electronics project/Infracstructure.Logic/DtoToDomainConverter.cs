using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic
{
    public static class DtoToDomainConverter
    {
        public static void Convert<DTO, T>(DTO dTO, T target)
        {
            foreach (var property in typeof(DTO).GetProperties())
            {
                var value = property.GetValue(dTO, null);
                var targetProperty = typeof(T).GetProperty(property.Name);

                if (targetProperty != null)
                {
                    if (targetProperty.PropertyType == typeof(string) && value is string)
                    {
                        targetProperty.SetValue(target, value);
                    }
                    if (targetProperty.PropertyType == typeof(int) && value is string stringValue)
                    {
                        if (int.TryParse(stringValue, out int intValue))
                        {
                            targetProperty.SetValue(target, intValue);
                        }
                    }
                    if (targetProperty.PropertyType == typeof(List<string>) && value is List<string> listValue)
                    {
                        if (listValue == null || listValue.Count == 0)
                        {
                            continue;
                        }
                        targetProperty.SetValue(target, listValue);
                    }
                    if (targetProperty.PropertyType == typeof(byte[]) && value is byte[] byteArrayValue)
                    {
                        targetProperty.SetValue(target, byteArrayValue);
                    }
                    if (targetProperty.PropertyType == typeof(double) && value is string doubleValue)
                    {
                        if (double.TryParse(doubleValue, out double intValue))
                        {
                            targetProperty.SetValue(target, intValue);
                        }
                    }
                }
                else
                {
                    throw new Exception($"Property '{property.Name}' does not exist in the target object");
                }
            }
        }
    }
}
