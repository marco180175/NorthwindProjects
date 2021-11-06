using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindWebForm.UserControl
{
    public partial class ContaCaracter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetInput(TextBox textBox)
        {
            string function = string.Format("counterCharacter('{0}','{1}',{2})",
                    textBox.ClientID,
                    Label1.ClientID,
                    textBox.MaxLength);
            textBox.Attributes["OnKeyUp"] = function;
            Label1.Text = string.Format("{0} / {1} caracteres", textBox.Text.Length, textBox.MaxLength);
        }
    }
}