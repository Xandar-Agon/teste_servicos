using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace teste_servicos
{
    public partial class frontpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            startpage startpage = new startpage();
            GridView1.DataSource = startpage.GetFavourites();
            GridView1.DataBind();
        }
    }
}