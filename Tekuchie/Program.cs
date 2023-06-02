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
            string connectionString = "server=localhost;port=3306;user=root;password=password;";


            string databaseName = "ErikDataBase";


            string sqlCreateDatabase = $"CREATE DATABASE {databaseName}";


            string sql = @"
                CREATE TABLE users (
                    id INTEGER PRIMARY KEY,
                    name TEXT NOT NULL,
                    email TEXT UNIQUE NOT NULL
                );

                CREATE TABLE posts (
                    id INTEGER PRIMARY KEY,
                    title TEXT NOT NULL,
                    content TEXT NOT NULL,
                    user_id INTEGER NOT NULL,
                    FOREIGN KEY (user_id) REFERENCES users (id)
                );

                CREATE TABLE comments (
                    id INTEGER PRIMARY KEY,
                    content TEXT NOT NULL,
                    user_id INTEGER NOT NULL,
                    post_id INTEGER NOT NULL,
                    FOREIGN KEY (user_id) REFERENCES users (id),
                    FOREIGN KEY (post_id) REFERENCES posts (id)
                );";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
              
                connection.Open();   
                using (MySqlCommand command = new MySqlCommand(sqlCreateDatabase, connection))
                {
                    
                    command.ExecuteNonQuery();
                }

       
                string databaseConnectionString = $"server=localhost;port=3306;user=root;password=your_password;database={databaseName}";

  
                using (MySqlConnection databaseConnection = new MySqlConnection(databaseConnectionString))
                {
              
                    databaseConnection.Open();

                    using (MySqlCommand command = new MySqlCommand(sql, databaseConnection))
                    {
                        command.ExecuteNonQuery();
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}