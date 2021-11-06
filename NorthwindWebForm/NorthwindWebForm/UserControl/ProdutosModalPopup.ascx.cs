using NorthwindBusiness.Src;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindWebForm.UserControl
{
    public partial class ProdutosModalPopup : System.Web.UI.UserControl
    {
        private ProductsBusiness products = new ProductsBusiness();
        private static int ctgId = 0;
        private static bool isShowing = false;
        private static int productId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SelectProducts(GridView1);
            }
        }

        public bool IsShowing { get { return isShowing; } }

        public void Show()
        {                
            ModalPopupExtender1.Show();
        }

        public void Show(int categoryID)
        {
            btnSelecionar.Enabled = false;
            productId = 0;
            isShowing = true;
            ctgId = categoryID;
            SelectProducts(GridView1);                   
            ModalPopupExtender1.Show();
        }

        private void SelectProducts(GridView gridView)
        {
            if (ctgId == 0)
                gridView.DataSource = products.SelectList();
            else
                gridView.DataSource = products.SelectListByCategory(ctgId);
            gridView.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var gridView = (GridView)sender;
            gridView.PageIndex = e.NewPageIndex;
            SelectProducts(gridView);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var gridView = (GridView)sender;
            foreach (GridViewRow row in gridView.Rows)
            {
                if (row.RowIndex == gridView.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                productId = Convert.ToInt32(e.CommandArgument);
                btnSelecionar.Enabled = true;
            }
        }

        public event EventHandler Selecionar;

        public event EventHandler Cancelar;

        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            isShowing = false;
            ModalPopupExtender1.Hide();
            if (Selecionar != null)
                Selecionar(this, e);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            isShowing = false;
            ModalPopupExtender1.Hide();
            if (Cancelar != null)
                Cancelar(this, e);
        }

        public int PoductId { get { return productId; } }
    }
}