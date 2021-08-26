using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace ADO.NET_training
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command;

                command = new SqlCommand("SELECT * FROM master.dbo.sysdatabases", connection);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine(reader.GetName(0));
                    while (reader.Read())
                        Console.WriteLine(reader.GetValue(0));
                }

                try
                {
                    command = new SqlCommand("CREATE DATABASE adonetdb", connection);
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = new SqlCommand("CREATE TABLE Product " +
                    "(maker NVARCHAR(1) NOT NULL," +
                    "model INT PRIMARY KEY NOT NULL, " +
                    "type NVARCHAR(16))", connection);
                await command.ExecuteNonQueryAsync();

                command = new SqlCommand("CREATE TABLE PC " +
                    "(code INT PRIMARY KEY IDENTITY NOT NULL," +
                    "model INT REFERENCES Product(model) NOT NULL," +
                    "speed INT, " +
                    "ram INT, " +
                    "hd FLOAT, " +
                    "cd NVARCHAR(16), " +
                    "price MONEY)", connection);
                await command.ExecuteNonQueryAsync();

                command = new SqlCommand("CREATE TABLE LAPTOP " +
                    "(code INT PRIMARY KEY IDENTITY NOT NULL," +
                    "model INT REFERENCES Product(model) NOT NULL," +
                    "speed INT, " +
                    "ram INT, " +
                    "hd FLOAT, " +
                    "cd NVARCHAR(16), " +
                    "price MONEY," +
                    "screen INT)", connection);
                await command.ExecuteNonQueryAsync();

                command = new SqlCommand("CREATE TABLE LAPTOP " +
                    "(code INT PRIMARY KEY IDENTITY NOT NULL," +
                    "model INT REFERENCES Product(model) NOT NULL," +
                    "color NVARCHAR(1) CHECK (color = 'y' OR color = 'n')" +
                    "type NVARCHAR(16)" +
                    "price MONEY)", connection);
                await command.ExecuteNonQueryAsync();
            }
            Console.Read();
        }
    }
}
