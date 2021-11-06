using NorthwindBusiness.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWinForm.Src.Forms.Reports
{
    public partial class SalesByCategoryForm : Form
    {
        public SalesByCategoryForm()
        {
            InitializeComponent();
            var categories = new CategoriesBusiness();
            var list = categories.SelectList();
            comboBox1.Items.AddRange(list.ToArray());            
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var procedureParams = new ProcedureParams("SalesByCategory");
            procedureParams.Parans.Add(new KeyValuePair<string, object>("@CategoryName", comboBox1.Text));
            procedureParams.Parans.Add(new KeyValuePair<string, object>("@OrdYear", numericUpDown1.Value));
            var procedure = new ProcedureBusiness();
            dataGridView1.DataSource = procedure.Execute(procedureParams);
        }
    }
}
