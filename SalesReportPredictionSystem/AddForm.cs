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
    public partial class AddForm : Form
    {
        public AddForm()
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
            if (!(tbName.Text == "") && !(tbBrand.Text == "") && !(tbCategory.Text == "") && !(tbSold.Text == ""))
            {
                // TODO:
                // add query to add table rows
                this.Close();
            }
            else
            {
                // error messagebox
                string caption = "Error";
                string message = "Some of the text fields have been left empty.";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }
    }
}
