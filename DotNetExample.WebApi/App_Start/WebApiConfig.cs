using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Elmah.Contrib.WebApi;
using DotNetExample.Common.Utils.Json;
using DotNetExample.WebApi.App_Start;
using System.Web.Http.ExceptionHandling;
using System.Web.Configuration;
using System.Configuration;

namespace DotNetExample.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new ElmahHandleErrorApiAttribute());
            // Configure Web API to use only bearer token authentication.
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.EnableCors();

            ConfigureGlobalExceptionHandler(config);
            ConfigureRoutes(config);
            ConfigureJsonFormatter(config);
        }

        private static void ConfigureGlobalExceptionHandler(HttpConfiguration config)
        {
            config.Services.Replace(typeof(IExceptionHandler), new WebApiGlobalExceptionHandler());

            var customErrors = (CustomErrorsSection) ConfigurationManager.GetSection("system.web/customErrors");

            if (customErrors == null) return;

            switch (customErrors.Mode)
            {
                case CustomErrorsMode.RemoteOnly:
                    {
                        config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;
                        break;
                    }
                case CustomErrorsMode.On:
                    {
                        config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Never;
                        break;
                    }
                case CustomErrorsMode.Off:
                    {
                        config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
                        break;
                    }
                default:
                    {
                        config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Default;
                        break;
                    }
            }
        }

        private static void ConfigureJsonFormatter(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings = JsonSettings.GetDefaultJsonSerializerSettings();
        }

        private static void ConfigureRoutes(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
