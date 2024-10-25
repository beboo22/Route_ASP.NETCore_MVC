using LinkDev._1stproj.DAL.Models.identity;
using LinkDev._1stProj.PL.ViewModels.identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LinkDev._1stProj.PL.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<User> _Usermng { get; }
        public SignInManager<User> _Sinmg { get; }
        private readonly RoleManager<Role> _roleManager;
        public AccountController(UserManager<User> usermng,
                                SignInManager<User> Sinmg,
                                RoleManager<Role> roleManager)
        {
            _Usermng = usermng;
            _Sinmg = Sinmg;
            _roleManager = roleManager;
        }
        ///public IActionResult sucscess()
        ///{
        ///    return View();
        ///}


        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpview signUpview)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _Usermng.FindByNameAsync(signUpview.Username);
            if (user is null)
            {
                var item = new User()
                {
                    FName = signUpview.FName,
                    Email = signUpview.Email,
                    LName = signUpview.LName,
                    RememberMe = signUpview.RememberMe,
                    UserName = signUpview.Username
                };

                var res = await _Usermng.CreateAsync(item, signUpview.Password);
                if (res.Succeeded)
                    return RedirectToAction(nameof(SignIn));
                foreach (var err in res.Errors)
                    ModelState.AddModelError(string.Empty, err.Description);
            }
            else
                ModelState.AddModelError(nameof(signUpview.Username), "username duplicate");

            return View("SignIn");
        }

        //https://localhost:7150/Account/SignIn?ReturnUrl=%2FDepartment
        public IActionResult SignIn(string? ReturnUrl = null)
        {
            TempData["ReturnUrl"] = ReturnUrl;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInview model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Email))
                return BadRequest();

            var user = await _Usermng.FindByEmailAsync(model.Email);
            if (user is { })
            {
                var flag = await _Usermng.CheckPasswordAsync(user, model.Password);
                if (flag)
                {
                    await _Sinmg.SignInAsync(user, false);
                    //return View(nameof(DepartmentController.DepartmentController.Index));
                    string ReturnUrl = TempData["ReturnUrl"] as string;
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {

                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            else
                ModelState.AddModelError(nameof(SignInview.Email), "wrong in email or email doesn't exist");

            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await _Sinmg.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }

    }
}
