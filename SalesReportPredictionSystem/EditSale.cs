using System;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace SalesReportPredictionSystem
{
    public class EditSale : Form, IHasSubmit
    {
        public bool CanSubmit { set { } }

        private int _orderNo;

        private Label _oldLbl;
        private TextBox _oldNameBox;
        private TextBox _oldDateBox;
        private ProductSearch _product;
        private Label _newLbl;
        private DateTimePicker _datePicker;
        private Button _delete;
        private Button _edit;
        private Button _cancel;

        public EditSale(int orderNo)
        {
            _orderNo = orderNo;

            _oldLbl = new Label();
            _oldNameBox = new TextBox();
            _oldDateBox = new TextBox();
            _product = new ProductSearch(this, 410);
            _newLbl = new Label();
            _datePicker = new DateTimePicker();
            _delete = new Button();
            _edit = new Button();
            _cancel = new Button();

            int productId = RetrieveOldSale();

            this.SuspendLayout();

            this.Text = "Edit Sale No. " + orderNo;
            this.Size = new Size(480, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            _oldLbl.Location = new Point(10, 12);
            _oldLbl.Text = "Old:";
            _oldLbl.AutoSize = true;

            _oldNameBox.Location = new Point(50, 10);
            _oldNameBox.Size = new Size(200, 30);
            _oldNameBox.ReadOnly = true;

            _oldDateBox.Location = new Point(260, 10);
            _oldDateBox.Size = new Size(200, 30);
            _oldDateBox.ReadOnly = true;

            _product.Location = new Point(50, 40);

            _newLbl.Location = new Point(10, 257);
            _newLbl.AutoSize = true;
            _newLbl.Text = "New:";

            _datePicker.Location = new Point(260, 255);
            _datePicker.Size = new Size(200, 30);
            _datePicker.Format = DateTimePickerFormat.Custom;
            _datePicker.CustomFormat = Database.DateFormat + " tt";

            _delete.Location = new Point(10, 290);
            _delete.Text = "Delete";
            _delete.Click += deleteButtonClick;

            _edit.Location = new Point(300, 290);
            _edit.Text = "Edit";
            _edit.Click += editButtonClick;

            _cancel.Location = new Point(380, 290);
            _cancel.Text = "Cancel";
            _cancel.Click += (s, e) => this.Close();

            this.Controls.Add(_oldLbl);
            this.Controls.Add(_oldNameBox);
            this.Controls.Add(_oldDateBox);
            this.Controls.Add(_newLbl);
            this.Controls.Add(_datePicker);
            this.Controls.Add(_delete);
            this.Controls.Add(_edit);
            this.Controls.Add(_cancel);
            this.Controls.Add(_product);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private int RetrieveOldSale()
        {
            var queryStr =
                "SELECT products.product_id,products.item_name,sale_datetime FROM current_sales " +
                "INNER JOIN products ON current_sales.product_id=products.product_id " +
                "WHERE order_no=" + _orderNo
            ;

            var cmd = new MySqlCommand(queryStr, Database.handle);
            var reader = cmd.ExecuteReader();

            int productId = -1;
            string itemName = "";
            string dateStr = "";
            while (reader.Read())
            {
                productId = reader.GetInt32(0);
                itemName = reader.GetString(1);
                dateStr = reader.GetString(2);
                break;
            }
            reader.Close();

            if (productId < 0)
            {
                MessageBox.Show("Failed to look up sale");
                this.Close();
                return productId;
            }

            _oldNameBox.Text = itemName;
            _oldDateBox.Text = dateStr;
            _datePicker.Value = DateTime.Parse(dateStr);

            return productId;
        }

        private void deleteButtonClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure that you want to delete this transaction?", "Delete Sale", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;

            var queryStr = "DELETE FROM current_sales WHERE order_no=" + _orderNo;
            var cmd = new MySqlCommand(queryStr, Database.handle);
            cmd.ExecuteNonQuery();

            this.Close();
        }

        private void editButtonClick(object sender, EventArgs e)
        {
            var queryStr =
                "UPDATE current_sales SET product_id=" + _product.SelectedID +
                ", sale_datetime='" + _datePicker.Value.ToString(Database.DateFormat) + "' " +
                "WHERE order_no=" + _orderNo
            ;
            var cmd = new MySqlCommand(queryStr, Database.handle);
            cmd.ExecuteNonQuery();

            this.Close();
        }
    }
}
