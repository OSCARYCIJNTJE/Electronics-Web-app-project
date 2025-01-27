using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.InterfaceServicesFolder;
using Electronics.Logic.ProductsServicesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RepositoryMocks
{
    public class ElectronicRepoMock : IElectronic
    {
        private List<Electronic> Electronics { get; set; }
        public ElectronicRepoMock()
        {
            Electronics = new List<Electronic>();
            FillList();
        }

        private void FillList()
        {
            int id = 1;
            int serialNumber = 1000;
            while (Electronics.Count < 40)
            {
                Electronics.Add(new Computer(id, serialNumber));
                id++;
                serialNumber++;
                Electronics.Add(new Phone(id, serialNumber));
            }
        }

        public Electronic GetById(int serialNumber)
        {
            foreach (var item in Electronics)
            {
                if (item.Id == serialNumber)
                {
                    return item;
                }
            }
            return new Electronic(0,0);
        }

        public List<Electronic> GetList()
        {
            return Electronics;
        }
    }
}
