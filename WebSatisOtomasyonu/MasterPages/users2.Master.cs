using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSatisOtomasyonu.MasterPages
{
    public partial class users2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnCikisYap_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/AdminPages/LoginScreenAdmin.aspx");
        }
    }
}