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
    public partial class ProductItem : System.Web.UI.Page
    {
        private ProductsBusiness products = new ProductsBusiness();
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            Product product;
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                var supplier = new SuppliersBusiness();
                ddlSupplier.DataSource = supplier.SelectList();
                ddlSupplier.DataTextField = "CompanyName";
                ddlSupplier.DataValueField = "SupplierID";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, new ListItem("Select", "-1"));
                //
                var categories = new CategoriesBusiness();
                ddlCategory.DataSource = categories.SelectList();
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("Select", "-1"));
                //
                if (id == -1)                
                    product = new Product();                
                else
                    product = (Product)products.SelectItem(id);
                //
                SetProductToField(product);
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ddlSupplier.SelectedValue != "-1";
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ddlCategory.SelectedValue != "-1";
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            Product product;
            if (IsValid)
            {
                if (id == -1)
                {
                    product = new Product();
                    GetFieldToProduct(product);
                    products.InsertItem(product);
                }
                else
                {
                    product = (Product)products.SelectItem(id);
                    GetFieldToProduct(product);
                    products.UpdateItem(product);
                }                    
                //
                Response.Redirect("ProductTable.aspx");
            }
        }

        private void SetProductToField(Product product)
        {
            txbProductName.Text = product.ProductName;
            ddlCategory.SelectedValue = product.CategoryID.ToString();
            ddlSupplier.SelectedValue = product.SupplierID.ToString();
            txbQuantityPerUnit.Text = product.QuantityPerUnit;
            txbUnitPrice.Text = product.UnitPrice.ToString();
            txbUnitsInStock.Text = product.UnitsInStock.ToString();
            txbUnitsOnOrder.Text = product.UnitsOnOrder.ToString();
            txbReorderLevel.Text = product.ReorderLevel.ToString();
            ckbDiscontinued.Checked = product.Discontinued;
        }

        private void GetFieldToProduct(Product product)
        {
            product.ProductName = txbProductName.Text ;
            product.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            product.SupplierID = Convert.ToInt32(ddlSupplier.SelectedValue);
            product.QuantityPerUnit = txbQuantityPerUnit.Text;
            product.UnitPrice = Convert.ToDecimal(txbUnitPrice.Text);
            product.UnitsInStock = Convert.ToInt16(txbUnitsInStock.Text);
            product.UnitsOnOrder = Convert.ToInt16(txbUnitsOnOrder.Text);
            product.ReorderLevel = Convert.ToInt16(txbReorderLevel.Text);
            product.Discontinued = ckbDiscontinued.Checked;
        }

        protected void btExit_Click(object sender, EventArgs e)
        {
            //
            Response.Redirect("ProductTable.aspx");
        }
    }
}