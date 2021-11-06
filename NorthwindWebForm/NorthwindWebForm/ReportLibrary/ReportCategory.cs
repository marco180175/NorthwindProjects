using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;


namespace NorthwindWebForm.ReportLibrary
{
    public class ReportCategory
    {
        private string m_reportName;
        public ReportCategory(string reportName)
        {
            m_reportName = reportName;
            ReportRender();
        }
        private void ReportRender()
        {
            //NorthwindDAO northwind = new NorthwindDAO();
            //var table = northwind.CategoriesSelect();//param
            ////
            //LocalReport report = new LocalReport();
            //ReportDataSource reportDataSource = new ReportDataSource("DataSet1", table);
            //report.DataSources.Add(reportDataSource);
            //report.ReportPath = @"Reports\CategoryReport.rdlc";//param
            ////
            //Warning[] warning;
            //string mime;
            //string encoding;
            //string extension;
            //string[] streaming;
            //byte[] context = report.Render("PDF", null, out mime, out encoding, out extension, out streaming, out warning);
            ////
            //HttpContext.Current.Response.Clear();            
            //HttpContext.Current.Response.ContentType = "application/pdf";
            //HttpContext.Current.Response.AddHeader("content-disposition", "inline; filename=" + m_reportName + ".pdf");           
            //HttpContext.Current.Response.BinaryWrite(context);
            //HttpContext.Current.Response.Flush();
            //HttpContext.Current.Response.End();
        }        
    }
}