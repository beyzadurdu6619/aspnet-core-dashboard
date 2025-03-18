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
    public class CustomerDal : ICustomerDal
    {
        Context context = new Context();

        public void Delete(Customer customer)
        {
            context.Remove(customer);
            context.SaveChanges();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomerListWithJob()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetList()
        {
            return context.Customers.ToList();
        }

        public void Insert(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }
    }
}
