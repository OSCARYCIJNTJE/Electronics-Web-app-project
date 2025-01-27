using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Domain.Products
{
    public class Computer : Electronics
    {
        public string Processor { get; private set; }
        public int RAM { get; private set; }
        public string KeyboardType { get; private set; }
        public string MouseType { get; private set; }
        public List<string> Ports { get; private set; }
        public string PowerSource { get; private set; }

        public Computer() { }

        public Computer(int id, string name, string oSystem, double screenInch, string capacity, int stock, byte[] image, string processorType, int rAMSizeInGB, string keyboardType, string mouseType, List<string> ports, string powerSource): base(id, name, oSystem, screenInch, capacity, stock, image)
        {
            Processor = processorType;
            RAM = rAMSizeInGB;
            KeyboardType = keyboardType;
            MouseType = mouseType;
            Ports = ports;
            PowerSource = powerSource;
        }

        public Computer(string name, string oSystem, double screenInch, string capacity, int stock, byte[] image, string processorType, int rAMSizeInGB, string keyboardType, string mouseType, List<string> ports, string powerSource) : base(name, oSystem, screenInch, capacity, stock, image)
        {
            Processor = processorType;
            RAM = rAMSizeInGB;
            KeyboardType = keyboardType;
            MouseType = mouseType;
            Ports = ports;
            PowerSource = powerSource;
        }
    }
}
