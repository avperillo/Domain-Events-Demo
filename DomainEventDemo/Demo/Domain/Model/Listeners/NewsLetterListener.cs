using Demo.Application.Services.NewsLetters;
using Demo.Domain.Model.NewsLetters;
using Demo.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Model.Listeners
{
    public class NewsLetterListener :
        IDomainEventListener<UserWasRegistered>
    {

        INewsLetterService _service;

        public NewsLetterListener(INewsLetterService service)
        {
            _service = service;
        }

        public void Handle(UserWasRegistered @event)
        {
            Subscriber subs = new Subscriber { Id = @event.UserId, Email = @event.UserEmail };

            _service.Suscribe(subs);
        }
    }
}
