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
    public class ProductController : ApiController
    {
        private ProductService productService = new ProductService();
        [ActionName("GetProduct")]
        public IEnumerable<Product> GetProducts()
        {
            return productService.List();
        }
		//[ActionName("GetProductById")]
		public IHttpActionResult Get(string id)
		{
			var ps = productService.Get(id);
			if (ps == null) return NotFound();
			return Ok(ps);
		}
		public IHttpActionResult Post (Product product)
        {
            var isSave = productService.Save(product);
            if (isSave == true) return Ok();
            return BadRequest();
        }
        public IHttpActionResult Put(Product product)
        {
            var isUpdate = productService.Update(product, product.id);
            if (isUpdate == true) return Ok();
            return BadRequest();
        }
        public IHttpActionResult Delete(string id)
        {
            var isDelete = productService.Delete(id);
            if (isDelete == true) return Ok();
            return BadRequest();
        }
    }
}

