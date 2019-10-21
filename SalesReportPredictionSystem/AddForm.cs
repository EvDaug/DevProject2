using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesReportPredictionSystem
{
    public partial class AddForm : Form
    {
        public AddForm( )
        {

            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
    
        }

        private void AddRow()
        {
            // checks for no empty textboxes
            if (!(tbName.Text == "") && !(tbBrand.Text == "") && !(tbCategory.Text == "") && !(tbId.Text == ""))
            {
                // check if limit reached
                if (tbName.Text.Length < 255 && tbBrand.Text.Length < 255 && tbCategory.Text.Length < 50)
                {
                    // check if input of ID integer
                    if (int.TryParse(tbId.Text, out int n))
                    {
                        // obtains selected date and formats for SQL query
                        DateTime date = dtpAddDate.Value;
                        string formattedDate = date.ToString("yyyy-MM-dd HH-mm-ss");

                        String query = "INSERT INTO current_sales( id, item_name, brand_name, category, sale_datetime) VALUES (\'" + tbId.Text + "\',\'" + tbName.Text + "\',\'" + tbBrand.Text + "\',\'" + tbCategory.Text + "\',\'" + date + "\')";


                        MySqlCommand cmd = new MySqlCommand(query, Database.handle);
                        cmd.ExecuteNonQuery();
                        this.Close();
                    } else
                    {
                        // no integer value has been input
                        string caption = "Error";
                        string message = "ID field must be a number value";
                        DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }
                } else
                {
                    // character limit has been reached
                    string caption = "Error";
                    string message = "Fields Name and Brand have 255 charcter limit. \nField Category has a 50 character limit";
                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
            }
            else
            {
                // some textboxes have been left empty
                string caption = "Error";
                string message = "Some of the text fields have been left empty.";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }
    }
}