using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pizza.Domain.JWTAuth;
using Pizza.Models;
using Pizza.Models.Context;
using Pizza.Models.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace Pizza.Controllers
{
    public class AccountController : Controller
    {
        PizzaProjectContext _db;
        public AccountController(PizzaProjectContext db)
        {
            _db = db;
        }
        public IActionResult Login() => View(new User());
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                if (ModelState.IsValid && user != null)
                {
                    var claim = new List<Claim>() 
                    {
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, user?.Role?.NameRole!),
                        new Claim("u_id", user?.Id.ToString()!)
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claim, "Cookies");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
    }
}
