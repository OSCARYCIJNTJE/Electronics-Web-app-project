using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;

namespace Electronics.Logic.DomainClasses.Products
{
    [Serializable]
    public class Phone : Electronic
    {
        public string Manufacturer { get; set; } = string.Empty;
        public int BatteryCapacitymAh { get; set; } = 1;
        public int CameraQualityMP { get; set; } = 1;
        public string SIMCardType { get; set; } = string.Empty;
        public List<string> Connectivity { get; set; } = new List<string>();
        public string BiometricFeatures { get; set; } = string.Empty;

        [JsonConstructor]
        public Phone(int id, int serialNumber) : base(id, serialNumber)
        {
            this.Manufacturer = Manufacturer;
            this.BatteryCapacitymAh = BatteryCapacitymAh;
            this.CameraQualityMP = CameraQualityMP;
            this.SIMCardType = SIMCardType;
            this.Connectivity = Connectivity;
            this.BiometricFeatures = BiometricFeatures;
        }

        public override Electronic InitializeElectronic()
        {
            return new Phone(base.Id, base.SerialNumber);
        }
    }
}
