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
        private Product product;
        protected void Page_Load(object sender, EventArgs e)
        {            
            id = Convert.ToInt32(Request.QueryString["id"]);
            //
            if (id == 0)
                product = null;
            else
                product = (Product)products.SelectItem(id);
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
                SetProductToField();
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
            Validate();
            if (IsValid)
            {
                if (id == 0)
                {
                    product = new Product();
                    GetFieldToProduct();
                    products.InsertItem(product);
                }
                else
                {
                    product = (Product)products.SelectItem(id);
                    GetFieldToProduct();
                    products.UpdateItem(product);
                }                    
                //
                Response.Redirect("ProductsForm.aspx");
            }
            else
            {
                ctlValidacaoModalPopup1.Show(Page);
            }
        }

        private void SetProductToField()
        {
            if (product != null)
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
        }

        private void GetFieldToProduct()
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
            Response.Redirect("ProductsForm.aspx");
        }
    }
}