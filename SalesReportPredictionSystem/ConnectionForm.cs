using System;
using System.Drawing;
using System.Windows.Forms;

namespace SalesReportPredictionSystem
{
    public class ConnectionForm : Form
    {
        Label serverLabel, dbLabel, uidLabel, pwdLabel;
        TextBox serverBox, dbBox, uidBox, pwdBox;
        CheckBox usePwdBox;
        Button retryBtn, exitBtn;

        private static TextBox InitTextBox(string value, int y)
        {
            var box = new TextBox();
            box.Text = value;
            box.Size = new Size(100, 24);
            box.Location = new Point(100, y);
            return box;
        }

        public ConnectionForm()
        {
            this.Size = new Size(256, 230);
            this.StartPosition = FormStartPosition.CenterScreen;

            serverLabel = new Label();
            serverLabel.Text = "Server:";
            serverLabel.AutoSize = true;
            serverLabel.Location = new Point(30, 20);

            dbLabel = new Label();
            dbLabel.Text = "Database:";
            dbLabel.AutoSize = true;
            dbLabel.Location = new Point(30, 50);

            uidLabel = new Label();
            uidLabel.Text = "User:";
            uidLabel.AutoSize = true;
            uidLabel.Location = new Point(30, 80);

            pwdLabel = new Label();
            pwdLabel.Text = "Password:";
            pwdLabel.AutoSize = true;
            pwdLabel.Location = new Point(30, 110);

            serverBox = InitTextBox(Database.ServerName, 18);
            dbBox = InitTextBox(Database.DBName, 48);
            uidBox = InitTextBox(Database.UserID, 78);
            pwdBox = InitTextBox(Database.Password, 108);

            serverBox.TextChanged += (s, e) => Database.ServerName = serverBox.Text;
            dbBox.TextChanged += (s, e) => Database.DBName = dbBox.Text;
            uidBox.TextChanged += (s, e) => Database.UserID = uidBox.Text;
            pwdBox.TextChanged += (s, e) => Database.Password = pwdBox.Text;

            pwdBox.UseSystemPasswordChar = true;
            pwdBox.Enabled = false;

            usePwdBox = new CheckBox();
            usePwdBox.Location = new Point(210, 108);
            usePwdBox.Checked = false;
            usePwdBox.CheckStateChanged += TogglePassword;

            retryBtn = new Button();
            retryBtn.Text = "Retry";
            retryBtn.Location = new Point(40, 160);
            retryBtn.Click += (s, e) => { this.DialogResult = DialogResult.Retry; this.Close(); };

            exitBtn = new Button();
            exitBtn.Text = "Exit";
            exitBtn.Location = new Point(120, 160);
            exitBtn.Click += (s, e) => { this.DialogResult = DialogResult.Abort; this.Close(); };

            this.Controls.Add(serverLabel);
            this.Controls.Add(dbLabel);
            this.Controls.Add(uidLabel);
            this.Controls.Add(pwdLabel);
            this.Controls.Add(serverBox);
            this.Controls.Add(dbBox);
            this.Controls.Add(uidBox);
            this.Controls.Add(pwdBox);
            this.Controls.Add(usePwdBox);
            this.Controls.Add(retryBtn);
            this.Controls.Add(exitBtn);
        }

        private void TogglePassword(object sender, EventArgs e)
        {
            bool usePwd = usePwdBox.CheckState == CheckState.Checked;
            pwdBox.Enabled = usePwd;
            Database.UsePwd = usePwd;
        }
    }
}
