using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


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
            dgvStock.Columns[5].HeaderText = "Stock Sold";

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
        private void ReloadGrid()
        {
            // clears table
            dgvStock.Rows.Clear();

            // populate table data
            // this query updates the gui with everything in the data base
            // may be more simple way to do this with datagridview??
            ReloadDB();
            MySqlCommand cmd = new MySqlCommand("SELECT id,ProductName,brand,stockRemaining, stockSold FROM table1", Database.handle);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] row0 = {
                    reader.GetInt32(0).ToString(),  reader.GetString(1),  reader.GetString(2).ToString(),
                    reader.GetInt32(3).ToString(),  reader.GetInt32(4).ToString(), "¯\\_(ツ)_/¯"
                };
                this.dgvStock.Rows.Add(row0);
            }
            reader.Close();            
        }
        

        // load monthly form
        private void btnMonthly_Click(object sender, EventArgs e)
        {
            this.Hide();
            MonthlyForm form = new MonthlyForm();
            form.ShowDialog();
            this.Show();
        }

        // load weekly form
        private void btnWeekly_Click(object sender, EventArgs e)
        {
            this.Hide();
            WeeklyForm form = new WeeklyForm();
            form.ShowDialog();
            this.Show();
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
            }
        }
    }
}
