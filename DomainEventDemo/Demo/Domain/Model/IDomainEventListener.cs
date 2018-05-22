using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Model
{
    public interface IDomainEventListener { }

    public interface IDomainEventListener<T> : IDomainEventListener
        where T: IDomainEvent
    {
        void Handle(T @event);
    }
}
