using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
    public class UserSingInViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez...!")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez...!")]

        public string Password { get; set; }
    }
}
