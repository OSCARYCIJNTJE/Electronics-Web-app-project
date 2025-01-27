using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.InterfaceServicesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.ProductsServicesFolder
{
    public class ComputerServices
    {
        private readonly IComputer InterfaceComp;
        public ComputerServices(IComputer iComputer)
        {
            InterfaceComp = iComputer;
        }

        public void AddComputer(Computer computer)
        {
            InterfaceComp.Add(computer);
        }

        public IReadOnlyCollection<Computer> GetComputers()
        {
            return InterfaceComp.GetList();
        }

        public Computer GetComputerBySerialNumber(int serialNumber)
        {
            return InterfaceComp.GetById(serialNumber);
        }

        public void EditComputer(Computer computer)
        {
            InterfaceComp.Edit(computer);
        }

        public void DeleteComputer(Computer computer)
        {
            InterfaceComp.Remove(computer);
        }

        private List<string> IncludedProperties()
        {
            return new List<string>()
            {
                "Model",
                "OperatingSystem",
                "ScreenSizeInInches",
                "StorageCapacity",
                "Processor",
                "RAM",
                "KeyboardType",
                "MouseType",
                "PowerSource"
            };
        }


        public List<MyPropertyInfo> GetProperties(Computer computer)
        {
            return PropertyGetter<Computer>.GetProperties(computer, IncludedProperties());
        }

    }
}
