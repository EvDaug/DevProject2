using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CsvHelper;

namespace SalesReportPredictionSystem
{
    public static class Utils
    {
        // Dumb but whatever
        public static readonly string[] Months =
        {
            "yeet",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };

        // Start from the 1st day of the month
        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        // Start from the most recent Sunday
        public static DateTime StartOfWeek(this DateTime date)
        {
            return date.AddDays(-(int)date.DayOfWeek);
        }

        public static void ExportResultsToCSV(MySqlCommand cmd, string fName)
        {
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                throw new ArgumentException("No results were found");
            }

            // Use that filename for CSV output directly from the MySql reader
            using (var w = new StreamWriter(fName))
            using (var csv = new CsvWriter(w))
            {
                // Get the first row
                reader.Read();

                // Write out the header record, using the first row
                int nCols = reader.FieldCount;
                for (int i = 0; i < nCols; i++)
                    csv.WriteField(reader.GetName(i));

                csv.NextRecord();

                // iterate over each row
                // we use 'do-while' instead of 'while' since we've already called reader.Read() once
                do
                {
                    // write the actual data for each column
                    for (int i = 0; i < nCols; i++)
                        csv.WriteField(reader[i]);

                    csv.NextRecord();
                }
                while (reader.Read());
            }

            reader.Close();
        }

        // loads data into the gridview
        public static void ReloadGrid(DataGridView gridView, string queryStr)
        {
            // clears table
            gridView.Rows.Clear();

            //ReloadDB(this);
            MySqlCommand cmd = new MySqlCommand(queryStr, Database.handle);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string[] row = new string[reader.FieldCount];
                for (int i = 0; i < row.Length; i++)
                    row[i] = reader[i].ToString();

                gridView.Rows.Add(row);
            }

            reader.Close();
        }
    }
}
