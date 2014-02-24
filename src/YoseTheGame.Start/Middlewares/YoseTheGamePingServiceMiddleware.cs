using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Newtonsoft.Json;

namespace YoseTheGame.Start.Middlewares
{
    public class YoseTheGamePingServiceMiddleware : OwinMiddleware
    {
        public YoseTheGamePingServiceMiddleware(OwinMiddleware next) : base(next)
        {

        }

        public override Task Invoke(IOwinContext context)
        {
            if (!context.Request.Path.Value.Equals(
                "/ping",
                StringComparison.InvariantCultureIgnoreCase))
            {
                return Next.Invoke(context);
            }

            var data = new
            {
                alive = true
            };

            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonConvert.SerializeObject(data));
        }
    }
}