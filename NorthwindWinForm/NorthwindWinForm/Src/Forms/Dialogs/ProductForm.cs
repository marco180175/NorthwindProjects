using NorthwindBusiness.Src;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWinForm.Src.Forms.Dialogs
{
    public partial class ProductForm : Form, IDialogs
    {
        private Product product = new Product();
        private bool isValid;
        public ProductForm(object item)
        {
            InitializeComponent();
            //            
            var categories = new CategoriesBusiness();
            var clist = categories.SelectList().Cast<Category>().ToList(); 
            cbCategory.Items.AddRange(clist.ToArray());
            cbCategory.Items.Insert(0, "Select");
            //            
            var suppliers = new SuppliersBusiness();
            var slist = suppliers.SelectList();
            cbSupplier.Items.AddRange(slist.ToArray());            
            cbSupplier.Items.Insert(0, "Select");
            //
            if (item != null)
            {
                Product product = (Product)item;
                this.product.ProductID = product.ProductID;
                //
                tbName.Text = product.ProductName;
                //
                int j = clist.FindIndex(x => x.CategoryID == product.CategoryID);
                cbCategory.SelectedIndex = j + 1;
                //
                j = slist.FindIndex(x => x.SupplierID == product.SupplierID);
                cbSupplier.SelectedIndex = j + 1;                
                //                
                tbQuantityPerUnit.Text = product.QuantityPerUnit;
                nudUnitPrice.Value = product.UnitPrice;
                nudUnitsInStock.Value = product.UnitsInStock;
                nudUnitsOnOrder.Value = product.UnitsOnOrder;
                nupReorderLevel.Value = product.ReorderLevel;
                cbDiscontinued.Checked = product.Discontinued;
            }
            else
            {                
                cbCategory.SelectedIndex = 0;
                cbSupplier.SelectedIndex = 0;
            }
        }

        public object Return { get { return product; } }

        private new void Validate()
        {
            isValid = true;
            List<string> messageList = new List<string>();
            if(string.IsNullOrEmpty(tbName.Text) )
            {
                isValid = false;
                messageList.Add("Nome do produto é requerido");
            }
            //
            if (cbSupplier.Text == "Select")
            {
                isValid = false;
                messageList.Add("Selecione um suplier para o produto");
            }
            //
            if (cbCategory.Text == "Select")
            {
                isValid = false;
                messageList.Add("Selecione uma categoria para o produto");
            }
            //
            if(nudUnitPrice.Value==0)
            {
                isValid = false;
                messageList.Add("Preço unitario deve ser maior que sero.");
            }
            if (!isValid)
            {
                ShowListMessageForm showListMessage = new ShowListMessageForm(messageList);
                showListMessage.ShowDialog();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Validate();
            if(isValid)
            {
                product.ProductName = tbName.Text;
                Supplier supplier = (Supplier)cbSupplier.SelectedItem;
                product.SupplierID = supplier.SupplierID;
                Category category = (Category)cbCategory.SelectedItem;
                product.CategoryID = category.CategoryID;
                product.QuantityPerUnit = tbQuantityPerUnit.Text;
                product.UnitPrice = nudUnitPrice.Value;
                product.UnitsInStock = Convert.ToInt16( nudUnitsInStock.Value);
                product.UnitsOnOrder = Convert.ToInt16(nudUnitsOnOrder.Value);
                product.ReorderLevel = Convert.ToInt16(nupReorderLevel.Value);
                product.Discontinued = cbDiscontinued.Checked;
                //
                DialogResult = DialogResult.OK;
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
