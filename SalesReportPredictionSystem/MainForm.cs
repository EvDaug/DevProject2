﻿using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SalesReportPredictionSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeGrid();
            ReloadGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // fix window size
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
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

        public void ReloadDB()
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

        private void btnReportWeekly_Click(object sender, EventArgs e)
        {
            ExportPrediciton();
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            ExportPrediciton();
        }

        private void ExportPrediciton()
        {
            ReloadDB();

            // Show a 'Save File' dialog so that the user can pick a folder & filename
            var saveDlg = new SaveFileDialog();
            saveDlg.Filter = "CSV file (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveDlg.ShowDialog() != DialogResult.OK)
                return;

            DateTime current = DateTime.Now;
            DateTime begin;

            int stock;
            if (rbMonthly.Checked)
            {
                begin = current.StartOfMonth();
                stock = 100;
            }
            else
            {
                begin = current.StartOfWeek();
                stock = 25;
            }

            string beginDate = begin.ToString("yyyy-MM-dd");
            string endDate = current.ToString("yyyy-MM-dd");

            string queryStr =
                "SELECT " + stock + "-COUNT(*) as stock_left,id,item_name,brand_name,category FROM current_sales " +
                "WHERE sale_datetime >= '" + beginDate + "' AND sale_datetime <= '" + endDate + "' " +
                "GROUP BY Order_No" // should be 'id', but doesn't work as the DB tables aren't configured appropriately
            ;

            try {
                var cmd = new MySqlCommand(queryStr, Database.handle);
                Utils.ExportResultsToCSV(cmd, saveDlg.FileName);
            }
            catch (Exception ex) {
                MessageBox.Show("Could not export prediction: " + ex.Message);
            }
        }

        // if checkbox or datepicker changed, updates table with new query
        private void RefreshSales()
        {
            DateTime firstDate = new DateTime();
            DateTime lastDate = new DateTime();

            if (rbMonthly.Checked)
            {
                // Start from the 1st day of the month
                firstDate = dtpDate.Value.StartOfMonth();
                int lastDay = DateTime.DaysInMonth(firstDate.Year, firstDate.Month);
                lastDate = new DateTime(firstDate.Year, firstDate.Month, lastDay);

                lblDate.Text = "Monthly Sales for " + Utils.Months[firstDate.Month];
            }
            else
            {
                // Start from the closest Sunday
                firstDate = dtpDate.Value.StartOfWeek();
                lastDate = firstDate.AddDays(6); // 7 days in a week minus 1

                lblDate.Text = "Weekly Sales for " + firstDate.ToString("dd/MM") + " to " + lastDate.ToString("dd/MM");
            }

            string firstDateStr = firstDate.ToString("yyyy-MM-dd");
            string lastDateStr = lastDate.ToString("yyyy-MM-dd");

            string queryStr = "SELECT " + Database.DefaultColumns + " FROM current_sales " +
                              "WHERE sale_datetime >= '" + firstDateStr + "' AND sale_datetime <= '" + lastDateStr + "'";

            ReloadGrid(queryStr);
        }

        // add row to database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm();
            form.ShowDialog();
            ReloadGrid();

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

            if (searchValue != null)
            {
                foreach (DataGridViewRow row in dgvStock.Rows)
                {
                    if ((row.Cells[2].Value.ToString().Equals(searchValue))
                        || (row.Cells[3].Value.ToString().Equals(searchValue))
                        || (row.Cells[4].Value.ToString().Equals(searchValue))
                        )
                    {
                        row.Selected = true;
                        found = true;
                    }
                }

                // displays error message when nothing found
                if (!found)
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
            string orderProduct, orderBrand, orderCategory, orderSold;
            if (e.ColumnIndex == dgvStock.Columns["Edit Item"].Index)
            {
                //find the prodcut id of current row
                int orderId = int.Parse(this.dgvStock.Rows[e.RowIndex].Cells[0].Value.ToString());
                orderProduct = dgvStock.Rows[e.RowIndex].Cells[2].Value.ToString();
                orderBrand = dgvStock.Rows[e.RowIndex].Cells[3].Value.ToString();
                orderCategory = dgvStock.Rows[e.RowIndex].Cells[4].Value.ToString();
                orderSold = dgvStock.Rows[e.RowIndex].Cells[5].Value.ToString();

                EditForm form = new EditForm(orderId, orderProduct, orderBrand, orderCategory, orderSold);
                form.ShowDialog();
                ReloadGrid();

            }
        }
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
    }
}