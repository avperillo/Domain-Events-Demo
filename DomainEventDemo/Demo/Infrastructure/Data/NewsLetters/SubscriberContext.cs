using Demo.Domain.Model.NewsLetters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Data.NewsLetters
{
    public class SubscriberContext : DbContext, ISubscriberContext
    {

        public SubscriberContext()
            : base()
        {
        }

        public SubscriberContext(string nameOrConnectionString) : base("name=UserContext")
        {
        }

        public IDbSet<Subscriber> Subscribers { get; set; }

    }
}
