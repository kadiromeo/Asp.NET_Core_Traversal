using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager <AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SingUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SingUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                surName = p.Surname,
                Email = p.Mail,
                UserName = p.userName
            };
            if (p.Password==p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SingIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }


        [HttpGet]
        public IActionResult SingIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SingIn(UserSingInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.userName, p.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Profile",new {areas="Member"});
                }
                else
                {
                    ViewBag.Uyari = "Kullanıcı Adı veya Şifreniz Hatalı...!";
                }
            }
            return View();
        }
    }
}
