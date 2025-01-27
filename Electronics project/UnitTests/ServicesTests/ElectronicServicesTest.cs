using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.ProductsServicesFolder;
using Electronics.Logic.UserServicesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.RepositoryMocks;

namespace UnitTests.ServicesTests
{
    [TestClass]
    public class ElectronicServicesTest
    {
        private ElectronicServices _ElectronicServices {  get; set; }
        private OrderServices _OrderServices { get; set; }
        private CustomerServices _CustomerServices { get; set; }
        private Customer Customer {  get; set; }

        [TestInitialize]
        public  void Setup()
        {
            _ElectronicServices = new ElectronicServices(new ElectronicRepoMock());
            _OrderServices = new OrderServices(new OrderRepoMock());
            _CustomerServices = new CustomerServices(new CustomerRepoMock());
            Customer = _CustomerServices.GetCustomerById(1);
        }

        [TestMethod]
        public void AlgorithmTest1()
        {
            //Arrange
            Computer computer = new Computer(1, 1000);
            List<Electronic> electronics = new List<Electronic>(_ElectronicServices.GetElectronics());
            List<Electronic> pastOrders = new List<Electronic>(_OrderServices.GetPastOrder(Customer));

            //Act
            bool result = false;
            List<Electronic> relateds = new List<Electronic>(_ElectronicServices.GetRelatedElectronics(computer, pastOrders));

            //Assert
            /*            if (relateds.Count == 4)
                        {
                            foreach (Electronic e in relateds)
                            {
                                if (e.SerialNumber != computer.SerialNumber)
                                {
                                    result = true;
                                }
                            }
                        }

                        Assert.IsTrue(result);*/

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(relateds, typeof(Electronic));
            CollectionAssert.AllItemsAreNotNull(relateds);
            CollectionAssert.DoesNotContain(relateds, computer);
            Assert.AreEqual(4, relateds.Count);
        }

        [TestMethod]
        public void AlgorithmTest2()
        {
            //Arrange
            Computer computer = new Computer(1, 1000);
            Computer computer3 = new Computer(3, 1003);
            computer.Price = 1000;
            List<Electronic> electronics = new List<Electronic>(_ElectronicServices.GetElectronics());

            List<Cart> order = new List<Cart>();

            Cart cart = new Cart();
            cart.SerialNumber = computer.SerialNumber;
            cart.Electronic = computer;
            cart.Quantity = 1;
            cart.TotalPrice = computer.Price * cart.Quantity;
            order.Add(cart);

            List<Electronic> pastOrders = new List<Electronic>(_OrderServices.GetPastOrder(Customer));

            //Act
            bool result = false;
            _OrderServices.Purchase(Customer, order);
            List<Electronic> relateds = new List<Electronic>(_ElectronicServices.GetRelatedElectronics(computer3, pastOrders));

            //Assert
            CollectionAssert.AllItemsAreInstancesOfType(relateds, typeof(Electronic));
            CollectionAssert.AllItemsAreNotNull(relateds);
            CollectionAssert.DoesNotContain(relateds, computer);
            CollectionAssert.DoesNotContain(relateds, computer3);
            Assert.AreEqual(4, relateds.Count);
            /*            if (relateds.Count == 4)
                        {
                            foreach (Electronic e in relateds)
                            {
                                if (e.SerialNumber == computer.SerialNumber)
                                {
                                    result = false;
                                }
                                if (e.SerialNumber != computer3.SerialNumber)
                                {
                                    result = true;
                                }
                                else
                                {
                                    result = true;
                                }
                            }
                        }
                        Assert.IsTrue(result);*/
        }

        [TestMethod]
        public void AlgorithmTest3()
        {
            //Arrange
            Computer computer = new Computer(2, 2000);
            List<Electronic> electronics = new List<Electronic>(_ElectronicServices.GetElectronics());
            List<Electronic> pastOrders = new List<Electronic>();

            //Act
            bool result = false;
            List<Electronic> relateds = new List<Electronic>(_ElectronicServices.GetRelatedElectronics(computer, pastOrders));

            //Assert
            CollectionAssert.AllItemsAreInstancesOfType(relateds, typeof(Electronic));
            CollectionAssert.AllItemsAreNotNull(relateds);
            CollectionAssert.DoesNotContain(relateds, computer);
            Assert.AreEqual(4, relateds.Count);

            Assert.IsFalse(electronics.Contains(computer), "The electronics list should not contain the computer.");
            /*            if (relateds.Count == 4)
                        {
                            if (!electronics.Contains(computer))
                            {
                                result = false;
                            }
                            else
                            {
                                foreach (Electronic e in relateds)
                                {
                                    if (e.SerialNumber != computer.SerialNumber)
                                    {
                                        result = true;
                                    }
                                }
                            }
                        }

                        Assert.IsFalse(result);*/
        }
    }
}
