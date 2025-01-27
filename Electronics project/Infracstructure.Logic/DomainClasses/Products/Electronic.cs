using System.Diagnostics;
using System.Reflection;
using System;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Electronics.Logic.DomainClasses.Products
{
    [Serializable]
    public class Electronic
    {
        public int Id { get; init; }
        public int SerialNumber { get; init; }
        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string OperatingSystem { get; set; } = string.Empty;
        public double ScreenSizeInInches { get; set; } = 1;
        public int StorageCapacity { get; set; } = 1;
        public int Stock { get; set; } = 1;
        public int Price { get; set; } = 1;
        public byte[] Image { get; set; } = new byte[0];
        public List<Review> Reviews { get; set; }

        [JsonConstructor]
        public Electronic(int id, int serialNumber)
        {
            Id = id;
            SerialNumber = serialNumber;
            Reviews = new List<Review>();
        }

        public virtual Electronic InitializeElectronic()
        {
            return new Electronic(Id, SerialNumber);
        }

        public string GetImageString()
        {
            string format = "image/png";
            string base64Image = Convert.ToBase64String(Image);
            return "data:" + format + ";base64," + base64Image;
        }
    }
}
