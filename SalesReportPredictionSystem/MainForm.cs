using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesReportPredictionSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            PopulateDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // fix window size
            this.MinimumSize = new System.Drawing.Size(this.Width+80, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            this.Hide();
            MonthlyForm form = new MonthlyForm();
            form.ShowDialog();
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            this.Hide();
            WeeklyForm form = new WeeklyForm();
            form.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddForm form = new AddForm();
            form.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvStock.ClearSelection();
            string searchValue = tbSearch.Text;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;      
            if(searchValue!=null)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvStock.Rows)
                    {
                        if ((row.Cells[0].Value.ToString().Equals(searchValue))||(row.Cells[1].Value.ToString().Equals(searchValue))||(row.Cells[2].Value.ToString().Equals(searchValue)))
                        {
                            row.Selected = true;                             
                        }
                    }
                }
                catch
                {
                }           
             }
        }


        private void PopulateDataGridView()
        {
            // column header text
            dgvStock.Columns[0].HeaderText = "Item ID";
            dgvStock.Columns[1].HeaderText = "Item Name";
            dgvStock.Columns[2].HeaderText = "Brand";
            dgvStock.Columns[3].HeaderText = "Stock Remaining";
            dgvStock.Columns[4].HeaderText = "Amount Sold";

            // populate table data
            string[] row0 = { "001", "item1", "brand1",
                "3", "5" };
            string[] row1 = { "002", "item2", "brand1",
                "6", "7" };
            string[] row2 = { "003", "item3", "brand3",
                "3", "4" };
            string[] row3 = { "004", "item4", "brand4",
                "2", "3" };
            this.dgvStock.Rows.Add(row0);
            this.dgvStock.Rows.Add(row1);
            this.dgvStock.Rows.Add(row2);
            this.dgvStock.Rows.Add(row3);

            // create edit buttons for table columns
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

        // when an edit button is clicked
        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvStock.Columns["Edit Item"].Index)
            {
                // TEST
                // sets the date lable to the row clicked
                lblDate.Text = e.RowIndex.ToString();

                //Do something with your button.
                //this.Hide();
                EditForm form = new EditForm();
                form.ShowDialog();
            }
        }
    }
}
