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

        private void Form1_Load(object sender, EventArgs e)
        {
            // fix window size
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

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
            dgvStock.Columns[0].HeaderText = "Item Name";
            dgvStock.Columns[1].HeaderText = "Brand";
            dgvStock.Columns[2].HeaderText = "Category";
            dgvStock.Columns[3].HeaderText = "\"Sale\"";
            dgvStock.Columns[4].HeaderText = "Date";

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
            MySqlCommand cmd = new MySqlCommand("SELECT item_name,brand_name,category,sale,sale_date FROM current_sales", Database.handle);
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
