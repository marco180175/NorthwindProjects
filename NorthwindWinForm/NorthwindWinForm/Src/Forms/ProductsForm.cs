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
        private SuppliersBusiness suppliers = new SuppliersBusiness();
        private CategoriesBusiness categories = new CategoriesBusiness();
        private BooleanBusiness booleans = new BooleanBusiness();
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
            dataGridView1.Columns[ProductProperties.REORDER_LEVEL].Visible = false;
            //
            drawDataGridViewButtonsManager = new DrawDataGridViewButtonsManager(dataGridView1);
            drawDataGridViewButtonsManager.addEditButton();
            drawDataGridViewButtonsManager.addDeleteButton();
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
            int productID = Convert.ToInt32(dataGridView1[ProductProperties.PRODUCT_ID, e.RowIndex].Value);
            if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_EDIT)
            {                
                drawDataGridViewButtonsManager.eventButtonEdit(productID, products, DialogType.ProductDialog);                                                      
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_DELETE)
            {
                drawDataGridViewButtonsManager.eventButtonDelete(productID, products);
            }

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            drawDataGridViewButtonsManager.drawButtons(e);            
        }

        private void cbxFilterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxFilterValue.Items.Clear();
            switch ( cbxFilterName.SelectedIndex )
            {
                case 1://suppliers
                    {                        
                        cbxFilterValue.Items.AddRange(suppliers.SelectList().ToArray());
                    }; break;
                case 2://categories
                    {                        
                        cbxFilterValue.Items.AddRange(categories.SelectList().ToArray());
                    }; break;
                case 3://booleans
                    {                        
                        cbxFilterValue.Items.AddRange(booleans.SelectList().ToArray());
                    }; break;
            }
            if(cbxFilterValue.Items.Count > 0)
                cbxFilterValue.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filter= string.Empty;
            switch(cbxFilterName.SelectedIndex)
            {
                case 1://suppliers
                    {
                        Supplier supplier = (Supplier)cbxFilterValue.SelectedItem;
                        filter = string.Format("{0}={1}", cbxFilterName.Text, supplier.SupplierID);
                    }; break;
                case 2://categories
                    {
                        Category category = (Category)cbxFilterValue.SelectedItem;
                        filter = string.Format("{0}={1}", cbxFilterName.Text, category.CategoryID);                        
                    }; break;
                case 3://booleans
                    {
                        BoolItem boolItem = (BoolItem)cbxFilterValue.SelectedItem;
                        filter = string.Format("{0}={1}", cbxFilterName.Text, boolItem.Index);                        
                    }; break;
            }
            //label1.Text = filter;
            if(!string.IsNullOrEmpty(filter))
                dataGridView1.DataSource = products.SelectList(filter);
        }
    }
}
