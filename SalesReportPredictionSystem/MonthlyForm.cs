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
    public partial class MonthlyForm : Form
    {
        public MonthlyForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form = new MainForm();
            form.ShowDialog();
        }
    }
}