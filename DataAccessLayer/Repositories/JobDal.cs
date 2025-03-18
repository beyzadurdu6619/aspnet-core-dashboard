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
    public class JobDal : IJobDal
    {
        Context context = new Context();

        public void Delete(Job Job)
        {
            context.Remove(Job);
            context.SaveChanges();
        }

        public Job GetById(int id)
        {
            var values=context.Jobs.Find(id);
            return values;

        }

        public List<Job> GetList()
        {
            return context.Jobs.ToList();
        }

        public void Insert(Job Job)
        {
            context.Add(Job);
            context.SaveChanges();
        }

        public void Update(Job Job)
        {
            context.Update(Job);
            context.SaveChanges();
        }
    }
}