using MaxiZoo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
namespace MaxiZoo.Persistence
{
    public class EmployeeRepository
    {

        //hente medarbejder ud fra ID
        private readonly string _connectionString;
        public EmployeeRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            _connectionString = config.GetConnectionString("MyDBConnection")
                ?? throw new InvalidOperationException("Connection string not found.");
        }
        public Employee? GetById(int employeeId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = "SELECT EmployeeID, Name, Role FROM Employee WHERE EmployeeID = @EmployeeID";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeID", employeeId);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Employee
                {
                    EmployeeID = (int)reader["EmployeeID"],
                    Name = reader["Name"].ToString() ?? "",
                    Role = (Role)(int)reader["Role"]
                };
            }
            return null;
        }
        //oprette medarbejder
        //fjerne medarbejder
    }
}

