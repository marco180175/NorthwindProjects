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
    public partial class CategoryForm : Form, IDialogs
    {
        Category category = new Category();
        public CategoryForm(object item)
        {
            InitializeComponent();
            category = (Category)item;
            if (category != null)
            {
                this.category.CategoryID = category.CategoryID;
                tbCategoryName.Text = category.CategoryName;
                tbDescription.Text = category.Description;
            }
        }

        public object Return { get { return category; } }

        private void button1_Click(object sender, EventArgs e)
        {
            category.CategoryName = tbCategoryName.Text;
            category.Description = tbDescription.Text;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
