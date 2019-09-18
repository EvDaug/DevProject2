namespace SalesReportPredictionSystem
{
    partial class WeeklyForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbStock = new System.Windows.Forms.ListBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(798, 100);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 46);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "find";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnBack.Location = new System.Drawing.Point(67, 95);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 57);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "< Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbStock
            // 
            this.lbStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbStock.FormattingEnabled = true;
            this.lbStock.ItemHeight = 25;
            this.lbStock.Location = new System.Drawing.Point(67, 160);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(792, 354);
            this.lbStock.TabIndex = 10;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblDate.Location = new System.Drawing.Point(213, 93);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(112, 46);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "Date";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(599, 108);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(193, 31);
            this.tbSearch.TabIndex = 12;
            this.tbSearch.Text = "Search";
            // 
            // WeeklyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(924, 629);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lbStock);
            this.Controls.Add(this.btnBack);
            this.Name = "WeeklyForm";
            this.Text = "Sales Prediction Report System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ListBox lbStock;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox tbSearch;
    }
}