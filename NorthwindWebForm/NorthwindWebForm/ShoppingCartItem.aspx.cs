using NorthwindBusiness.Src;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindWebForm
{
    public partial class ShoppingCartItem : System.Web.UI.Page
    {
        private ProductsBusiness products = new ProductsBusiness();        
        private int shoppingCartID, shoppingCartItemID;
        protected void Page_Load(object sender, EventArgs e)
        {
            shoppingCartItemID = Convert.ToInt32(Request.QueryString["id"]);
            shoppingCartID = Convert.ToInt32(Request.QueryString["cartId"]);
            if (!IsPostBack)
            {
                //Popula categories
                var categories = new CategoriesBusiness();               
                ddlCategories.DataSource = categories.SelectList(); 
                ddlCategories.DataTextField = "CategoryName";
                ddlCategories.DataValueField = "CategoryID";                
                ddlCategories.DataBind();
                ddlCategories.Items.Insert(0, new ListItem("All", "0"));
                //Carrega objeto para edição
                if (shoppingCartItemID != -1)
                {
                    var shoppingCartBusiness = new ShoppingCartItemBusiness(shoppingCartID);
                    var shoppingCartItem = shoppingCartBusiness.SelectItem(shoppingCartItemID);
                    tbQuantity.Text = shoppingCartItem.Quantity.ToString();
                    //Seleciona category
                    var product = (Product)products.SelectItem(shoppingCartItem.ProductID);
                    ddlCategories.SelectedValue = product.CategoryID.ToString();
                    //Seleciona produto
                    //gdvProducts.DataSource = products.SelectListByCategory(product.CategoryID);
                    //gdvProducts.DataBind();
                    //Seleciona no gridview
                   // GridViewSelectRowByProductyID(product.ProductID);
                }
                else
                {
                   // gdvProducts.DataSource = products.SelectList();
                   // gdvProducts.DataBind();
                }
            }
            //
            if (ProdutosModalPopup1.IsShowing)
            {
                ProdutosModalPopup1.Selecionar += new EventHandler(ProdutosModalPopup1_Selecionar);
                ProdutosModalPopup1.Show();
            }
        }

        private void GridViewSelectRowByProductyID(int productID)
        {
            //List<Product> table = (List<Product>)gdvProducts.DataSource;
            //for (int i = 0; i < gdvProducts.PageCount; i++)
            //{
            //    gdvProducts.PageIndex = i;
            //    gdvProducts.DataBind();
            //    int k = i * gdvProducts.PageSize;
            //    for (int j = 0; j < gdvProducts.PageSize; j++)
            //    {
            //        if ((k + j) < table.Count)
            //        {
            //            if (table[0].productID == productID)
            //            {
            //                gdvProducts.SelectedIndex = j;
            //                break;
            //            }
            //        }
            //        else
            //            break;                  
            //    }
            //    break;
            //}
            //GridView1_SelectedIndexChanged(null, EventArgs.Empty);
        }
        static int categoryID=0;
        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryID = Convert.ToInt32(ddlCategories.SelectedValue);
            //if(categoryID == 0)
            //    gdvProducts.DataSource = products.SelectList();
            //else
            //    gdvProducts.DataSource = products.SelectListByCategory(categoryID);
            //gdvProducts.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ProdutosModalPopup1.Selecionar += new EventHandler(ProdutosModalPopup1_Selecionar);
            ProdutosModalPopup1.Show(categoryID);
        }

        private void ProdutosModalPopup1_Selecionar(object sender, EventArgs e)
        {
            int productId = ProdutosModalPopup1.PoductId;
            var product = (Product)products.SelectItem(productId);
            TextBox1.Text = product.ProductID.ToString();
            TextBox2.Text = product.UnitPrice.ToString();
            Session["product"] = products.SelectItem(productId);
        }

        private void ProdutosModalPopup1_Cancelar(object sender, EventArgs e)
        {
            
        }


        protected void btSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Session["product"] != null)
                {
                    //Insert novo item
                    if (shoppingCartItemID == -1)
                    {
                        Product product = (Product)Session["product"];
                        var shoppingCartItem = new NorthwindModel.Models.ShoppingCartItem();
                        shoppingCartItem.ProductID = product.ProductID;
                        shoppingCartItem.UnitPrice = product.UnitPrice;
                        shoppingCartItem.Quantity = Convert.ToInt32(tbQuantity.Text);
                        var shoppingCartBusiness = new ShoppingCartItemBusiness(shoppingCartID);
                        shoppingCartBusiness.InsertItem(shoppingCartItem);
                        Response.Redirect("ShoppingItem.aspx?id=" + shoppingCartID.ToString());
                    }
                    //Update current item
                    else
                    {
                        var shoppingCartBusiness = new ShoppingCartItemBusiness(shoppingCartID);
                        Product product = (Product)Session["product"];
                        var shoppingCartItem = shoppingCartBusiness.SelectItem(shoppingCartItemID);
                        shoppingCartItem.ProductID = product.ProductID;
                        shoppingCartItem.UnitPrice = product.UnitPrice;
                        shoppingCartItem.Quantity = Convert.ToInt32(tbQuantity.Text);
                        shoppingCartBusiness.UpdateItem(shoppingCartItem);
                        Response.Redirect("ShoppingItem.aspx?id=" + shoppingCartID.ToString());
                    }
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                    //    "err_msg", "alert('Select a product from the list!)');", true);
                }
            }
        }

        

        protected void btExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingItem.aspx?id=" + shoppingCartID.ToString());
        }

        
    }
}