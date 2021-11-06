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
    public partial class TenMostExpensiveProductsForm : Form
    {
        public TenMostExpensiveProductsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var procedureParams = new ProcedureParams("Ten Most Expensive Products");            
            var procedure = new ProcedureBusiness();
            dataGridView1.DataSource = procedure.Execute(procedureParams);
        }
    }
}
