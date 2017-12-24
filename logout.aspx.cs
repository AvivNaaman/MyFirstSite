using System;
using GlobalVariables;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["User"] != null)
        {
            Application["Online"] = (int)Application["Online"] - 1;
            Session.Abandon();
            GlobalingRegisterSignOutMessage.SetGlobalRegisterSignOutMessageValue("SignedOut");
            Response.Redirect("login.aspx?rm=out");
        }
        else
        {
            Response.Redirect("login.aspx?rm=none");
        }
    }
}