using Owin;
using YoseTheGame.Start.Middlewares;

namespace YoseTheGame.Start.Extensions
{
    public static class YoseTheGameExtensions
    {
        public static IAppBuilder UseYoseTheGamePage(this IAppBuilder app)
        {
            return app.Use(typeof (YoseTheGamePageMiddleware));
        }

        public static IAppBuilder UseYoseTheGamePingService(this IAppBuilder app)
        {
            return app.Use(typeof(YoseTheGamePingServiceMiddleware));
        }
    }
}
