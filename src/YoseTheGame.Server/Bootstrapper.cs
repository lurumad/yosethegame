using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Responses;
using Nancy.TinyIoc;

namespace YoseTheGame.Server
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.OnError.AddItemToEndOfPipeline(
                (nancyContext, exception) => 
                    new JsonResponse(
                        new
                        {
                            error = exception.Message
                        }, 
                        new DefaultJsonSerializer()));

            base.RequestStartup(container, pipelines, context);
        }
    }
}
