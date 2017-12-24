using System;
using System.Data;
using GlobalHTML;
using GlobalVariables;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class UserManagment : System.Web.UI.Page
{
    public string SiteVr;
    public int TotalAccountsNum = 0;
    public DataSet ds;
    public string NavBar;
    public string UserNavBarTools;
    public string DeleteConfirmationValue;
    public string ChangeUserNameToDeleteStyle;
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteVr = GlobalingVr.GlobalVr;
        string sqlS = "SELECT * FROM Accounts ORDER BY ID ASC"; //sort by ascending
        DalAccess dal = new DalAccess(sqlS);
        ds = dal.GetDataSet(sqlS, "Accounts");
        if ((string)Session["IsAdmin"] != "True" || (string)Session["User"] == null)
        {
            GlobalingRedirectedFrom.SetGlobalRedirectedFromValue(Request.RawUrl);
            Response.Redirect("Lessons.aspx");
        }
        else
        {
            UserNavBarTools = "<span class='AdminNavBarTools'> ברוך הבא, <a href='profileE.aspx'>"+ Session["User"] + "</a>&nbsp;<a href='logout.aspx' id='1'>התנתק</a></span><a href='../../usermanagment.aspx' class='NavBarItem NavBarButton'>ניהול</a>";
            NavBar = GlobalingHTMLNavBar.GlobalHTMLNavBar; //מבקש קוד לסרגל כלים העליון
        }
    }
    protected void PrintAccountsList()
    {
        Response.Write("<details class='UserManagmentPageAccountsListDetails' style='font-family: Arial;' open='open'><summary>רשימת משתמשים</summary>");
        Response.Write("<br />");
        Response.Write("<div class='tableDiv'><table class='UserManagmentPageAccountsListTable' style='direction:ltr !important;'>");
        string TableAccountsValues = "<tr><th style='border:2px solid black' width='150px'>שם פרטי</th><th style='border:2px solid black' width='150px'>שם משפחה</th><th style='border:2px solid black' width='120px'>שם משתמש</th><th style='border:2px solid black' width='120px'>סיסמה</th><th style='border:2px solid black' width='350px'>כתובת דואר אלקטרוני</th><th style='border:2px solid black'>יום הולדת</th><th style='border:2px solid black' width='70px'>מין</th><th style='border:2px solid black' width='200px'>טלפון</th><th style='border:2px solid black' width='200px'>מנהל?</th><th style='border:2px solid black'>ID</th></tr>";
        for (int r = 0; r <ds.Tables[0].Rows.Count; r++)
        {
            DataRow row = ds.Tables[0].Rows[r];
            string Admincolor;
            Admincolor = row["Manager"].ToString();
            if (Admincolor == "True")
                Admincolor = "Red";
            else
                Admincolor = "#d1cccc";
            TableAccountsValues += "<tr class='UserManagmentPageAccountsListTableRow"+ r +"' style='background-color:" + Admincolor + "'>";
            TableAccountsValues += "<td>" + row["FName"].ToString() + "</td>";
            TableAccountsValues += "<td>" + row["LName"].ToString() + "</td>";
            TableAccountsValues += "<td>" + row["UserName"].ToString() + "</td>";
            TableAccountsValues += "<td><span data-text='" + row["Pass"].ToString() + "'</td>";
            TableAccountsValues += "<td><a href='mailto:" + row["Mail"].ToString() + "?Subject=From%20AvivSite%20Managment' target='_top'>" + row["Mail"].ToString() + "</a></td>";
            TableAccountsValues += "<td>" + row["Birth"].ToString() + "</td>";
            TableAccountsValues += "<td>" + row["Gender"].ToString() + "</td>";
            TableAccountsValues += "<td><a href='tel:" + row["Phone"].ToString() + "'> +" + row["Phone"].ToString() + "</a></td>";
            TableAccountsValues += "<td>" + row["Manager"].ToString() + "</td>";
            TableAccountsValues += "<td>" + row["ID"].ToString() + "</td>";
            TableAccountsValues += "</tr>";
            TotalAccountsNum++;
        }
        Response.Write(TableAccountsValues);
        Response.Write("</table></div>");
        Response.Write("</details>");
    }
    public string FirstName, LastName, UserName, mail, Gender, Phone, BDay, BMonth, BYear, Manager;
    protected void UserInsert_Click(object sender, EventArgs e)
    {
        string Pass;
        //Request.Form[""]
        FirstName = Request.Form["FirstName"];
        LastName = Request.Form["LastName"];
        UserName = Request.Form["UserName"];
        Pass = Request.Form["Pass"];
        mail = Request.Form["mail"];
        Gender = Request.Form["Gender"];
        Phone = Request.Form["Phone"];
        BDay = Request.Form["BDay"];
        BMonth = Request.Form["BMonth"];
        BYear = Request.Form["BYear"];
        Manager = Request.Form["Manager"];
        if (Manager != "on")
            Manager = "False";
        else
            Manager = "True";
        string Birth = BMonth + "/" + BDay + "/" + BYear;
        string ToAdd = null, ToAddValues = null;
        /*
        string[] CheckExist = { "FirstName.Fname", "LastName.Lname", "UserName.UserName", "Pass.Pass", "mail.mail", "Gender.Gender", "Phone.Phone", "Birth.Birth" };
        foreach (string item in CheckExist)
        {
            string[] itemS = item.Split('.');
            string temp = itemS[0];
            temp = (string)this.GetType().GetProperty(temp).GetValue(this);
            if (!(temp == "" || temp == null))
            {
                ToAdd += itemS[1] + ", ";
                ToAddValues += "'" + temp + "',";
            }
        }*/
        string sqlS = "INSERT INTO Accounts (Fname, Lname, UserName, Pass, mail, Gender, Phone, Birth, Manager, RegTime) values ('" + FirstName + "','" + LastName + "','" + UserName + "','" + Pass + "','" + mail + "','" + Gender + "','" + Phone + "','" + Birth + "','" + Manager + "','" + DateTime.Now + "')";
        DalAccess dal = new DalAccess(sqlS);
        int y = dal.InsertUpdateDelete(sqlS);
        if (y > 0)
            Response.Redirect(Request.RawUrl);
        else
            alert("SQL error");
    }
    protected void PrintBirthDaysSelection()
    {
        for (int n = 1; n < 31; n++)
        {
            string ForPrint = "<option value='" + n + "'>" + n + "</option>";
            Response.Write(ForPrint);
        }
    }

    protected void UserDeleteHid_Click(object sender, EventArgs e)
    {
        string UserNameToDelete;
        string sqlS = "SELECT * FROM Accounts ORDER BY ID ASC";
        DalAccess dal = new DalAccess(sqlS);
        ds = dal.GetDataSet(sqlS, "Accounts");
        UserNameToDelete = Request.Form["UserNameToDelete"];
        if (UserNameToDelete == "")
        {
            ChangeUserNameToDeleteStyle = ".UserNameToDelete { border: 1px solid red; }";
        }
        else
        {
            if (Request.Form["DeleteConfirmation"] != "on")
            {

                alert("אנא סמן תיבת אישור");
            }
            else
            {
                string DeletePar = Request.Form["DeletePar"];
                sqlS = "SELECT * FROM Accounts where " + DeletePar + "='" + UserNameToDelete + "'";
                DataSet ds = new DataSet(sqlS);
                ds = dal.GetDataSet(sqlS, "Accounts");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    alert("לא קיים " + UserNameToDelete);
                }
                else
                {
                    sqlS = "DELETE * From Accounts where " + DeletePar + "='" + UserNameToDelete + "'";
                    dal = new DalAccess(sqlS);
                    int x = dal.InsertUpdateDelete(sqlS);
                    if (x > 0)
                    {
                        alert("נמחק " + UserNameToDelete + " ");
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        alert("SQL ERROR");
                    }
                }
            }
        }
    }

    protected void DeleteAllHid_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["con"] == "aviv")
        {
            string sqlS = "DELETE FROM Accounts WHERE true";
            DalAccess dal = new DalAccess(sqlS);
            int y = dal.InsertUpdateDelete(sqlS);
            if (y > 0)
                Response.Redirect(Request.RawUrl);
            else
                alert("SQL error");
        }
    }
    protected void PrintManagMessages()
    {
        string sqlS = "SELECT * FROM Contact ORDER BY ID ASC";
        DalAccess dal = new DalAccess(sqlS);
        ds = dal.GetDataSet(sqlS, "Contact");
        if (ds.Tables[0].Rows.Count > 0)
        {
            string MessagesTableString = "<div class='tableDiv'><table class='UserManagmentPageAccountsListTable' style='direction:rtl;width:600px;'><tr><th style='border:2px solid black;direction:rtl;'>ID</th><th style='border:2px solid black;direction:rtl;'>שולח</td><td style='border:2px solid black;direction:rtl;'>תאריך</th><th style='border:2px solid black;direction:rtl;'>נושא</th><th style='border:2px solid black;direction:rtl !important;width: 50% !important;'>תוכן</th></tr><tr>";
            for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            {
                DataRow row = ds.Tables[0].Rows[r];
                MessagesTableString += "<td style='background-color:#d1cccc'>" + row["ID"].ToString() + "</td>";
                MessagesTableString += "<td style='background-color:#d1cccc'>" + row["UserName"].ToString() + "</td>";
                MessagesTableString += "<td style='background-color:#d1cccc'>" + row["SendDate"].ToString() + "</td>";
                MessagesTableString += "<td style='background-color:#d1cccc'>" + row["Subject"].ToString() + "</td>";
                MessagesTableString += "<td style='background-color:#d1cccc'>" + row["Message"].ToString() + "</td>";
                MessagesTableString += "</tr>";
            }
            MessagesTableString += "</table></div>";
            Response.Write(MessagesTableString);
        }
        else
            Response.Write("<i>No Messages</i>");
    }
    protected void alert(string message)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "')", true);
    }
}