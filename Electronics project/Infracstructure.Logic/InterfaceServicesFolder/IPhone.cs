using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.InterfaceServicesFolder.SharedInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.InterfaceServicesFolder
{
    public interface IPhone : IRepoWriter<Phone>, IRepoViewer<Phone>, IRepoRemover<Phone>
    {

    }
}
