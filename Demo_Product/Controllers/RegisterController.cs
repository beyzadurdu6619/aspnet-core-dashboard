using DataAccessLayer.Abstract;
using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            if (userRegisterViewModel.UserName.Any(c => !allowedChars.Contains(c)))
            {
                ModelState.AddModelError("UserName", "Kullanıcı adı yalnızca harf, rakam ve -._@+ karakterlerini içerebilir.");
                return View(userRegisterViewModel);
            }



            AppUser appUser = new AppUser()
            { 
                Name = userRegisterViewModel.Name,
                Surname = userRegisterViewModel.Surname,
                UserName = userRegisterViewModel.UserName,
                Email = userRegisterViewModel.Email
            };
          

            if (userRegisterViewModel.Password == userRegisterViewModel.ConfirmPassword)
            {
                if (string.IsNullOrWhiteSpace(userRegisterViewModel.UserName))
                {
                    ModelState.AddModelError("UserName", "Kullanıcı adı boş olamaz!");
                    return View(userRegisterViewModel);
                }

                IdentityResult result = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(userRegisterViewModel);
        }


    }
}
