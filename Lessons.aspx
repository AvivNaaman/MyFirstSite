<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lessons.aspx.cs" Inherits="lessons" %>

<!DOCTYPE html>

<html lang="he" xmlns="http://www.w3.org/1999/xhtml" class="LessonsPageHTML">
<head runat="server">
    <title>למד</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" type="text/css" href="Resources/CSS/GlobalStyle.css" />
    <link rel="shortcut icon" href="Resources/Images/HTML5_CSS_JavaScript1.ico" type="image/x-icon"/>
    <meta charset="utf-8" />
</head>
<body>
    <div class="PageNavBar"><%=NavBar %><%=UserNavBarTools%></div>
    <br />
    <br />
    <br />
    <nav><a href="#HTML1" class="linkButton">HTML</a> <a class="linkButton" href="#Js1">Js</a></nav>
    <form method="post"  id="form1" runat="server">
        <div class="LessonsMainDiv">
            <div id="HTML">
                <div class="LessonsBannerDiv" style="float:right;" id="HTML1">
                    <a href="Lessons/HTML/HTML1.aspx"><img src="Resources/Images/Banners/HTML/HTML1.png" alt="HTML1" height="500" width="500" class="LessonsBanner"/></a>
                </div>
                <div class="LessonsBannerDiv" style="float:left;">
                    <a href="Lessons/HTML/HTML2.aspx"><img src="Resources/Images/Banners/HTML/HTML2.png" alt="HTML2" height="500" width="500" class="LessonsBanner"/></a>
                </div>
                <div class="LessonsBannerDiv" style="float:right;">
                    <a href="Lessons/HTML/HTML3.aspx"><img src="Resources/Images/Banners/HTML/HTML3.png" alt="HTML3" height="500" width="500" class="LessonsBanner"/></a>
                </div>
                <div class="LessonsBannerDiv" style="float:left;">
                    <a href="Lessons/HTML/HTML4.aspx"><img src="Resources/Images/Banners/HTML/HTML4.png" alt="HTML4" height="500" width="500" class="LessonsBanner"/></a>
                </div>
            </div>
            <div id="Js">
                <div class="LessonsBannerDiv" style="float:right;" id="Js1">
                    <a href="Lessons/Js/Js1.aspx"><img src="Resources/Images/Banners/JS/Js1.png" alt="Js1" class="LessonsBanner" /></a>
                </div>
                <div class="LessonsBannerDiv" style="float:left;" id="Js2">
                    <a href="Lessons/Js/Js2.aspx"><img src="Resources/Images/Banners/JS/Js2.png" alt="Js2" class="LessonsBanner" /></a>
                </div>
                <div class="LessonsBannerDiv" style="float:right;" id="Js3">
                    <a href="Lessons/Js/Js3.aspx"><img src="Resources/Images/Banners/JS/Js3.png" alt="Js3" class="LessonsBanner" /></a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
