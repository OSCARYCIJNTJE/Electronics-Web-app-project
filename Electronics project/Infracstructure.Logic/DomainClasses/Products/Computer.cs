using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Electronics.Logic.DomainClasses.Products
{
    [Serializable]
    public class Computer : Electronic
    {
        public string Processor { get; set; } = string.Empty;
        public int RAM { get; set; } = 1;
        public string KeyboardType { get; set; } = string.Empty;
        public string MouseType { get; set; } = String.Empty;
        public List<string> Ports { get; set; } = new List<string>();
        public string PowerSource { get; set; } = string.Empty;

        [JsonConstructor]
        public Computer(int id, int serialNumber) : base(id, serialNumber)
        {
            this.Processor = Processor;
            this.RAM = RAM;
            this.KeyboardType = KeyboardType;
            this.MouseType = MouseType;
            this.Ports = Ports;
            this.PowerSource = PowerSource;
        }

        public override Electronic InitializeElectronic()
        {
            return new Computer(base.Id, base.SerialNumber);
        }

    }
}
