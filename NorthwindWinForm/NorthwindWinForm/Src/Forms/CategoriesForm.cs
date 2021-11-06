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
    public partial class CategoriesForm : Form
    {
        private CategoriesBusiness categories = new CategoriesBusiness();
        private DrawDataGridViewButtonsManager drawDataGridViewButtonsManager;
        public CategoriesForm(Control parent)
        {
            InitializeComponent();
            //            
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Parent = parent;
            this.Dock = DockStyle.Fill;
            //            
            dataGridView1.DataSource = categories.SelectList();
            //
            drawDataGridViewButtonsManager = new DrawDataGridViewButtonsManager(dataGridView1);
            drawDataGridViewButtonsManager.addEditButton();
            drawDataGridViewButtonsManager.addDeleteButton();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int categoryID = Convert.ToInt32(dataGridView1[CategoryProperties.CATEGORY_ID, e.RowIndex].Value);
            if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_EDIT)
            {                
                drawDataGridViewButtonsManager.eventButtonEdit(categoryID, categories, DialogType.CategoryDialog);                                                    
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_DELETE)
            {
                drawDataGridViewButtonsManager.eventButtonDelete(categoryID, categories);
            }            
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var categoryForm = new CategoryForm(null);
            if (categoryForm.ShowDialog(this) == DialogResult.OK)
            {
                categories.InsertItem(categoryForm.Return);
                dataGridView1.DataSource = categories.SelectList();
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            drawDataGridViewButtonsManager.drawButtons( e);            
        }        
    }
}
