
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NorthwindModel.Models;
using NorthwindBusiness.Src;
using NorthwindWinForm.Src.Forms.Dialogs;

namespace NorthwindWinForm.Src.Forms
{
    public partial class ShoppingForm : Form
    {        
        private ShoppingCartBusiness shoppingCartList = new ShoppingCartBusiness();
        private DrawDataGridViewButtonsManager drawDataGridViewButtonsManager;
        public ShoppingForm(Control parent)
        {
            InitializeComponent();
            //            
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Parent = parent;
            this.Dock = DockStyle.Fill;
            //
            dataGridView1.DataSource = shoppingCartList.SelectList();
            //
            drawDataGridViewButtonsManager = new DrawDataGridViewButtonsManager(dataGridView1);
            drawDataGridViewButtonsManager.AddEditButton();
            drawDataGridViewButtonsManager.AddDeleteButton();
            drawDataGridViewButtonsManager.AddListButton(toolStripButton4_Click);           
        }
        //
        public event ShowListFormEventHandler ShowList;
        /*!
         * Create
         */
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShoppingCartForm form = new ShoppingCartForm(null);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                shoppingCartList.InsertItem(form.Return);
                dataGridView1.DataSource = shoppingCartList.SelectList();
            }
        }
        
        
        /*!
         * list shoppingItem
         */
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            { 
                int shoppingCartID = Convert.ToInt32(dataGridView1[ShoppingCartProperties.SHOPPINGCART_ID, dataGridView1.SelectedRows[0].Index].Value);
                OnShowList(new ShowListFormEventArgs(shoppingCartID));
            }
        }

        private void OnShowList(ShowListFormEventArgs e)
        {
            ShowList?.Invoke(this, e);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            drawDataGridViewButtonsManager.DrawButtons(e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int id = Convert.ToInt32(dataGridView1[ShoppingCartProperties.SHOPPINGCART_ID, e.RowIndex].Value);
                if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_EDIT)
                {
                    EditShopping(id);
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_DELETE)
                {
                    DeleteShopping(id);
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_LIST)
                { 
                    drawDataGridViewButtonsManager.EventButtonList();
                }                
            }
        }

        private void EditShopping(int id)
        {            
            var item = shoppingCartList.SelectItem(id);
            var dialog = new ShoppingCartForm(item);
            //verificar null
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                shoppingCartList.UpdateItem(dialog.Return);
                dataGridView1.DataSource = shoppingCartList.SelectList();
            }
        }

        private void DeleteShopping(int id)
        {
            if (MessageBox.Show(string.Format("{0} {1} ?", AppStrings.STR_CONFIRM_DELETE, id), AppStrings.STR_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var item = shoppingCartList.SelectItem(id);
                shoppingCartList.DeleteItem(id);
                dataGridView1.DataSource = shoppingCartList.SelectList();
            }
        }
    }
}
