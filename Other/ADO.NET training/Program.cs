using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace ADO.NET_training
{
    class Program
    {
        static bool DoesTableExist(string name, SqlConnection connection)
        {
            string sqlExpression = "SELECT Count(*) FROM sys.tables WHERE name = @name";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.Add(new SqlParameter("@name", name));
            return (Int32)command.ExecuteScalar() != 0;
        }

        static bool DoesDbExist(string name, SqlConnection connection)
        {
            string sqlExpression = "SELECT Count(*) FROM master.dbo.sysdatabases WHERE name = @name";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.Add(new SqlParameter("@name", name));
            return (Int32)command.ExecuteScalar() != 0;
        }

        static bool IsTableEmpty(string name, SqlConnection connection)
        {
            //Есть вопросы к безопасности, но, увы, названия таблиц нельзя передавать в качетсве параметров 
            string sqlExpression = $"USE adonetdb; SELECT Count(*) FROM {name}";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            return (Int32)command.ExecuteScalar() != 0;
        }

        static void TableOutput(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                int colsCount = reader.FieldCount;

                for (int i = 0; i < colsCount; i++)
                    Console.Write($"{reader.GetName(i)}\t");
                Console.WriteLine('\n');
                while (reader.Read())
                    for (int i = 0; i < colsCount; i++)
                    {
                        Console.Write($"{reader.GetValue(i)}\t");
                        if (i + 1 == colsCount)
                            Console.WriteLine('\n');
                    }
            }
        }

        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command;


                Console.WriteLine("Проверка на сущетвование БД");

                if(!DoesDbExist("adonetdb", connection))
                {
                    command = new SqlCommand("CREATE DATABASE adonetdb", connection);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("БД готова к работе");

            }

            connectionString = "Server=(localdb)\\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command;

                if (!DoesTableExist("Product", connection))
                {
                    command = new SqlCommand("CREATE TABLE Product " +
                        "(maker NVARCHAR(1) NOT NULL," +
                        "model INT PRIMARY KEY NOT NULL, " +
                        "type NVARCHAR(16))", connection);
                    command.ExecuteNonQuery();
                }

                if (!DoesTableExist("PC", connection))
                {
                    command = new SqlCommand("CREATE TABLE PC " +
                        "(code INT PRIMARY KEY IDENTITY NOT NULL," +
                        "model INT REFERENCES Product(model) NOT NULL," +
                        "speed INT, " +
                        "ram INT, " +
                        "hd FLOAT, " +
                        "cd NVARCHAR(16), " +
                        "price MONEY)", connection);
                    command.ExecuteNonQuery();
                }

                if (!DoesTableExist("LAPTOP", connection))
                {
                    command = new SqlCommand("CREATE TABLE Laptop " +
                        "(code INT PRIMARY KEY IDENTITY NOT NULL," +
                        "model INT REFERENCES Product(model) NOT NULL," +
                        "speed INT, " +
                        "ram INT, " +
                        "hd FLOAT, " +
                        "price MONEY," +
                        "screen INT)", connection);
                    command.ExecuteNonQuery();
                }

                if (!DoesTableExist("Printer", connection))
                {
                    command = new SqlCommand("CREATE TABLE Printer " +
                        "(code INT PRIMARY KEY IDENTITY NOT NULL," +
                        "model INT REFERENCES Product(model) NOT NULL," +
                        "color NVARCHAR(1)," +
                        "type NVARCHAR(16)," +
                        "price MONEY)", connection);
                    command.ExecuteNonQuery();
                }

                if (!IsTableEmpty("Product", connection))
                {
                    command = new SqlCommand("INSERT INTO Product VALUES" +
                        "('A', 1232, 'PC')," +
                        "('A', 1233, 'PC')," +
                        "('A', 1276, 'Printer')," +
                        "('A', 1298, 'Laptop')," +
                        "('A', 1401, 'Printer')," +
                        "('A', 1408, 'Printer')," +
                        "('A', 1752, 'Laptop')," +

                        "('B', 1121, 'PC')," +
                        "('B', 1750, 'Laptop')," +

                        "('C', 1321, 'Laptop')," +

                        "('D', 1288, 'Printer')," +
                        "('D', 1433, 'Printer')," +

                        "('E', 1260, 'PC')," +
                        "('E', 1434, 'Printer')," +
                        "('E', 2112, 'PC')," +
                        "('E', 2113, 'PC')", connection);
                    command.ExecuteNonQuery();
                }

                if(!IsTableEmpty("PC", connection))
                {
                    command = new SqlCommand("INSERT INTO PC (model, speed, ram, hd, cd, price) VALUES" +
                        "(1232, 500, 64, 5, '12x', 600)," +
                        "(1121, 750, 128, 14, '40x', 850)," +
                        "(1233, 500, 64, 5, '12x', 600)," +
                        "(1121, 600, 128, 14, '40x', 850)," +
                        "(1121, 750, 128, 8, '40x', 850)," +
                        "(1233, 750, 128, 20, '50x', 950)," +
                        "(1232, 500, 32, 10, '12x', 400)," +
                        "(1232, 450, 64, 8, '24x', 350)," +
                        "(1232, 450, 32, 10, '24x', 350)," +
                        "(1260, 500, 32, 10, '12x', 350)," +
                        "(1233, 900, 128, 40, '40x', 980)," +
                        "(1233, 800, 128, 20, '50x', 970)", connection);
                    command.ExecuteNonQuery();
                }

                if(!IsTableEmpty("Laptop", connection))
                {
                    command = new SqlCommand("INSERT INTO Laptop (model, speed, ram, hd, price, screen) VALUES" +
                        "(1298, 350, 32, 4, 700, 11)," +
                        "(1321, 500, 64, 8, 970, 12)," +
                        "(1750, 750, 128, 12, 1200, 14)," +
                        "(1298, 600, 64, 10, 1050, 15)," +
                        "(1752, 750, 128, 10, 1150, 14)," +
                        "(1298, 450, 64, 10, 950, 12)", connection);
                    command.ExecuteNonQuery();
                }

                if(!IsTableEmpty("Printer", connection))
                {
                    command = new SqlCommand("INSERT INTO Printer (model, color, type, price) VALUES" +
                        "(1276, 'n', 'Laser', 400)," +
                        "(1433, 'y', 'Jet', 270)," +
                        "(1434, 'y', 'Jet', 290)," +
                        "(1401, 'n', 'Matrix', 150)," +
                        "(1408, 'n', 'Matrix', 270)," +
                        "(1288, 'n', 'Laser', 400)", connection);
                    command.ExecuteNonQuery();
                }

                SqlDataReader reader;

                //#6
                Console.WriteLine("Для каждого производителя, выпускающего ПК-блокноты c объёмом жесткого диска не менее 10 Гбайт,\n " +
                    "найти скорости таких ПК-блокнотов. Вывод: производитель, скорость.\n");

                command = new SqlCommand("Select DISTINCT Product.maker, Laptop.speed " +
                    "from Product " +
                    "INNER JOIN Laptop ON Product.type = 'laptop' and Laptop.model = Product.model and Laptop.hd >= 10", connection);
                reader = command.ExecuteReader();
                TableOutput(reader);
                reader.Close();

                //#7
                Console.WriteLine("Найдите номера моделей и цены всех имеющихся в продаже\n " +
                    "продуктов (любого типа) производителя B (латинская буква).\n");

                command = new SqlCommand("SELECT Product.model, PC.Price " +
                    "FROM Product INNER JOIN PC ON Product.model = PC.model WHERE Product.maker = 'B' " +
                    "UNION " +
                    "SELECT Product.model, Laptop.price " +
                    "FROM Product INNER JOIN Laptop ON Product.model=Laptop.model WHERE Product.maker='B' " +
                    "UNION " +
                    "SELECT Product.model, Printer.price " +
                    "FROM Product INNER JOIN Printer ON Product.model=Printer.model WHERE Product.maker='B' ", connection);
                reader = command.ExecuteReader();
                TableOutput(reader);
                reader.Close();

                //#8
                Console.WriteLine("Найдите производителя, выпускающего ПК, но не ПК-блокноты.\n");

                command = new SqlCommand("select distinct maker from product " +
                    "where type in ('pc') " +
                    "except " +
                    "select distinct maker from product " +
                    "where type in ('laptop')", connection);
                reader = command.ExecuteReader();
                TableOutput(reader);
                reader.Close();

                //#9
                Console.WriteLine("Найдите производителей ПК с процессором не менее 450 Мгц.\n" +
                    "Вывести: Maker");

                command = new SqlCommand("select distinct product.maker from product " +
                    "join pc on product.model = pc.model " +
                    "where pc.speed >= 450", connection);
                reader = command.ExecuteReader();
                TableOutput(reader);
                reader.Close();

                //#10
                Console.WriteLine("Найдите модели принтеров, имеющих самую высокую цену. Вывести: model, price\n");

                command = new SqlCommand("Select model, price from printer " +
                    "where price = (select max(price) from printer)", connection);
                reader = command.ExecuteReader();
                TableOutput(reader);
                reader.Close();

                //#17
                Console.WriteLine("Найдите модели ПК-блокнотов, скорость которых меньше скорости\n" +
                    "каждого из ПК.\n" +
                    "Вывести: type, model, speed\n");

                command = new SqlCommand("Select distinct p.type, l.model, l.speed from laptop as l " +
                    "join product as p on p.model = l.model " +
                    "where speed < (select min(speed) from pc)", connection);
                reader = command.ExecuteReader();
                TableOutput(reader);
                reader.Close();

                //#24
                Console.WriteLine("Перечислите номера моделей любых типов, имеющих самую\n" +
                    "высокую цену по всей имеющейся в базе данных продукции.\n");

                command = new SqlCommand("SELECT model " +
                    "FROM ( " +
                    " SELECT model, price " +
                    " FROM pc " +
                    " UNION " +
                    " SELECT model, price " +
                    " FROM Laptop " +
                    " UNION " +
                    " SELECT model, price" +
                    " FROM Printer" +
                    ") t1 " +
                    "where price = ( " +
                    "select max(price) from ( " +
                    "select price from pc " +
                    "union " +
                    "select price from laptop " +
                    "union " +
                    "select price from printer " +
                    ")t2 " +
                    ")", connection);
                reader = command.ExecuteReader();
                TableOutput(reader);
                reader.Close();

            }
            Console.Read();
        }
    }
}
