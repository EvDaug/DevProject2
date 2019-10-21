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
        int id;
        string strName, strBrand, strCategory;
        DateTime dtDate;

        public EditForm(int i, string name, string brand, string category, DateTime date)
        {
            // product id of row being edited used to update data base
            id = i;
            strName = name;
            strBrand = brand;
            strCategory = category;
            dtDate = date;
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            tbName.Text = strName;
            tbBrand.Text = strBrand;
            tbCategory.Text = strCategory;
            dtpEditDate.Value = dtDate;
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
            if (!(tbName.Text == "") && !(tbBrand.Text == "") && !(tbCategory.Text == ""))
            {
                // check for appropriate field lengths
                if (tbName.Text.Length < 255 && tbBrand.Text.Length < 255 && tbCategory.Text.Length < 50)
                {
                    DateTime dateValue = dtpEditDate.Value;
                    string date = dateValue.ToString("yyyy-MM-dd HH-mm-ss");

                    String query = "UPDATE current_sales SET item_name=\'" + tbName.Text + "\',brand_name=\'" + tbBrand.Text + "\',category=\'" + tbCategory.Text + "\', sale_datetime=\'" + date + "\' WHERE Order_No=" + id;
                    MySqlCommand cmd = new MySqlCommand(query, Database.handle);

                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                else
                {
                    // character limit has been reached
                    string caption = "Error";
                    string message = "Fields Name and Brand have 255 charcter limit. \nField Category has a 50 character limit";
                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
                
            } else
            {
                // some textboxes have been left empty
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
