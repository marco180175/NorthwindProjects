using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using NorthwindWebForm.ReportLibrary;

namespace NorthwindWebForm
{
    public partial class CategoryReportyWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ReportCategory reportCategory = new ReportCategory("CATEGORY");
                //NorthwindDAO northwind = new NorthwindDAO();
                //var table = northwind.CategoriesSelect();
                //ReportViewer1.Reset();
                //ReportDataSource reportDataSource = new ReportDataSource("DataSet1",table);
                //ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                //ReportViewer1.LocalReport.ReportPath = @"Reports\CategoryReport.rdlc";
                //ReportViewer1.LocalReport.Refresh();
            }
        }        
    }
}