using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Service.Service
{
	public class UserService
	{
		private ProductEntities1 db = new ProductEntities1();
		public User GetUser(string username, string password )
		{
			return db.Users.Where(x => x.username.Equals(username) && x.password.Equals(password)).FirstOrDefault();
		}
		public bool Save(User user)
		{
			//throw new NotImplementedException();
			try
			{
				db.Users.Add(user);
				db.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}