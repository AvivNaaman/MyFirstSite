using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GlobalHTMLDefaults
/// </summary>
namespace GlobalHTML
{
    public class GlobalingHTMLNavBar
    {
        static GlobalingHTMLNavBar() { GlobalHTMLNavBar = "<a href='../../../' class='NavBarItem NavBarButton'>בית</a><a href='../../Lessons.aspx' class='NavBarItem NavBarButton'>למד</a><a href='../../reference.aspx' class='NavBarItem NavBarButton'>רשימות</a><a href='../../contact.aspx' class='NavBarItem NavBarButton'>צור קשר</a>"; } // default value
        public static string GlobalHTMLNavBar { get; private set; }
    }
    public class GlobalingHTMLFooter
    {
        static GlobalingHTMLFooter() { GlobalHTMLFooter = ""; }
        public static string GlobalHTMLFooter { get; private set; }
    }
    //TODO: Make New DB access that will request the HTML code.
    public class GlobalingHTMLNavBarHTML
    {
        static GlobalingHTMLNavBarHTML() { GlobalHTMLNavBarHTML = "<a href='../../../' class='NavBarItem NavBarButton'>Home</a><a href='../../Lessons.aspx' class='NavBarItem NavBarButton'>למד</a><a href='../../reference.aspx' class='NavBarItem NavBarButton'>ספח</a>"; } // default value
        public static string GlobalHTMLNavBarHTML { get; private set; }
    }
    public class GlobalingHTMLNavBarMobile
    {
        static GlobalingHTMLNavBarMobile() { GlobalHTMLNavBarMobile = "<li><a href='../' class='linkButton'>Home</a></li><li><a href='lessons.aspx' class='linkButton'>Lessons</a></li><li><a href='reference.aspx' class='linkButton'>refrence</a></li>"; } // default value
        public static string GlobalHTMLNavBarMobile { get; private set; }
    }
    public class GlobalingHTMLNavBarMobileAdmin
    {
        static GlobalingHTMLNavBarMobileAdmin() { GlobalHTMLNavBarMobileAdmin = "<li><a href='../' class='linkButton'>Home</a></li><li><a href='lessons.aspx' class='linkButton'>Lessons</a></li><li><a href='reference.aspx' class='linkButton'>refrence</a></li><li><a href='../UserManagment.aspx' class='linkButton'>Managment</a></li>"; } // default value
        public static string GlobalHTMLNavBarMobileAdmin { get; private set; }
    }
    public class GlobalingHTMLNavBarMobileless
    {
        static GlobalingHTMLNavBarMobileless() { GlobalHTMLNavBarMobileless = "<li><a href='../../mobile/' class='linkButton'>Home</a></li><li><a href='../../mobile/lessons.aspx' class='linkButton'>Lessons</a></li><li><a href='../../mobile/reference.aspx' class='linkButton'>refrence</a></li>"; } // default value
        public static string GlobalHTMLNavBarMobileless { get; private set; }
    }
    public class GlobalingHTMLNavBarMobileAdminless
    {
        static GlobalingHTMLNavBarMobileAdminless() { GlobalHTMLNavBarMobileAdminless = "<li><a href='../../mobile/' class='linkButton'>Home</a></li><li><a href='../../mobile/lessons.aspx' class='linkButton'>Lessons</a></li><li><a href='../../mobile/reference.aspx' class='linkButton'>refrence</a></li><li><a href='../../UserManagment.aspx' class='linkButton'>Managment</a></li>"; } // default value
        public static string GlobalHTMLNavBarMobileAdminless { get; private set; }
    }
}
