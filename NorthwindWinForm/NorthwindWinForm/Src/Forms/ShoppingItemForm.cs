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
    public partial class ShoppingItemForm : Form
    {
        private ShoppingCartItemBusiness shoppingCartItemBusiness;
        private int shoppingCartID;
        private DrawDataGridViewButtonsManager drawDataGridViewButtonsManager;
        public ShoppingItemForm(Control parent,int shoppingCartID)
        {
            InitializeComponent();
            //            
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Parent = parent;
            this.Dock = DockStyle.Fill;
            //
            this.shoppingCartID = shoppingCartID;
            shoppingCartItemBusiness = new ShoppingCartItemBusiness(shoppingCartID);
            dataGridView1.DataSource = shoppingCartItemBusiness.SelectList();
            //
            drawDataGridViewButtonsManager = new DrawDataGridViewButtonsManager(dataGridView1);
            drawDataGridViewButtonsManager.AddEditButton();
            drawDataGridViewButtonsManager.AddDeleteButton();
        }
        /*!
         * Create
         */
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var form = new ShoppingCartItemForm(null);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var shoppingCartItemBusiness = new ShoppingCartItemBusiness(shoppingCartID);
                shoppingCartItemBusiness.InsertItem(form.Return);
                dataGridView1.DataSource = shoppingCartItemBusiness.SelectList();
            }
        }
                
        private void dataGridView3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            drawDataGridViewButtonsManager.DrawButtons( e);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int id = Convert.ToInt32(dataGridView1[ShoppingCartItemProperty.SHOPPINGCARTITEM_ID, e.RowIndex].Value);
                if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_EDIT)
                {
                    EditShopping(id);
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_DELETE)
                {
                    DeleteShopping(id);
                }                         
            }
        }

        private void EditShopping(int id)
        {
            var item = (IShoppingCartItem)shoppingCartItemBusiness.SelectItem(id);
            var dialog = new ShoppingCartItemForm(item);
            //verificar null
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                shoppingCartItemBusiness.UpdateItem(dialog.Return);
                dataGridView1.DataSource = shoppingCartItemBusiness.SelectList();
            }
        }

        public void DeleteShopping(int id)
        {
            if (MessageBox.Show(string.Format("{0} {1} ?", AppStrings.STR_CONFIRM_DELETE, id), AppStrings.STR_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                shoppingCartItemBusiness.DeleteItem(id);
                dataGridView1.DataSource = shoppingCartItemBusiness.SelectList();
            }
        }
    }
}
