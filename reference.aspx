<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reference.aspx.cs" Inherits="reference" %>

<!DOCTYPE html>

<html lang="he" xmlns="http://www.w3.org/1999/xhtml" class="ReferencePageHTML">
<head runat="server">
    <title>רשימות</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" type="text/css" href="Resources/CSS/GlobalStyle.css" />
    <link rel="shortcut icon" type="image/x-icon" href="Resources/Images/list.ico" />
    <style>
        table, th, td {
            border: 1px solid black;
        }
        table {
            border-collapse:collapse;
        }
        td {
            padding-left: 5px;
        }
    </style>
    <script type="text/javascript">
        function SearchTable(InputName, TableName) {
            var input, filter, table, tr, td, i, r;
            input = document.getElementById(InputName);
            filter = input.value.toUpperCase();
            table = document.getElementById(TableName);
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[0];
                if (td) {
                    if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
    </script>
</head>
<body>
    <div class="PageNavBar"><%=NavBar %><%=UserNavBarTools%></div>
    <br />
    <h1>רשימות:</h1>
    <form method="post"  id="form1" runat="server">
        <div>
            <h2>תגיות HTML</h2>
            <input type="text" onkeyup="SearchTable('HTMLin', 'HTML')" id="HTMLin" placeholder="חפש..." class="SearchBox"/>
		    <table border="1" width="100%" id="HTML">
			    <tr>
				    <th>התגית</th>
				    <th>משמשת ל..</th>
				    <th>דוגמה</th>
			    </tr>
			    <tr>
				    <td dir="ltr"><<span>!--comments...--</span>></td>
				    <td>כתיבת הערה בדף.</td>
				    <td></td>
			    </tr>
			    <tr>
				    <td dir="ltr"><<span>a href=""><</span>/a></td>
				    <td>הוספת היפר קישור</td>
				    <td><a href="../" target="_blank">פתח דף בית</a></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>b><</span>/b></td>
				    <td>הדגשת טקסט</td>
				    <td><b>זהו טקסט מודגש</b></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>body><</span>/body></td>
				    <td>כולל בתוכו כל מה שמופיע בדף (ויזואלית)</td>
				    <td></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>br></span></td>
				    <td>יורד שורה באתר</td>
				    <td>hi<br /> <%=Session["User"] %></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>button><</span>button/></td>
				    <td>יוצר כפתור.</td>
				    <td><button>לחץ עליי</button></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>canvas><</span>/canvas></td>
				    <td>יוצר משטח גרפיקה שניתן לשינוי ע"י ג'בה סקריפט.</td>
				    <td><canvas id="MyCanvas" style="border:1px solid black" height="100" width="100"></canvas></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>div><</span>/div></td>
				    <td>יוצר מקטע (משמש להפרדה, דירוג ומיון, בעיקר לשינויי סגנון)</td>
				    <td></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>form><</span>/form></td>
				    <td>יוצר טופס. בתוכו שמים קלטים.</td>
				    <td></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>h1..h6><</span>/h1..h6></td>
				    <td>הוספת כותרת. ככל שהמספר גדל כך הגודל קטן.</td>
				    <td><h1>כותרת 1</h1><h2>כותרת 2</h2><h3>כותרת 3</h3></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>head><</span>/head></td>
				    <td>תגית משמעותית, בתוכה נמצאות הגדרות של הדף (דברים שלא רואים בדפדפן)</td>
				    <td></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>hr></span></td>
				    <td>יוצר קו הפרדה</td>
				    <td>שלום<hr />לך</td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>html><</span>/html></td>
				    <td>תגית שכוללת בה את כל המסמך. התגית הראשית, בתוכה תגיות הhead והbody.</td>
				    <td></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>i><</span>/i></td>
				    <td>מטה את הטקסט</td>
				    <td><i>טקסט מוטה</i></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>img</span>/></td>
				    <td>מוסיף תמונה.</td>
				    <td><img src="Resources/Images/CSS3.png" height="130" width="100" style="margin-bottom:initial !important;"/></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>input</span>/></td>
				    <td>מוסיף קלט.</td>
				    <td><input type="text" /><input type="button" value="שלח" /></td>
			    </tr>
                <tr id="option">
				    <td dir="ltr"><<span>option><</span>/option></td>
				    <td>מגדיר אפשרות לבחירה בתוך קלט מסוג תיבת גלילה.</td>
				    <td></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>script type="text/javascript"><</span>script/></td>
				    <td>תגית אשר בתוכה נרשם תסריט</td>
				    <td></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>select><</span>/select></td>
				    <td>תגית קלט מסוג תיבת גלילה. בתוכה יש להכניס תגיות <a href="#option">אפשרות</a></td>
				    <td></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>table><</span>/table></td>
				    <td>תגית המגדירה טבלה. יש למקם בתוכה עוד תגיות על מנת שתוצג טבלה.</td>
				    <td><table width="50px"><tr><td>א</td><td>ב</td></tr><tr><td>ג</td><td>ד</td></tr></table></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>td><</span>/td></td>
				    <td>מגדיר תא רגיל של טבלה. יש למקם את התא בתוך תגית שורה בתוך תגית טבלה.</td>
				    <td><table width="50px"><tr><td>א</td><td>ב</td></tr><tr><td>ג</td><td>ד</td></tr></table></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>textarea><</span>/textarea></td>
				    <td>מגדיר מקום להערה, לטקסט נרחב.</td>
				    <td><textarea></textarea></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>th><</span>/th></td>
				    <td>מגדיר תא כותרת (טקסט מודגש וממורכז) בטבלה.</td>
				    <td><table width="50px"><tr><th>א</th><th>ב</th></tr><tr><th>ג</th><th>ד</th></tr></table></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>title><</span>/title></td>
				    <td>מגדיר את הכותרת של הכרטיסייה. ממוקם בhead</td>
				    <td></td>
			    </tr>
                <tr>
				    <td dir="ltr"><<span>tr><</span>/tr></td>
				    <td>מגדיר שורה בתוך תגית טבלה. בתוך השורה נמאים התאים</td>
				    <td><table width="50px"><tr><td>א</td><td>ב</td></tr><tr><td>ג</td><td>ד</td></tr></table></td>
			    </tr>
                <tr>
				    <td dir="ltr"   ><<span>u><</span>/u></td>
				    <td>משנה את הטקסט לטקסט עם קו תחתי.</td>
				    <td><u>טקסט עם קו תחתי.</u></td>
			    </tr>
		    </table>
            <h2>פקודות JavaScript</h2>
            <input type="text" onkeyup="SearchTable('Jsin', 'Js')" id="Jsin" placeholder="חפש..." class="SearchBox"/>
            <table width="100%" id="js">
                <tr>
                    <th>קוד</th>
                    <th>שימוש</th>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">alert(message);</td>
                    <td>הודעה למשתמש (פופ-אפ)</td>
                </tr>
                <tr>
                    <td dir="ltr">document.write(output);</td>
                    <td>לוקח את הטקסט ושם אותו בתוך הbody</td>
                </tr>
                <tr>
                    <td dir="ltr">var x;</td>
                    <td>הכרזה על משתנה</td>
                </tr>
                <tr>
                    <td dir="ltr">prompt(message)</td>
                    <td>קולט מידע מהמשתמש ע"י פופ-אפ עם שדה טקסט.</td>
                </tr>
                <tr>
                    <td dir="ltr">parseInt(input)</td>
                    <td>קליטת ערך מסוים כמספר שלם.</td>
                </tr>
                <tr>
                    <td dir="ltr">if (bool) { ... }</td>
                    <td>מבצע קוד בתנאי שהביטוי בסוגריים הוא ביטוי אמת.</td>
                </tr>
                <tr>
                    <td dir="ltr">else { ... }</td>
                    <td>נכתב אחרי הוראת if. מבצע את ההוראות בצומדיים אם הביטוי בif הוא ביטוי שקר.</td>
                </tr>
                <tr>
                    <td dir="ltr">function (num1, num1) { ... }</td>
                    <td>מגדיר פונקציה. בסוגריים ניתן להוסיף פרמטרים, שמוגדרים כאשר הפונקציה מופעלת.</td>
                </tr>
                <tr>
                <td dir="ltr">while (bool) { ... }</td>
                    <td>לולאה אשר מבצעת את הקוד כל עוד ערך הביטוי הוא נכון.</td>
                </tr>
                <tr>
                <td dir="ltr">for (var x = 0; x > 5; x++) { ... }</td>
                    <td>לולאה אשר מבצעת פעולה מספר פעמים, לפי ערך המשתנה. בסוגריים נמצאים: הגדרת המשתנה ואיפוסו, התנאי להפסקת הלולאה, שינוי ערך המשתנה בסיום סיבוב של הלולאה.</td>
                </tr>
            </table>
            <h2>פקודות canvas</h2>
            <input type="text" onkeyup="SearchTable('Canin', 'canvas')" id="Canin" placeholder="חפש..." class="SearchBox"/>
            <table width="100%" id="canvas">
                <tr>
                    <th>קוד</th>
                    <th>שימוש</th>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.fillStyle = color;</td>
                    <td>קובע את מילוי הצורה</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.fillRect(X, Y, width, height);</td>
                    <td>יוצר מלבן, לפי גובה, רוחב, ומיקום.</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.moveTo(X, Y);</td>
                    <td>קובע מיקום התחלה (לקו לדוגמה)</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.lineTo(X, Y);</td>
                    <td>קובע את מילוי הצורה</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.stroke();</td>
                    <td>יוצר גבול לצורה.</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.strokeStyle = color;</td>
                    <td>קובע את צבע הגבול.</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.fillStyle = color;</td>
                    <td>קובע את מילוי הצורה</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.beginPath();</td>
                    <td>מתחיל ציור מעגל.</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.font = "size Font-Family";</td>
                    <td>יוצר מעגל, לפי רדיוס, ומיקום בצירים.</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.font = "size Font-Family";</td>
                    <td>קובע מאפיינים לפונט של הטקסט שיוצג.</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.textAlign = "center";</td>
                    <td>קובע מיקום אופקי של הטקסט</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.fillText(text, x, y);</td>
                    <td>כותב טקסט לפי המאפיינים ומאפייני מילוי.</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.strokeText(text, x, y)ף</td>
                    <td>כתוב טקסט מודגש בגבולו לפי המאפיינים שהוגדרו לגבול.</td>
                </tr>
                <tr>
                    <td dir="ltr" width="25%">ctx.drawImage(image, x, y);</td>
                    <td>יוצר תמונה על הקנבס (יש ליצור object לתמונה לפני כן)</td>
                </tr>
            </table>
            <h2>מאפייני סגנון (CSS)</h2>
            <input type="text" onkeyup="SearchTable('cssin', 'css')" id="cssin" placeholder="חפש..." class="SearchBox"/>
            <table width="100%" id="css">
                <tr>
                    <th>מאפיין</th>
                    <th>תיאור</th>
                    <th>דוגמה</th>
                </tr>
                <tr>
                    <td dir="ltr">align: right/left/center;</td>
                    <td>קובע את המיקום האופקי של התוכן.</td>
                    <td align="center">טקסט ממורכז</td>
                </tr>
                <tr>
                    <td dir="ltr">font-family: Family Name(Arial, Comic Sans MS, Gisha...);</td>
                    <td>קובע את הפונט.</td>
                    <td style="font-family:Aharoni">פונט אהרוני</td>
                </tr>
                <tr>
                    <td dir="ltr">color: color (#aaaaaa/(255, 255, 255)/ColorName);</td>
                    <td>מגדיר צבע טקסט</td>
                    <td style="color:#aaaaaa">טקסט אפור</td>
                </tr>
                <tr>
                    <td dir="ltr">background-color: color (#aaaaaa/(255, 255, 255)/ColorName);</td>
                    <td>מגדיר צבע רקע</td>
                    <td style="background-color:#ff0000">רקע אדום</td>
                </tr>
                <tr>
                    <td dir="ltr">font-size: size (px);</td>
                    <td>מגדיר גודל טקסט</td>
                    <td style="font-size: 125%">טקסט בגודל 125% </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
