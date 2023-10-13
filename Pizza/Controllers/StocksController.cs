using Microsoft.AspNetCore.Mvc;
using Pizza.Context;

namespace Pizza.Controllers
{
    public class StocksController : Controller
    {
        private PizzaProjectContext _db;
        public StocksController(PizzaProjectContext db) => _db = db;
        public IActionResult Index()
        {
            return View(_db.PromoActions);
        }
    }
}
