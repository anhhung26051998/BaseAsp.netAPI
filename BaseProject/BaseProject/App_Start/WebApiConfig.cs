
using BaseProject.App_Start;
using Newtonsoft.Json.Serialization;
using Owin;
using Sentry;
using Sentry.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace BaseProject
{
    public static class WebApiConfig
    {
   

        public static void Register(HttpConfiguration config)
        {
            
     
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Filters.Add(new CustomExceptionFilter());
        }
    }
}
