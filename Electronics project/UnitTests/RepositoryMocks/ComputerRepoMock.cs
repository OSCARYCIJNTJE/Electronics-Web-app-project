using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.InterfaceServicesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RepositoryMocks
{
    public class ComputerRepoMock : IComputer
    {
        public List<Computer> Computers { get; private set; }
        public ComputerRepoMock()
        {
            Computers = new List<Computer>();
        }

        public void AddComputer(Computer computer)
        {
            Computers.Add(computer);
        }

        public void EditComputer(Computer computer)
        {
            for(int i = 0; i < Computers.Count; i++)
            {
                if (computer.SerialNumber == Computers[i].SerialNumber)
                {
                    Computers[i] = computer;
                    break;
                }
            }
        }

        public void DeleteComputer(Computer computer)
        {
            foreach (var item in Computers)
            {
                if (computer == item)
                {
                    Computers.Remove(item);
                    break;
                }
            }
        }

        public Computer GetComputerBySerialNumber(int serialNumber)
        {
            Computer computer = null;
            foreach (var item in Computers)
            {
                if (serialNumber == item.SerialNumber)
                {
                    computer = item;
                }
            }
            return computer;
        }

        public List<Computer> ComputerList()
        {
            return Computers;
        }

        public void Add(Computer item)
        {
            throw new NotImplementedException();
        }

        public void Edit(Computer item)
        {
            throw new NotImplementedException();
        }

        public Computer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Computer> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(Computer item)
        {
            throw new NotImplementedException();
        }
    }
}
