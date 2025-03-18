using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context context = new Context();
        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();

        }

        public T GetById(int id)
        {
            var entity = context.Set<T>().Find(id);
            return entity;
        }

        public List<T> GetList()
        {
            return context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
