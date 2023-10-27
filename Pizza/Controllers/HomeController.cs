using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Models.Context;
using Pizza.Models.ViewModels;

namespace Pizza.Controllers
{
    public class HomeController : Controller
    {
        PizzaProjectContext db;
        public HomeController(PizzaProjectContext db) => this.db = db;
        public IActionResult Index()
        {
            IndexViewModel indexModel = new() { products = db.Products, promoActions = db.PromoActions, Categories = db.Categories.Include(c => c.Products) };
            return View(indexModel);
        }
    }
}
