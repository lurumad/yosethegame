using Owin;
using YoseTheGame.Start.Extensions;

namespace YoseTheGame.Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseYoseTheGamePingService();
            app.UseYoseTheGamePage();
        }
    }
}
