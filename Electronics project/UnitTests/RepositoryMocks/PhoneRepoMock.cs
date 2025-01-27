using Electronics.Logic.DomainClasses.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RepositoryMocks
{
    public class PhoneRepoMock
    {
        public List<Phone> Phones { get; set; }
        public PhoneRepoMock()
        {
            Phones = new List<Phone>();
        }
        
    }
}
