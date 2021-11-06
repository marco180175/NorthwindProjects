using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesteValidadores.UserControl
{
    public partial class ModalPopupValidacao : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        public void Show(Page page)
        {
            List<string> mensagens = new List<string>();
            foreach (BaseValidator validador in page.Validators)
            {
                if (!validador.IsValid)
                    mensagens.Add(validador.ErrorMessage);
            }
            ListBox1.DataSource = mensagens;
            ListBox1.DataBind();
            ModalPopupExtender1.Show();
        }
    }
}