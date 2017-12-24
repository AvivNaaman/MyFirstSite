<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html lang="he" xmlns="http://www.w3.org/1999/xhtml" class="SignUpPageHTML">
<head runat="server">
    <title>הרשמה</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" type="text/css" href="Resources/CSS/GlobalStyle.css" />
</head>
<body>
    <center>
        <h1 class="SignUpPageShadow">הרשמה</h1>
        <form method="post"  id="form1" runat="server" class="container">
            <div class="container">
                <span class="SignUpPageShadow">שם פרטי:</span>
                <input type="text" id="FirstName" name="FirstName" class="SignUpPageBoxShadow SignUpTextBox" maxlength="13"/>
                <br />
                <br />
                <span class="SignUpPageShadow">שם משפחה:</span>
                <input type="text" id="LastName" name="LastName" class="SignUpPageBoxShadow SignUpTextBox" maxlength="13"/>
                <br />
                <br />
                <span class="SignUpPageShadow">שם משתמש:</span>
                <input type="text" id="UserName" name="UserName" class="SignUpPageBoxShadow SignUpTextBox" maxlength="10"/>
                <br />
                <br />
                <span class="SignUpPageShadow">סיסמה:</span>
                <input type="password" id="Password" name="Password" class="SignUpPageBoxShadow SignUpTextBox" maxlength="10"/>
                <br />
                <br />
                <span class="SignUpPageShadow">מייל:</span>
                <input type="text" id="Mail" name="Mail" class="SignUpPageBoxShadow SignUpTextBox" maxlength="40" size="30"/>
                <br />
                <br />
                <span class="SignUpPageShadow">מין: &nbsp זכר</span>
                <input type="radio" id="Male" name="Gender" class="SignUpPageShadow" value="Male" checked="checked"/>
                <span class="SignUpPageShadow">נקבה</span>
                <input type="radio" id="Female" name="Gender" class="SignUpPageShadow" value="Female" />
                <br />
                <br />
                <span class="SignUpPageShadow">טלפון:</span>
                <input type="text" id="PhoneLast" name="PhoneLast" class="SignUpPageBoxShadow SignUpTextBox" maxlength="7" size="6"/>
                <span class="SignUpPageShadow"> - </span>
                <select id="PhoneMid" name="PhoneMid" class="SignUpPageBoxShadow SignUpTextBox">
                    <option class="SignUpPageBoxShadow" value="null" selected="selected">&nbsp</option>
                    <option value="50">50</option>
                    <option value="52">52</option>
                    <option value="53">53</option>
                    <option value="54">54</option>
                    <option value="55">55</option>
                    <option value="58">58</option>
                </select>
                <select class="SignUpPageBoxShadow SignUpTextBox" id="PhoneFirst" name="PhoneFirst">
                    <%PrintPhoneCountryselection(); %>
                </select>
                <span class="SignUpPageShadow">+</span>
                <br />
                <br />
                <span class="SignUpPageShadow">תאריך לידה:</span>
                <select class="SignUpPageBoxShadow SignUpTextBox" id="BirthYear" name="BirthYear">
                    <option value="null" selected="selected">שנה</option>
                    <%PrintBirthYearsSelection(); %>
                </select>
                <span class="SignUpPageShadow">/</span>
                <select class="SignUpPageBoxShadow SignUpTextBox" id="BirthMonth" name="BirthMonth">
                    <option value="null" selected="selected">חודש</option>
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
                <span class="SignUpPageShadow">/</span>
                <select class="SignUpPageBoxShadow SignUpTextBox" id="BirthDay" name="BirthDay">
                    <option value="null" selected="selected">יום</option>
                    <%PrintBirthDaysSelection(); %>
                </select>
                <br />
                <div style="margin-top: 10px;">
                    <input type="submit" runat="server" id="SubmitSignUp" name="SubmitSignUp" class="SignUpPageBoxShadow SignUpTextBox"/>
                    <input type="reset" name="SignUpReset" id="SignUpReset" class="SignUpPageBoxShadow SignUpTextBox"/>
                </div>
            </div>
        </form>
        <span class="SignUpPageShadow"><a href="login.aspx" style="color:black !important;">התחבר</a></span>
    </center>
    <%=Errors %>
</body>
</html>
