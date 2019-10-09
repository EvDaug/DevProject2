using System;
using MySql.Data.MySqlClient;

namespace SalesReportPredictionSystem
{
    static class dbconnect
    {
        // 
        public static MySqlConnection handle;
       

        public static void Init()
        {
            Console.WriteLine("Opening DB...");

            handle= new MySqlConnection(@"server=localhost;database=newdb;uid=root");
            try
            {
                handle.Open();
                System.Diagnostics.Debug.WriteLine("Connection successful!");

                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure :(\n{0}", ex.Message);
            }

        }
        
    }
}