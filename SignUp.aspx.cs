using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GlobalVariables;

public partial class SignUp : System.Web.UI.Page
{
    public string FirstName, LastName, UserName, Mail, Gender, PhoneFirst, PhoneMid, PhoneLast, BirthDay, BirthMonth, BirthYear, Birth, Phone;
    public string Errors;
    public bool TempBool;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            Session.Abandon();
            Response.Redirect(Request.RawUrl);
        }
        Session.Abandon();
        if (IsPostBack)
        {
            string Pass;
            FirstName = Request.Form["FirstName"];
            LastName = Request.Form["LastName"];
            UserName = Request.Form["UserName"];
            Pass = Request.Form["Password"];
            Mail = Request.Form["Mail"];
            Gender = Request.Form["Gender"];
            PhoneFirst = Request.Form["PhoneFirst"];
            PhoneMid = Request.Form["PhoneMid"];
            PhoneLast = Request.Form["PhoneLast"];
            BirthDay = Request.Form["BirthDay"];
            BirthMonth = Request.Form["BirthMonth"];
            BirthYear = Request.Form["BirthYear"];
            Errors = "<details dir='rtl' style='border-color:red;color:red;float:right;'>";
            
            string[] VarToCheck = { FirstName, LastName, UserName, Pass };
            foreach (string i in VarToCheck)
            {
                string stringToCheck = i;

                string[] BadWords = { "Shit", "Bitch", "חרא", "כלב"};

                foreach (string x in BadWords)
                {
                    if (stringToCheck.Contains(x))
                    {
                        Errors += "אנא השתמש במילים הולמות. <br />";
                    }
                }
            }
            TempBool = Regex.IsMatch(FirstName, @"^[a-zA-Z]+$");
            if (TempBool == false) //check if FirstName including only letters, without nums.
            {
                Errors += "שם פרטי אינו כולל מספרים. <br />";
            }
            if (UserName.Length < 1)
            {
                Errors += "אורך שם פרטי חייב לעלות על תו אחד. <br />";
            }
            TempBool = Regex.IsMatch(LastName, @"^[a-zA-Z]+$");
            if (TempBool == false) //check if FirstName including only letters, without nums.
            {
                Errors += "שם משפחה אינו כולל מספרים. <br />";
            }
            if (LastName.Length < 1)
            {
                Errors += "אורך שם משפחה חייב לעלות על תו אחד. <br />";
            }
            TempBool = UserName.Any(c => char.IsDigit(c));
            if (TempBool == false || UserName.Length < 6)
            {
                if (TempBool == false)
                {
                    Errors += "יש לכלול מספרים בשם המשתמש. <br />";
                }
                if (UserName.Length < 6)
                {
                    Errors += "אורך שם משתמש חייב לעלות על חמישה תווים <br />";
                }
            }
            string sqlS = "SELECT * FROM Accounts where UserName='" + UserName + "'";
            DalAccess dal = new DalAccess(sqlS);
            ds = dal.GetDataSet(sqlS, "Accounts");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Errors += "שם המשתמש כבר בשימוש. אנא בחר שם אחר. <br />";
            }
            if ((Pass.Any(c => char.IsUpper(c))) == false || (Pass.Any(c => char.IsLower(c))) == false || (Pass.Any(c => char.IsDigit(c))) == false)
            {
                Errors += "יש לכלול מספרים, אותיות גדולות ואותיות קטנות בסיסמה <br />";
            }
            if (Pass.Length < 6)
            {
                Errors += "אורך סיסמה חייב לעלות על חמישה תווים <br />";
            }
            if (Mail.IndexOf("@") < 1 || Mail.IndexOf(".") < 1)
            {
                Errors += "מייל אינו תקין. <br />";
            }
            if (Mail.Length < 10)
            {
                Errors += "כתובת מייל חייבת לעלות על 10 תווים. <br />";
            }
            sqlS = "SELECT * FROM Accounts where mail='" + Mail + "'";
            ds = dal.GetDataSet(sqlS, "Accounts");
            if(ds.Tables[0].Rows.Count > 0)
            {
                Errors += "המייל כבר בשימוש. אנא בחר מייל אחר. <br />";
            }
            TempBool = Regex.IsMatch(PhoneLast, @"^[0-9]+$");
            if (PhoneMid == "null")
            {
                Errors += "אנא בחר קידומת מפעיל סלולרי. <br />";
            }
            if (PhoneLast.Length < 7)
            {
                Errors += "אנא הזן מספר טלפון מלא. <br />";
            }
            if (TempBool == false)
            {
                Errors += "אנא הזן מספרים בלבד במספר הטלפון. <br />";
            }
            Phone = PhoneFirst + PhoneMid + PhoneLast;
            sqlS = "SELECT * FROM Accounts where Phone='" + Phone + "'";
            ds = dal.GetDataSet(sqlS, "Accounts");
            if(ds.Tables[0].Rows.Count > 0)
            {
                Errors += "מספר הטלפון כבר בשימוש. אנא הזן מספר שונה.";
            }
            if(BirthDay == "null" || BirthMonth == "null" || BirthYear == "null")
            {
                Errors += "אנא הזן תאריך לידה במלואו. <br />";
            }
            Birth = BirthMonth + "/" + BirthDay + "/" + BirthYear;
            if (Errors == "<details dir='rtl' style='border-color:red;color:red;float:right;'>")//Errors == "<details style='border-color:red;color:red;float:right;'>"
            {
                sqlS = "INSERT INTO Accounts (Fname, Lname, UserName, Pass, mail, Gender, Phone, Birth, Manager, RegTime) values ('" + FirstName + "','" + LastName + "','" + UserName + "','" + Pass + "','" + Mail + "','" + Gender + "','" + Phone + "','" + Birth + "','False','" + DateTime.Now + "')";
                int x = dal.InsertUpdateDelete(sqlS);
                if (x > 0)
                {
                    Errors += "Success!";
                    Session["User"] = UserName;
                    Session["FirstTime"] = true;
                    Session["IsAdmin"] = "False";
                    Response.Redirect("login.aspx?rm=reg");
                }
                else
                    Errors += "err";
                Errors += "</details>";
            }
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
    protected void PrintBirthDaysSelection()
    {
        for (int n = 1; n < 31; n++)
        {
            string ForPrint = "<option value='" + n + "'>" + n + "</option>";
            Response.Write(ForPrint);
        }
    }
    protected void PrintBirthYearsSelection()
    {
        for (int i = 1950; i < 2011; i++)
        {
            string ForPrint = "<option value='" + i + "'>" + i + "</option>";
            Response.Write(ForPrint);
        }
    }
}
