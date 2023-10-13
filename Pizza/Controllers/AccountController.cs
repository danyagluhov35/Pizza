using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pizza.Context;
using Pizza.Context.Entities;
using Pizza.Domain.JWTAuth;
using Pizza.Models.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pizza.Controllers
{
    public class AccountController : Controller
    {
        PizzaProjectContext _db;
        public AccountController(PizzaProjectContext db)
        {
            _db = db;
        }
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                if (user == null)
                    ModelState.AddModelError("IsValidUser", "Пользователь не найден");
                if (ModelState.IsValid)
                {
                    var claim = new List<Claim>() { new Claim(ClaimTypes.Name, user.Login!) };
                    ClaimsIdentity identity = new ClaimsIdentity(claim, "Cookies");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
    }
}
