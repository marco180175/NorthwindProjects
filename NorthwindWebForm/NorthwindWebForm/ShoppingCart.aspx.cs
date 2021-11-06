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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        private const string RETURN_PAGE = "Shopping.aspx";
        private ShoppingCartListBusiness shoppingCartList = new ShoppingCartListBusiness();
        private int shoppingCartID;
        private NorthwindModel.Models.ShoppingCart shoppingCart;
        protected void Page_Load(object sender, EventArgs e)
        {            
            //
            shoppingCartID = Convert.ToInt32(Request.QueryString["id"]);
            if (shoppingCartID == -1)
                shoppingCart = new NorthwindModel.Models.ShoppingCart();
            else
                shoppingCart = (NorthwindModel.Models.ShoppingCart)shoppingCartList.SelectItem(shoppingCartID);
            //
            if (!IsPostBack)
            {
                var customers = new CustomersBusiness();
                var list = customers.SelectList();

                ddlCustomerID.DataSource = list;
                ddlCustomerID.DataTextField = "CompanyName";
                ddlCustomerID.DataValueField = "CustomerID";
                ddlCustomerID.DataBind();
                ddlCustomerID.Items.Insert(0, "Select...");
                ddlCustomerID.SelectedValue = shoppingCart.CustomerID;
                if(shoppingCart.PurchaseDate.HasValue)
                    tbDate.Text = shoppingCart.PurchaseDate.Value.ToString("dd/MM/yyyy");
                tbDescription.Text = shoppingCart.Description;
                //string function = string.Format("counterCharacter('{0}','{1}',{2})",
                //    tbDescription.ClientID,
                //    lbDescriptionCount.ClientID,
                //    tbDescription.MaxLength);
                //tbDescription.Attributes["OnKeyUp"] = function;
                ContaCaracter1.SetInput(tbDescription);

            }
            //
            //lbDescriptionCount.Text = string.Format("{0} / {1} caracteres", tbDescription.Text.Length, tbDescription.MaxLength);            
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            Validate();
            if (Page.IsValid)
            {
                shoppingCart.CustomerID = ddlCustomerID.SelectedValue;
                shoppingCart.PurchaseDate = Convert.ToDateTime(tbDate.Text);
                shoppingCart.Description = tbDescription.Text;
                if (shoppingCartID == -1)
                    shoppingCartList.InsertItem(shoppingCart);
                else
                    shoppingCartList.UpdateItem(shoppingCart);
                //
                Response.Redirect(RETURN_PAGE);
            }
            else
            {
                ctlValidacaoModalPopup1.Show(Page);
            }
        }

        protected void btExit_Click(object sender, EventArgs e)
        {
            Response.Redirect(RETURN_PAGE);
        }

        protected void cvCustomerID_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !(args.Value == "Select...");            
        }

        protected void cvDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var customValidator = (CustomValidator)source;
            if ((args.Value == "__/__/____"))
            {
                args.IsValid = false;
                customValidator.ErrorMessage = "Insira data.";
            }
            else
            {
                args.IsValid = ValidaDataBrasil.Valida(args.Value);
                customValidator.ErrorMessage = ValidaDataBrasil.Mensagem;
            }
        }

        protected void cvDescription_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var customValidator = (CustomValidator)source;
            
            if(args.Value.Length > tbDescription.MaxLength)
            {
                args.IsValid = false;
                customValidator.ErrorMessage = string.Format("Digite no maximo {0} caracteres.", tbDescription.MaxLength);
            }                      
        }        
    }
}