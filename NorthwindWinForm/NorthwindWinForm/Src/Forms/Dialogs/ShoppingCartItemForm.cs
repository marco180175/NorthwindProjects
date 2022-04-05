using NorthwindBusiness.Src;
using NorthwindDAO.Src;
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
    
    public partial class ShoppingCartItemForm : Form//, IDialogs
    {
        private ShoppingCartItem shoppingCartItem;
        private int productID;
        private bool fEdit;
        private CategoriesBusiness categories = new CategoriesBusiness();
        private ProductsBusiness products = new ProductsBusiness();
        public ShoppingCartItemForm(object item)
        {
            InitializeComponent();
            shoppingCartItem = new ShoppingCartItem();            
            //
            if (item == null)
            {
                productID = 0;                
                numericUpDown1.Value = 0;
                fEdit = false;
               
                var table = categories.SelectList();
                comboBox1.Items.Add("All");
                comboBox1.Items.AddRange(table.ToArray());                
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                ShoppingCartItem cartItem = (ShoppingCartItem)item;
                productID = cartItem.ProductID;
                shoppingCartItem.ShoppingCartItemID = cartItem.ShoppingCartItemID;
                shoppingCartItem.ProductID = cartItem.ProductID;
                numericUpDown1.Value = Convert.ToDecimal(cartItem.Quantity);
                fEdit = true;
                var product = products.SelectItem(productID);
                var table = categories.SelectList();
                comboBox1.Items.Add("All");
                comboBox1.Items.AddRange(table.ToArray());
                int index = table.FindIndex(x => x.CategoryID == product.CategoryID);
                comboBox1.SelectedIndex = index + 1;                
            }
            
        }

        private void ShoppingCartItemForm_Load(object sender, EventArgs e)
        {           
            dataGridView1.Columns["CategoryID"].Visible = false;
            dataGridView1.Columns["ProductID"].Visible = true;
            dataGridView1.Columns["SupplierID"].Visible = false;
            dataGridView1.Columns["ReorderLevel"].Visible = false;
            dataGridView1.Columns["UnitsOnOrder"].Visible = false;
            dataGridView1.Columns["UnitsInStock"].Visible = false;
            dataGridView1.Columns["Discontinued"].Visible = false;
            dataGridView1.Columns["QuantityPerUnit"].Visible = false;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                dataGridView1.SelectedRows[i].Selected = false;
        }

        public ShoppingCartItem Return { get { return shoppingCartItem; } }
        private bool isValidate=true;
        private List<string> listValidate = new List<string>();
        private new void Validate()
        {
            listValidate.Clear();
            isValidate = true;
            if (productID == 0)
            {
                listValidate.Add("Selecione produto");
                isValidate = false;
            }
            if (numericUpDown1.Value == 0)
            {
                listValidate.Add("Qunatidade deve ser maior que zero");
                isValidate = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Validate();
            if(isValidate)
            { 
                var product = (Product)products.SelectItem(productID);
            
                shoppingCartItem.ProductID = product.ProductID;
                shoppingCartItem.UnitPrice = product.UnitPrice;
                shoppingCartItem.Quantity = Convert.ToDouble(numericUpDown1.Value);
                DialogResult = DialogResult.OK;
            }
            else
            {
                var validationSumary = new ValidateSummaryDialog(listValidate);
                validationSumary.ShowDialog(this);                
            }
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
                
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            products = new ProductsBusiness();
            DataTable table;
            if (comboBox1.SelectedIndex == 0)
            {
                var list = products.SelectList();
                table = CollectionHelper.ConvertTo<Product>(list.Cast<Product>().ToList());
            }
            else
            {
                Category category = (Category)comboBox1.SelectedItem;
                table = CollectionHelper.ConvertTo<Product>(products.SelectListByCategory(category.CategoryID));
            }
            DataView dataView = new DataView(table);
            dataView.Sort = table.Columns[0].ColumnName;
            dataGridView1.DataSource = dataView;

            if (fEdit)
            {
                CurrencyManager currencyManager = (CurrencyManager)dataGridView1.BindingContext[dataView];
                currencyManager.Position = dataView.Find(productID);
                fEdit = false;
            }
            else
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    dataGridView1.SelectedRows[i].Selected = false;
                productID = 0;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            productID = Convert.ToInt32(dataGridView1["ProductID", e.RowIndex].Value);
            //label1.Text ="ProductID = "+ productID.ToString();
        }

        
    }    
}
