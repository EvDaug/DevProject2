namespace SalesReportPredictionSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMonthly = new System.Windows.Forms.Button();
            this.btnWeekly = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.lbStock = new System.Windows.Forms.ListBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMonthly
            // 
            this.btnMonthly.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnMonthly.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMonthly.Location = new System.Drawing.Point(471, 474);
            this.btnMonthly.Name = "btnMonthly";
            this.btnMonthly.Size = new System.Drawing.Size(388, 57);
            this.btnMonthly.TabIndex = 0;
            this.btnMonthly.Text = "View Monthly Sales";
            this.btnMonthly.UseVisualStyleBackColor = false;
            this.btnMonthly.Click += new System.EventHandler(this.btnMonthly_Click);
            // 
            // btnWeekly
            // 
            this.btnWeekly.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnWeekly.Location = new System.Drawing.Point(67, 474);
            this.btnWeekly.Name = "btnWeekly";
            this.btnWeekly.Size = new System.Drawing.Size(398, 57);
            this.btnWeekly.TabIndex = 1;
            this.btnWeekly.Text = "View Weekly Sales";
            this.btnWeekly.UseVisualStyleBackColor = false;
            this.btnWeekly.Click += new System.EventHandler(this.btnWeekly_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnReport.Location = new System.Drawing.Point(67, 537);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(398, 57);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Generate CSV Report";
            this.btnReport.UseVisualStyleBackColor = false;
            // 
            // lbStock
            // 
            this.lbStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbStock.FormattingEnabled = true;
            this.lbStock.ItemHeight = 25;
            this.lbStock.Location = new System.Drawing.Point(67, 95);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(792, 354);
            this.lbStock.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblDate.Location = new System.Drawing.Point(59, 27);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(112, 46);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(599, 43);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(193, 31);
            this.tbSearch.TabIndex = 5;
            this.tbSearch.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(798, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 46);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "find";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(471, 537);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(388, 57);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add Item";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(924, 629);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lbStock);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnWeekly);
            this.Controls.Add(this.btnMonthly);
            this.Name = "MainForm";
            this.Text = "Sales Prediction Report System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMonthly;
        private System.Windows.Forms.Button btnWeekly;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.ListBox lbStock;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
    }
}

