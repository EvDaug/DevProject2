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
        string strName, strBrand, strCategory, strSold;
        public MainForm row;

        public EditForm(int i, string name, string brand, string category, string sold )
        {
            // product id of row being edited used to update data base
            id = i;
            strName = name;
            strBrand = brand;
            strCategory = category;
            strSold = sold;
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            tbName.Text = strName;
            tbBrand.Text = strBrand;
            tbCategory.Text = strCategory;
            tbSold.Text = strSold;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateRow();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }


        // updates a table row with the newly entered data
        private void UpdateRow()
        {
            // checks for no empty textboxes
            if (!(tbName.Text == "") && !(tbBrand.Text == "") && !(tbCategory.Text == "") && !(tbSold.Text == "")) {
                // TODO:
                // this query needs to be updated for new database
                /*
                // this query updates the database with text input
                String query = "UPDATE table1 SET id=" + tbID.Text + ",ProductName=\'" + tbName.Text + "\',brand=\'" + tbBrand.Text + "\',stockRemaining=" + tbStock.Text + ", stockSold=" + tbSold.Text + " WHERE id="+id;
                MySqlCommand cmd = new MySqlCommand(query, Database.handle);
                cmd.ExecuteNonQuery();
                this.Close();
                */
            } else
            {
                string caption = "Error";
                string message = "Some of the text fields have been left empty.";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }

        // deletes the selected row from the database
        private void DeleteRow()
        {
            string caption = "Warning";
            string message = "Do you want to delete this item? You cannot undo this action.";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // TODO: 
                // query to delete selected row
                this.Close();
            }
        }
    }
}
