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
    public class CategoryDal : ICategoryDal
    {
        Context context = new Context();

        public void Delete(Category category)
        {
            context.Remove(category);
            context.SaveChanges();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetList()
        {
            return context.Categories.ToList();
        }

        public void Insert(Category category)
        {
            context.Add(category);
            context.SaveChanges();
        }

        public void Update(Category category)
        {
            context.Update(category);
            context.SaveChanges();
        }
    }
}
