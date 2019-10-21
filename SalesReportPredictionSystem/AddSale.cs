using System;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace SalesReportPredictionSystem
{
    public class AddSale : Form, IHasSubmit
    {
        private ProductSearch _product;
        private Button _add;
        private Button _cancel;

        public bool CanSubmit { set { _add.Enabled = value; } }

        public AddSale()
        {
            this.Text = "Add Sale";
            this.Size = new Size(480, 320);
            this.StartPosition = FormStartPosition.CenterScreen;

            _product = new ProductSearch(this);
            _product.Location = new Point(10, 10);

            _add = new Button();
            _add.Location = new Point(300, 260);
            _add.AutoSize = true;
            _add.Text = "Add";
            _add.Click += addSaleClick;
            _add.Enabled = false;

            _cancel = new Button();
            _cancel.Location = new Point(380, 260);
            _cancel.AutoSize = true;
            _cancel.Text = "Cancel";
            _cancel.Click += (s, e) => this.Close();

            this.Controls.Add(_product);
            this.Controls.Add(_add);
            this.Controls.Add(_cancel);
        }

        private void addSaleClick(object sender, EventArgs e)
        {
            int productId = _product.SelectedID;
            if (productId < 0)
                return;

            string dateStr = DateTime.Now.ToString(Database.DateFormat);

            string queryStr =
                "INSERT INTO current_sales (product_id, sale_datetime) " +
                "VALUES (" + productId + ", '" + dateStr + "');"
            ;

            MySqlCommand cmd = new MySqlCommand(queryStr, Database.handle);
            cmd.ExecuteNonQuery();

            this.Close();
        }
    }
}
