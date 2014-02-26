using System.Linq;
using Nancy;
using Nancy.Responses;
using Nancy.Routing;

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

            Get["/primeFactors"] = parameters =>
            {

            };   
        }
    }
}
