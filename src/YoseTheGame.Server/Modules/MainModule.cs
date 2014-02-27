using System;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Nancy;
using Nancy.Responses;
using Nancy.Routing;
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

            Get["/primeFactors"] = parameters =>
            {
                var primeFactors = new PrimeFactors();
                dynamic response = new ExpandoObject();
                response.number = Request.Query.number;

                if (!primeFactors.IsValidNumber(response.number))
                {
                    response.error = "not a number";
                    return BuildJsonResponse(response);
                }

                if (primeFactors.IsBigNumber(response.number))
                {
                    response.error = "too big number (>1e6)";
                    return BuildJsonResponse(response);
                }

                response.decomposition = primeFactors.Decomposition(response.number);

                return BuildJsonResponse(response);
            };   
        }

        private JsonResponse BuildJsonResponse(dynamic json)
        {
            return new JsonResponse(
                json,
                new DefaultJsonSerializer());
        }
    }
}
