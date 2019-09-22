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
        private void btnSearch_Click(object sender, EventArgs e){
            lbStock.ClearSelection();
             string searchValue = tbSearch.Text;
             lbStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           
            if(searchValue!=null){
                 try{
                

                foreach (DataGridViewRow row in lbStock.Rows)
               
                {
                    if ((row.Cells[0].Value.ToString().Equals(searchValue))||(row.Cells[1].Value.ToString().Equals(searchValue))||(row.Cells[2].Value.ToString().Equals(searchValue)))
                    {
                        row.Selected = true;
                        
                       
                    }
                }
                }
                catch{
                    //execption message
                    }
               
             }

        }
       

    }
}
