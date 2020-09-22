using Sentry;
using Sentry.Protocol;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace BaseProject.App_Start
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private IDisposable _sentrySdk;
        public override void OnException(HttpActionExecutedContext context)
        {
            _sentrySdk = SentrySdk.Init(o =>
            {
                // We store the DSN inside Web.config
                o.Dsn = new Dsn(ConfigurationManager.AppSettings["SentryDsn"]);
                // Add the EntityFramework integration
                o.AddEntityFramework();
                
            });

            SentrySdk.CaptureException(context.Exception);
            
            _sentrySdk.Dispose();
        }
    }
}