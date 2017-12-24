<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManagment.aspx.cs" Inherits="UserManagment" %>

<!DOCTYPE html>

<html lang="he" xmlns="http://www.w3.org/1999/xhtml" class="UserManagmentHTML">
<head runat="server">
    <title>ניהול</title>
    <link rel="shortcut icon" href="Resources/Images/User.ico" type="image/x-icon"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" type="text/css" href="Resources/CSS/GlobalStyle.css" />
    <script type="text/javascript">
        var AccountsTableOpen, UserDeleteOpen;
        function refresh()
        {
            document.location.reload();
        }
        function DeleteUser() {
            document.getElementById('UserDeleteHid').click();
        }
        function InsertUser() {
            document.getElementById('InsertUserHid').click();
        }
        function DeleteAll() {
            document.getElementById('DeleteAllHid').click();
        }
    </script>
    <style>
        <%=ChangeUserNameToDeleteStyle %>
    </style>
    <style>
        .tableDiv {overflow-x:auto !important;}
    </style>
</head>
<body>
    <div class="PageNavBar"><%=NavBar %><%=UserNavBarTools%></div>
    <div style="margin-top: 100px;">
    <button onclick="refresh()" style="direction: ltr !important;">Refresh!</button>
    <br />
    <%PrintAccountsList(); %>
    <form method="post"  id="form1" runat="server">
        <div>
     <details class="UserManagmentPageDeleteUser">
        <summary>מחיקת משתמש</summary>
         <br />
         <div>
        <input type="text" id="UserNameToDelete" name="UserNameToDelete" class="UserNameToDelete" autofocus="autofocus"/>
             לפי:
        <select id="DeletePar" name="DeletePar">
            <option value="ID">Id</option>
            <option value="Mail">מייל</option>
            <option value="Fname">שם פרטי</option>
            <option value="Lname">שם משפחה</option>
            <option value="UserName" selected="selected">שם משתמש</option>
        </select>
        <input type="checkbox" id="DeleteConfirmation" name="DeleteConfirmation" class="DeleteConfirmation"/>
        <label for="Deleteconfirmation" class="DeleteConfirmationLabel">אישור</label>
        <asp:Button ID="UserDeleteHid" runat="server" OnClick="UserDeleteHid_Click" TEXT="מחק משתמש"/>
        </div>
    </details>
    <details>
        <summary>הוספת משתמש</summary>
        <div class="TableDiv">
            <table class='UserManagmentPageAccountsListTable' style='direction:ltr !important;width:1000px !important;'>
                <tr>
                    <th style='border:2px solid black' width='150px'>שם פרטי</th>
                    <th style='border:2px solid black' width='150px'>שם משפחה</th>
                    <th style='border:2px solid black' width='120px'>שם משתמש</th>
                    <th style='border:2px solid black' width='120px'>סיסמה</th>
                    <th style='border:2px solid black' width='350px'>כתובת דואר אלקטרוני</th>
                    <th style='border:2px solid black' width='200px'>מין</th>
                    <th style='border:2px solid black' width='200px'>טלפון</th>
                    <th style='border:2px solid black'>יום הולדת</th>
                    <th style='border:2px solid black'>חודש הולדת</th>
                    <th style='border:2px solid black'>שנת הולדת</th>
                    <th style='border:2px solid black' width='200px'>מנהל?</th>
                </tr>
                <tr class='UserManagmentPageAccountsListTableRow"+ r +"' style=''>
                    <td><input type="text" id="FirstName" name="FirstName"/></td>
                    <td><input type="text" id="LastName" name="LastName"/></td>
                    <td><input type="text" id="UserName" name="UserName"/></td>
                    <td><input type="text" id="Pass" name="Pass"/></td>
                    <td><input type="text" id="mail" name="mail" size="52"/></td>
                    <td dir="rtl">זכר<input type="radio" id="Male" name="Gender" value="Male"/>נקבה<input type="radio" id="Female" name="Gender" value="Female"/></td>
                    <td><input type="text" id="Phone" name="Phone"/></td>
                    <td><select id="BDay" name="BDay"><%PrintBirthDaysSelection(); %></select></td>
                    <td>               
                        <select id="BMonth" name="BMonth">
                        <option>Jan</option>
                        <option>Feb</option>
                        <option>Mar</option>
                        <option>Apr</option>
                        <option>May</option>
                        <option>Jun</option>
                        <option>Jul</option>
                        <option>Aug</option>
                        <option>Sep</option>
                        <option>Oct</option>
                        <option>Nov</option>
                        <option>Dec</option>
                    </select>
                    </td>
                    <td><input type="text" id="BYear" name="BYear" size="28" maxlength="4"/></td>
                    <td><input type="checkbox" id="Manager" name="Manager"/></td>
                    </tr>
            </table>
        </div>
	    <asp:Button ID="InsertUserHid" runat="server" Text="הוסף משתמש" OnClick="UserInsert_Click"/>
    </details>
            <details>
                <summary>איפוס בסיס נתונים</summary>
                <asp:Button runat="server" ID="DeleteAllHid" OnClick="DeleteAllHid_Click" TEXT="איפוס"/>
            </details>
            <details class='UserManagmentPageAccountsListDetails' style='font-family: Arial;'>
                <summary>הודעות לניהול</summary>
                <div style="align-content:right !important;">
                    <%PrintManagMessages(); %>
                </div>
                </details>
            <details>
                <summary>סטטיסטיקות</summary>
                התחברויות מאז השיגור האחרון:
                <%=Application["Logins"].ToString() %>
                &nbsp
                משתמשים מחוברים:
                <%=Application["Online"].ToString() %>
                משתמשים קיימים:
                <%=TotalAccountsNum %>
                משקל האתר:
                ~5.03MB
                הודעות שנשלחו:
                <% if (Application["MesSent"] == null) { Response.Write("<i>אין נתונים</i>"); } else { Response.Write(Application["MesSent"].ToString()); } %>
            </details>
            <details dir="ltr">
                <summary>Development Info</summary>
                AvivSite
                <br />
                verison <%=SiteVr %>
                <br/>
                Fully Developed By <i class="inital">@AvivNaaman</i>
                <br />
                <a href="mailto:avivnaaman04@gmail.com?Subject=AvivSite2.1Developer">For Any Problems</a>
                <br />
                <u><b>All Rights Reserved To <i>AvivNaaman</i></b></u>
                <br />
                developed using:
                <br />
                <img src="Resources/Images/aspnet.png" style="margin-bottom:initial!important; padding:initial !important;"/>
            </details>
            </div>
    </form>
    </div>
</body>
</html>
