// See https://aka.ms/new-console-template for more information

using MySqlConnector;
using System;
using System.Data.SqlClient;


namespace ConsoleSqlTables
{
    class Program
    {
        static void Main(string[] args)
        {
           string connectionString = "server=localhost;user id=root;password=your_password;database=myDatabase";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

        
            string createCustomersTableQuery = "CREATE TABLE Customers (Id INT PRIMARY KEY, FirstName VARCHAR(50), LastName VARCHAR(50), Email VARCHAR(50))";
            MySqlCommand createCustomersTableCommand = new MySqlCommand(createCustomersTableQuery, connection);
            createCustomersTableCommand.ExecuteNonQuery();

         
            string createOrdersTableQuery = "CREATE TABLE Orders (Id INT PRIMARY KEY, OrderDate DATETIME, CustomerId INT, FOREIGN KEY (CustomerId) REFERENCES Customers(Id))";
            MySqlCommand createOrdersTableCommand = new MySqlCommand(createOrdersTableQuery, connection);
            createOrdersTableCommand.ExecuteNonQuery();

            
            string createOrderItemsTableQuery = "CREATE TABLE OrderItems (Id INT PRIMARY KEY, ProductName VARCHAR(50), Quantity INT, Price DECIMAL(18,2), OrderId INT, FOREIGN KEY (OrderId) REFERENCES Orders(Id))";
            MySqlCommand createOrderItemsTableCommand = new MySqlCommand(createOrderItemsTableQuery, connection);
            createOrderItemsTableCommand.ExecuteNonQuery();

            string insertCustomersQuery = "INSERT INTO Customers (Id, FirstName, LastName, Email) VALUES " +
                "(1, 'John', 'Smith', 'john.smith@example.com'), " +
                "(2, 'Jane', 'Doe', 'jane.doe@example.com')";
            SqlCommand insertCustomersCommand = new SqlCommand(insertCustomersQuery, connection);
            insertCustomersCommand.ExecuteNonQuery();

        
            string insertOrdersQuery = "INSERT INTO Orders (Id, OrderDate, CustomerId) VALUES " +
                "(1, '2023-06-01 10:00:00', 1), " +
                "(2, '2023-06-02 14:30:00', 2)";
            SqlCommand insertOrdersCommand = new SqlCommand(insertOrdersQuery, connection);
            insertOrdersCommand.ExecuteNonQuery();

           
            string insertOrderItemsQuery = "INSERT INTO OrderItems (Id, ProductName, Quantity, Price, OrderId) VALUES " +
                "(1, 'Product 1', 2, 10.00, 1), " +
                "(2, 'Product 2', 1, 15.00, 1), " +
                "(3, 'Product 3', 3, 5.00, 2)";
            SqlCommand insertOrderItemsCommand = new SqlCommand(insertOrderItemsQuery, connection);
            insertOrderItemsCommand.ExecuteNonQuery();

           
            Console.WriteLine("Customers:");
            string selectCustomersQuery = "SELECT * FROM Customers";
            MySqlCommand selectCustomersCommand = new MySqlCommand(selectCustomersQuery, connection);
            MySqlDataReader customersReader = selectCustomersCommand.ExecuteReader();
            while (customersReader.Read())
            {
                Console.WriteLine("{0} {1} {2} {3}", customersReader.GetInt32(0), customersReader.GetString(1), customersReader.GetString(2), customersReader.GetString(3));
            }
            customersReader.Close();

      
            Console.WriteLine("Orders:");
            string selectOrdersQuery = "SELECT * FROM Orders";
            MySqlCommand selectOrdersCommand = new MySqlCommand(selectOrdersQuery, connection);
            MySqlDataReader ordersReader = selectOrdersCommand.ExecuteReader();
            while (ordersReader.Read())
            {
                Console.WriteLine("{0} {1} {2}", ordersReader.GetInt32(0), ordersReader.GetDateTime(1), ordersReader.GetInt32(2));
            }
            ordersReader.Close();

        
            Console.WriteLine("OrderItems:");
            string selectOrderItemsQuery = "SELECT * FROM OrderItems";
            MySqlCommand selectOrderItemsCommand = new MySqlCommand(selectOrderItemsQuery, connection);
            MySqlDataReader orderItemsReader = selectOrderItemsCommand.ExecuteReader();
            while (orderItemsReader.Read())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", orderItemsReader.GetInt32(0), orderItemsReader.GetString(1), orderItemsReader.GetInt32(2), orderItemsReader.GetDecimal(3), orderItemsReader.GetInt32(4));
            }
            orderItemsReader.Close();

            connection.Close();
            Console.ReadLine();
                }
            }
        }
    
