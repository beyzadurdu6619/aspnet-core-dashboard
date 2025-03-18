using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adı değeri giriniz.")]
        public string UserName { get; set; } = " ";


        [Required(ErrorMessage = "Lütfen şifre değeri giriniz.")]
        public string Password { get; set; }
    }
}
