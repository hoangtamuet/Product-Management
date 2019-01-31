using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Service.Service
{
	interface ICustomerService
	{
		List<Customer> List();
		Customer Get(int id);
		bool Save(Customer customer);
		bool Update(Customer customer, int id);
		bool Delete(int id);
	}
}