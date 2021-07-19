using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace RWA_Project
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            _SetJSONAsReturnType(config);
        }

		private static void _SetJSONAsReturnType(HttpConfiguration config)
		{
			MediaTypeHeaderValue xmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(mt => mt.MediaType == "application/xml");

            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(xmlType);
        }
	}
}
