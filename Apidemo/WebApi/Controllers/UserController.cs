using API.Data;
using API.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
		private UserService userService = new UserService();
		public IHttpActionResult Post(User user)
		{
			var isSave = userService.Save(user);
			if (isSave == true) return Ok();
			return BadRequest();
		}
	}
}
