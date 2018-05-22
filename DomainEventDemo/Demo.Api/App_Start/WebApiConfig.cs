using Demo.Api.App_Start;
using Demo.Application.Services.Users;
using Demo.Domain.Model.Users;
using Demo.Infrastructure.Data;
using Demo.Infrastructure.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Demo.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(new UserContext()));

            var userRepository = container.Resolve<IUserRepository>();

            container.RegisterType<IUserServices, UserServices>(new InjectionConstructor(userRepository));

            config.DependencyResolver = new UnityResolver(container);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
