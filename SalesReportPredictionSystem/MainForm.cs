using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SalesReportPredictionSystem
{
    public partial class MainForm : Form
    {
        private readonly string DefaultColumns = "order_no, products.item_name, products.brand_name, products.category, sale_datetime";

        public MainForm()
        {
            InitializeComponent();
            InitializeGrid();
            ReloadGrid();
        }

        // sets up the gridviews headers and buttons
        private void InitializeGrid()
        {
            // column header text
            dgvStock.ColumnCount = 5;

            dgvStock.Columns[0].HeaderText = "Order ID";
            dgvStock.Columns[1].HeaderText = "Item Name";
            dgvStock.Columns[2].HeaderText = "Brand";
            dgvStock.Columns[3].HeaderText = "Category";
            dgvStock.Columns[4].HeaderText = "Time Sold";

            // create edit buttons for table column
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit Item";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndex = 5;
            if (dgvStock.Columns["Edit Item"] == null)
            {
                dgvStock.Columns.Insert(columnIndex, editButtonColumn);
            }
            dgvStock.CellClick += dgvStock_CellClick;
        }

        private void ReloadGrid()
        {
            Utils.ReloadDB();
            Utils.ReloadGrid(
                this.dgvStock,
                "SELECT " + DefaultColumns + " FROM current_sales " +
                "INNER JOIN products on current_sales.product_id = products.product_id"
            );
        }

        private void btnReportWeekly_Click(object sender, EventArgs e)
        {
            ExportPrediction(DateTime.Now.StartOfWeek(), 25);
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            ExportPrediction(DateTime.Now.StartOfMonth(), 100);
        }

        private void ExportPrediction(DateTime beginDate, int stockCeil)
        {
            Utils.ReloadDB();

            // Show a 'Save File' dialog so that the user can pick a folder & filename
            var saveDlg = new SaveFileDialog();
            saveDlg.Filter = "CSV file (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveDlg.ShowDialog() != DialogResult.OK)
                return;

            string beginDateStr = beginDate.ToString("yyyy-MM-dd");
            string endDateStr = DateTime.Now.ToString("yyyy-MM-dd");

            string queryStr =
                "SELECT " + stockCeil + "-COUNT(*) as stock_left,id,item_name,brand_name,category FROM current_sales " +
                "WHERE sale_datetime >= '" + beginDateStr + "' AND sale_datetime <= '" + endDateStr + "' " +
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

            string queryStr = "SELECT " + DefaultColumns + " FROM current_sales " +
                              "WHERE sale_datetime >= '" + firstDateStr + "' AND sale_datetime <= '" + lastDateStr + "'";

            Utils.ReloadGrid(this.dgvStock, queryStr);
        }

        // add row to database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddSale();
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
            if (e.ColumnIndex != dgvStock.Columns.Count - 1)
                return;

            // get the order number for the current row
            int orderNo = Convert.ToInt32(this.dgvStock.Rows[e.RowIndex].Cells[0].Value);

            EditSale form = new EditSale(orderNo);
            form.ShowDialog();
            ReloadGrid();
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
