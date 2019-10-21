using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace SalesReportPredictionSystem
{
    public interface IHasSubmit
    {
        bool CanSubmit { set; }
    }

    public class ProductSearch : Panel
    {
        public delegate void SelectDelegate();

        private int _selectedId = -1;
        public int SelectedID { get { return _selectedId; } }

        private IHasSubmit _parent;

        private Label _searchLbl;
        private TextBox _searchBox;
        private DataGridView _gridView;
        private Label _resultLbl;

        private static DataGridViewTextBoxColumn NewColumn(string name)
        {
            var col = new DataGridViewTextBoxColumn();
            col.Name = name;
            return col;
        }

        public ProductSearch(IHasSubmit parent)
        {
            _parent = parent;

            this.Size = new Size(450, 250);

            _searchLbl = new Label();
            _searchLbl.Location = new Point(0, 0);
            _searchLbl.AutoSize = true;
            _searchLbl.Text = "Search: ";

            _searchBox = new TextBox();
            _searchBox.Location = new Point(50, 0);
            _searchBox.Size = new Size(200, 30);
            _searchBox.Text = "";
            _searchBox.TextChanged += (s, e) => Search();

            _gridView = new DataGridView();
            _gridView.Location = new Point(0, 35);
            _gridView.Size = new Size(450, 180);
            _gridView.ReadOnly = true;
            _gridView.AllowUserToAddRows = false;
            _gridView.AllowUserToDeleteRows = false;
            _gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _gridView.Columns.AddRange(
                new DataGridViewColumn[] {
                    NewColumn("ID"),
                    NewColumn("Item"),
                    NewColumn("Brand"),
                    NewColumn("Category")
                }
            );
            _gridView.Columns[0].Width /= 2;
            _gridView.SelectionChanged += selectionChangedHandler;

            _resultLbl = new Label();
            _resultLbl.Location = new Point(2, 220);
            _resultLbl.Size = new Size(400, 30);
            _resultLbl.Text = "";

            this.Controls.Add(_searchLbl);
            this.Controls.Add(_searchBox);
            this.Controls.Add(_gridView);
            this.Controls.Add(_resultLbl);

            Search();
        }

        private void SelectRow()
        {
            var row = this._gridView.SelectedRows[0];
            _resultLbl.Text = row.Cells[1].Value.ToString();
            _selectedId = Convert.ToInt32(row.Cells[0].Value);
            _parent.CanSubmit = true;
        }

        private void Search()
        {
            _canSelect = false;
            _gridView.ClearSelection();
            Utils.ReloadDB();

            string queryStr = "SELECT product_id,item_name,brand_name,category FROM products";

            string token = _searchBox.Text;
            if (token.Length > 0)
            {
                // remove all non-alphanumeric chars
                token = Regex.Replace(token, "[^0-9a-zA-Z ]+", "");
                queryStr += " WHERE item_name LIKE '%" + token + "%'";
            }

            Utils.ReloadGrid(this._gridView, queryStr);
            _canSelect = true;
        }

        private bool _canSelect = true;
        private void selectionChangedHandler(object sender, EventArgs e)
        {
            if (_canSelect && _gridView.SelectedRows.Count > 0)
                SelectRow();
        }
    }
}
