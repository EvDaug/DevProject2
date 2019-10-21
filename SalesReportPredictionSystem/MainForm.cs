using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CsvHelper;

namespace SalesReportPredictionSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeTables();
            InitializeGrid();
            ReloadGrid();
        }
        /*
        private void Form1_Load(object sender, EventArgs e)
        {
            // fix window size
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        */
        private void InitializeTables()
        {
            /*
            _salesTbl = new DataTable();
            // initialise _salesTbl
            this.dgvStock.DataSource = _salesTbl;
            */
        }

        // sets up the gridviews headers and buttons
        private void InitializeGrid()
        {
            // column header text
            dgvStock.ColumnCount = 6;

            dgvStock.Columns[0].HeaderText = "Order ID";
            dgvStock.Columns[1].HeaderText = "Item ID";
            dgvStock.Columns[2].HeaderText = "Item Name";
            dgvStock.Columns[3].HeaderText = "Brand";
            dgvStock.Columns[4].HeaderText = "Category";
            dgvStock.Columns[5].HeaderText = "Time Sold";


            // create edit buttons for table column
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit Item";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndex = 6;
            if (dgvStock.Columns["Edit Item"] == null)
            {
                dgvStock.Columns.Insert(columnIndex, editButtonColumn);
            }
            dgvStock.CellClick += dgvStock_CellClick;
        }

        private void ReloadDB()
        {
            if (Database.Connected)
                return;

            bool retry = false;
            try
            {
                Database.Init();
            }
            catch (MySqlException ex)
            {
                Database.handle = null;
                var result = Database.ShowError(ex);

                if (result == DialogResult.Yes)
                {
                    var prompt = new ConnectionForm();
                    prompt.ShowDialog(this);
                    retry = prompt.DialogResult == DialogResult.Retry;
                }
            }

            if (retry)
                ReloadDB();

            if (!Database.Connected)
                Environment.Exit(0); // Exits the program
        }

        // loads data into the gridview
        private void ReloadGrid(string queryStr)
        {
            // clears table
            dgvStock.Rows.Clear();

            // populate table data
            // this query updates the gui with everything in the data base
            // may be more simple way to do this with datagridview??

            ReloadDB();
            MySqlCommand cmd = new MySqlCommand(queryStr, Database.handle);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string[] row = new string[reader.FieldCount];
                for (int i = 0; i < row.Length; i++)
                    row[i] = reader[i].ToString();

                this.dgvStock.Rows.Add(row);

            }
            reader.Close();            
        }

        private void ReloadGrid()
        {
            ReloadGrid("SELECT " + Database.DefaultColumns + " FROM current_sales");
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReloadDB();

            // Show a 'Save File' dialog so that the user can pick a folder & filename
            var saveDlg = new SaveFileDialog();
            saveDlg.Filter = "CSV file (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveDlg.ShowDialog() != DialogResult.OK)
                return;

            var cmd = new MySqlCommand("SELECT * FROM current_sales", Database.handle);
            var reader = cmd.ExecuteReader();

            // Use that filename for CSV output directly from the MySql reader
            using (var w = new StreamWriter(saveDlg.FileName))
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

        // add row to database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm();
            form.ShowDialog();
        }

        // reloads the data ito the gridview
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReloadGrid();
        }

        // search function
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = tbSearch.Text;
            bool found = false; 

            dgvStock.ClearSelection();
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;    
            
            if(searchValue!=null)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvStock.Rows)
                    {
                        if ((row.Cells[2].Value.ToString().Equals(searchValue))
                            ||(row.Cells[3].Value.ToString().Equals(searchValue))
                            ||(row.Cells[4].Value.ToString().Equals(searchValue))
                            )
                        {
                            row.Selected = true;
                            found = true;
                        }
                    }
                }
                catch
                {
                    
                }

                // displays error message when nothing found
                if (found == false)
                {
                    string message = "Could not find " + searchValue + ".";
                    string caption = "Error";
                    MessageBox.Show(message, caption);
                }
             }
        }

        // edit button
        // gets data from row and loads edit form
        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderId;
            string orderProduct, orderBrand, orderCategory, orderDate;

            if (e.ColumnIndex == dgvStock.Columns["Edit Item"].Index)
            {           
                //find the prodcut id of current row
                orderId = int.Parse(this.dgvStock.Rows[e.RowIndex].Cells[0].Value.ToString());
                orderProduct = dgvStock.Rows[e.RowIndex].Cells[2].Value.ToString();
                orderBrand = dgvStock.Rows[e.RowIndex].Cells[3].Value.ToString();
                orderCategory = dgvStock.Rows[e.RowIndex].Cells[4].Value.ToString();
                orderDate = dgvStock.Rows[e.RowIndex].Cells[5].Value.ToString();

                EditForm form = new EditForm(orderId, orderProduct, orderBrand, orderCategory, DateTime.Parse(orderDate));
                form.ShowDialog();
            }
        }

        // calls for new query when date value has canged
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshSales();
        }

        private void rbMonthly_CheckedChanged(object sender, EventArgs e)
        {
            RefreshSales();
        }

        private void rbWeekly_CheckedChanged(object sender, EventArgs e)
        {
            RefreshSales();
        }

        // Dumb but whatever
        private readonly string[] Months =
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

        private int SundayGone = 1;

        // if checkbox or datepicker changed, updates table with new query
        private void RefreshSales()
        {
            DateTime firstDate = new DateTime();
            DateTime lastDate = new DateTime();
            if (rbMonthly.Checked)
            {
                firstDate = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, 1);
                int lastDay = DateTime.DaysInMonth(firstDate.Year, firstDate.Month);
                lastDate = new DateTime(firstDate.Year, firstDate.Month, lastDay);
            }
            else
            {
                // set the date to be the Sunday just gone
                var timeDiff = new TimeSpan((int)dtpDate.Value.DayOfWeek, 0, 0, 0);
                firstDate = dtpDate.Value - timeDiff;
                this.SundayGone = firstDate.Day;
                lastDate = firstDate + new TimeSpan(6, 0, 0, 0); // 7 days in a week minus 1
            }

            string firstDateStr = firstDate.ToString("yyyy-MM-dd");
            string lastDateStr = lastDate.ToString("yyyy-MM-dd");

            //MessageBox.Show("First = " + firstDateStr + ", Last = " + lastDateStr);

            string queryStr = "SELECT " + Database.DefaultColumns + " FROM current_sales " +
                              "WHERE sale_datetime >= '" + firstDateStr + "' AND sale_datetime <= '" + lastDateStr + "'";

            ReloadGrid(queryStr);            

            // check if checkbox is selected
            if (rbMonthly.Checked)
            {
                // show monthly sales
                lblDate.Text = "Sales for " + this.Months[dtpDate.Value.Month];
            }
            else
            {
                // show weekly sales
                lblDate.Text = "Sales of week: " + this.SundayGone + "/" + this.Months[dtpDate.Value.Month];
            }
        }
    }
}
