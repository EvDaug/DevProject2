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
            tbDate.Text = strSold;
            
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

            if (!(tbName.Text == "") && !(tbBrand.Text == "") && !(tbCategory.Text == "") && !(tbDate.Text == "")) {

                DateTime dateValue = DateTime.Parse(tbDate.Text);
                string date = dateValue.ToString("yyyy-MM-dd HH:mm");
                String query = "UPDATE current_sales SET item_name=\'" + tbName.Text + "\',brand_name=\'"+ tbBrand.Text + "\',category=\'" + tbCategory.Text + "\', sale_datetime=\'" + date+ "\' WHERE Order_No=" + id;
                MySqlCommand cmd = new MySqlCommand(query, Database.handle);

                cmd.ExecuteNonQuery();
                this.Close();
                
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
                String query = "DELETE FROM current_sales WHERE Order_No=" + id;
                MySqlCommand cmd = new MySqlCommand(query, Database.handle);
                cmd.ExecuteNonQuery();
                this.Close();
            }
        }
    }
}
