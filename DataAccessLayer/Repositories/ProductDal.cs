using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Repositories
{
    public class ProductDal : IProductDal
    {
        Context context = new Context();
   
        public void Delete(Product product)
        {
           context.Remove(product);
           context.SaveChanges();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetList()
        {
            return context.Products.ToList();
        }

        public void Insert(Product product)
        {
           context.Add(product);
           context.SaveChanges();
        }

        public void Update(Product product)
        {
           context.Update(product);
            context.SaveChanges();
        }
    }
}
