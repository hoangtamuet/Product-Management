using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Data;

namespace API.Service.Service
{
	public class CustomerService : ICustomerService
	{
		private ProductEntities1 db = new ProductEntities1();
		public bool Delete(int id)
		{
			//new NotImplementedException(); customers
			try
			{
				var customer = db.Customers.Where(x => x.id == id).FirstOrDefault();
				if (customer == null) return false;
				db.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
				db.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public Customer Get(int id)
		{
			//row new NotImplementedException();
			return db.Customers.Where(x => x.id == id).FirstOrDefault();
		}

		public List<Customer> List()
		{
			//row new NotImplementedException();
			return db.Customers.ToList();
		}

		public bool Save(Customer customer)
		{
			//row new NotImplementedException();
			try
			{
				db.Customers.Add(customer);
				db.SaveChanges();
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
		}
		
		public bool Update(Customer customer, int id)
		{
			//row new NotImplementedException();
			try
			{
				db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
				db.SaveChanges();
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
		}
	}
}