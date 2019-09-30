using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace SalesReportPredictionSystem
{
    public partial class EditForm : Form
    {
        public int id, index1;
       public MainForm row;
        public EditForm(int i)
        {
            //product id of row being edited used to update data base
            id = i;
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //this query updates the database with text input
            String query = "UPDATE table1 SET id=" + tbID.Text + ",ProductName=\'" + tbName.Text + "\',brand=\'" + tbBrand.Text + "\',stockRemaining=" + tbStock.Text + ", stockSold=" + tbSold.Text + " WHERE id="+id;
            MySqlCommand cmd = new MySqlCommand(query, dbconnect.handle);
            cmd.ExecuteNonQuery();
            this.Hide();
            //
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            //MainForm form = new MainForm();
            //form.ShowDialog();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
