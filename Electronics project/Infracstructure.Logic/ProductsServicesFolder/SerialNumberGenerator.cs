using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.ProductsServicesFolder
{
    public static class SerialNumberGenerator
    {
        public static int GenerateSerialNumber()
        {
            Random random = new Random();

            int minSerialNumber = 1000000;
            int maxSerialNumber = 10000000;

            int randomSerialNumber = random.Next(minSerialNumber, maxSerialNumber + 1);
            return randomSerialNumber;
        }
    }
}
