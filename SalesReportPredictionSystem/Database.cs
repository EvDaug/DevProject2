using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SalesReportPredictionSystem
{
    enum ErrorMsgs
    {
        TRY_OPENING_MYSQL
    }

    static class Database
    {
        private static string[] errMsgs =
        {
            "Make sure that you have a MySQL session runnning with a database named 'newdb'."
        };

        public static MySqlConnection handle;
        public static bool Connected { get { return handle != null; } }

        private static void ShowError(string exMsg, ErrorMsgs errIdx)
        {
            MessageBox.Show(
                "Exception Message: \n\n" + exMsg + "\n\n" + errMsgs[(int)errIdx],
                "Error Connecting to the Database",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

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
                handle = null;
                ShowError(ex.Message, ErrorMsgs.TRY_OPENING_MYSQL);
            }
        }
    }
}