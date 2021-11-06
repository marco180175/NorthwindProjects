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
    public partial class SalesbyYearForm : Form
    {
        public SalesbyYearForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var procedureParams = new ProcedureParams("Sales by Year");
            procedureParams.Parans.Add(new KeyValuePair<string, object>("@Beginning_Date", dateTimePicker1.Value.ToString("yyyyMMdd")));
            procedureParams.Parans.Add(new KeyValuePair<string, object>("@Ending_Date", dateTimePicker2.Value.ToString("yyyyMMdd")));
            var procedure = new ProcedureBusiness();
            dataGridView1.DataSource = procedure.Execute(procedureParams);
        }       
    }
}
