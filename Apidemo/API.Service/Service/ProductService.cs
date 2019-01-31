using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Data;

namespace API.Service.Service
{
    public class ProductService : IProductService
    {
        private ProductEntities1 db = new ProductEntities1();
		
        public bool Delete(String Id)
        {
            //throw new NotImplementedException();
            //throw new NotImplementedException();s
            try
            {
                var product = db.Products.Where(x => x.id == Id).FirstOrDefault();
                if (product == null) return false;
                db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        

        public List<Product> List()
        {
            //throw new NotImplementedException();
            return db.Products.ToList();
        }
		public Product Get(String id)
		{
			//throw new NotImplementedException();
			return db.Products.Where(x => x.id == id).FirstOrDefault();
		}
		public bool Save(Product product)
        {
            //throw new NotImplementedException();
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Product product, String id)
        {
            //throw new NotImplementedException();
            try
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
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