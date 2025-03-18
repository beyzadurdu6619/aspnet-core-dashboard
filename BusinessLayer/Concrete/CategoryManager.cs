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
    public class CategoryManager : IGenericService<Category>
    {
        ICategoryDal _CategoryDal;

        public CategoryManager(ICategoryDal CategoryDal)
        {
            _CategoryDal = CategoryDal;
        }

        public void TDelete(Category t)
        {
            _CategoryDal.Delete(t);
        }

        public Category TGetById(int id)
        {
            return _CategoryDal.GetById(id);
        }

        public List<Category> TGetList()
        {
            return _CategoryDal.GetList();
        }

        public void TInsert(Category t)
        {
            _CategoryDal.Insert(t);
        }

        public void TUpdate(Category t)
        {
            _CategoryDal.Update(t);
        }
    }
}
