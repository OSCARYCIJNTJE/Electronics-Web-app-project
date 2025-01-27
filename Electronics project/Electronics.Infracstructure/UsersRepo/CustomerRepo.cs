using Electronics.Logic.DomainClasses.CustomExceptions;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Security;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.InterfaceServicesFolder;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Infracstructure.UsersRepo
{
    public class CustomerRepo : ICustomer
    {
        private readonly DatabaseCon con = new DatabaseCon();

        public void RegisterCustomer(Customer customer)
        {
            string sqlAdd = "INSERT INTO [User] (FirstName, LastName, Email, Username, Password)VALUES(@fName, @lName, @email, @username, @password); SELECT SCOPE_IDENTITY();";
            string sqlCustomerAdd = "INSERT INTO Customer(Id, Country, PostalCode, CardInfo)VALUES(@id, @country, @postalCode, @cardInfo)";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                int id = 0;
                using (SqlCommand add = new SqlCommand(sqlAdd, conn))
                {
                    add.Parameters.AddWithValue("@fName", customer.FirstName);
                    add.Parameters.AddWithValue("@lName", customer.LastName);
                    add.Parameters.AddWithValue("@email", customer.Email);
                    add.Parameters.AddWithValue("@username", customer.UserName);
                    add.Parameters.AddWithValue("@password", PasswordHasher.HashPassword(customer.Password));
                    id = Convert.ToInt32(add.ExecuteScalar());
                }

                using (SqlCommand customerAdd = new SqlCommand(sqlCustomerAdd, conn))
                {
                    customerAdd.Parameters.AddWithValue("@id", id);
                    customerAdd.Parameters.AddWithValue("@country", customer.Country);
                    customerAdd.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                    customerAdd.Parameters.AddWithValue("@cardInfo", customer.CardInfo);

                    customerAdd.ExecuteNonQuery();
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

        public Customer GetCustomerById(int id)
        {
            string sqlComputerGet = "SELECT u.*, c.Country, c.PostalCode, c.CardInfo FROM [User] as u INNER JOIN Customer as c ON u.Id = c.Id WHERE u.Id = @id";
            SqlConnection conn = con.Connection();
            Customer customer = null;
            try
            {
                conn.Open();

                using (SqlCommand customerGet = new SqlCommand(sqlComputerGet, conn))
                {
                    customerGet.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = customerGet.ExecuteReader();
                    while (reader.Read())
                    {
                        customer = GetCustomerInfos(reader);
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
            return customer;
        }

        private Customer GetCustomerInfos(SqlDataReader reader)
        {
            Customer customer = null;

            int ID = Convert.ToInt32(reader["Id"]);
            string? fName = Convert.ToString(reader["FirstName"]);
            string? lName = Convert.ToString(reader["LastName"]);
            string? email = Convert.ToString(reader["Email"]);
            string? username = Convert.ToString(reader["Username"]);
            string? password = Convert.ToString(reader["Password"]);
            string? country = Convert.ToString(reader["Country"]);
            string? postalCode = Convert.ToString(reader["PostalCode"]);
            string? cardInfo = Convert.ToString(reader["CardInfo"]);

            customer = new Customer(ID, email, username, password)
            {
                FirstName = fName,
                LastName = lName,
                Country = country,
                PostalCode = postalCode,
                CardInfo = cardInfo
            };
            return customer;
        }

        public void EditCustomer(Customer customer)
        {
            string sqlEdit = "UPDATE [User] SET FirstName = @fName, LastName = @lName, Email = @email, Username = @username WHERE Id = @userId";
            string sqlCustomerEdit = "UPDATE Customer SET Country = @country, PostalCode = @postalCode, CardInfo = @cardInfo WHERE Id = @userId";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                using (SqlCommand add = new SqlCommand(sqlEdit, conn))
                {
                    add.Parameters.AddWithValue("@userId", customer.Id);
                    add.Parameters.AddWithValue("@fName", customer.FirstName);
                    add.Parameters.AddWithValue("@lName", customer.LastName);
                    add.Parameters.AddWithValue("@email", customer.Email);
                    add.Parameters.AddWithValue("@username", customer.UserName);
                }

                using (SqlCommand customerEdit = new SqlCommand(sqlCustomerEdit, conn))
                {
                    customerEdit.Parameters.AddWithValue("@userId", customer.Id);
                    customerEdit.Parameters.AddWithValue("@country", customer.Country);
                    customerEdit.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                    customerEdit.Parameters.AddWithValue("@cardInfo", customer.CardInfo);

                    customerEdit.ExecuteNonQuery();
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

        public void DeleteCustomer(Customer customer)
        {
            string sqlDelete = "DELETE FROM Customer WHERE Id = @id";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                int id = 0;
                using (SqlCommand delete = new SqlCommand(sqlDelete, conn))
                {
                    delete.Parameters.AddWithValue("@id", customer.Id);
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

        public Customer GetCustomerByUserNameAndPassword(string username, string password)
        {
            string sqlEmployeeGet = "SELECT u.*, c.Country, c.PostalCode, c.CardInfo FROM [User] as u INNER JOIN Customer as c ON u.Id = c.Id WHERE u.Username = @username";
            SqlConnection conn = con.Connection();
            Customer customer = null;
            try
            {
                conn.Open();

                using (SqlCommand customerGet = new SqlCommand(sqlEmployeeGet, conn))
                {
                    customerGet.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = customerGet.ExecuteReader();
                    while (reader.Read())
                    {
                        customer = GetCustomerInfos(reader);
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
            if (customer != null && PasswordHasher.VerifyPassword(password, customer.Password))
            {
                return customer;
            }
            return customer;
        }

        public void SaveFavorites(Customer customer)
        {
            string sqlAddFavorites = "INSERT INTO Favorite(FirstName, LastName, Email, Username, Password)VALUES(@fName, @lName, @email, @username, @password); SELECT SCOPE_IDENTITY();";
            string sqlCustomerAdd = "INSERT INTO Customer(Id, Country, PostalCode, CardInfo)VALUES(@id, @country, @postalCode, @cardInfo)";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                int id = 0;
                using (SqlCommand add = new SqlCommand(sqlAddFavorites, conn))
                {
                    add.Parameters.AddWithValue("@fName", customer.FirstName);
                    add.Parameters.AddWithValue("@lName", customer.LastName);
                    add.Parameters.AddWithValue("@email", customer.Email);
                    add.Parameters.AddWithValue("@username", customer.UserName);
                    add.Parameters.AddWithValue("@password", PasswordHasher.HashPassword(customer.Password));
                    id = Convert.ToInt32(add.ExecuteScalar());
                }

                using (SqlCommand customerAdd = new SqlCommand(sqlCustomerAdd, conn))
                {
                    customerAdd.Parameters.AddWithValue("@id", id);
                    customerAdd.Parameters.AddWithValue("@country", customer.Country);
                    customerAdd.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                    customerAdd.Parameters.AddWithValue("@cardInfo", customer.CardInfo);

                    customerAdd.ExecuteNonQuery();
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

        public List<Electronic> GetFavorites(Customer customer)
        {
            return new List<Electronic>();
        }

        /*public List<Electronic> GetFavorites(Customer customer)
        {
            string sqlAdd = "INSERT INTO Users(FirstName, LastName, Email, Username, Password)VALUES(@fName, @lName, @email, @username, @password); SELECT SCOPE_IDENTITY();";
            string sqlCustomerAdd = "INSERT INTO Customer(Id, Country, PostalCode, CardInfo)VALUES(@id, @country, @postalCode, @cardInfo)";
            SqlConnection conn = con.Connection();
            try
            {
                conn.Open();
                int id = 0;
                using (SqlCommand add = new SqlCommand(sqlAdd, conn))
                {
                    add.Parameters.AddWithValue("@fName", customer.FirstName);
                    add.Parameters.AddWithValue("@lName", customer.LastName);
                    add.Parameters.AddWithValue("@email", customer.Email);
                    add.Parameters.AddWithValue("@username", customer.UserName);
                    add.Parameters.AddWithValue("@password", PasswordHasher.HashPassword(customer.Password));
                    id = Convert.ToInt32(add.ExecuteScalar());
                }

                using (SqlCommand customerAdd = new SqlCommand(sqlCustomerAdd, conn))
                {
                    customerAdd.Parameters.AddWithValue("@id", id);
                    customerAdd.Parameters.AddWithValue("@country", customer.Country);
                    customerAdd.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                    customerAdd.Parameters.AddWithValue("@cardInfo", customer.CardInfo);

                    customerAdd.ExecuteNonQuery();
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
        }*/
    }
}
