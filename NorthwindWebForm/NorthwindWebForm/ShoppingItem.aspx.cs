using NorthwindBusiness.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindWebForm
{
    public partial class ShoppingItem : System.Web.UI.Page
    {
        
        private int shoppingCartID;
        protected void Page_Load(object sender, EventArgs e)
        {
            shoppingCartID = Convert.ToInt32(Request.QueryString["id"]);
            var shoppingCartBusiness = new ShoppingCartBusiness(shoppingCartID);
            if (!IsPostBack)
            {                
                GridView1.DataSource = shoppingCartBusiness.SelectList();
                GridView1.DataBind();
            }
        }
        /*!
         * Novo item no carrinho
         */
        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = string.Format("ShoppingCartItem.aspx?id={0}&cartId={1}", "-1", shoppingCartID);
            Response.Redirect(url);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string url = string.Format("ShoppingCartItem.aspx?id={0}&cartId={1}", e.CommandArgument, shoppingCartID);
                Response.Redirect(url);
            }
            if (e.CommandName == "Delete")
            {
                var shoppingCartBusiness = new ShoppingCartBusiness(shoppingCartID);
                int shoppingCartItemID = Convert.ToInt32(e.CommandArgument);
                shoppingCartBusiness.DeleteItem(shoppingCartItemID);
                GridView1.DataSource = shoppingCartBusiness.SelectList();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = false;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Shopping.aspx");
        }
    }
}