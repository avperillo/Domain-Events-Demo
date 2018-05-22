using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Model
{
    public static class DomainEvents
    {
        private static readonly List<object> listeners = new List<object>();

        public static void Register(IDomainEventListener handler)
        {
            listeners.Add(handler);
        }

        public static void Raise<T>(T @event) where T : IDomainEvent
        {
            var thisEventListeners = listeners.Where(x => x is IDomainEventListener<T>).ToArray();

            foreach (var handler in thisEventListeners)
                (handler as IDomainEventListener<T>).Handle(@event);
        }
    }
}
