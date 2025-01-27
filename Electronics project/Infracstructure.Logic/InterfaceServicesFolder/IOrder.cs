using Electronics.DTO;
using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.InterfaceServicesFolder
{
    public interface IOrder
    {
        public void PurchaseOrder(Customer customer, List<Cart> cart);
        public List<Electronic> GetPastOrders(Customer customer);
    }
}
