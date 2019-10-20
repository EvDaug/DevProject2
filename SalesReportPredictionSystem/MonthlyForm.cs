using MySql.Data.MySqlClient;
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
    
    public partial class MonthlyForm : Form
    {
        private String monthid,date;
        private DateTime dt, startOfMonth;
        public MonthlyForm()
        {
            InitializeComponent();
            GetLatestMonth();
            RefreshTable();
        }

        // return to main page
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MonthlyForm_Load(object sender, EventArgs e)
        {
            // fix window size
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        private void GetLatestMonth() {
            //not enough tables  -2->-1
             dt = DateTime.Now.AddMonths(-2);
             startOfMonth = new DateTime(dt.Year, dt.Month, 1);
             date = startOfMonth.ToString("yyyy-MM-dd");

           

        }

        // loads infomation into table
        private void RefreshTable()
        {
            dgvStock.Columns[0].HeaderText = "Item ID";
            dgvStock.Columns[1].HeaderText = "Item Name";
            dgvStock.Columns[2].HeaderText = "Brand";
            dgvStock.Columns[3].HeaderText = "Categorey";
            dgvStock.Columns[4].HeaderText = "Time Sold";
            dbconnect.Init();
            MySqlCommand cmd = new MySqlCommand("SELECT id,item_name,brand_name,category,sale_datetime FROM "+monthid, dbconnect.handle);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] row0 = {
                    reader.GetInt32(0).ToString(),  reader.GetInt32(1).ToString(),  reader.GetString(2),
                    reader.GetString(3),  reader.GetString(4), reader.GetDateTime(5).ToString()
                };
                this.dgvStock.Rows.Add(row0);
            }
            reader.Close();
        }
    }
    }

