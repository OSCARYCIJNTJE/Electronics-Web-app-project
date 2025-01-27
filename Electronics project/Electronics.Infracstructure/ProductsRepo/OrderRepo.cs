using Electronics.DTO;
using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.CustomExceptions;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.InterfaceServicesFolder;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Infracstructure.ProductsRepo
{
    public class OrderRepo : IOrder
    {
        private DatabaseCon con = new DatabaseCon();

        public void PurchaseOrder(Customer customer, List<Cart> carts)
        {
            string sqlOrder = "INSERT INTO [Order](UserId)VALUES(@userId); SELECT SCOPE_IDENTITY();";
            string sqlOrderInfo = "INSERT INTO OrderInfo(OrderId, ProductId, Quantity, TotalPrice) VALUES(@id, @productId, @quantity, @totalPrice)";
            string sqlUpdateStock = "UPDATE Electronics SET Stock = Stock - @quantity WHERE SerialNumber = @serial";

            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();

                int id = 0;

                using (SqlCommand order = new SqlCommand(sqlOrder, conn))
                {
                    order.Parameters.AddWithValue("@userId", customer.Id);
                    id = Convert.ToInt32(order.ExecuteScalar());
                }

                using (SqlCommand addInfo = new SqlCommand(sqlOrderInfo, conn))
                {
                    foreach (var cart in carts)
                    {
                        addInfo.Parameters.Clear();
                        addInfo.Parameters.AddWithValue("@id", id);
                        addInfo.Parameters.AddWithValue("@productId", cart.Electronic.Id);
                        addInfo.Parameters.AddWithValue("@quantity", cart.Quantity);
                        addInfo.Parameters.AddWithValue("@totalPrice", cart.TotalPrice);
                        addInfo.ExecuteNonQuery();
                    }
                }

                using (SqlCommand updateStock = new SqlCommand(sqlUpdateStock, conn))
                {
                    foreach (var cart in carts)
                    {
                        updateStock.Parameters.AddWithValue("@serial", cart.Electronic.SerialNumber);
                        updateStock.Parameters.AddWithValue("@quantity", cart.Quantity);
                        updateStock.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException(ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public int SoldItems()
        {
            return 0;
        }

        public List<Electronic> GetPastOrders(Customer customer)
        {
            if (customer == null)
            {
                return new List<Electronic>();
            }

            List<Electronic> pastOrders = new List<Electronic>();
            string sqlGetOrders = "SELECT * FROM Electronics as E INNER JOIN OrderInfo as OI ON E.Id = OI.ProductId INNER JOIN [Order] as o ON OI.OrderId = o.Id WHERE o.UserId = @userId";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                
                using (SqlCommand find = new SqlCommand(sqlGetOrders, conn))
                {
                    find.Parameters.AddWithValue("@userId", customer.Id);
                    SqlDataReader reader = find.ExecuteReader();

                    while (reader.Read())
                    {
                        Electronic electronic = GetInfos(reader);
                        pastOrders.Add(electronic);
                    }
                }

            }
            catch(Exception ex)
            {
                throw new DatabaseConnectionException(ex);
            }
            finally
            {
                conn.Close();
            }

            return pastOrders;
        }


        private Electronic GetInfos(SqlDataReader reader)
        {
            int ID = Convert.ToInt32(reader["Id"]);
            int serialNumber = Convert.ToInt32(reader["SerialNumber"]);
            string name = reader.GetString("Name");
            string model = reader.GetString("Model");
            string OS = reader.GetString("OperatingSystem");
            double screenSize = reader.GetDouble("ScreenSizeInInches");
            int capacity = reader.GetInt32("StorageCapacity");
            int stock = reader.GetInt32("Stock");
            int price = reader.GetInt32("Price");
            byte[] imageData = (byte[])reader[reader.GetOrdinal("Image")];

/*            string processor = reader.GetString("Processor");
            int ram = reader.GetInt32("RAM");
            string keyboard = reader.GetString("KeyboardType");
            string mouse = reader.GetString("MouseType");
            string portStrings = reader.GetString("Ports");
            List<string> portStringsList = portStrings.Split(",").ToList();
            string powerSource = reader.GetString("PowerSource");*/

            Electronic electronic = new Electronic(ID, serialNumber)
            {
                Name = name,
                Model = model,
                OperatingSystem = OS,
                ScreenSizeInInches = screenSize,
                StorageCapacity = capacity,
                Stock = stock,
                Price = price,
                Image = imageData,
/*                Processor = processor,
                RAM = ram,
                KeyboardType = keyboard,
                MouseType = mouse,
                Ports = portStringsList,
                PowerSource = powerSource*/
            };

            if (electronic == null)
            {
                throw new Exception("Electronic returned empty");
            }
            return electronic;
        }
    }
}
