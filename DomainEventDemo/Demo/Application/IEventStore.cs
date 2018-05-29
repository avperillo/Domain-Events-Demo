using Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application
{
    public interface IEventStore
    {
        void Append(IDomainEvent @event);
        IEnumerable<StoredEvent> GetAllSince(DateTime date);
    }
}
