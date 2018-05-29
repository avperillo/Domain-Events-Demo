using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Model.NewsLetters
{
    public interface ISubscriberRepository
    {
        Subscriber GetById(Guid id);
        IEnumerable<Subscriber> GetAll();
        Subscriber Add(Subscriber entity);
    }
}
