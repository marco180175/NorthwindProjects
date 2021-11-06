using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NorthwindWebForm.ReportLibrary;

namespace NorthwindWebForm
{
    public partial class ReportForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //    GeneratePDF();
            if (!IsPostBack)
            {
                ReportCategory reportCategory = new ReportCategory("CATEGORY");
            }
        }
        protected void GeneratePDF()
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                PdfWriter pdfWriter = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                Chunk chunk = new Chunk("This is from Chunk.");
                document.Add(chunk);

                Phrase phrase = new Phrase("This is from Phrase.");
                document.Add(phrase);

                Paragraph para = new Paragraph("This is from paragraph.");
                document.Add(para);

                string text = @"you are successfully created PDF file.";
                Paragraph paragraph = new Paragraph();
                paragraph.SpacingBefore = 10;
                paragraph.SpacingAfter = 10;
                paragraph.Alignment = Element.ALIGN_LEFT;
                paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
                paragraph.Add(text);
                document.Add(paragraph);
                document.Close();//1
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                Response.Clear();
                string pdfName = "User";
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "inline; filename=" + pdfName + ".pdf");//abre em outra aba
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");//salva
                Response.Buffer = true;
                Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
                Response.Close();//2
            }
        }
    }
}