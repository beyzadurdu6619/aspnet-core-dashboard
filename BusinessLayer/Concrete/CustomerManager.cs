using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : IGenericService<Customer>
    {
        ICustomerDal _CustomerDal;

        public CustomerManager(ICustomerDal CustomerDal)
        {
            _CustomerDal = CustomerDal;
        }

    

        public void TDelete(Customer t)
        {
            _CustomerDal.Delete(t);
        }

        public Customer TGetById(int id)
        {
            return _CustomerDal.GetById(id);
        }

        public List<Customer> TGetList()
        {
            return _CustomerDal.GetList();
        }

        public void TInsert(Customer t)
        {
            _CustomerDal.Insert(t);
        }

        public void TUpdate(Customer t)
        {
            _CustomerDal.Update(t);
        }

    
        public List<Customer> GetCustomerListWithJob()
        {
            return _CustomerDal.GetCustomerListWithJob();
        }
    }
}
