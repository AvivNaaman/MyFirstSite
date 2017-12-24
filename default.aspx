<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html>

<!--FOR WEBHOSTING SERVER!(Equals to index.html or whatever)-->
<html lang="he" xmlns="http://www.w3.org/1999/xhtml" class="MainPageHTML">
<head runat="server">
    <title>AvivSite</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="Resources/CSS/GlobalStyle.css" />
    <link rel="shortcut icon" type="image/x-icon" href="Resources/Images/logo.ico"
    <meta charset="utf-8" />
</head>
<body>
    <div class="PageNavBar"><%=NavBar %><!--<marquee width="30%" speed="50"style="color:white;">HELLO</marquee>--><%=UserNavBarTools%></div>
    <form method="post" id="form1" runat="server">
        <div>
            <img src="Resources/Images/Penguins.jpg" height="750" width="1200" />
        </div>
    </form>
</body>
</html>
