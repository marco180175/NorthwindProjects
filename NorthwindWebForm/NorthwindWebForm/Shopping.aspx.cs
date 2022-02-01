using NorthwindBusiness.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindWebForm
{
    public partial class Shopping : System.Web.UI.Page
    {
        private ShoppingCartListBusiness shopingCartList = new ShoppingCartListBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = shopingCartList.SelectList();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("ShoppingCart.aspx?id=" + e.CommandArgument);
            }
            if (e.CommandName == "List")
            {
                Response.Redirect("ShoppingItem.aspx?id=" + e.CommandArgument);
            }
            if (e.CommandName == "Delete")
            {
                int shoppingCartId = Convert.ToInt32(e.CommandArgument);
                //shopingCartList.Delete(shoppingCartId);
                GridView1.DataSource = shopingCartList.SelectList();
                GridView1.DataBind();
            }
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx?id=0");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = false;
        }
    }
}