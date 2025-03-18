using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class CategoryController : Controller
    {
        

        CategoryManager CategoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var values = CategoryManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Category Category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            var result = validationRules.Validate(Category);
            if (result.IsValid)
            {
                CategoryManager.TInsert(Category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
        public IActionResult Delete(int id)
        {
            var value = CategoryManager.TGetById(id);
            CategoryManager.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var value = CategoryManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Category Category)
        {
            CategoryManager.TUpdate(Category);
            return RedirectToAction("Index");
        }


    }
}
