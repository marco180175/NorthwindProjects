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
    public partial class CustOrderHistForm : Form
    {
        public CustOrderHistForm()
        {
            InitializeComponent();
            var customers = new CustomersBusiness();
            var list = customers.SelectList();
            foreach(var item in list)
                comboBox1.Items.Add(item.CustomerID);
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var procedureParams = new ProcedureParams("CustOrderHist");
            procedureParams.Parans.Add(new KeyValuePair<string, object>("@CustomerID", comboBox1.Text));
            var procedure = new ProcedureBusiness();
            dataGridView1.DataSource = procedure.Execute(procedureParams);
        }
    }
}
