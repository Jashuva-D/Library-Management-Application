using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LibraryManagementWebAPI
{
    public class CustomJsonForamtting : JsonMediaTypeFormatter
    {
        public CustomJsonForamtting()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //FOR ACCESS ALLOW CONTROL
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Books",
                routeTemplate: "api/books/{id}",
                defaults: new { controller="books" , id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Authors",
                routeTemplate: "api/authors/{id}",
                defaults: new { controller = "authors", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Publishers",
                routeTemplate: "api/publishers/{id}",
                defaults: new { controller = "publishers", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "BookRepository",
                routeTemplate: "api/bookrepository/id/{edition}",
                defaults: new { controller = "bookrepository",edition=RouteParameter.Optional}
            );
            config.Formatters.Add(new CustomJsonForamtting());
        }
    }
}
