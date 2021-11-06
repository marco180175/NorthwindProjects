using NorthwindBusiness.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindWebForm
{
    public partial class CategoryTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var categories = new CategoriesBusiness();
                GridView1.DataSource = categories.SelectList();
                GridView1.DataBind();
            }
        }
    }
}