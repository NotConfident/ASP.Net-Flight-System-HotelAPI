using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using web2020apr_p01_t3.Models;

namespace web2020apr_p01_t3.DAL
{
    public class CustomerDAL
    {
        private SqlConnection conn;
        private IConfiguration configuration { get; set; }

        public CustomerDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configuration = builder.Build();
            string connString = configuration.GetConnectionString("Air_Flights_DB");

            conn = new SqlConnection(connString);
        }

        public int? createCustomer(CustomerModel customer)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"insert into Customer([CustomerName], [Nationality], [BirthDate], [TelNo], [EmailAddr])
                                OUTPUT INSERTED.CustomerID values(@name, @nationality, @DOB, @telNo, @email)";
            cmd.Parameters.AddWithValue("@name", customer.Name);
            cmd.Parameters.AddWithValue("@nationality", String.IsNullOrEmpty(customer.Nationality) ? string.Empty : "NULL");
            if (!String.IsNullOrEmpty(customer.cDOB.ToString()))
            {
                cmd.Parameters.AddWithValue("@DOB", customer.cDOB);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@telNo", String.IsNullOrEmpty(customer.Nationality) ? string.Empty : "NULL");
            cmd.Parameters.AddWithValue("@email", customer.cEmail);
            conn.Open();
            customer.id = (int)cmd.ExecuteScalar();
            conn.Close();
            return customer.id;
        }

        public bool checkEmail(string email)
        {
            int? result = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"select count(*) from Customer where EmailAddr = @email";
            cmd.Parameters.AddWithValue("@email", email);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = !reader.IsDBNull(0) ? reader.GetInt32(0) : (int?)null;
                }
            }

            conn.Close();
            if (result.Value == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public int getID(string email, string password)
        {
            int? id = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"select CustomerID from Customer where EmailAddr = @cEmail and Password = @Password";
            cmd.Parameters.AddWithValue("@cEmail", email);
            cmd.Parameters.AddWithValue("@Password", password);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = !reader.IsDBNull(0) ? (int?)reader.GetInt32(0) : null;
                }
            }
            conn.Close();
            return id.Value;

        }


        public CustomerModel getCustomer(int? id)
        {

            CustomerModel customer = new CustomerModel();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"select * from Customer where CustomerID = @cID";
            cmd.Parameters.AddWithValue("@cID", id.Value); //get from loging in ID 
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    customer.id = id;
                    customer.Name = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                    customer.Nationality = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                    customer.cDOB = !reader.IsDBNull(3) ? reader.GetDateTime(3) : (DateTime?)null;
                    customer.cTeleNo = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                    customer.cEmail = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                    customer.Password = !reader.IsDBNull(6) ? reader.GetString(6) : null;
                }
            }

            reader.Close();
            conn.Close();
            return customer;

        }

        public int update(CustomerModel customer)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"update [Customer] 
                                set Password = @newPW
                                output inserted.CustomerID
                                where CustomerID = @cID";
            cmd.Parameters.AddWithValue("@newPW", customer.Password);
            cmd.Parameters.AddWithValue("@cID", customer.id);
            conn.Open();
            int update = cmd.ExecuteNonQuery();
            conn.Close();
            return customer.id.Value;
        }
    }
}
