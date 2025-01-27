using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.InterfaceServicesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RepositoryMocks
{
    public class OrderRepoMock : IOrder
    {
        private List<Cart> PastOrders;

        public OrderRepoMock()
        {
            PastOrders = new List<Cart>();
        }

        public List<Electronic> GetPastOrders(Customer customer)
        {
            List<Electronic> pastOrders = new List<Electronic>();
            foreach (var cart in PastOrders)
            {
                pastOrders.Add(cart.Electronic);
            }
            return pastOrders;
        }

        public void PurchaseOrder(Customer customer, List<Cart> cart)
        {
            PastOrders = cart;
        }
    }
}
