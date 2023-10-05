using Microsoft.AspNetCore.Mvc;
using Pizza.Context;

namespace Pizza.Controllers
{
    public class HomeController : Controller
    {
        PizzaProjectContext db;
        public HomeController(PizzaProjectContext db) => this.db = db;
        public IActionResult Index()
        {
            return View(db);
        }
    }
}
