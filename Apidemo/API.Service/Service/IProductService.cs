using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Service.Service
{
    interface IProductService
    {
        List<Product> List();
        Product Get(String id);
        bool Save(Product product);
        bool Update(Product product , String id);
        bool Delete(String Id);
    }
}
