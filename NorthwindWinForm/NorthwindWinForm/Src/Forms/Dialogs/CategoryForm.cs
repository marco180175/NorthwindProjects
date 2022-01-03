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
        Category category;
        public CategoryForm(object item)
        {
            InitializeComponent();            
            if (item != null)
            {
                category = (Category)item;                
                tbCategoryName.Text = category.CategoryName;
                tbDescription.Text = category.Description;
            }
            else
            {
                category = new Category();
            }
        }

        public object Return { get { return category; } }
        private bool isValidate = false;
        List<string> listValidate = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            Validate();
            if (isValidate)
            {
                category.CategoryName = tbCategoryName.Text;
                category.Description = tbDescription.Text;
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

        private new void Validate()
        {
            listValidate.Clear();
            isValidate = true;
            //
            if (string.IsNullOrEmpty(tbCategoryName.Text))
            {
                isValidate = false;
                listValidate.Add("CategoryName is empty.");
            }
            //
            if (string.IsNullOrEmpty(tbDescription.Text))
            {
                isValidate = false;
                listValidate.Add("Description is empty.");
            }
            //
            if (tbCategoryName.Text.Length > 50)
            {
                isValidate = false;
                listValidate.Add("CategoryName deve ter maximo 15.");
            }
            //
            if (tbDescription.Text.Length > 100)
            {
                isValidate = false;
                listValidate.Add("Description deve ter maximo 100.");
            }            
        }
    }
}
