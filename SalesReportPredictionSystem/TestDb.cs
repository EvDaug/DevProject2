using System;
using MySql.Data.MySqlClient;

namespace SqlTest
{
    class Program
    {
        public static MySqlConnection Connect()
        {
            var conn = new MySqlConnection(@"server=localhost;database=sqltest;uid=root");
            return conn;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Opening DB...");

            var conn = Connect();
            try
            {
                conn.Open();
                Console.WriteLine("Connection successful!");
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure :(\n{0}", ex.Message);
            }

            Console.ReadKey(true);
        }
    }
}