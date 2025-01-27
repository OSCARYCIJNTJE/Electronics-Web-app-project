using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.DTO.ProductsDTO
{
    public class PhoneDTO : ElectronicDTO
    {
        public string Manufacturer { get; set; } = string.Empty;
        public int BatteryCapacitymAh { get; set; }
        public int CameraQualityMP { get; set; }
        public string SIMCardType { get; set; } = string.Empty;
        public List<string> Connectivity { get; set; } = new List<string>();
        public string BiometricFeatures { get; set; } = string.Empty;
    }
}
