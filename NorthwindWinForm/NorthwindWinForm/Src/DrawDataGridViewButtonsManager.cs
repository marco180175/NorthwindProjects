using NorthwindBusiness.Src;
using NorthwindWinForm.Src.Forms.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWinForm.Src
{
    public enum DialogType
    {
        CategoryDialog,
        OrderDialog,
        ProductDialog,
        ShoppingCartDialog,
        ShoppingCartItemDialog,
    }

    public sealed class DrawDataGridViewButtonsManager
    {
        private DataGridView dataGridView;

        public DrawDataGridViewButtonsManager(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        public void addEditButton()
        {
            //Button edit
            DataGridViewButtonColumn buttonEdit = new DataGridViewButtonColumn();
            buttonEdit.Name = AppStrings.STR_EDIT;
            dataGridView.Columns.Add(buttonEdit);            
        }

        public void addDeleteButton()
        {            
            //Button delete
            DataGridViewButtonColumn buttonDelete = new DataGridViewButtonColumn();
            buttonDelete.Name = AppStrings.STR_DELETE;
            dataGridView.Columns.Add(buttonDelete);
        }

        public void addListButton(EventHandler eventList)
        {
            //Button edit
            DataGridViewButtonColumn buttonList = new DataGridViewButtonColumn();
            buttonList.Name = AppStrings.STR_LIST;
            dataGridView.Columns.Add(buttonList);
            ShowList += new EventHandler(eventList);
        }

        public void drawButtons(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > -1)
            {
                if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (dataGridView.Columns[e.ColumnIndex].Name == AppStrings.STR_EDIT)
                        drawStringButtonText(AppStrings.STR_EDIT, dataGridView.Font, e);
                    if (dataGridView.Columns[e.ColumnIndex].Name == AppStrings.STR_DELETE)
                        drawStringButtonText(AppStrings.STR_DELETE, dataGridView.Font, e);
                    if (dataGridView.Columns[e.ColumnIndex].Name == AppStrings.STR_LIST)
                        drawStringButtonText(AppStrings.STR_LIST, dataGridView.Font, e);
                    e.Handled = true;
                }
            }
        }

        private void drawStringButtonText(string text,Font font, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            SizeF sizeStr = e.Graphics.MeasureString(text, font);
            var x = e.CellBounds.Left + (e.CellBounds.Width - sizeStr.Width) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - sizeStr.Height) / 2;
            e.Graphics.DrawString(text, font, new SolidBrush(Color.Black), x, y);
        }

        private event EventHandler ShowList;

        private IDialogs dialogFactory(int id, ICustomBusiness business, DialogType dialogType)
        {
            object item = business.SelectItem(id);
            switch (dialogType)
            {
                case DialogType.CategoryDialog:
                    return new CategoryForm(item);
                    
                case DialogType.OrderDialog:
                    return new OrderFieldForm(item);
                    
                case DialogType.ProductDialog:
                    return new ProductForm(item);
                    
                case DialogType.ShoppingCartDialog:
                    return new ShoppingCartForm(item);
                    
                case DialogType.ShoppingCartItemDialog:
                    return new ShoppingCartItemForm(item);                    
                default:
                    return  null;
                    
            }
        }

        public void eventButtonEdit(int id, ICustomBusiness business, DialogType dialogType)
        {
            IDialogs dialog = dialogFactory(id, business, dialogType);           
            //verificar null
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                business.UpdateItem(dialog.Return);
                dataGridView.DataSource = business.SelectList();
            }
        }

        public void eventButtonDelete(int id, ICustomBusiness business)
        {            
            if (MessageBox.Show(string.Format("{0} {1} ?", AppStrings.STR_CONFIRM_DELETE, id), AppStrings.STR_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                business.DeleteItem(id);
                dataGridView.DataSource = business.SelectList();
            }            
        }

        public void eventButtonList()
        {            
            OnShowList(EventArgs.Empty);            
        }

        private void OnShowList(EventArgs e)
        {
            ShowList?.Invoke(this, e);
        }
    }
}
