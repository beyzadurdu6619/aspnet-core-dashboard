using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class ProductController : Controller
    {

        ProductManager productManager = new ProductManager(new EfProductDal());
        public IActionResult Index()
        {
            var values = productManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {   ProductValidator validationRules = new ProductValidator();
            var result = validationRules.Validate(product);
            if (result.IsValid)
            {
                productManager.TInsert(product);
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
            var value=productManager.TGetById(id);
            productManager.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var value = productManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            productManager.TUpdate(product);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var value = productManager.TGetById(id);
            return View(value);
        }








    }
}
