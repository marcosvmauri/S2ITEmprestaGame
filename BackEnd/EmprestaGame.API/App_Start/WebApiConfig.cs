using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;


namespace EmprestaGame.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            string hostCors = System.Configuration.ConfigurationManager.AppSettings["cors"];

            var enableCorsAttribute = new EnableCorsAttribute(hostCors, "*", "*");
            config.EnableCors(enableCorsAttribute);


            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Remover formatter de XML.
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //Configurar formatter de JSON, indentando e removendo caixa alta do começo dos nomes de objetos (padrão js).
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.Indent = true;

            jsonFormatter.UseDataContractJsonSerializer = false;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
