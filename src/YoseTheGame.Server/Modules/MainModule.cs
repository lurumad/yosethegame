using System;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Nancy;
using Nancy.Responses;
using Nancy.Routing;
using Newtonsoft.Json.Linq;
using YoseTheGame.Server.Model;

namespace YoseTheGame.Server.Modules
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = _ => View["Index"];

            Get["/ping"] = _ => 
                new JsonResponse(
                    new { alive = true }, 
                    new DefaultJsonSerializer());
        }
    }
}
