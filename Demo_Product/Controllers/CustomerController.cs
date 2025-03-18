using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
           

        CustomerManager CustomerManager = new CustomerManager(new EfCustomerDal());
        public IActionResult Index()
        {
           
            var values = CustomerManager.GetCustomerListWithJob();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            JobManager jobManager = new JobManager(new EfJobDal());
            var jobList = jobManager.TGetList();

            if (jobList != null && jobList.Any())
            {
                List<SelectListItem> jobValues = jobList.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.JobId.ToString()
                }).ToList();

                ViewBag.v = jobValues;
            }
            else
            {
                ViewBag.v = new List<SelectListItem>();  // Eğer liste boşsa, en azından boş bir liste ata
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (customer == null)
            {
                ModelState.AddModelError("", "Geçersiz müşteri bilgisi!");
                return View();
            }

            // Debug için log ekleyelim
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"City: {customer.City}");
            Console.WriteLine($"JobId: {customer.JobId}");

            if (customer.JobId == 0)
            {
                ModelState.AddModelError("JobId", "Lütfen bir meslek seçin!");
                return View();
            }

            // Fluent Validation ile doğrulama
            CustomerValidator validationRules = new CustomerValidator();
            var result = validationRules.Validate(customer);

            if (result.IsValid)
            {
                CustomerManager.TInsert(customer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var value = CustomerManager.TGetById(id);
            CustomerManager.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var value = CustomerManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Customer Customer)
        {
            CustomerManager.TUpdate(Customer);
            return RedirectToAction("Index");
        }


    }
}
