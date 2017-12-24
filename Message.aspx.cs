using System;
using System.Data;
using GlobalHTML;
using GlobalVariables;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Message : System.Web.UI.Page
{
    public DataSet ds;
    string sqlS;
    string UserName;
    public string outputR = null, outputS = null;
    public string Subject, From, SDate, Content, Title;
    public string NavBar;
    public string UserNavBarTools;
    protected void Page_Load(object sender, EventArgs e)
    {
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
        DalAccess dal = new DalAccess(sqlS);
        if (Request.QueryString["mode"] == null)
            Response.Redirect(Request.RawUrl + "?mode=rec");
        if (Request.QueryString["mode"] == "rec")
        {
            Title = "הודעות נכנסות";
            recPanel.Visible = true;
            sentPanel.Visible = false;
            newPanel.Visible = false;
            viewPanel.Visible = false;
            UserName = Session["User"].ToString();
            sqlS = "SELECT  * FROM Messages WHERE ForN='" + UserName.ToLower() + "' ORDER BY ID ASC";
            ds = dal.GetDataSet(sqlS, "Messages");
            if (ds.Tables[0].Rows.Count > 0)
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    DataRow row = ds.Tables[0].Rows[r];
                    outputR += "<tr>";
                    outputR += "<td style='background-color:#d1cccc;'>" + (r + 1) + "</td>";
                    outputR += "<td style='background-color:#d1cccc;'>" + row["FromN"].ToString() + "</td>";
                    outputR += "<td style='background-color:#d1cccc;'><a href='Message.aspx?mode=mess&id=" + row["ID"].ToString() + "'>" + row["Subject"].ToString() + "</a></td>";
                    outputR += "<td style='background-color:#d1cccc;'>" + row["SentD"].ToString() + "</td>";
                    outputR += "</tr>";
                }
            else
                outputR += "<tr><td><i>No Messages Found...</i></td></tr>";
        }
        else if (Request.QueryString["mode"] == "mess")
        {
            if (Request.QueryString["id"] != null)
            {
                recPanel.Visible = false;
                sentPanel.Visible = false;
                newPanel.Visible = false;
                viewPanel.Visible = true;
                sqlS = "SELECT * FROM Messages WHERE ID=" + Request.QueryString["id"].ToString() + "";
                ds = dal.GetDataSet(sqlS, "Messages");
                if (ds.Tables[0].Rows.Count == 1)
                {
                    UserName = Session["User"].ToString();
                    UserName = UserName.ToLower();
                    DataRow row = ds.Tables[0].Rows[0];
                    Title = "הודעה:" + row["Subject"].ToString();
                    if (UserName == row["ForN"].ToString() || UserName == row["FromN"].ToString())
                    {
                        Subject = row["Subject"].ToString();
                        From = row["FromN"].ToString();
                        SDate = row["SentD"].ToString();
                        Content = row["ContentV"].ToString();
                    }
                    else { redBack(); }
                }
            }
            else { redBack(); }
        }
        else if (Request.QueryString["mode"] == "sent")
        {
            recPanel.Visible = false;
            sentPanel.Visible = true;
            newPanel.Visible = false;
            viewPanel.Visible = false;
            Title = "הודעות יוצאות";
            UserName = Session["User"].ToString();
            sqlS = "SELECT  * FROM Messages WHERE FromN='" + UserName.ToLower() + "' ORDER BY ID ASC";
            ds = dal.GetDataSet(sqlS, "Messages");
            if (ds.Tables[0].Rows.Count > 0)
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    DataRow row = ds.Tables[0].Rows[r];
                    outputS += "<tr>";
                    outputS += "<td style='background-color:#d1cccc;'>" + (r + 1) + "</td>";
                    outputS += "<td style='background-color:#d1cccc;'>" + row["ForN"].ToString() + "</td>";
                    outputS += "<td style='background-color:#d1cccc;'><a href='Message.aspx?mode=mess&id=" + row["ID"].ToString() + "'>" + row["Subject"].ToString() + "</a></td>";
                    outputS += "<td style='background-color:#d1cccc;'>" + row["SentD"].ToString() + "</td>";
                    outputS += "</tr>";
                }
            else
                outputS += "<tr><td><i>No Messages Found...</i></td></tr>";
        }
        else if (Request.QueryString["mode"] == "new")
        {
            recPanel.Visible = false;
            sentPanel.Visible = false;
            newPanel.Visible = true;
            viewPanel.Visible = false;
            Title = "הודעה חדשה";
        }
        else if (Request.QueryString["mode"] == "showall")
        {
            recPanel.Visible = true;
            sentPanel.Visible = true;
            newPanel.Visible = true;
            viewPanel.Visible = true;
        }
        else
        {

        }
        if (IsPostBack)
        {
            string ForN, FromN, Subject, Content;
            ForN = Request.Form["SendToUser"];
            Subject = Request.Form["subject"];
            Content = Request.Form["content"];
            FromN = Session["User"].ToString();
            FromN = FromN.ToLower();
            sqlS = "INSERT INTO Messages(ForN, FromN, Subject, SentD, ContentV) VALUES ('" + ForN + "','" + FromN + "','" + Subject + "','" + DateTime.Now + "','" + Content + "')";
            int x = dal.InsertUpdateDelete(sqlS);
            if (x > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sent.')", true);
                if (Application["MesSent"] == null)
                    Application["MesSent"] = 1;
                else
                    Application["MesSent"] = (int)Application["MesSent"] + 1;
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SQL error')", true);
        }
    }
    private void redBack()
    {
        Response.Redirect("Message.aspx?mode=rec");
    }
    protected void newMessOptUser()
    {
        string ForPrint = null;
        string sqlS = "SELECT * FROM Accounts ORDER BY UserName ASC";
        DalAccess dal = new DalAccess(sqlS);
        ds = dal.GetDataSet(sqlS, "users");
        UserName = Session["User"].ToString();
        for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
        {
            DataRow row = ds.Tables[0].Rows[r];
            string UserRow = row["UserName"].ToString();
            if(!(UserRow.ToLower() == UserName.ToLower()))
                ForPrint += "<option value='" + row["UserName"].ToString() + "'>" + row["UserName"].ToString() + "</option>";
        }
        Response.Write(ForPrint);
    }
}