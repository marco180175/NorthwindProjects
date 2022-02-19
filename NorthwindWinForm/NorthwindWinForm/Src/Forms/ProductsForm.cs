using NorthwindBusiness.Src;
using NorthwindModel.Models;
using NorthwindWinForm.Src.Forms.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWinForm.Src.Forms
{    
    public partial class ProductsForm : Form
    {
        private ProductsBusiness products = new ProductsBusiness();       
        
        private DrawDataGridViewButtonsManager drawDataGridViewButtonsManager;
        public ProductsForm(Control parent)
        {
            InitializeComponent();
            //            
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Parent = parent;
            this.Dock = DockStyle.Fill;
            //
            dataGridView1.DataSource = products.SelectList();
            dataGridView1.Columns[ProductProperties.UNITS_IN_STOCK].Visible = false;
            dataGridView1.Columns[ProductProperties.UNITS_ON_ORDER].Visible = false;
            //dataGridView1.Columns[ProductProperties.REORDER_LEVEL].Visible = false;
            //
            drawDataGridViewButtonsManager = new DrawDataGridViewButtonsManager(dataGridView1);
            drawDataGridViewButtonsManager.AddEditButton();
            drawDataGridViewButtonsManager.AddDeleteButton();
            //
            cbxFilterName.Items.Add("None");
            cbxFilterName.Items.Add(ProductProperties.SUPPLIER_ID);
            cbxFilterName.Items.Add(ProductProperties.CATEGORY_ID);
            cbxFilterName.Items.Add(ProductProperties.DISCONTINUED);
            cbxFilterName.SelectedIndex = 0;
        }

        private void tsbCreate_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm(null);
            if (productForm.ShowDialog(this) == DialogResult.OK)
            {
                products.InsertItem(productForm.Return);
                dataGridView1.DataSource = products.SelectList();
            }
        }
                
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1[ProductProperties.PRODUCT_ID, e.RowIndex].Value);
            if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_EDIT)
            {
                EditProduct(id);                                                      
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_DELETE)
            {
                DeleteProduct(id);
            }

        }

        public void DeleteProduct(int id)
        {
            if (MessageBox.Show(string.Format("{0} {1} ?", AppStrings.STR_CONFIRM_DELETE, id), AppStrings.STR_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                products.DeleteItem(id);
                dataGridView1.DataSource = products.SelectList();
            }
        }

        public void EditProduct(int id)
        {
            var products = new ProductsBusiness();
            var item = products.SelectItem(id);
            var dialog = new ProductForm(item);
            //verificar null
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                products.UpdateItem(dialog.Return);
                dataGridView1.DataSource = products.SelectList();
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            drawDataGridViewButtonsManager.DrawButtons(e);            
        }

        private void cbxFilterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxFilterValue.DataSource = null;
            cbxFilterValue.Items.Clear();
            //switch ( cbxFilterName.SelectedIndex )
            //{
            //    case 1://suppliers
            //        {                        
            //            SuppliersBusiness suppliers = new SuppliersBusiness();
            //            cbxFilterValue.Items.AddRange(suppliers.SelectList().ToArray());
            //        }; break;
            //    case 2://categories
            //        {
            //            CategoriesBusiness categories = new CategoriesBusiness();
            //            cbxFilterValue.Items.AddRange(categories.SelectList().ToArray());
            //        }; break;
            //    case 3://booleans
            //        {
            //            BooleanBusiness booleans = new BooleanBusiness();
            //            cbxFilterValue.Items.AddRange(booleans.SelectList().ToArray());
            //        }; break;
            //}
            //if(cbxFilterValue.Items.Count > 0)
            //    cbxFilterValue.SelectedIndex = 0;

            switch (cbxFilterName.SelectedIndex)
            {
                case 1://suppliers
                    {
                        SuppliersBusiness suppliers = new SuppliersBusiness();
                        cbxFilterValue.DataSource = suppliers.SelectList();
                        cbxFilterValue.ValueMember = "SupplierID";
                        cbxFilterValue.DisplayMember = "CompanyName";
                    }; break;
                case 2://categories
                    {
                        CategoriesBusiness categories = new CategoriesBusiness();
                        cbxFilterValue.DataSource = categories.SelectList();
                        cbxFilterValue.ValueMember = "CategoryID";
                        cbxFilterValue.DisplayMember = "CategoryName";
                    }; break;
                case 3://booleans
                    {
                        BooleanBusiness booleans = new BooleanBusiness();
                        cbxFilterValue.DataSource = booleans.SelectList();
                        cbxFilterValue.ValueMember = "Index";
                        cbxFilterValue.DisplayMember = "Name";
                    }; break;
            }
            //if(cbxFilterValue.Items.Count > 0)
            //    cbxFilterValue.SelectedIndex = 0;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string filter= string.Empty;
            if(cbxFilterName.SelectedIndex > 0)
            {
                filter = string.Format("{0}={1}", cbxFilterName.Text, cbxFilterValue.SelectedValue);                
                if (!string.IsNullOrEmpty(filter))
                    dataGridView1.DataSource = products.SelectList(filter);
            }
            else
            {
                dataGridView1.DataSource = products.SelectList();
            }            
        }
    }
}
