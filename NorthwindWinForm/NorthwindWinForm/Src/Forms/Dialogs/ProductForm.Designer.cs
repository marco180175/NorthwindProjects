namespace NorthwindWinForm.Src.Forms.Dialogs
{
    partial class ProductForm
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
            this.btExit = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lbSupplier = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.Label();
            this.tbQuantityPerUnit = new System.Windows.Forms.TextBox();
            this.lbQuantityPerUnit = new System.Windows.Forms.Label();
            this.nudUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.nudUnitsInStock = new System.Windows.Forms.NumericUpDown();
            this.nudUnitsOnOrder = new System.Windows.Forms.NumericUpDown();
            this.nupReorderLevel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDiscontinued = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitsInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitsOnOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupReorderLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(414, 325);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 3;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(327, 325);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(35, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(209, 20);
            this.tbName.TabIndex = 4;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(37, 22);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 5;
            this.lbName.Text = "Name";
            // 
            // cbSupplier
            // 
            this.cbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(35, 100);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(209, 21);
            this.cbSupplier.TabIndex = 6;
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(35, 165);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(209, 21);
            this.cbCategory.TabIndex = 7;
            // 
            // lbSupplier
            // 
            this.lbSupplier.AutoSize = true;
            this.lbSupplier.Location = new System.Drawing.Point(37, 84);
            this.lbSupplier.Name = "lbSupplier";
            this.lbSupplier.Size = new System.Drawing.Size(45, 13);
            this.lbSupplier.TabIndex = 8;
            this.lbSupplier.Text = "Supplier";
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(41, 151);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(49, 13);
            this.lbCategory.TabIndex = 9;
            this.lbCategory.Text = "Category";
            // 
            // tbQuantityPerUnit
            // 
            this.tbQuantityPerUnit.Location = new System.Drawing.Point(38, 229);
            this.tbQuantityPerUnit.Name = "tbQuantityPerUnit";
            this.tbQuantityPerUnit.Size = new System.Drawing.Size(206, 20);
            this.tbQuantityPerUnit.TabIndex = 10;
            // 
            // lbQuantityPerUnit
            // 
            this.lbQuantityPerUnit.AutoSize = true;
            this.lbQuantityPerUnit.Location = new System.Drawing.Point(41, 213);
            this.lbQuantityPerUnit.Name = "lbQuantityPerUnit";
            this.lbQuantityPerUnit.Size = new System.Drawing.Size(81, 13);
            this.lbQuantityPerUnit.TabIndex = 11;
            this.lbQuantityPerUnit.Text = "QuantityPerUnit";
            // 
            // nudUnitPrice
            // 
            this.nudUnitPrice.DecimalPlaces = 2;
            this.nudUnitPrice.Location = new System.Drawing.Point(370, 39);
            this.nudUnitPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudUnitPrice.Name = "nudUnitPrice";
            this.nudUnitPrice.Size = new System.Drawing.Size(120, 20);
            this.nudUnitPrice.TabIndex = 12;
            // 
            // nudUnitsInStock
            // 
            this.nudUnitsInStock.Location = new System.Drawing.Point(370, 100);
            this.nudUnitsInStock.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudUnitsInStock.Name = "nudUnitsInStock";
            this.nudUnitsInStock.Size = new System.Drawing.Size(120, 20);
            this.nudUnitsInStock.TabIndex = 13;
            // 
            // nudUnitsOnOrder
            // 
            this.nudUnitsOnOrder.Location = new System.Drawing.Point(370, 151);
            this.nudUnitsOnOrder.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudUnitsOnOrder.Name = "nudUnitsOnOrder";
            this.nudUnitsOnOrder.Size = new System.Drawing.Size(120, 20);
            this.nudUnitsOnOrder.TabIndex = 14;
            // 
            // nupReorderLevel
            // 
            this.nupReorderLevel.Location = new System.Drawing.Point(370, 206);
            this.nupReorderLevel.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupReorderLevel.Name = "nupReorderLevel";
            this.nupReorderLevel.Size = new System.Drawing.Size(120, 20);
            this.nupReorderLevel.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "UnitPrice";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "UnitsInStock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "UnitsOnOrder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "ReorderLevel";
            // 
            // cbDiscontinued
            // 
            this.cbDiscontinued.AutoSize = true;
            this.cbDiscontinued.Location = new System.Drawing.Point(370, 252);
            this.cbDiscontinued.Name = "cbDiscontinued";
            this.cbDiscontinued.Size = new System.Drawing.Size(88, 17);
            this.cbDiscontinued.TabIndex = 20;
            this.cbDiscontinued.Text = "Discontinued";
            this.cbDiscontinued.UseVisualStyleBackColor = true;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 359);
            this.Controls.Add(this.cbDiscontinued);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nupReorderLevel);
            this.Controls.Add(this.nudUnitsOnOrder);
            this.Controls.Add(this.nudUnitsInStock);
            this.Controls.Add(this.nudUnitPrice);
            this.Controls.Add(this.lbQuantityPerUnit);
            this.Controls.Add(this.tbQuantityPerUnit);
            this.Controls.Add(this.lbCategory);
            this.Controls.Add(this.lbSupplier);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.cbSupplier);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitsInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitsOnOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupReorderLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lbSupplier;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.TextBox tbQuantityPerUnit;
        private System.Windows.Forms.Label lbQuantityPerUnit;
        private System.Windows.Forms.NumericUpDown nudUnitPrice;
        private System.Windows.Forms.NumericUpDown nudUnitsInStock;
        private System.Windows.Forms.NumericUpDown nudUnitsOnOrder;
        private System.Windows.Forms.NumericUpDown nupReorderLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbDiscontinued;
    }
}