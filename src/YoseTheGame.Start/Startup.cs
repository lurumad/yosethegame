using Newtonsoft.Json;
using Owin;

namespace YoseTheGame.Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                if (context.Request.Path.Value == "/ping")
                {
                    var jsonAlive = new {alive = true};
                    context.Response.ContentType = "application/json";
                    return context.Response.WriteAsync(JsonConvert.SerializeObject(jsonAlive));
                }

                context.Response.ContentType = "text/html";
                return context.Response.WriteAsync("Hello Yose <a href=\"https://github.com/lurumad/yosethegame\">Github repo</a>");
            });
        }
    }
}
