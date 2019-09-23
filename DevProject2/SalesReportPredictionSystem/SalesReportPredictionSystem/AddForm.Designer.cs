namespace SalesReportPredictionSystem
{
    partial class AddForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblSold = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbSold = new System.Windows.Forms.TextBox();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.tbBrand = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(497, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 45);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(634, 373);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 45);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(337, 44);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(153, 37);
            this.lblHeading.TabIndex = 23;
            this.lblHeading.Text = "Add Item";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(151, 238);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(143, 25);
            this.lblStock.TabIndex = 22;
            this.lblStock.Text = "Current Stock";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(225, 164);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 25);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "Name";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(262, 127);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(32, 25);
            this.lblID.TabIndex = 20;
            this.lblID.Text = "ID";
            // 
            // lblSold
            // 
            this.lblSold.AutoSize = true;
            this.lblSold.Location = new System.Drawing.Point(239, 275);
            this.lblSold.Name = "lblSold";
            this.lblSold.Size = new System.Drawing.Size(55, 25);
            this.lblSold.TabIndex = 19;
            this.lblSold.Text = "Sold";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(225, 201);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(69, 25);
            this.lblBrand.TabIndex = 18;
            this.lblBrand.Text = "Brand";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(300, 124);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(300, 31);
            this.tbID.TabIndex = 17;
            // 
            // tbSold
            // 
            this.tbSold.Location = new System.Drawing.Point(300, 272);
            this.tbSold.Name = "tbSold";
            this.tbSold.Size = new System.Drawing.Size(300, 31);
            this.tbSold.TabIndex = 16;
            // 
            // tbStock
            // 
            this.tbStock.Location = new System.Drawing.Point(300, 235);
            this.tbStock.Name = "tbStock";
            this.tbStock.Size = new System.Drawing.Size(300, 31);
            this.tbStock.TabIndex = 15;
            // 
            // tbBrand
            // 
            this.tbBrand.Location = new System.Drawing.Point(300, 198);
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(300, 31);
            this.tbBrand.TabIndex = 14;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(300, 161);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(300, 31);
            this.tbName.TabIndex = 13;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblSold);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.tbSold);
            this.Controls.Add(this.tbStock);
            this.Controls.Add(this.tbBrand);
            this.Controls.Add(this.tbName);
            this.Name = "AddForm";
            this.Text = "Sales Prediction Report System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblSold;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbSold;
        private System.Windows.Forms.TextBox tbStock;
        private System.Windows.Forms.TextBox tbBrand;
        private System.Windows.Forms.TextBox tbName;
    }
}