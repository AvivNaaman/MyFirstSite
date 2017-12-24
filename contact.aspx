<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<!DOCTYPE html>

<html lang="he" xmlns="http://www.w3.org/1999/xhtml"  class="MainPageHTML">
<head runat="server">
    <title>צור קשר</title>
    <link rel="Stylesheet" type="text/css" href="Resources/CSS/GlobalStyle.css" />
    <link rel="shortcut icon" type="images/x-icon" href="Resources/Images/contact1.ico" />
    <meta name="viewport" content="width=device-width; initial-scale=1; maximum-scale=1"/>
</head>
<body>
    <div class="PageNavBar"><%=NavBar %><%=UserNavBarTools%></div>
    <br />
    <br />
    <br />
    <center>
    <form id="form1" runat="server">
        <div>
            <h1>צור קשר:</h1>
            <input type="text" id="UserName" name="UserName" disabled="disabled" value="שם: <%=Session["User"] %>" style="text-align:center"/>
            <br />
            נושא:
            <input type="text" id="Subject" name="Subject" maxlength="50" placeholder="הקלד נושא..." size="45"/>
            <br/>   
            <br />
            <textarea style="resize:none; font-family:Arial !important;"  id="Message" name="Message" maxlength="1000" rows="20" cols="50" placeholder="הקלד הודעתך כאן..."></textarea>
            <br />
            <input type="submit" runat="server" />
            <input type="reset" />
        </div>
    </form>
        </center>
</body>
</html>
