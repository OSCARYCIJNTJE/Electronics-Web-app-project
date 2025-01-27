using Electronics.DTO;
using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.InterfaceServicesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.UserServicesFolder
{
    public class OrderServices
    {
        private readonly IOrder _IOrder;

        public OrderServices(IOrder IOrder)
        {
            _IOrder = IOrder;
        }

        public void Purchase(Customer customer, List<Cart> cartDTOs)
        {
            _IOrder.PurchaseOrder(customer, cartDTOs);
        }

        public IReadOnlyCollection<Electronic> GetPastOrder(Customer customer)
        {
            return _IOrder.GetPastOrders(customer);
        }
    }
}
