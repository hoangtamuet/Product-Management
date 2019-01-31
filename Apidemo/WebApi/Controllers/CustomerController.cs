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
	[Authorize]
    public class CustomerController : ApiController
    {
		private CustomerService customerService = new CustomerService();

		[HttpGet]
		public IEnumerable<Customer> List()
		{
			return customerService.List();
		}
		
		public IHttpActionResult Get(int id)
		{
			var ps = customerService.Get(id);
			if (ps == null) return NotFound();
			return Ok(ps);
		}
		public IHttpActionResult Post(Customer customer)
		{
			var isSave = customerService.Save(customer);
			if (isSave == true) return Ok();
			return BadRequest();
		}
		public IHttpActionResult Put(Customer customer)
		{
			var isUpdate = customerService.Update(customer, customer.id);
			if (isUpdate == true) return Ok();
			return BadRequest();
		}
		public IHttpActionResult Delete(int id)
		{
			var isDelete = customerService.Delete(id);
			if (isDelete == true) return Ok();
			return BadRequest();
		}
	}
}
