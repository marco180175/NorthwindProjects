using NorthwindBusiness.Src;
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

namespace NorthwindWinForm.Src.Forms.Reports
{
    public partial class CustOrdersDetailForm : Form
    {
        public CustOrdersDetailForm()
        {
            InitializeComponent();

            var orders = new OrdersBusiness();
            List<Order> list = orders.SelectList().Cast<Order>().ToList();

            numericUpDown1.Maximum = (decimal)list.Max(t => t.OrderID);
            numericUpDown1.Minimum = (decimal)list.Min(t => t.OrderID);
            

            numericUpDown1.Value = numericUpDown1.Minimum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var procedureParams = new ProcedureParams("CustOrdersDetail");
            
            procedureParams.Parans.Add(new KeyValuePair<string, object>("@OrderID", numericUpDown1.Value));
            var procedure = new ProcedureBusiness();
            dataGridView1.DataSource = procedure.Execute(procedureParams);
        }
    }
}
