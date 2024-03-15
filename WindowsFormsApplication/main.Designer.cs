namespace WindowsFormsApplication2
{
    partial class main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.farmersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SugercaneBillingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSalesBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewFarmersBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSalesBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printFarmersBillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSalesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSugercaneReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.farmersReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.billingToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.printToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1170, 36);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem,
            this.farmersToolStripMenuItem,
            this.customersToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(65, 32);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(182, 32);
            this.productsToolStripMenuItem.Text = "Products";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
            // 
            // farmersToolStripMenuItem
            // 
            this.farmersToolStripMenuItem.Name = "farmersToolStripMenuItem";
            this.farmersToolStripMenuItem.Size = new System.Drawing.Size(182, 32);
            this.farmersToolStripMenuItem.Text = "Farmers";
            this.farmersToolStripMenuItem.Click += new System.EventHandler(this.farmersToolStripMenuItem_Click);
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(182, 32);
            this.customersToolStripMenuItem.Text = "Customers";
            this.customersToolStripMenuItem.Click += new System.EventHandler(this.customersToolStripMenuItem_Click);
            // 
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBillToolStripMenuItem,
            this.SugercaneBillingToolStripMenuItem});
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(78, 32);
            this.billingToolStripMenuItem.Text = "Billing";
            // 
            // newBillToolStripMenuItem
            // 
            this.newBillToolStripMenuItem.Name = "newBillToolStripMenuItem";
            this.newBillToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.newBillToolStripMenuItem.Text = "New Bill";
            this.newBillToolStripMenuItem.Click += new System.EventHandler(this.newBillToolStripMenuItem_Click);
            // 
            // SugercaneBillingToolStripMenuItem
            // 
            this.SugercaneBillingToolStripMenuItem.Name = "SugercaneBillingToolStripMenuItem";
            this.SugercaneBillingToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.SugercaneBillingToolStripMenuItem.Text = "Sugercane Bill";
            this.SugercaneBillingToolStripMenuItem.Click += new System.EventHandler(this.SugercaneBillingToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSalesBillToolStripMenuItem,
            this.viewFarmersBillToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(65, 32);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // viewSalesBillToolStripMenuItem
            // 
            this.viewSalesBillToolStripMenuItem.Name = "viewSalesBillToolStripMenuItem";
            this.viewSalesBillToolStripMenuItem.Size = new System.Drawing.Size(235, 32);
            this.viewSalesBillToolStripMenuItem.Text = "View Sales Bill";
            this.viewSalesBillToolStripMenuItem.Click += new System.EventHandler(this.viewSalesBillToolStripMenuItem_Click);
            // 
            // viewFarmersBillToolStripMenuItem
            // 
            this.viewFarmersBillToolStripMenuItem.Name = "viewFarmersBillToolStripMenuItem";
            this.viewFarmersBillToolStripMenuItem.Size = new System.Drawing.Size(235, 32);
            this.viewFarmersBillToolStripMenuItem.Text = "View Farmers Bill";
            this.viewFarmersBillToolStripMenuItem.Click += new System.EventHandler(this.viewFarmersBillToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printSalesBillToolStripMenuItem,
            this.printFarmersBillsToolStripMenuItem});
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(65, 32);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // printSalesBillToolStripMenuItem
            // 
            this.printSalesBillToolStripMenuItem.Name = "printSalesBillToolStripMenuItem";
            this.printSalesBillToolStripMenuItem.Size = new System.Drawing.Size(243, 32);
            this.printSalesBillToolStripMenuItem.Text = "Print Sales Bills";
            this.printSalesBillToolStripMenuItem.Click += new System.EventHandler(this.printSalesBillToolStripMenuItem_Click);
            // 
            // printFarmersBillsToolStripMenuItem
            // 
            this.printFarmersBillsToolStripMenuItem.Name = "printFarmersBillsToolStripMenuItem";
            this.printFarmersBillsToolStripMenuItem.Size = new System.Drawing.Size(243, 32);
            this.printFarmersBillsToolStripMenuItem.Text = "Print Farmers Bills";
            this.printFarmersBillsToolStripMenuItem.Click += new System.EventHandler(this.printFarmersBillsToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printSalesReportToolStripMenuItem,
            this.printSugercaneReportToolStripMenuItem,
            this.productsReportToolStripMenuItem,
            this.customersReportToolStripMenuItem,
            this.farmersReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(91, 32);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // printSalesReportToolStripMenuItem
            // 
            this.printSalesReportToolStripMenuItem.Name = "printSalesReportToolStripMenuItem";
            this.printSalesReportToolStripMenuItem.Size = new System.Drawing.Size(286, 32);
            this.printSalesReportToolStripMenuItem.Text = "Print SalesReport";
            this.printSalesReportToolStripMenuItem.Click += new System.EventHandler(this.printSalesReportToolStripMenuItem_Click);
            // 
            // printSugercaneReportToolStripMenuItem
            // 
            this.printSugercaneReportToolStripMenuItem.Name = "printSugercaneReportToolStripMenuItem";
            this.printSugercaneReportToolStripMenuItem.Size = new System.Drawing.Size(286, 32);
            this.printSugercaneReportToolStripMenuItem.Text = "Print SugercaneReport";
            this.printSugercaneReportToolStripMenuItem.Click += new System.EventHandler(this.printSugercaneReportToolStripMenuItem_Click);
            // 
            // productsReportToolStripMenuItem
            // 
            this.productsReportToolStripMenuItem.Name = "productsReportToolStripMenuItem";
            this.productsReportToolStripMenuItem.Size = new System.Drawing.Size(286, 32);
            this.productsReportToolStripMenuItem.Text = "ProductsReport";
            this.productsReportToolStripMenuItem.Click += new System.EventHandler(this.productsReportToolStripMenuItem_Click);
            // 
            // customersReportToolStripMenuItem
            // 
            this.customersReportToolStripMenuItem.Name = "customersReportToolStripMenuItem";
            this.customersReportToolStripMenuItem.Size = new System.Drawing.Size(286, 32);
            this.customersReportToolStripMenuItem.Text = "CustomersReport";
            this.customersReportToolStripMenuItem.Click += new System.EventHandler(this.customersReportToolStripMenuItem_Click);
            // 
            // farmersReportToolStripMenuItem
            // 
            this.farmersReportToolStripMenuItem.Name = "farmersReportToolStripMenuItem";
            this.farmersReportToolStripMenuItem.Size = new System.Drawing.Size(286, 32);
            this.farmersReportToolStripMenuItem.Text = "FarmersReport";
            this.farmersReportToolStripMenuItem.Click += new System.EventHandler(this.farmersReportToolStripMenuItem_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 659);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main";
            this.Text = "Laxmi Jaggery";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem farmersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SugercaneBillingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSalesBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewFarmersBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSalesBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSalesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSugercaneReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printFarmersBillsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem farmersReportToolStripMenuItem;
    }
}

