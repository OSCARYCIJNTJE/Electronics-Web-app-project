using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Electronics.Domain.Products
{
    public class Phone : Electronics
    {
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public int BatteryCapacitymAh { get; private set; }
        public int CameraQualityMP { get; private set; }
        public string SIMCardType { get; private set; }
        public List<string> Connectivity { get; private set; }
        public string BiometricFeatures { get; private set; }
        public Phone() { }

        public Phone(int id, string name, string oSystem, double screenInch, string capacity, int stock, byte[] image, string manufacturer, string model, int batteryCapacitymAh, int cameraQualityMP, string sIMCardType, List<string> connectivity, string biometricFeatures) : base(id, name, oSystem, screenInch, capacity, stock, image)
        {
            Manufacturer = manufacturer;
            Model = model;
            BatteryCapacitymAh = batteryCapacitymAh;
            CameraQualityMP = cameraQualityMP;
            SIMCardType = sIMCardType;
            Connectivity = connectivity;
            BiometricFeatures = biometricFeatures;
        }

        public Phone(string name, string oSystem, double screenInch, string capacity, int stock, byte[] image, string manufacturer, string model, int batteryCapacitymAh, int cameraQualityMP, string sIMCardType, List<string> connectivity, string biometricFeatures) : base(name, oSystem, screenInch, capacity, stock, image)
        {
            Manufacturer = manufacturer;
            Model = model;
            BatteryCapacitymAh = batteryCapacitymAh;
            CameraQualityMP = cameraQualityMP;
            SIMCardType = sIMCardType;
            Connectivity = connectivity;
            BiometricFeatures = biometricFeatures;
        }
    }
}
