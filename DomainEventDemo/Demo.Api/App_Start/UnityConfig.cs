using Demo.Application;
using Demo.Application.Services.NewsLetters;
using Demo.Application.Services.Users;
using Demo.Domain.Model;
using Demo.Domain.Model.Listeners;
using Demo.Domain.Model.NewsLetters;
using Demo.Domain.Model.Users;
using Demo.Infrastructure.Application;
using Demo.Infrastructure.Data;
using Demo.Infrastructure.Data.NewsLetters;
using Demo.Infrastructure.Data.Users;
using Demo.Infrastructure.Repository.EF;
using System;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;

namespace Demo.Api
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<IUserContext, UserContext>(
                        new InjectionConstructor("name=UserContext"));
            container.RegisterType<ISubscriberContext, SubscriberContext>(
                        new InjectionConstructor("name=UserContext"));
            container.RegisterType<IEventStoreContext, EventStoreContext>(
                        new InjectionConstructor("name=UserContext"));

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ISubscriberRepository, SubscriberRepository>();

            container.RegisterType<IUserServices, UserServices>(new InjectionConstructor(container.Resolve<IUserRepository>()));
            container.RegisterType<INewsLetterService, NewsLetterServices>(new InjectionConstructor(container.Resolve<ISubscriberRepository>()));

            container.RegisterType<IEventStore, EventStore>(new InjectionConstructor(container.Resolve<IEventStoreContext>()));

            container.RegisterType<IDomainEventListener<UserWasRegistered>, NewsLetterListener>("NewsLetterListener", new PerRequestLifetimeManager());
            container.RegisterType<IDomainEventListener<IDomainEvent>, EventStoreListener>("EventStoreListener", new PerRequestLifetimeManager());

            DomainEvents.Init(container);
        }
    }
}