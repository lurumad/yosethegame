using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Microsoft.Owin.Hosting;
using Microsoft.WindowsAzure.ServiceRuntime;
using YoseTheGame.Server;

namespace YoseTheGame.ServerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private IDisposable _app;

        public override void Run()
        {
            Trace.TraceInformation("YoseTheGame.StartRole entry point called");

            while (true)
            {
                Thread.Sleep(10000);
                Trace.TraceInformation("Working");
            }
        }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["YoseEndpoint"];
            var url = String.Format("{0}://{1}", endpoint.Protocol, endpoint.IPEndpoint);

            _app = WebApp.Start<Startup>(new StartOptions(url));

            return base.OnStart();
        }

        public override void OnStop()
        {
            if (_app != null)
                _app.Dispose();

            base.OnStop();
        }
    }
}
