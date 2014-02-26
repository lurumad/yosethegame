using Nancy;
using Nancy.Responses;

namespace YoseTheGame.Server.Modules
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = _ => View["Index"];

            Get["/ping"] = _ => new JsonResponse(
                new Model.Ping
                {
                    Alive = true
                }, 
                new DefaultJsonSerializer());
        }
    }
}
