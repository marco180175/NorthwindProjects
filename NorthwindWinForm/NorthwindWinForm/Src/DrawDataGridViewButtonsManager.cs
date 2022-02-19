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
    public sealed class DrawDataGridViewButtonsManager
    {
        private DataGridView dataGridView;

        public DrawDataGridViewButtonsManager(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        public void AddEditButton()
        {
            //Button edit
            DataGridViewButtonColumn buttonEdit = new DataGridViewButtonColumn();
            buttonEdit.Name = AppStrings.STR_EDIT;
            dataGridView.Columns.Add(buttonEdit);            
        }

        public void AddDeleteButton()
        {            
            //Button delete
            DataGridViewButtonColumn buttonDelete = new DataGridViewButtonColumn();
            buttonDelete.Name = AppStrings.STR_DELETE;
            dataGridView.Columns.Add(buttonDelete);
        }

        public void AddListButton(EventHandler eventList)
        {
            //Button edit
            DataGridViewButtonColumn buttonList = new DataGridViewButtonColumn();
            buttonList.Name = AppStrings.STR_LIST;
            dataGridView.Columns.Add(buttonList);
            ShowList += new EventHandler(eventList);
        }

        public void DrawButtons(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > -1)
            {
                if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (dataGridView.Columns[e.ColumnIndex].Name == AppStrings.STR_EDIT)
                        DrawStringButtonText(AppStrings.STR_EDIT, dataGridView.Font, e);
                    if (dataGridView.Columns[e.ColumnIndex].Name == AppStrings.STR_DELETE)
                        DrawStringButtonText(AppStrings.STR_DELETE, dataGridView.Font, e);
                    if (dataGridView.Columns[e.ColumnIndex].Name == AppStrings.STR_LIST)
                        DrawStringButtonText(AppStrings.STR_LIST, dataGridView.Font, e);
                    e.Handled = true;
                }
            }
        }

        private void DrawStringButtonText(string text,Font font, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            SizeF sizeStr = e.Graphics.MeasureString(text, font);
            var x = e.CellBounds.Left + (e.CellBounds.Width - sizeStr.Width) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - sizeStr.Height) / 2;
            e.Graphics.DrawString(text, font, new SolidBrush(Color.Black), x, y);
        }

        private event EventHandler ShowList;       

        public void EventButtonList()
        {
            OnShowList(EventArgs.Empty);
        }

        private void OnShowList(EventArgs e)
        {
            ShowList?.Invoke(this, e);
        }


    }
}
