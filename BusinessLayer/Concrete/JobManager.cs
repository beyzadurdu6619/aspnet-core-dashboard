using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JobManager : IGenericService<Job>
    {
        IJobDal _JobDal;

        public JobManager(IJobDal JobDal)
        {
            _JobDal = JobDal;
        }

        public List<Customer> GetCustomerListWithJob()
        {
            throw new NotImplementedException();
        }

        public void TDelete(Job t)
        {
            _JobDal.Delete(t);
        }

        public Job TGetById(int id)
        {
            return _JobDal.GetById(id);
        }

        public List<Job> TGetList()
        {
            return _JobDal.GetList();
        }

        public void TInsert(Job t)
        {
            _JobDal.Insert(t);
        }

        public void TUpdate(Job t)
        {
            _JobDal.Update(t);
        }
    }
}
