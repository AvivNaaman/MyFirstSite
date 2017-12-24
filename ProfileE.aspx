<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfileE.aspx.cs" Inherits="ProfileE" %>

<!DOCTYPE html>

<html lang="he" xmlns="http://www.w3.org/1999/xhtml" class="ProfileEditHTML" lang="he">
<head runat="server">
    <title></title><!--Sets By asp.-->
    <link rel="stylesheet" type="text/css" href="Resources/CSS/GlobalStyle.css" />
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0"/>
    <meta name="CODE_LANGUAGE" Content="C#"/>
    <meta name=vs_defaultClientScript content="JavaScript"/>
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5"/>
    <style>
        th, td, table {
            border: 1px solid black;
        }
        table {
            border-collapse:collapse;
        }
        td {
            padding: 6px;
        }
    </style>
    <script>
        function checkedChange(FromSt, ToSt)
        {
            var c = document.getElementById(FromSt).checked;
            if (c == false)
            {
                document.getElementById(ToSt).disabled = true;
                document.getElementById(ToSt).value = '';
            }
            else
            {
                document.getElementById(ToSt).disabled = false;
            }
        }
    </script>
</head>
<body onload="checkedChange('fcheck', 'Fname');checkedChange('lcheck', 'Lname');checkedChange('mcheck', 'mail');checkedChange('pcheck', 'PhoneLast');">
    <div class="PageNavBar"><%=NavBar %><%=UserNavBarTools%></div>
    <br />
    <br />
    <div>
        <img src="<%=PPpath() %>" height="225" width="225" alt="ProfilePhoto" style="margin-bottom:0px!important;padding:10px !important;"/>
    </div>
    <h2>עריכת פרטי חשבון:</h2>
    <form method="post"  id="form1" runat="server" enctype="multipart/form-data">
        <asp:Panel runat="server" ID="MainPanel">
            <div>
                <table>
                        <tr>
                            <td>
                                <input type="checkbox" id="fcheck" onchange="checkedChange('fcheck', 'Fname')"/>
                            </td>
                            <td>
                                שם פרטי:
                            </td>
                            <td>
                                <%=Fname %>
                            </td>
                            <td>
                                <input type="text" id="Fname" name="Fname" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="checkbox" id="lcheck" onchange="checkedChange('lcheck', 'Lname')"/>
                            </td>
                            <td>
                                שם משפחה
                            </td>
                            <td>
                                <%=Lname %>
                            </td>
                            <td>
                                <input type="text" id="Lname" name="Lname" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="checkbox" id="mcheck" onchange="checkedChange('mcheck', 'mail')"/>
                            </td>
                            <td>
                                כתובת מייל
                            </td>
                            <td>
                                <%=mail %>
                            </td>
                            <td>
                                <input type="text" id="mail" name="mail" maxlength="40" size="25" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="checkbox" id="pcheck" onchange="checkedChange('pcheck', 'PhoneLast')"/>
                            </td>
                            <td>
                                מספר טלפון
                            </td>
                            <td>
                                <%=Phone %>
                            </td>
                            <td>
                                <input type="text" id="PhoneLast" name="PhoneLast" maxlength="7" size="6"/>
                                <span> - </span>
                                <select id="PhoneMid" name="PhoneMid">
                                    <option value="50">50</option>
                                    <option value="52">52</option>
                                    <option value="53">53</option>
                                    <option value="54">54</option>
                                    <option value="55">55</option>
                                    <option value="58">58</option>
                                </select>
                                <select id="PhoneFirst" name="PhoneFirst">
                                    <%PrintPhoneCountryselection(); %>
                                </select>
                                <span>+</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="checkbox" id="bcheck" name="bcheck"/>
                            </td>
                            <td>
                                תאריך יום הולדת
                            </td>
                            <td>
                                <%=Birth %>
                            </td>
                            <td>
                                <select id="BirthYear" name="BirthYear">
                                    <%PrintBirthYears(); %>
                                </select> / 
                                <select id="BirthMonth" name="BirthMonth">
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
                                </select> / 
                                <select id="BirthDay" name="BirthDay">
                                    <%PrintBirthDays(); %>
                                </select> 
                            </td>
                        </tr>
                </table>
                <asp:Button OnClick="ChangeDetails_Click" runat="server" ID="ChangeDetails" Text="עדכן פרטים"/>
                <h2>שינוי סיסמה:</h2>
                סיסמה ישנה:<input type="password" id="OldPass" name="OldPass" />
                <br />
                סיסמה חדשה:<input type="password" id="NewPass" name="NewPass"/>
                <br />
                אימות סיסמה:<input type="password" id="NewPassV" name="NewPassV" />
                <br />
                <asp:Button OnClick="ChangePass_Click" ID="ChangePass" runat="server" Text="עדכן סיסמה" />
                <br />
                <a href="ProfileE.aspx?p=up"><img src="Resources/Images/upload.jpg" height="50" width="50" style="margin-bottom:initial;display:inline;"/></a>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="UploadPanel">
            <input type="file" runat="server" id="File1" NAME="File1"/>
            <br />
            <input type="submit" id="Submit1" value="העלה" runat="server" NAME="Submit1"/>
            <br />
            <%=UploadInfo %>
            <br />
            +יכול להיווצר עיקוב בהשלמת שינוי התמונה.
            <br />
            <a href="ProfileE.aspx?p=m">ערוך חשבון</a>
        </asp:Panel>
    </form>
        <a href="Message.aspx"><img src="Resources/Images/contact.png" alt="mail" height="50" width="50" style="margin-bottom:initial;display:inline;"/></a>
</body>
</html>
