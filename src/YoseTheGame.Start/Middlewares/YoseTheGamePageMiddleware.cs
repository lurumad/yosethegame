using System.Threading.Tasks;
using Microsoft.Owin;
using YoseTheGame.Start.Views;

namespace YoseTheGame.Start.Middlewares
{
    public class YoseTheGamePageMiddleware : OwinMiddleware
    {
        public YoseTheGamePageMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            var page = new YoseTheGameHomePage();
            page.Execute(context);

            return Next.Invoke(context);
        }
    }
}
