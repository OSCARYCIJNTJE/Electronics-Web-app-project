using Electronics.Logic.DomainClasses.CustomExceptions;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.InterfaceServicesFolder;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Infracstructure.ProductsRepo
{
    public class PhoneRepo : IPhone
    {
        private DatabaseCon con = new DatabaseCon();

        public void Add(Phone phone)
        {
            string sqlAdd = "INSERT INTO Electronics(SerialNumber,Name,Model,OperatingSystem,ScreenSizeInInches,StorageCapacity,Stock,Price,Image)VALUES(@serial,@name,@model,@Os,@screenSize,@capacity,@stock,@price,@image); SELECT SCOPE_IDENTITY();";
            string sqlPhoneAdd = "INSERT INTO Phone(Id,Manufacturer,BatteryCapacityMah,CameraQualityMP,SIMCardType,Connectivity,BiometricFeatures)VALUES(@id,@manufacturer,@batteryCapacity,@cameraQuality,@simCardType,@connectivity,@features)";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                int id = 0;
                using (SqlCommand add = new SqlCommand(sqlAdd, conn))
                {
                    add.Parameters.AddWithValue("@serial", phone.SerialNumber);
                    add.Parameters.AddWithValue("@name", phone.Name);
                    add.Parameters.AddWithValue("@model", phone.Model);
                    add.Parameters.AddWithValue("@Os", phone.OperatingSystem);
                    add.Parameters.AddWithValue("@screenSize", phone.ScreenSizeInInches);
                    add.Parameters.AddWithValue("@capacity", phone.StorageCapacity);
                    add.Parameters.AddWithValue("@stock", phone.Stock);
                    add.Parameters.AddWithValue("@price", phone.Price);
                    add.Parameters.AddWithValue("@image", phone.Image);
                    id = Convert.ToInt32(add.ExecuteScalar());
                }

                using (SqlCommand phoneAdd = new SqlCommand(sqlPhoneAdd, conn))
                {
                    phoneAdd.Parameters.AddWithValue("@id", id);
                    phoneAdd.Parameters.AddWithValue("@manufacturer", phone.Manufacturer);
                    phoneAdd.Parameters.AddWithValue("@batteryCapacity", phone.BatteryCapacitymAh);
                    phoneAdd.Parameters.AddWithValue("@cameraQuality", phone.CameraQualityMP);
                    phoneAdd.Parameters.AddWithValue("@simCardType", phone.SIMCardType);

                    string connectivity = string.Join(",", phone.Connectivity);
                    phoneAdd.Parameters.AddWithValue("@connectivity", connectivity);

                    phoneAdd.Parameters.AddWithValue("@features", phone.BiometricFeatures);
                    phoneAdd.ExecuteNonQuery();
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

        public Phone GetById(int serialNumber)
        {
            string sqlPhoneGet = "SELECT e.*, p.Manufacturer, p.BatteryCapacityMah, p.CameraQualityMP, p.SIMCardType, p.Connectivity, p.BiometricFeatures FROM Electronics as e INNER JOIN Phone as p ON e.Id = p.Id WHERE e.SerialNumber = @serial";
            Phone phone = null;
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();

                using (SqlCommand phoneGet = new SqlCommand(sqlPhoneGet, conn))
                {
                    phoneGet.Parameters.AddWithValue("@serial", serialNumber);
                    SqlDataReader reader = phoneGet.ExecuteReader();
                    while (reader.Read()){
                        phone = GetPhoneInfos(reader);
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
            return phone;
        }

        private Phone GetPhoneInfos(SqlDataReader reader)
        {
            Phone phone = null;

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

            string manufacturer = reader.GetString("Manufacturer");
            int batteryCap = reader.GetInt32("BatteryCapacityMah");
            string simCard = reader.GetString("SIMCardType");
            int cameraQuality = reader.GetInt32("CameraQualityMP");
            string connStrings = reader.GetString("Connectivity");
            List<string> connStringsList = connStrings.Split(",").ToList();
            string bioFeatures = reader.GetString("BiometricFeatures");

            phone = new Phone(ID, serialNumber)
            {
                Name = name,
                Model = model,
                OperatingSystem = OS,
                ScreenSizeInInches = screenSize,
                StorageCapacity = capacity,
                Stock = stock,
                Price = price,
                Image = imageData,
                Manufacturer = manufacturer,
                BatteryCapacitymAh = batteryCap,
                SIMCardType = simCard,
                CameraQualityMP = cameraQuality,
                Connectivity = connStringsList,
                BiometricFeatures = bioFeatures
            };

            if (phone == null)
            {
                throw new Exception("Phone returned empty");
            }
            return phone;
        }

        public List<Phone> GetList()
        {
            string sqlList = "SELECT * FROM Electronics as e INNER JOIN Phone as p ON e.Id = p.Id";
            List<Phone> phoneList = new List<Phone>();
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();

                using (SqlCommand phoneAll = new SqlCommand(sqlList, conn))
                {
                    SqlDataReader reader = phoneAll.ExecuteReader();
                    while (reader.Read())
                    {
                        Phone phone = GetPhoneInfos(reader);

                        phoneList.Add(phone);
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
            return phoneList;
        }

        public void Edit(Phone phone)
        {
            string sqlEdit = "UPDATE Electronics SET SerialNumber = @serial, Name = @name, Model = @model, OperatingSystem = @Os, ScreenSizeInInches = @screenSize, StorageCapacity = @capacity, Stock = @stock, Price = @price, Image = @image WHERE Id = @id ";
            string sqlPhoneEdit = "UPDATE Computer SET Manufacturer = @manufacturer, BatteryCapacityMah = @batteryCapacity, CameraQualityMP = @cameraQuality, SIMCardType = @simCardType, Connectivity = @connectivity, BiometricFeatures = @features WHERE Id = @id";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                using (SqlCommand edit = new SqlCommand(sqlEdit, conn))
                {
                    edit.Parameters.AddWithValue("@serial", phone.SerialNumber);
                    edit.Parameters.AddWithValue("@name", phone.Name);
                    edit.Parameters.AddWithValue("@model", phone.Model);
                    edit.Parameters.AddWithValue("@Os", phone.OperatingSystem);
                    edit.Parameters.AddWithValue("@screenSize", phone.ScreenSizeInInches);
                    edit.Parameters.AddWithValue("@capacity", phone.StorageCapacity);
                    edit.Parameters.AddWithValue("@stock", phone.Stock);
                    edit.Parameters.AddWithValue("@price", phone.Price);
                    edit.Parameters.AddWithValue("@image", phone.Image);
                    edit.Parameters.AddWithValue("@id", phone.Id);

                    edit.ExecuteNonQuery();
                }

                using (SqlCommand edit = new SqlCommand(sqlPhoneEdit, conn))
                {
                    edit.Parameters.AddWithValue("@manufacturer", phone.Manufacturer);
                    edit.Parameters.AddWithValue("@batteryCapacity", phone.BatteryCapacitymAh);
                    edit.Parameters.AddWithValue("@cameraQuality", phone.CameraQualityMP);
                    edit.Parameters.AddWithValue("@simCardType", phone.SIMCardType);

                    string connectivityString = string.Join(",", phone.Connectivity);
                    edit.Parameters.AddWithValue("@connectivity", connectivityString);
                    edit.Parameters.AddWithValue("@features", phone.BiometricFeatures);
                    edit.Parameters.AddWithValue("@id", phone.Id);

                    edit.ExecuteNonQuery();
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

        public void Remove(Phone phone)
        {
            string sqlDelete = "DELETE FROM Electronics WHERE ID = @id";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                using (SqlCommand delete = new SqlCommand(sqlDelete, conn))
                {
                    delete.Parameters.AddWithValue("@id",phone.Id);
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
