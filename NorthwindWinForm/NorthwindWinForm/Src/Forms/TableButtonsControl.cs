using NorthwindBusiness.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWinForm.Src.Forms
{
    public class TableButtonsControl
    {
        private DataGridView dataGridView;
        private ICustomBusiness customBusiness;
        private Type formType;
        public TableButtonsControl(DataGridView dataGridView, ICustomBusiness customBusiness,Type formType)
        {
            this.dataGridView = dataGridView;
            this.customBusiness = customBusiness;
            this.formType = formType;
            DataGridViewButtonColumn buttonEdit = new DataGridViewButtonColumn();
            buttonEdit.Name = AppStrings.STR_EDIT;
            dataGridView.Columns.Add(buttonEdit);

            DataGridViewButtonColumn buttonDelete = new DataGridViewButtonColumn();
            buttonDelete.Name = AppStrings.STR_DELETE;
            dataGridView.Columns.Add(buttonDelete);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int categoryID = Convert.ToInt32(dataGridView["CategoryID", e.RowIndex].Value);
                if (dataGridView.Columns[e.ColumnIndex].Name == AppStrings.STR_EDIT)
                {
                    var category = customBusiness.SelectItem(categoryID);
                    Form categoryForm = new formType(category);
                    if (categoryForm.ShowDialog(this) == DialogResult.OK)
                    {
                        customBusiness.UpdateItem(categoryForm.Return);
                        dataGridView.DataSource = customBusiness.SelectList();
                    }
                }
                if (dataGridView.Columns[e.ColumnIndex].Name == AppStrings.STR_DELETE)
                {
                    if (MessageBox.Show(this, string.Format("Confirm delete Category {0} ?", categoryID),
                        AppStrings.STR_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        customBusiness.DeleteItem(categoryID);
                        dataGridView.DataSource = customBusiness.SelectList();
                    }
                }
            }
        }
    }
}
