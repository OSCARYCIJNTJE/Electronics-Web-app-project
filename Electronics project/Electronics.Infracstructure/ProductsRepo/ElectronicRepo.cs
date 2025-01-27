using Electronics.Logic.DomainClasses.CustomExceptions;
using Electronics.Logic.DomainClasses.Products;
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
    public class ElectronicRepo : IElectronic
    {
        private DatabaseCon con = new DatabaseCon();
        public Electronic GetById(int serialNumber)
        {
            string sqlElectronicGet = "SELECT * FROM Electronics WHERE SerialNumber = @serial";
            SqlConnection conn = con.Connection();
            Electronic electronic = null;
            try
            {
                conn.Open();

                using (SqlCommand electronicGet = new SqlCommand(sqlElectronicGet, conn))
                {
                    electronicGet.Parameters.AddWithValue("@serial", serialNumber);

                    SqlDataReader reader = electronicGet.ExecuteReader();
                    while (reader.Read())
                    {
                        electronic = GetInfos(reader);
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
            return electronic;
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
            };

            if (electronic == null)
            {
                throw new Exception("Computer returned empty");
            }
            return electronic;
        }

        public List<Electronic> GetList()
        {
            string sqlList = "SELECT * FROM Electronics ";
            List<Electronic> electronics = new List<Electronic>();
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                using (SqlCommand electronicView = new SqlCommand(sqlList, conn))
                {
                    SqlDataReader reader = electronicView.ExecuteReader();

                    while (reader.Read())
                    {
                        Electronic electronic = GetInfos(reader);

                        electronics.Add(electronic);
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
            return electronics;
        }
    }
}
