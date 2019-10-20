using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SalesReportPredictionSystem
{
    static class Database
    {
        public static MySqlConnection handle;
        public static bool Connected { get { return handle != null; } }

        public static string ServerName = "localhost";
        public static string DBName = "big_pharma";
        public static string UserID = "test";
        public static string Password = null;
        public static bool UsePwd = false;

        private static string ConnString
        {
            get {
                string str = "server=" + ServerName +
                             ";database=" + DBName +
                             ";uid=" + UserID;
                if (UsePwd)
                    str += ";password=" + Password;

                return str;
            }
        }

        public static DialogResult ShowError(MySqlException ex)
        {
            string suggestionMsg =
                "Make sure that you have a MySQL session runnning on '" + ServerName +
                "' and that the connection details are correct.\n\n" +
                "Retry with different settings?";

            return MessageBox.Show(
                "Exception Message: \n\n" + ex.Message + "\n\n" + suggestionMsg,
                "Error Connecting to the Database",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error
            );
        }

        public static void Init()
        {
            handle = new MySqlConnection(ConnString);
            handle.Open();
        }
    }
}