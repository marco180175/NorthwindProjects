
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

namespace NorthwindWinForm.Src.Forms
{
    public partial class ProceduresForm : Form
    {
        private ProcedureParams procedureParams;
        public ProceduresForm()
        {
            InitializeComponent();            
            ////
            //procedureParams = new ProcedureParams("CustOrderHist");
            ////sp.ProcedureError += Sp_ProcedureError;
            //procedureParams.Parans.Add(new KeyValuePair<string, object>("@CustomerID", "ALFKI"));            
            //tscbProcudures.Items.Add(procedureParams);
            //
            procedureParams = new ProcedureParams("CustOrdersDetail");
            //sp.ProcedureError += Sp_ProcedureError;
            procedureParams.Parans.Add(new KeyValuePair<string, object>("@OrderID", 1));            
            tscbProcudures.Items.Add(procedureParams);
            //
            procedureParams = new ProcedureParams("CustOrdersOrders");
            //sp.ProcedureError += Sp_ProcedureError;
            procedureParams.Parans.Add(new KeyValuePair<string, object>("@CustomerID", "TOMSP"));            
            tscbProcudures.Items.Add(procedureParams);
            //
            procedureParams = new ProcedureParams("Employee Sales by Country");
            //sp.ProcedureError += Sp_ProcedureError;
            procedureParams.Parans.Add(new KeyValuePair<string, object>("@Beginning_Date", Convert.ToDateTime("01 / 06 / 2020")));
            procedureParams.Parans.Add(new KeyValuePair<string, object>("@Ending_Date", Convert.ToDateTime("07 / 06 / 2020")));
            tscbProcudures.Items.Add(procedureParams);
        }

        //private void Sp_ProcedureError(object sender, StoredProcedureEventArgs e)
        //{
        //    MessageBox.Show(e.Message);
        //}
        
        private void tscbProcudures_SelectedIndexChanged(object sender, EventArgs e)
        {
            procedureParams = (ProcedureParams)tscbProcudures.SelectedItem;
        }

        private void tsbRunProcedure_Click(object sender, EventArgs e)
        {
            var procedure = new ProcedureBusiness();
            dataGridView1.DataSource = procedure.Execute(procedureParams);
        }
    }
}
