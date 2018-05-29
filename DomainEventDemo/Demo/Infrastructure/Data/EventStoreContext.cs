using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Model;

namespace Demo.Infrastructure.Data
{
    public class EventStoreContext : DbContext, IEventStoreContext
    {
        public EventStoreContext()
           : base()
        {
        }

        public EventStoreContext(string nameOrConnectionString) : base("name=UserContext")
        {
        }

        public IDbSet<StoredEvent> StoredEvents { get; set; }

    }
}
