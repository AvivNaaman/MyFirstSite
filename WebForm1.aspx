<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm1.aspx.cs" Inherits="WebForm1" %>

<!DOCTYPE html>

<html lang="he" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="Resources/CSS/GlobalStyle.css" />
</head>
<body style="font-size:150%" class="MainPageHTML">
    <div class="PageNavBar"><%=NavBar %><%=UserNavBarTools%></div>
    <br />
    <br />
    <br />
    <center>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
        <div style="width:1500px!important;">
            <input type="file" runat="server" id="File1" NAME="File1" style="height:200px; width:900px; font-size:72px" dir="ltr"/>
            <br />
            <br />
            <br />
            <input type="submit" id="Submit1" value="Upload" runat="server" NAME="Submit1" style="height:300px; width:750px; font-size:72px"/>
            <%=UploadInfo %>
        </div>
    </form>
    </center>
</body>
</html>
