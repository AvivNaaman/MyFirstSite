<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" %>

<!DOCTYPE html>

<html lang="he" xmlns="http://www.w3.org/1999/xhtml" class="MainPageHTML">
<head runat="server">
    <title><%=Title %></title>
    <link rel="stylesheet" type="text/css" href="Resources/CSS/GlobalStyle.css" />
    <link rel="shortcut icon" type="images/x-icon" href="Resources/Images/contact1.ico" />
</head>
<body>
    <div class="PageNavBar"><%=NavBar %><%=UserNavBarTools%></div>
    <br />
    <br />
    <br />
    <nav><a href="Message.aspx?mode=rec" class="linkButton">הודעות נכנסות</a> <a href="Message.aspx?mode=sent" class="linkButton">הודעות יוצאות</a> <a href="Message.aspx?mode=new" class="linkButton">הודעה חדשה</a></nav>
    <br />
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="recPanel" runat="server">
                <table width="50%">
                    <tr>
                        <th style="border:1px solid black">ID</th>
                        <th style="border:1px solid black">שולח</th>
                        <th style="border:1px solid black">תאריך\שעה</th>
                        <th style="border:1px solid black">נושא</th>
                    </tr>
                    <%=outputR %>
                </table>
            </asp:Panel>
            <asp:Panel ID="sentPanel" runat="server">
                 <table width="50%">
                    <tr>
                        <th style="border:1px solid black">ID</th>
                        <th style="border:1px solid black">נשלח אל</th>
                        <th style="border:1px solid black">תאריך\שעה</th>
                        <th style="border:1px solid black">נושא</th>
                    </tr>
                    <%=outputS %>
                </table>
            </asp:Panel>
            <asp:Panel ID="newPanel" runat="server">
                נמען:
                <select id="users"  name="SendToUser">
                    <option value="default" selected="selected">Select User</option>
                    <%newMessOptUser(); %>
                </select>
                <br />
                מוען:
                <input type="text" disabled="disabled" value="<%=Session["User"].ToString() %>"/>
                <br />
                נושא:
                <input type="text" id="subject" name="subject" placeholder="הקלד נושא כאן..."/>
                <br />
                <textarea style="resize:none;font-family:Arial;" placeholder="הקלד הודעתך כאן..." cols="75" rows="25" id="content" name="content"></textarea>
                <br />
                <input type="submit" runat="server" />
            </asp:Panel>
            <asp:Panel ID="viewPanel" runat="server">
                <h1>הודעה: <%=Subject %></h1>
                <h2>נשלח ע"י <%=From %> בתאריך <span dir="ltr"><%=SDate %></span></h2>
                <p><%=Content %></p>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
