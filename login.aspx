<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html lang="he" xmlns="http://www.w3.org/1999/xhtml" class="LoginPageHTML SignInbody">
<head runat="server">
    <title>התחבר</title>
    <meta name="viewport" content="width=device-width; initial-scale=1; maximum-scale=1"/>
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="Resources/CSS/GlobalStyle.css" />
    <style>
        <%=ChangeThePassToRed %>
        <%=ChangeTheUserToRed %>
    </style>
</head>
<body>
    <center>
        <form method="post"  id="form1" runat="server" class="container">
            <div>
                <h1 class="LoginPageOut LoginPageShadow">התחברות</h1>
                <span class="LoginPageOut LoginPageShadow">שם משתמש:</span>
                <input type="text" id="LoginUserName" name="LoginUserName" class="LoginUserName LoginPageBoxShadow" autofocus="autofocus" maxlength="20"/>
                <br />
                <br />
                <span class="LoginPageOut LoginPageShadow">סיסמה:</span>
                <input type="password" id="LoginUserPass" name="LoginUserPass" class="LoginUserPass LoginPageBoxShadow" maxlength="20"/>
                <br />
                <br />
                <input type="submit" runat="server" id="LoginSubmit" name="LoginSubmit" class="LoginSubmit LoginPageBoxShadow"/>
                <br />
                <br />
                <span class="LoginPageShadow"><a href="SignUp.aspx" style="color:white !important;">הירשם</a></span>
                <br />
                <span class="LoginPageShadow LoginPageOut" style="width:auto;"><%=Invalid %></span>
            </div>
        </form>
    </center>
</body>
</html>
