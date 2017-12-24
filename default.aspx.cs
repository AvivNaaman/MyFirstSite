using System;
using GlobalHTML;
using GlobalVariables;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using mobileC;

public partial class _default : System.Web.UI.Page
{
    public string NavBar;
    public string UserNavBarTools;
    protected void Page_Load(object sender, EventArgs e)
    {//NavBar = GlobalingHTMLNavBar.GlobalHTMLNavBar; //מבקש קוד לסרגל כלים העליון
        if (Session["User"] == null)
        {
            Response.Redirect("login.aspx?rf=" + Request.RawUrl + "");
        }
        else if(mobileCheck.Check((string)Request.ServerVariables["HTTP_USER_AGENT"]))
        {
            Response.Redirect("/mobile");
        }
        else if  ((string)Session["IsAdmin"] == "False")
        {
            UserNavBarTools = "<span class='UserNavBarTools'><a href='logout.aspx' id='1'>התנתק</a> <a href='profileE.aspx'> " + Session["User"] + "</a> ,ברוך הבא</span>";
            NavBar = GlobalingHTMLNavBar.GlobalHTMLNavBar; //מבקש קוד לסרגל כלים העליון
        }
        else if((string)Session["IsAdmin"] == "True")
        {
            UserNavBarTools = "<span class='AdminNavBarTools'> ברוך הבא, <a href='profileE.aspx'>"+ Session["User"] + "</a>&nbsp;<a href='logout.aspx' id='1'>התנתק</a></span><a href='../../usermanagment.aspx' class='NavBarItem NavBarButton'>ניהול</a>";
            NavBar = GlobalingHTMLNavBar.GlobalHTMLNavBar; //מבקש קוד לסרגל כלים העליון
        }
    }
}