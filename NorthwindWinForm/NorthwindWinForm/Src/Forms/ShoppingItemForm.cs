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
        private ShoppingCartBusiness shoppingCartBusiness;
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
            shoppingCartBusiness = new ShoppingCartBusiness(shoppingCartID);
            dataGridView3.DataSource = shoppingCartBusiness.SelectList();
            //
            drawDataGridViewButtonsManager = new DrawDataGridViewButtonsManager(dataGridView3);
            drawDataGridViewButtonsManager.addEditButton();
            drawDataGridViewButtonsManager.addDeleteButton();
        }
        /*!
         * Create
         */
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var form = new ShoppingCartItemForm(null);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var shoppingCartBusiness = new ShoppingCartBusiness(shoppingCartID);
                shoppingCartBusiness.InsertItem(form.Return);
                dataGridView3.DataSource = shoppingCartBusiness.SelectList();
            }
        }
                
        private void dataGridView3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            drawDataGridViewButtonsManager.drawButtons( e);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int id = Convert.ToInt32(dataGridView3[ShoppingCartItemProperty.SHOPPINGCARTITEM_ID, e.RowIndex].Value);
                if (dataGridView3.Columns[e.ColumnIndex].Name == AppStrings.STR_EDIT)
                {                    
                    drawDataGridViewButtonsManager.eventButtonEdit(id, shoppingCartBusiness, DialogType.ShoppingCartItemDialog);                                                        
                }
                if (dataGridView3.Columns[e.ColumnIndex].Name == AppStrings.STR_DELETE)
                {
                    drawDataGridViewButtonsManager.eventButtonDelete(id, shoppingCartBusiness);
                }                         
            }
        }
    }
}
