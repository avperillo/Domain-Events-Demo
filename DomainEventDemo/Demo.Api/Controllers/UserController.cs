﻿using Demo.Application.Services.Users;
using Demo.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Api.Controllers
{
    public class UserController : ApiController
    {
        private IUserServices _userService { get; }

        public UserController(IUserServices userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public IHttpActionResult Get()
        {
            return Json(_userService.GetAll());
        }

        public IHttpActionResult Get(Guid id)
        {
            return Json(_userService.GetById(id));
        }

        public IHttpActionResult Post(User value)
        {
            value = _userService.RegisterNewUser(value);
            return Json(value);
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
