namespace YoseTheGame.Start.Views
{
    public class YoseTheGamePage : Microsoft.Owin.Diagnostics.Views.BaseView
    {
        public override void Execute()
        {
            Context.Response.ContentType = "text/html";

            WriteLiteral("\r\n<!DOCTYPE html>");
            WriteLiteral("\n\r<html>");
            WriteLiteral("\n\r<head>");
            WriteLiteral("\n\r<title>YoseTheGame</title>");
            WriteLiteral("\n\r</head>");
            WriteLiteral("\n\r<body>");
            WriteLiteral("\n\r<p>Hello Yose");
            WriteLiteral("\n\r<p>YoseTheGame practice using Katana + Azure</p><a href=\"https://github.com/lurumad/yosethegame\">Github repository</a>");
            WriteLiteral("\n\r</body>");
            WriteLiteral("\n\r</html>");
        }
    }
}
