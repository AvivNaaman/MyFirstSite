using System;
using GlobalHTML;
using GlobalVariables;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact : System.Web.UI.Page
{
    public string NavBar;
    public string UserNavBarTools;
    protected void Page_Load(object sender, EventArgs e)
    {//NavBar = GlobalingHTMLNavBar.GlobalHTMLNavBar; //מבקש קוד לסרגל כלים העליון
        if (Session["User"] == null)
        {
            Response.Redirect("login.aspx?rf=" + Request.RawUrl + "");
        }
        else if ((string)Session["IsAdmin"] == "False")
        {
            UserNavBarTools = "<span class='UserNavBarTools'><a href='logout.aspx' id='1'>התנתק</a><a href='profileE'> " + Session["User"] + "</a> ,ברוך הבא</span>";
            NavBar = GlobalingHTMLNavBar.GlobalHTMLNavBar; //מבקש קוד לסרגל כלים העליון
        }
        else if ((string)Session["IsAdmin"] == "True")
        {
            UserNavBarTools = "<span class='AdminNavBarTools'> ברוך הבא, <a href='profileE.aspx'>"+ Session["User"] + "</a>&nbsp;<a href='logout.aspx' id='1'>התנתק</a></span><a href='../../usermanagment.aspx' class='NavBarItem NavBarButton'>ניהול</a>";
            NavBar = GlobalingHTMLNavBar.GlobalHTMLNavBar; //מבקש קוד לסרגל כלים העליון
        }
        if(IsPostBack)
        {
            string UserName, Message, Subject;
            UserName = Session["User"].ToString();
            UserName = UserName.ToLower();
            Subject = Request.Form["Subject"];
            Message = Request.Form["Message"];
            string sqlS = "INSERT INTO Contact (UserName, Subject, Message,SendDate) VALUES ('"+UserName+"','" + Subject + "','"+Message+"','"+DateTime.Now+"')";
            DalAccess dal = new DalAccess(sqlS);
            int x = dal.InsertUpdateDelete(sqlS);
            if(x > 0)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('HELLO')", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SQL error')", true);
        }
    }
}