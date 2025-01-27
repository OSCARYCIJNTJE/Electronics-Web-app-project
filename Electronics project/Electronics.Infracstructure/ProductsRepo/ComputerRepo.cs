using Electronics.Logic.DomainClasses.CustomExceptions;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.InterfaceServicesFolder;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Infracstructure.ProductsRepo
{
    public class ComputerRepo : IComputer
    {
        private DatabaseCon con = new DatabaseCon();

        public void Add(Computer computer)
        {
            string sqlAdd = "INSERT INTO Electronics(SerialNumber,Name,Model,OperatingSystem,ScreenSizeInInches,StorageCapacity,Stock,Price,Image)VALUES(@serial,@name,@model,@Os,@screenSize,@capacity,@stock,@price,@image); SELECT SCOPE_IDENTITY();";
            string sqlComputerAdd = "INSERT INTO Computer(Id,SerialNumber,Processor,RAM,KeyboardType,MouseType,Ports,PowerSource)VALUES(@id,@serial,@processor,@ram,@keyboardType,@mouseType,@ports,@powerSource)";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();

                int id = 0;
                using (SqlCommand add = new SqlCommand(sqlAdd, conn))
                {
                    add.Parameters.AddWithValue("@serial", computer.SerialNumber);
                    add.Parameters.AddWithValue("@name", computer.Name);
                    add.Parameters.AddWithValue("@model", computer.Model);
                    add.Parameters.AddWithValue("@Os", computer.OperatingSystem);
                    add.Parameters.AddWithValue("@screenSize", computer.ScreenSizeInInches);
                    add.Parameters.AddWithValue("@capacity", computer.StorageCapacity);
                    add.Parameters.AddWithValue("@stock", computer.Stock);
                    add.Parameters.AddWithValue("@price", computer.Price);
                    add.Parameters.AddWithValue("@image", computer.Image);
                    id = Convert.ToInt32(add.ExecuteScalar());
                }

                using (SqlCommand computerAdd = new SqlCommand(sqlComputerAdd, conn))
                {
                    computerAdd.Parameters.AddWithValue("@id", id);
                    computerAdd.Parameters.AddWithValue("@serial", computer.SerialNumber);
                    computerAdd.Parameters.AddWithValue("@processor", computer.Processor);
                    computerAdd.Parameters.AddWithValue("@ram", computer.RAM);
                    computerAdd.Parameters.AddWithValue("@keyboardType", computer.KeyboardType);
                    computerAdd.Parameters.AddWithValue("@mouseType", computer.MouseType);

                    string portsString = string.Join(",", computer.Ports);
                    computerAdd.Parameters.AddWithValue("@ports", portsString);

                    computerAdd.Parameters.AddWithValue("@powerSource", computer.PowerSource);
                    computerAdd.ExecuteNonQuery();
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

        public Computer GetById(int serialNumber)
        {
            string sqlComputerGet = "SELECT e.*, c.KeyboardType, c.MouseType, c.Ports, c.PowerSource, c.Processor, c.RAM FROM Electronics as e INNER JOIN Computer as c ON e.Id = c.Id WHERE e.SerialNumber = @serial";
            SqlConnection conn = con.Connection();
            Computer computer = null;
            try
            {
                conn.Open();

                using (SqlCommand computerGet = new SqlCommand(sqlComputerGet, conn))
                {
                    computerGet.Parameters.AddWithValue("@serial", serialNumber);

                    SqlDataReader reader = computerGet.ExecuteReader();
                    while (reader.Read())
                    {
                        computer = GetCompInfos(reader);
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
            return computer;
        }

        private Computer GetCompInfos(SqlDataReader reader)
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

            string processor = reader.GetString("Processor");
            int ram = reader.GetInt32("RAM");
            string keyboard = reader.GetString("KeyboardType");
            string mouse = reader.GetString("MouseType");
            string portStrings = reader.GetString("Ports");
            List<string> portStringsList = portStrings.Split(",").ToList();
            string powerSource = reader.GetString("PowerSource");

            Computer computer = new Computer(ID, serialNumber)
            {
                Name = name,
                Model = model,
                OperatingSystem = OS,
                ScreenSizeInInches = screenSize,
                StorageCapacity = capacity,
                Stock = stock,
                Price = price,
                Image = imageData,
                Processor = processor,
                RAM = ram,
                KeyboardType = keyboard,
                MouseType = mouse,
                Ports = portStringsList,
                PowerSource = powerSource
            };

            if (computer == null)
            {
                throw new Exception("Computer returned empty");
            }
            return computer;
        }

        public List<Computer> GetList()
        {
            string sqlList = "SELECT * FROM Electronics as e INNER JOIN Computer as c ON e.Id = c.Id";
            List<Computer> computerList = new List<Computer>();
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                using (SqlCommand computerView = new SqlCommand(sqlList, conn))
                {
                    SqlDataReader reader = computerView.ExecuteReader();

                    while (reader.Read())
                    {
                        Computer computer = GetCompInfos(reader);

                        computerList.Add(computer);
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
            return computerList;
        }

        public void Edit(Computer computer)
        {
            string sqlEdit = "UPDATE Electronics SET Name = @name, Model = @model, OperatingSystem = @Os, ScreenSizeInInches = @screenSize, StorageCapacity = @capacity, Stock = @stock, Price = @price, Image = @image WHERE SerialNumber = @serial;";
            string sqlComputerEdit = "UPDATE Computer SET Processor = @processor, KeyboardType = @keyboardType, MouseType = @mouseType, Ports = @ports, PowerSource = @powerSource WHERE SerialNumber = @serial";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                int id = 0;
                using (SqlCommand edit = new SqlCommand(sqlEdit, conn))
                {
                    edit.Parameters.AddWithValue("@serial", computer.SerialNumber);
                    edit.Parameters.AddWithValue("@name", computer.Name);
                    edit.Parameters.AddWithValue("@model", computer.Model);
                    edit.Parameters.AddWithValue("@Os", computer.OperatingSystem);
                    edit.Parameters.AddWithValue("@screenSize", computer.ScreenSizeInInches);
                    edit.Parameters.AddWithValue("@capacity", computer.StorageCapacity);
                    edit.Parameters.AddWithValue("@stock", computer.Stock);
                    edit.Parameters.AddWithValue("@price", computer.Price);
                    edit.Parameters.AddWithValue("@image", computer.Image);
                }

                using (SqlCommand computerEdit = new SqlCommand(sqlComputerEdit, conn))
                {
                    computerEdit.Parameters.AddWithValue("@serial", computer.SerialNumber);
                    computerEdit.Parameters.AddWithValue("@processor", computer.Processor);
                    computerEdit.Parameters.AddWithValue("@ram", computer.RAM);
                    computerEdit.Parameters.AddWithValue("@keyboardType", computer.KeyboardType);
                    computerEdit.Parameters.AddWithValue("@mouseType", computer.MouseType);

                    string portsString = string.Join(",", computer.Ports);
                    computerEdit.Parameters.AddWithValue("@ports", portsString);

                    computerEdit.Parameters.AddWithValue("@powerSource", computer.PowerSource);
                    computerEdit.ExecuteNonQuery();
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

        public void Remove(Computer computer)
        {
            string sqlDelete = "DELETE FROM Electronics WHERE Id = @id";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                using (SqlCommand delete = new SqlCommand(sqlDelete, conn))
                {
                    delete.Parameters.AddWithValue("@id", computer.Id);
                    delete.ExecuteNonQuery();
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
    }
}
