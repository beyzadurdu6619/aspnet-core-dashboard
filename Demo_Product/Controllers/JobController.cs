using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Job.Controllers
{
    public class JobController : Controller
    {

        JobManager JobManager = new JobManager(new EfJobDal());
        public IActionResult Index()
        {
            var values = JobManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Job Job)
        {
            JobValidator validationRules = new JobValidator();
            var result = validationRules.Validate(Job);
            if (result.IsValid)
            {
                JobManager.TInsert(Job);
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
            var value = JobManager.TGetById(id);
            JobManager.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var value = JobManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Job Job)
        {
            JobManager.TUpdate(Job);
            return RedirectToAction("Index");
        }




    }
}
