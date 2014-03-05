using System.Dynamic;
using System.Linq;
using Nancy;
using Nancy.Responses;
using YoseTheGame.Server.Model;

namespace YoseTheGame.Server.Modules
{
    public class PrimeFactorsModule : NancyModule
    {
        public PrimeFactorsModule()
        {
            Get["/primeFactors"] = parameters =>
            {
                var primeFactors = new PrimeFactors();
                var numberParameter = Request.Query.number;

                if (!numberParameter.HasValue)
                {
                    return BuildJsonResponse(new {error = "number parameter is not present in the querystring"});
                }

                string [] numbers = numberParameter.ToString().Split(',');

                if (numbers.Length > 1)
                {
                    var dynamicArray = numbers.Select(number => ProcessNumber(primeFactors, number)).ToList();
                    return BuildJsonResponse(dynamicArray);
                }

                return BuildJsonResponse(ProcessNumber(primeFactors, numberParameter));
            };

            Get["/primeFactors/ui"] = _ => View["Index"];
        }

        private dynamic ProcessNumber(PrimeFactors primeFactors, dynamic number)
        {
            dynamic response = new ExpandoObject();
            response.number = number;

            int result;
           
            if (!int.TryParse(number, out result))
            {
                response.error = "not a number";
                return response;
            }

            if (primeFactors.IsBigNumber(result))
            {
                response.error = "too big number (>1e6)";
                return response;
            }

            response.decomposition = primeFactors.Decomposition(result);

            return response;
        }

        private JsonResponse BuildJsonResponse(dynamic json)
        {
            return new JsonResponse(
                json,
                new DefaultJsonSerializer());
        }
    }
}