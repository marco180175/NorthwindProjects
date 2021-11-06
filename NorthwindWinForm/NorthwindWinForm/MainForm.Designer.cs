namespace NorthwindWinForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miTables = new System.Windows.Forms.ToolStripMenuItem();
            this.miCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.miProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.miOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.miOrderDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.miSuppliers = new System.Windows.Forms.ToolStripMenuItem();
            this.miCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.miEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.custOrderHistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.custOrdersDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeSalesbyCountryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tenMostExpensiveProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.miShopping = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShoppingCarts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miTables,
            this.miShopping,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miTables
            // 
            this.miTables.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCategories,
            this.miProducts,
            this.miOrders,
            this.miOrderDetails,
            this.miSuppliers,
            this.miCustomers,
            this.miEmployees});
            this.miTables.Name = "miTables";
            this.miTables.Size = new System.Drawing.Size(53, 20);
            this.miTables.Text = "Tables";
            // 
            // miCategories
            // 
            this.miCategories.Name = "miCategories";
            this.miCategories.Size = new System.Drawing.Size(180, 22);
            this.miCategories.Text = "Categories";
            this.miCategories.Click += new System.EventHandler(this.miCategories_Click);
            // 
            // miProducts
            // 
            this.miProducts.Name = "miProducts";
            this.miProducts.Size = new System.Drawing.Size(180, 22);
            this.miProducts.Text = "Products";
            this.miProducts.Click += new System.EventHandler(this.miProducts_Click);
            // 
            // miOrders
            // 
            this.miOrders.Name = "miOrders";
            this.miOrders.Size = new System.Drawing.Size(180, 22);
            this.miOrders.Text = "Orders";
            this.miOrders.Click += new System.EventHandler(this.miOrders_Click);
            // 
            // miOrderDetails
            // 
            this.miOrderDetails.Name = "miOrderDetails";
            this.miOrderDetails.Size = new System.Drawing.Size(180, 22);
            this.miOrderDetails.Text = "Order Details";
            this.miOrderDetails.Click += new System.EventHandler(this.miOrderDetails_Click);
            // 
            // miSuppliers
            // 
            this.miSuppliers.Name = "miSuppliers";
            this.miSuppliers.Size = new System.Drawing.Size(180, 22);
            this.miSuppliers.Text = "Suppliers";
            this.miSuppliers.Click += new System.EventHandler(this.miSuppliers_Click);
            // 
            // miCustomers
            // 
            this.miCustomers.Name = "miCustomers";
            this.miCustomers.Size = new System.Drawing.Size(180, 22);
            this.miCustomers.Text = "Customers";
            this.miCustomers.Click += new System.EventHandler(this.miCustomers_Click);
            // 
            // miEmployees
            // 
            this.miEmployees.Name = "miEmployees";
            this.miEmployees.Size = new System.Drawing.Size(180, 22);
            this.miEmployees.Text = "Employees";
            this.miEmployees.Click += new System.EventHandler(this.miEmployees_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.custOrderHistToolStripMenuItem,
            this.custOrdersDetailToolStripMenuItem,
            this.toolStripMenuItem1,
            this.salesByCategoryToolStripMenuItem,
            this.employeeSalesbyCountryToolStripMenuItem,
            this.salesByYearToolStripMenuItem,
            this.tenMostExpensiveProductsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // custOrderHistToolStripMenuItem
            // 
            this.custOrderHistToolStripMenuItem.Name = "custOrderHistToolStripMenuItem";
            this.custOrderHistToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.custOrderHistToolStripMenuItem.Text = "CustOrderHist";
            this.custOrderHistToolStripMenuItem.Click += new System.EventHandler(this.custOrderHistToolStripMenuItem_Click);
            // 
            // custOrdersDetailToolStripMenuItem
            // 
            this.custOrdersDetailToolStripMenuItem.Name = "custOrdersDetailToolStripMenuItem";
            this.custOrdersDetailToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.custOrdersDetailToolStripMenuItem.Text = "CustOrdersDetail";
            this.custOrdersDetailToolStripMenuItem.Click += new System.EventHandler(this.custOrdersDetailToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 22);
            this.toolStripMenuItem1.Text = "CustOrdersOrders";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // salesByCategoryToolStripMenuItem
            // 
            this.salesByCategoryToolStripMenuItem.Name = "salesByCategoryToolStripMenuItem";
            this.salesByCategoryToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.salesByCategoryToolStripMenuItem.Text = "SalesByCategory";
            this.salesByCategoryToolStripMenuItem.Click += new System.EventHandler(this.salesByCategoryToolStripMenuItem_Click);
            // 
            // employeeSalesbyCountryToolStripMenuItem
            // 
            this.employeeSalesbyCountryToolStripMenuItem.Name = "employeeSalesbyCountryToolStripMenuItem";
            this.employeeSalesbyCountryToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.employeeSalesbyCountryToolStripMenuItem.Text = "Employee Sales by Country";
            this.employeeSalesbyCountryToolStripMenuItem.Click += new System.EventHandler(this.employeeSalesbyCountryToolStripMenuItem_Click);
            // 
            // salesByYearToolStripMenuItem
            // 
            this.salesByYearToolStripMenuItem.Name = "salesByYearToolStripMenuItem";
            this.salesByYearToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.salesByYearToolStripMenuItem.Text = "Sales by Year";
            this.salesByYearToolStripMenuItem.Click += new System.EventHandler(this.salesByYearToolStripMenuItem_Click);
            // 
            // tenMostExpensiveProductsToolStripMenuItem
            // 
            this.tenMostExpensiveProductsToolStripMenuItem.Name = "tenMostExpensiveProductsToolStripMenuItem";
            this.tenMostExpensiveProductsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.tenMostExpensiveProductsToolStripMenuItem.Text = "TenMost Expensive Products";
            this.tenMostExpensiveProductsToolStripMenuItem.Click += new System.EventHandler(this.tenMostExpensiveProductsToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 553);
            this.panel1.TabIndex = 7;
            // 
            // miShopping
            // 
            this.miShopping.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShoppingCarts});
            this.miShopping.Name = "miShopping";
            this.miShopping.Size = new System.Drawing.Size(70, 20);
            this.miShopping.Text = "Shopping";
            // 
            // tsmShoppingCarts
            // 
            this.tsmShoppingCarts.Name = "tsmShoppingCarts";
            this.tsmShoppingCarts.Size = new System.Drawing.Size(180, 22);
            this.tsmShoppingCarts.Text = "ShoppingCarts";
            this.tsmShoppingCarts.Click += new System.EventHandler(this.tsmShoppingCarts_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 602);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miTables;
        private System.Windows.Forms.ToolStripMenuItem miCategories;
        private System.Windows.Forms.ToolStripMenuItem miProducts;
        private System.Windows.Forms.ToolStripMenuItem miOrders;
        private System.Windows.Forms.ToolStripMenuItem miOrderDetails;
        private System.Windows.Forms.ToolStripMenuItem miSuppliers;
        private System.Windows.Forms.ToolStripMenuItem miCustomers;
        private System.Windows.Forms.ToolStripMenuItem miEmployees;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem custOrderHistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem custOrdersDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesByCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeSalesbyCountryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salesByYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tenMostExpensiveProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miShopping;
        private System.Windows.Forms.ToolStripMenuItem tsmShoppingCarts;
    }
}

