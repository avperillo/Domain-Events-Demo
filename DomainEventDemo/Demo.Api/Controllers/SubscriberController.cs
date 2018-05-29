using Demo.Application.Services.NewsLetters;
using Demo.Domain.Model.NewsLetters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Api.Controllers
{
    public class SubscriberController : ApiController
    {
        private INewsLetterService _newLetterService { get; }

        public SubscriberController(INewsLetterService newLetterService)
        {
            _newLetterService = newLetterService ?? throw new ArgumentNullException(nameof(newLetterService));
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            return Json(_newLetterService.GetAll());
        }

        public string Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Post(Subscriber value)
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
