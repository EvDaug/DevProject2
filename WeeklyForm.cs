﻿using System;
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
    public partial class WeeklyForm : Form
    {
        public WeeklyForm()
        {
            InitializeComponent();
            RefreshTable();
        }

        // return to main page
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WeeklyForm_Load(object sender, EventArgs e)
        {
            // fix window size
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        // loads infomation into table
        private void RefreshTable()
        {
            dgvStock.Columns[0].HeaderText = "Item ID";
            dgvStock.Columns[1].HeaderText = "Item Name";
            dgvStock.Columns[2].HeaderText = "Brand";
            dgvStock.Columns[3].HeaderText = "Stock Remaining";
            dgvStock.Columns[4].HeaderText = "Amount Sold";

            

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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}