using System;
using GlobalVariables;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    public string Invalid;
    public string UserName, RedUserName;
    public string ChangeTheUserToRed, ChangeThePassToRed;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["rm"] == "" || Request.QueryString["rm"] == null)
        {
            Invalid = null;
        }
        if (Request.QueryString["rm"] == "out")
        {
            Invalid = "התנתקת בהצלחה";
        }
        else if (Request.QueryString["rm"] == "reg")
        {
            Invalid = "נרשמת בהצלחה!";
        }
        if (IsPostBack)
        {
            string Password;
            ChangeTheUserToRed = null;
            ChangeThePassToRed = null;
            UserName = Request.Form["LoginUserName"];
            Password = Request.Form["LoginUserPass"];
            if ((UserName == "") || (Password == ""))
            {
                if (UserName == "")
                {
                    ChangeTheUserToRed = ".LoginUserName{border: 1px solid red;}";
                }
                if (Password == "")
                {
                    ChangeThePassToRed = ".LoginUserPass{border: 1px solid red;}";
                }
            }
            else
            {
                string sqlS = "SELECT * FROM Accounts where UserName='" + UserName + "' and Pass='" + Password + "' and manager='True'";
                DalAccess dal = new DalAccess(sqlS);
                ds = dal.GetDataSet(sqlS, "Accounts");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["User"] = UserName;
                    Session["IsAdmin"] = "True";
                    Session.Timeout = 60;
                    string[] ApplicationsCounters = { "Online", "Logins" };
                    foreach (string item in ApplicationsCounters)
                    {
                        if (Application[item] == null)
                        {
                            Application[item] = 0;
                        }
                        Application.Lock();
                        Application[item] = (int)Application[item] + 1;
                        Application.UnLock();
                    }
                    string rfS = Request.QueryString["rf"];
                    if (rfS == null || rfS == "")
                    {
                            Response.Redirect("~/");
                    }
                    else if (CheckPageExist(Request.QueryString["rf"]))
                        Response.Redirect(Request.QueryString["rf"]);
                    else
                        Response.Redirect("~/");
                }
                else
                {
                    sqlS = "SELECT * FROM Accounts where UserName='" + UserName + "' and Pass='" + Password + "'";
                    ds = dal.GetDataSet(sqlS, "Accounts");
                    LMessage(UserName);
                }
            }
        }
    }
    protected void LMessage(string item)
    {
        Response.Write("<center>");
        if (ds.Tables[0].Rows.Count == 0)
            Invalid = "<span class='LoginPageOut LoginPageShadow'>שם המשתמש או הסיסמה שגויים!<br /> השם " + item + " אינו מתאים לסיסמה/אינו קיים </span>";
        else
        {
            Session["User"] = UserName;
            Session["IsAdmin"] = "False";
            Session.Timeout = 60;
            string[] ApplicationsCounters = { "Online", "Logins" };
            foreach (string App in ApplicationsCounters)
            {
                if (Application[App] == null)
                {
                    Application[App] = 0;
                }
                Application.Lock();
                Application[App] = (int)Application[App] + 1;
                Application.UnLock();
            }
            string rfS = Request.QueryString["rf"];
            if (rfS == null || rfS == "")
            {
                Response.Redirect("~/");
            }
            else if (CheckPageExist(Request.QueryString["rf"]))
                Response.Redirect(Request.QueryString["rf"]);
            else
                Response.Redirect("~/");
        }
    }
    protected void Page_Load()
    {
        string RedPassword;
        while (5 != 6)
        {
            RedUserName = Request.Form["LoginUserName"];
            RedPassword = Request.Form["LoginUserPass"];
            if (RedUserName != "" && RedPassword != "")
            {
                ChangeTheUserToRed = "";
                ChangeThePassToRed = "";
            }
        }
    }
    protected bool CheckPageExist(string nameof)
    {
        string[] CheckPageExist = { "js4.aspx", "js3.aspx", "js2.aspx", "js1.aspx", "html4.aspx", "html3.aspx", "html2.aspx", "html1.aspx", "signup.aspx", "reference.aspx", "profilee.aspx", "message.aspx", "lessons.aspx", "../", "contact.aspx", "/lessons/js/js1.aspx", "/lessons/js/js2.aspx", "/lessons/js/js3.aspx", "/lessons/html/html1.aspx", "/lessons/html/html2.aspx", "/lessons/html/html3.aspx", "/lessons/html/html4.aspx" };
        bool outp = false;
        foreach (string pageN in CheckPageExist)
        {
            if (nameof.ToLower().Contains(pageN.ToLower()))
                outp =  true;
        }
        return outp;
    }
}