using Electronics.Logic.DomainClasses.Calculators;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.InterfaceServicesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.ProductsServicesFolder
{
    public class ElectronicServices
    {
        private readonly IElectronic InterfaceElectronic;

        public ElectronicServices(IElectronic interfaceElectronic)
        {
            InterfaceElectronic = interfaceElectronic;
        }
        public IReadOnlyCollection<Electronic> GetElectronics()
        {
            return InterfaceElectronic.GetList();
        }

        public Electronic GetElectronicById(int serialNumber)
        {
            return InterfaceElectronic.GetById(serialNumber);
        }

        public IReadOnlyCollection<Electronic> GetRelatedElectronics(Electronic electronic, List<Electronic> pastOrders)
        {
            return RelatedProducts.Calc(electronic, pastOrders, (List<Electronic>)GetElectronics());
        }
    }
}
