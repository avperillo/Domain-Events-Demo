using Demo.Application;
using Demo.Domain.Model.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Demo.Domain.Model
{
    public static class DomainEvents
    {

        private static List<Delegate> actions;

        public static IUnityContainer Container { get; set; }

        public static void Init(IUnityContainer container)
        {
            Container = container;
        }

        public static void Register<T>(Action<T> callback)
        {
            if (actions == null)
                actions = new List<Delegate>();

            actions.Add(callback);
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (Container != null)
            {
                var listeners = Container.Registrations.Where(c =>
                                                              c.RegisteredType.IsGenericType
                                                              && c.RegisteredType.GenericTypeArguments.Any(generic => generic.Name == typeof(T).Name)
                                                          )
                                                          .Select(r =>
                                                                      (IDomainEventListener<T>)Container.Resolve(r.RegisteredType, r.Name)
                                                          );
                foreach (var listener in listeners)
                {
                    listener.Handle(args);
                }

                var eventStore = Container.Resolve<IEventStore>();
                eventStore.Append(args);
            }


            if (actions != null)
                foreach (var action in actions)
                    if (action is Action<T>)
                        ((Action<T>)action)(args);

        }

    }
}
