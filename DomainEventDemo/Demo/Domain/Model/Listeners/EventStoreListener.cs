using Demo.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Model.Listeners
{
    public class EventStoreListener :
        IDomainEventListener<IDomainEvent>
    {
        private IEventStore _eventStore { get; set; }

        public EventStoreListener(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void Handle(IDomainEvent @event)
        {
            _eventStore.Append(@event);
        }
    }
}
