using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.InterfaceServicesFolder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.ProductsServicesFolder
{
    public class PhoneServices
    {
        private readonly IPhone InterfaceComp;
        public PhoneServices(IPhone iPhone)
        {
            InterfaceComp = iPhone;
        }

        public void AddPhone(Phone phone)
        {
            InterfaceComp.Add(phone);
        }

        public IReadOnlyCollection<Phone> GetPhones()
        {
            return InterfaceComp.GetList();
        }

        public Phone GetPhoneBySerialNumber(int serialNumber)
        {
            return InterfaceComp.GetById(serialNumber);
        }

        public void EditPhone(Phone phone)
        {
            InterfaceComp.Edit(phone);
        }

        public void Deletephone(Phone phone)
        {
            InterfaceComp.Remove(phone);
        }

        private List<string> IncludedProperties()
        {
            return new List<string>()
            {
                "Model",
                "OperatingSystem",
                "ScreenSizeInInches",
                "StorageCapacity",
                "Manufacturer"
            };
        }

        public List<MyPropertyInfo> GetProperties(Phone phone)
        {
            return PropertyGetter<Phone>.GetProperties(phone, IncludedProperties());
        }
    }
}
