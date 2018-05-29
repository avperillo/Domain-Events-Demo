using Demo.Domain.Model.NewsLetters;
using Demo.Infrastructure.Data;
using Demo.Infrastructure.Data.NewsLetters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Infrastructure.Repository.EF
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private ISubscriberContext context;

        public SubscriberRepository(ISubscriberContext context)
        {
            this.context = context;
        }

        public Subscriber Add(Subscriber entity)
        {
            try
            {
                context.Subscribers.Add(entity);
                context.SaveChanges();
                return GetById(entity.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Subscriber GetById(Guid id)
        {
            Subscriber subscriber = default(Subscriber);

            try
            {
                subscriber = (from u in context.Subscribers
                           where u.Id == id
                           select u).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return subscriber;
        }

        public IEnumerable<Subscriber> GetAll()
        {
            return context.Subscribers;
        }

    }
}
