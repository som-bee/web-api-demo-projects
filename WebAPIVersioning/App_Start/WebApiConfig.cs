using System.Web.Http;
using System.Web.Http.Dispatcher;
using WebAPIVersioning.Custom;

namespace WebAPIVersioning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "Version1",
            //    routeTemplate: "api/v1/Students/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "StudentsV1" }
            //);
            //            config.Routes.MapHttpRoute(
            //    name: "Version2",
            //    routeTemplate: "api/v2/Students/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "StudentsV2" }
            //);

            //using custom controller selector for versioning of api
            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector(config));

        }
    }
}
