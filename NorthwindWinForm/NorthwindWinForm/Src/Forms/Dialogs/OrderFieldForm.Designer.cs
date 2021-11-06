namespace NorthwindWinForm.Src.Forms.Dialogs
{
    partial class OrderFieldForm
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
            this.btOk = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.cbxCustomerID = new System.Windows.Forms.ComboBox();
            this.cbxEmployeeID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblRequiredDate = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.txtRequiredDate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtShippedDate = new System.Windows.Forms.TextBox();
            this.lblShippedDate = new System.Windows.Forms.Label();
            this.nudFreight = new System.Windows.Forms.NumericUpDown();
            this.txtShipName = new System.Windows.Forms.TextBox();
            this.txtShipAddress = new System.Windows.Forms.TextBox();
            this.txtShipCity = new System.Windows.Forms.TextBox();
            this.txtShipRegion = new System.Windows.Forms.TextBox();
            this.lblShipVia = new System.Windows.Forms.Label();
            this.lblFreight = new System.Windows.Forms.Label();
            this.lblShipName = new System.Windows.Forms.Label();
            this.lblShipAddress = new System.Windows.Forms.Label();
            this.lblShipCity = new System.Windows.Forms.Label();
            this.lblShipRegion = new System.Windows.Forms.Label();
            this.txtShipCountry = new System.Windows.Forms.TextBox();
            this.txtShipPostalCode = new System.Windows.Forms.TextBox();
            this.lblShipPostalCode = new System.Windows.Forms.Label();
            this.lblShipCountry = new System.Windows.Forms.Label();
            this.cbxShippers = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreight)).BeginInit();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(324, 340);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(406, 340);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 1;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // cbxCustomerID
            // 
            this.cbxCustomerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCustomerID.FormattingEnabled = true;
            this.cbxCustomerID.Location = new System.Drawing.Point(24, 33);
            this.cbxCustomerID.Name = "cbxCustomerID";
            this.cbxCustomerID.Size = new System.Drawing.Size(230, 21);
            this.cbxCustomerID.TabIndex = 2;
            // 
            // cbxEmployeeID
            // 
            this.cbxEmployeeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmployeeID.FormattingEnabled = true;
            this.cbxEmployeeID.Location = new System.Drawing.Point(24, 80);
            this.cbxEmployeeID.Name = "cbxEmployeeID";
            this.cbxEmployeeID.Size = new System.Drawing.Size(147, 21);
            this.cbxEmployeeID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "CustomerID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "EmployeeID";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(27, 119);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(56, 13);
            this.lblOrderDate.TabIndex = 8;
            this.lblOrderDate.Text = "OrderDate";
            // 
            // lblRequiredDate
            // 
            this.lblRequiredDate.AutoSize = true;
            this.lblRequiredDate.Location = new System.Drawing.Point(27, 166);
            this.lblRequiredDate.Name = "lblRequiredDate";
            this.lblRequiredDate.Size = new System.Drawing.Size(73, 13);
            this.lblRequiredDate.TabIndex = 9;
            this.lblRequiredDate.Text = "RequiredDate";
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(24, 135);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(121, 20);
            this.txtOrderDate.TabIndex = 10;
            this.txtOrderDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOrderDate_KeyUp);
            // 
            // txtRequiredDate
            // 
            this.txtRequiredDate.Location = new System.Drawing.Point(24, 182);
            this.txtRequiredDate.Name = "txtRequiredDate";
            this.txtRequiredDate.ReadOnly = true;
            this.txtRequiredDate.Size = new System.Drawing.Size(121, 20);
            this.txtRequiredDate.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 13;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(151, 229);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(20, 20);
            this.button3.TabIndex = 16;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txtShippedDate
            // 
            this.txtShippedDate.Location = new System.Drawing.Point(24, 230);
            this.txtShippedDate.Name = "txtShippedDate";
            this.txtShippedDate.ReadOnly = true;
            this.txtShippedDate.Size = new System.Drawing.Size(121, 20);
            this.txtShippedDate.TabIndex = 15;
            // 
            // lblShippedDate
            // 
            this.lblShippedDate.AutoSize = true;
            this.lblShippedDate.Location = new System.Drawing.Point(27, 214);
            this.lblShippedDate.Name = "lblShippedDate";
            this.lblShippedDate.Size = new System.Drawing.Size(69, 13);
            this.lblShippedDate.TabIndex = 14;
            this.lblShippedDate.Text = "ShippedDate";
            // 
            // nudFreight
            // 
            this.nudFreight.DecimalPlaces = 4;
            this.nudFreight.Location = new System.Drawing.Point(25, 317);
            this.nudFreight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudFreight.Name = "nudFreight";
            this.nudFreight.Size = new System.Drawing.Size(120, 20);
            this.nudFreight.TabIndex = 18;
            // 
            // txtShipName
            // 
            this.txtShipName.Location = new System.Drawing.Point(300, 34);
            this.txtShipName.Name = "txtShipName";
            this.txtShipName.Size = new System.Drawing.Size(100, 20);
            this.txtShipName.TabIndex = 19;
            // 
            // txtShipAddress
            // 
            this.txtShipAddress.Location = new System.Drawing.Point(300, 81);
            this.txtShipAddress.Name = "txtShipAddress";
            this.txtShipAddress.Size = new System.Drawing.Size(100, 20);
            this.txtShipAddress.TabIndex = 20;
            // 
            // txtShipCity
            // 
            this.txtShipCity.Location = new System.Drawing.Point(300, 125);
            this.txtShipCity.Name = "txtShipCity";
            this.txtShipCity.Size = new System.Drawing.Size(100, 20);
            this.txtShipCity.TabIndex = 21;
            // 
            // txtShipRegion
            // 
            this.txtShipRegion.Location = new System.Drawing.Point(300, 168);
            this.txtShipRegion.Name = "txtShipRegion";
            this.txtShipRegion.Size = new System.Drawing.Size(100, 20);
            this.txtShipRegion.TabIndex = 22;
            // 
            // lblShipVia
            // 
            this.lblShipVia.AutoSize = true;
            this.lblShipVia.Location = new System.Drawing.Point(27, 253);
            this.lblShipVia.Name = "lblShipVia";
            this.lblShipVia.Size = new System.Drawing.Size(43, 13);
            this.lblShipVia.TabIndex = 23;
            this.lblShipVia.Text = "ShipVia";
            // 
            // lblFreight
            // 
            this.lblFreight.AutoSize = true;
            this.lblFreight.Location = new System.Drawing.Point(27, 301);
            this.lblFreight.Name = "lblFreight";
            this.lblFreight.Size = new System.Drawing.Size(39, 13);
            this.lblFreight.TabIndex = 24;
            this.lblFreight.Text = "Freight";
            // 
            // lblShipName
            // 
            this.lblShipName.AutoSize = true;
            this.lblShipName.Location = new System.Drawing.Point(303, 19);
            this.lblShipName.Name = "lblShipName";
            this.lblShipName.Size = new System.Drawing.Size(56, 13);
            this.lblShipName.TabIndex = 25;
            this.lblShipName.Text = "ShipName";
            // 
            // lblShipAddress
            // 
            this.lblShipAddress.AutoSize = true;
            this.lblShipAddress.Location = new System.Drawing.Point(300, 65);
            this.lblShipAddress.Name = "lblShipAddress";
            this.lblShipAddress.Size = new System.Drawing.Size(66, 13);
            this.lblShipAddress.TabIndex = 26;
            this.lblShipAddress.Text = "ShipAddress";
            // 
            // lblShipCity
            // 
            this.lblShipCity.AutoSize = true;
            this.lblShipCity.Location = new System.Drawing.Point(303, 112);
            this.lblShipCity.Name = "lblShipCity";
            this.lblShipCity.Size = new System.Drawing.Size(45, 13);
            this.lblShipCity.TabIndex = 27;
            this.lblShipCity.Text = "ShipCity";
            // 
            // lblShipRegion
            // 
            this.lblShipRegion.AutoSize = true;
            this.lblShipRegion.Location = new System.Drawing.Point(303, 152);
            this.lblShipRegion.Name = "lblShipRegion";
            this.lblShipRegion.Size = new System.Drawing.Size(62, 13);
            this.lblShipRegion.TabIndex = 28;
            this.lblShipRegion.Text = "ShipRegion";
            // 
            // txtShipCountry
            // 
            this.txtShipCountry.Location = new System.Drawing.Point(300, 264);
            this.txtShipCountry.Name = "txtShipCountry";
            this.txtShipCountry.Size = new System.Drawing.Size(100, 20);
            this.txtShipCountry.TabIndex = 30;
            // 
            // txtShipPostalCode
            // 
            this.txtShipPostalCode.Location = new System.Drawing.Point(300, 214);
            this.txtShipPostalCode.Name = "txtShipPostalCode";
            this.txtShipPostalCode.Size = new System.Drawing.Size(100, 20);
            this.txtShipPostalCode.TabIndex = 29;
            // 
            // lblShipPostalCode
            // 
            this.lblShipPostalCode.AutoSize = true;
            this.lblShipPostalCode.Location = new System.Drawing.Point(300, 198);
            this.lblShipPostalCode.Name = "lblShipPostalCode";
            this.lblShipPostalCode.Size = new System.Drawing.Size(82, 13);
            this.lblShipPostalCode.TabIndex = 31;
            this.lblShipPostalCode.Text = "ShipPostalCode";
            // 
            // lblShipCountry
            // 
            this.lblShipCountry.AutoSize = true;
            this.lblShipCountry.Location = new System.Drawing.Point(300, 248);
            this.lblShipCountry.Name = "lblShipCountry";
            this.lblShipCountry.Size = new System.Drawing.Size(64, 13);
            this.lblShipCountry.TabIndex = 32;
            this.lblShipCountry.Text = "ShipCountry";
            // 
            // cbxShippers
            // 
            this.cbxShippers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxShippers.FormattingEnabled = true;
            this.cbxShippers.Location = new System.Drawing.Point(24, 269);
            this.cbxShippers.Name = "cbxShippers";
            this.cbxShippers.Size = new System.Drawing.Size(121, 21);
            this.cbxShippers.TabIndex = 33;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(406, 125);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 34;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // OrderFieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 375);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cbxShippers);
            this.Controls.Add(this.lblShipCountry);
            this.Controls.Add(this.lblShipPostalCode);
            this.Controls.Add(this.txtShipCountry);
            this.Controls.Add(this.txtShipPostalCode);
            this.Controls.Add(this.lblShipRegion);
            this.Controls.Add(this.lblShipCity);
            this.Controls.Add(this.lblShipAddress);
            this.Controls.Add(this.lblShipName);
            this.Controls.Add(this.lblFreight);
            this.Controls.Add(this.lblShipVia);
            this.Controls.Add(this.txtShipRegion);
            this.Controls.Add(this.txtShipCity);
            this.Controls.Add(this.txtShipAddress);
            this.Controls.Add(this.txtShipName);
            this.Controls.Add(this.nudFreight);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtShippedDate);
            this.Controls.Add(this.lblShippedDate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRequiredDate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.lblRequiredDate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxEmployeeID);
            this.Controls.Add(this.cbxCustomerID);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderFieldForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrderFieldForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudFreight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.ComboBox cbxCustomerID;
        private System.Windows.Forms.ComboBox cbxEmployeeID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblRequiredDate;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.TextBox txtRequiredDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtShippedDate;
        private System.Windows.Forms.Label lblShippedDate;
        private System.Windows.Forms.NumericUpDown nudFreight;
        private System.Windows.Forms.TextBox txtShipName;
        private System.Windows.Forms.TextBox txtShipAddress;
        private System.Windows.Forms.TextBox txtShipCity;
        private System.Windows.Forms.TextBox txtShipRegion;
        private System.Windows.Forms.Label lblShipVia;
        private System.Windows.Forms.Label lblFreight;
        private System.Windows.Forms.Label lblShipName;
        private System.Windows.Forms.Label lblShipAddress;
        private System.Windows.Forms.Label lblShipCity;
        private System.Windows.Forms.Label lblShipRegion;
        private System.Windows.Forms.TextBox txtShipCountry;
        private System.Windows.Forms.TextBox txtShipPostalCode;
        private System.Windows.Forms.Label lblShipPostalCode;
        private System.Windows.Forms.Label lblShipCountry;
        private System.Windows.Forms.ComboBox cbxShippers;
        private System.Windows.Forms.Button button4;
    }
}