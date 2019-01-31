using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services

			// Web API routes
			//config.MapHttpAttributeRoutes();

			//         config.Routes.MapHttpRoute(
			//             name: "ActionApi",
			//             routeTemplate: "api/{controller}/{action}/{id}",
			//             defaults: new { id = RouteParameter.Optional }
			//         );
			//         config.Routes.MapHttpRoute(
			//             name: "DefaultApi",
			//             routeTemplate: "api/{controller}/{id}",
			//             defaults: new { id = RouteParameter.Optional }
			//         );
			//         config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
			//config.Formatters.Remove(config.Formatters.XmlFormatter);
			//config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

			//var cors = new EnableCorsAttribute("http://localhost:1010", "*", "*");
			//config.EnableCors(cors);
			// Web API configuration and services  
			config.Formatters.Clear();
			config.Formatters.Add(new JsonMediaTypeFormatter());
			// Configure Web API to use only bearer token authentication.  
			//config.SuppressDefaultHostAuthentication();
			//config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
			// Web API routes  
			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute(
				name: "ActionApi",
				routeTemplate: "api/{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			

		}
    }
}
