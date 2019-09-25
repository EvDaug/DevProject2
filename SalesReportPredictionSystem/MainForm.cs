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
            lbStock.ClearSelection();
            string searchValue = tbSearch.Text;
            lbStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;      
            if(searchValue!=null)
            {
                try
                {
                    foreach (DataGridViewRow row in lbStock.Rows)
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
            string[] row0 = { "001", "item1", "brand1",
                "3", "5" };
            string[] row1 = { "002", "item2", "brand1",
                "6", "7" };
            string[] row2 = { "003", "item3", "brand3",
                "3", "4" };
            string[] row3 = { "004", "item4", "brand4",
                "2", "3" };
            this.lbStock.Rows.Add(row0);
            this.lbStock.Rows.Add(row1);
            this.lbStock.Rows.Add(row2);
            this.lbStock.Rows.Add(row3);
        }
    }
}
