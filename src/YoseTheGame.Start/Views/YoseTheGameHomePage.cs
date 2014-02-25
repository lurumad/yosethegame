using System;

namespace YoseTheGame.Start.Views
{
    public class YoseTheGameHomePage : Microsoft.Owin.Diagnostics.Views.BaseView
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
            WriteLiteral("\n\r<h1>Hello Yose</h1>");
            WriteLiteral("\n\r<p>YoseTheGame practice using Katana + Azure</p>");
            WriteLiteral("\r\n<a id=\"repository-link\" href=\"https://github.com/lurumad/yosethegame\">Github repository</a>");
            WriteLiteral("\r\n<a id=\"contact-me-link\" href=\"http://www.linkedin.com/in/luisruizpavon\">About me</a>");
            WriteLiteral("\n\r<p>Ping service</p>");
            WriteLiteral("\r\n<a id=\"ping-challenge-link\" href=\"http://yosethegame.cloudapp.net/ping\">Test</a>");
            WriteLiteral("\n\r</body>");
            WriteLiteral("\n\r</html>");
        }
    }
}
