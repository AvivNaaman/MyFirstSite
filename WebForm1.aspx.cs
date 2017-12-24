using System;
using GlobalHTML;
using GlobalVariables;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Drawing2D;
using System.Drawing;

public partial class WebForm1 : System.Web.UI.Page
{
    protected System.Web.UI.HtmlControls.HtmlInputFile File;
    protected System.Web.UI.HtmlControls.HtmlInputButton Submit;
    public string NavBar;
    public string UserNavBarTools;
    public string UploadInfo;
    protected void Page_Load(object sender, EventArgs e)
    {//NavBar = GlobalingHTMLNavBar.GlobalHTMLNavBar; //מבקש קוד לסרגל כלים העליון
        if (Session["User"] == null)
        {
            GlobalingRedirectedFrom.SetGlobalRedirectedFromValue(Request.RawUrl);
            Response.Redirect("login.aspx");
        }
        else if ((string)Session["IsAdmin"] == "False")
        {
            UserNavBarTools = "<span class='UserNavBarTools'><a href='logout.aspx' id='1'>התנתק</a><a href='profileE.aspx'> " + Session["User"] + "</a> ,ברוך הבא</span>";
            NavBar = GlobalingHTMLNavBar.GlobalHTMLNavBar; //מבקש קוד לסרגל כלים העליון
        }
        else if ((string)Session["IsAdmin"] == "True")
        {
            UserNavBarTools = "<span class='AdminNavBarTools'> ברוך הבא, <a href='profileE.aspx'>"+ Session["User"] + "</a>&nbsp;<a href='logout.aspx' id='1'>התנתק</a></span><a href='../../usermanagment.aspx' class='NavBarItem NavBarButton'>ניהול</a>";
            NavBar = GlobalingHTMLNavBar.GlobalHTMLNavBar; //מבקש קוד לסרגל כלים העליון
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
}