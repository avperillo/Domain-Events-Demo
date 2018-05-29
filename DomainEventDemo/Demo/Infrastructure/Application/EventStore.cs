using Demo.Application;
using Demo.Domain.Model;
using Demo.Infrastructure.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Application
{
    public class EventStore : IEventStore
    {

        IEventStoreContext _eventStoreContext;

        public EventStore(IEventStoreContext eventStoreContext)
        {
            _eventStoreContext = eventStoreContext;
        }

        public void Append(IDomainEvent @event)
        {
            StoredEvent storedEvent = new StoredEvent
            {
                EventType = @event.GetType().FullName,
                EventBody = JsonConvert.SerializeObject(@event),
                OcurredOn = @event.OcurredOn
            };

            _eventStoreContext.StoredEvents.Add(storedEvent);
            _eventStoreContext.SaveChanges();
        }

        public IEnumerable<StoredEvent> GetAllSince(DateTime date)
        {
            return _eventStoreContext.StoredEvents
                        .Where(storeEvent => storeEvent.OcurredOn >= date);
        }
    }
}
