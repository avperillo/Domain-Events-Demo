using Demo.Application;
using Demo.Application.Services.Users;
using Demo.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Api.Controllers
{
    public class EventController : ApiController
    {
        private IEventStore _eventStore { get; }

        public EventController(IEventStore eventStore)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        public IHttpActionResult Get()
        {
            return Json(_eventStore.GetAllSince(new DateTime(2018,1,1)));
        }

        public IHttpActionResult Get(DateTime dateTime)
        {
            return Json(_eventStore.GetAllSince(dateTime));
        }

        public IHttpActionResult Post(User value)
        {
            throw new NotImplementedException();
        }

        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
