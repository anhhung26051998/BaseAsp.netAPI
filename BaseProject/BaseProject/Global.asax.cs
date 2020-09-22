using Sentry;
using Sentry.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BaseProject
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IDisposable _sentrySdk;
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
           GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SentryDatabaseLogging.UseBreadcrumbs();
            _sentrySdk = SentrySdk.Init(o =>
            {
                // We store the DSN inside Web.config
                o.Dsn = new Dsn(ConfigurationManager.AppSettings["SentryDsn"]);
                // Add the EntityFramework integration
                o.AddEntityFramework();
            });


        }
        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            SentrySdk.CaptureException(exception);
        }

        public override void Dispose()
        {
            _sentrySdk.Dispose();
            base.Dispose();
        }
    }
}
