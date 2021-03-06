
using NorthwindBusiness.Src;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWinForm.Src.Forms.Dialogs
{
    public partial class ShoppingCartForm : Form//, IDialogs
    {
        private const string STR_SELECT = "Select...";
        private ShoppingCart shoppingCart;
        public ShoppingCartForm(object item)
        {
            InitializeComponent();
            shoppingCart = new ShoppingCart();
            CustomersBusiness customers = new CustomersBusiness();
            var list = customers.SelectList();
            cbCostumers.Items.Add(STR_SELECT);
            cbCostumers.Items.AddRange(list.ToArray());            
            //
            if(item == null)
            {                
                cbCostumers.SelectedIndex = 0;
                dtpDate.Value = DateTime.Now;
                tbDescription_TextChanged(null, EventArgs.Empty);
            }
            else
            {
                ShoppingCart cart = (ShoppingCart)item;
                shoppingCart.ShoppingCartID = cart.ShoppingCartID;                
                dtpDate.Value = cart.PurchaseDate;
                tbDescription.Text = cart.Description;
                //seleciona customer no combobox
                int index = list.FindIndex(x => x.CustomerID == cart.CustomerID);                
                cbCostumers.SelectedIndex = index+1;               
            }
        }

        public ShoppingCart Return { get { return shoppingCart; } }

        private void btOk_Click(object sender, EventArgs e)
        {
            Validate();
            if (isValidate)
            {
                Customer customer = (Customer)cbCostumers.SelectedItem;
                shoppingCart.CustomerID = customer.CustomerID;
                shoppingCart.PurchaseDate = dtpDate.Value;
                shoppingCart.Description = tbDescription.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                var validationSumary = new ValidateSummaryDialog(listValidate);
                validationSumary.ShowDialog(this);
            }
        }
        private bool isValidate = false;
        List<string> listValidate = new List<string>();
        private new void Validate()
        {
            listValidate.Clear();
            isValidate = true;
            if (cbCostumers.Text == STR_SELECT)
            {
                listValidate.Add("Costumer field need by selected.");
                isValidate = false;
            }
            if (tbDescription.Text.Length > tbDescription.MaxLength)
            {
                listValidate.Add("Maximum caracteres in description.");
                isValidate = false;
            }            
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            int c = tbDescription.Text.Length;
            lbCountCharacter.Text = string.Format("{0}/{1}", c, tbDescription.MaxLength);
        }
    }
}
