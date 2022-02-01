using NorthwindBusiness.Src;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindWebForm
{
    public partial class ProductTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var products = new ProductsBusiness();
                GridView1.DataSource = products.SelectList();
                GridView1.DataBind();

                ddlFilterName.Items.Add("None");
                ddlFilterName.Items.Add(ProductProperties.SUPPLIER_ID);
                ddlFilterName.Items.Add(ProductProperties.CATEGORY_ID);
                ddlFilterName.Items.Add(ProductProperties.DISCONTINUED);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductForm.aspx?id=0");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("ProductForm.aspx?id=" + e.CommandArgument);
            }
            
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                //shopingCartList.Delete(shoppingCartId);
                //GridView1.DataSource = shopingCartList.SelectList();
                //GridView1.DataBind();
            }
        }

        protected void ddlFilterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlFilterValue.Items.Clear();
            switch (ddlFilterName.SelectedIndex)
            {
                case 1://suppliers
                    {
                        SuppliersBusiness suppliers = new SuppliersBusiness();
                        ddlFilterValue.DataSource = suppliers.SelectList();                        
                        ddlFilterValue.DataValueField = "SupplierID";
                        ddlFilterValue.DataTextField = "CompanyName";
                        ddlFilterValue.DataBind();
                    }; break;
                case 2://categories
                    {
                        CategoriesBusiness categories = new CategoriesBusiness();
                        ddlFilterValue.DataSource = categories.SelectList();                        
                        ddlFilterValue.DataValueField = "CategoryID";
                        ddlFilterValue.DataTextField = "CategoryName";
                        ddlFilterValue.DataBind();
                    }; break;
                case 3://booleans
                    {
                        BooleanBusiness booleans = new BooleanBusiness();
                        ddlFilterValue.DataSource = booleans.SelectList();                        
                        ddlFilterValue.DataValueField = "Index";
                        ddlFilterValue.DataTextField = "Name";
                        ddlFilterValue.DataBind();
                    }; break;
            }            
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            var products = new ProductsBusiness();
            string filter = string.Empty;
            if (ddlFilterName.SelectedIndex > 0)
            {                                       
                filter = string.Format("{0}={1}", ddlFilterName.Text, ddlFilterValue.SelectedValue);
                if (!string.IsNullOrEmpty(filter))
                {                    
                    GridView1.DataSource = products.SelectList(filter);
                    GridView1.DataBind();
                }
            }            
            else 
            {                
                GridView1.DataSource = products.SelectList();
                GridView1.DataBind();
            }
        }
    }
}