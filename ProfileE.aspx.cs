using System;
using System.Data;
using GlobalVariables;
using GlobalHTML;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfileE : System.Web.UI.Page
{
    public DataSet ds;
    public string demo;
    public string NavBar;
    public string PPsrc;
    public string UserNavBarTools;
    public string Fname, Lname, mail, Phone, Birth;
    public string UploadInfo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //NavBar = GlobalingHTMLNavBar.GlobalHTMLNavBar; //מבקש קוד לסרגל כלים העליון
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
        if (Request.QueryString["p"] == null)
            Response.Redirect(Request.RawUrl + "?p=m");
        else if (Request.QueryString["p"] == "m")
        {
            MainPanel.Visible = true;
            UploadPanel.Visible = false;
            Title = "עריכת פרופיל";
        }
        else if (Request.QueryString["p"] == "up")
        {
            MainPanel.Visible = false;
            UploadPanel.Visible = true;
            Title = "העלאת תמונה";
        }
        else
            Response.Redirect("ProfileE.aspx?p=m");
        string sqlS = "SELECT  * FROM Accounts WHERE UserName='" + Session["User"] + "'";
        DalAccess dal = new DalAccess(sqlS);
        ds = dal.GetDataSet(sqlS, "Accounts");
        if (ds.Tables[0].Rows.Count == 1)
        {
            DataRow row = ds.Tables[0].Rows[0];
            Fname = row["FName"].ToString();
            Lname = row["LName"].ToString();
            mail = row["Mail"].ToString();
            Phone = "<span dir='ltr'>+" + row["Phone"].ToString() + "</span>";
            Birth = row["Birth"].ToString();
        }
    }
    protected void PrintBirthYears()
    {
        for (int y = 1950; y < 2010; y++)
        {
            Response.Write("<option value='" + y + "'>" + y + "</option>");
        }
    }
    protected void PrintBirthDays()
    {
        for (int z = 1; z < 32; z++)
        {
            Response.Write("<option value='" + z + "'>" + z + "</option>");
        }
    }
    protected void PrintPhoneCountryselection()
    {
        for (int n = 1; n < 1000; n++)
        {
            string ForPrint;
            if (n == 972)
            {
                ForPrint = "<option value='" + n + "' selected='selected'>" + n + "</option>";
            }
            else
            {
                ForPrint = "<option value='" + n + "'>" + n + "</option>";
            }
            Response.Write(ForPrint);
        }
    }
    public string FirstName, LastName, Email, BirthA, PhoneN;
    protected void ChangeDetails_Click(object sender, EventArgs e)
    {
        int c = 0, d = 0;
        FirstName = Request.Form["Fname"];
        if (FirstName != Fname && FirstName != null && FirstName != "")
        {
            string sqlS = "UPDATE Accounts SET Fname='"+FirstName+"' WHERE Fname='"+Fname+"'";
            DalAccess dal = new DalAccess(sqlS);
            d += dal.InsertUpdateDelete(sqlS);
            c += 1;
        }
        LastName = Request.Form["Lname"];
        if (LastName != Lname && LastName != null && LastName != "")
        {
            string sqlS = "UPDATE Accounts SET Lname='" + LastName + "' WHERE UserName='" + Session["User"] + "'";
            DalAccess dal = new DalAccess(sqlS);
            d += dal.InsertUpdateDelete(sqlS);
            c += 1;
        }
        Email = Request.Form["mail"];
        if (Email != mail && Email != null && Email != "")
        {
            string sqlS = "UPDATE Accounts SET mail='" + Email + "' WHERE UserName='" + Session["User"] + "'";
            DalAccess dal = new DalAccess(sqlS);
            d += dal.InsertUpdateDelete(sqlS);
            c += 1;
        }
        PhoneN = Request.Form["PhoneLast"];
        if (PhoneN != Phone && PhoneN != null && PhoneN != "")
        {
            PhoneN = Request.Form["PhoneFirst"] + Request.Form["PhoneMid"] + Request.Form["PhoneLast"];
            string sqlS = "UPDATE Accounts SET Phone='" + PhoneN + "' WHERE UserName='" + Session["User"] + "'";
            DalAccess dal = new DalAccess(sqlS);
            d += dal.InsertUpdateDelete(sqlS);
            c += 1;
        }
        BirthA = Request.Form["BirthMonth"] + "/" + Request.Form["BirthDay"] + "/" + Request.Form["BirthYear"];
        if (BirthA != Birth && BirthA != null && Request.Form["bcheck"] == "on")
        {
            string sqlS = "UPDATE Accounts SET Birth='" + BirthA + "' WHERE UserName='" + Session["User"] + "'";
            DalAccess dal = new DalAccess(sqlS);
            d += dal.InsertUpdateDelete(sqlS);
            c += 1;
        }
        if (c == d)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('100%')", true);
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ooops..')", true);
        Response.Redirect(Request.RawUrl);
    }

    protected void ChangePass_Click(object sender, EventArgs e)
    {
        string OldPass, NewPass, NewPassV;
        OldPass = Request.Form["OldPass"];
        NewPass = Request.Form["NewPass"];
        NewPassV = Request.Form["NewPassV"];
        if(NewPass != NewPassV || NewPass == null || NewPass == "" || NewPass.Length < 6)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('הסיסמאות החדשות אינן תקינות.')", true);
        }
        else
        {
            string sqlS = "SELECT * FROM Accounts WHERE UserName='" + Session["User"] + "'";
            DalAccess dal = new DalAccess(sqlS);
            DataSet ds = new DataSet(sqlS);
            ds = dal.GetDataSet(sqlS, "Accounts");
            DataRow row = ds.Tables[0].Rows[0];
            string Pass = row["Pass"].ToString();
            if (OldPass != Pass)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('סיסמתך הישנה שגויה.')", true);
            }
            else
            {
                sqlS = "UPDATE Accounts SET Pass='" + NewPass + "' WHERE UserName='" + Session["user"] + "'";
                int w = dal.InsertUpdateDelete(sqlS);
                if(w > 0)
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('complete')", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('SQL error')", true);
            }
        }
    }
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        // 
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        // 
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
        this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion 

    private void Submit1_ServerClick(object sender, System.EventArgs e)
    {
        if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
        {
            string OriginalFileName = System.IO.Path.GetFileName(File1.PostedFile.FileName);
            char sep = '.';
            string FileType = OriginalFileName.Split(sep)[1];
            string[] ValidFileTypes = { "png", "jpg", "bmp", "gif" };
            foreach (string x in ValidFileTypes)
            {
                if (FileType.Contains(x))
                {

                    string userName = (string)Session["User"];
                    userName = userName.ToLower();
                    string fn = userName + "ProfileP." + FileType;
                    string SaveLocation = Server.MapPath("Data") + "\\" + fn;
                    try
                    {
                        File1.PostedFile.SaveAs(SaveLocation);
                        UploadInfo = "The file has been uploaded.";
                    }
                    catch (Exception ex)
                    {
                        UploadInfo = "Error: " + ex.Message;
                        //Note: Exception.Message returns a detailed message that describes the current exception. 
                        //For security reasons, we do not recommend that you return Exception.Message to end users in 
                        //production environments. It would be better to return a generic error message. 
                    }
                }
                else
                {
                    UploadInfo = "Invalid File Type";
                }
            }
        }
    }
    protected string PPpath()
    {
        string SessionUser = Session["User"].ToString();
        SessionUser = SessionUser.ToLower();
        PPsrc = @"Data\" + SessionUser + "ProfileP." + "jpg";
        if (File.Exists(PPsrc))
            return (PPsrc);
        else
            return (PPsrc);
    }
}