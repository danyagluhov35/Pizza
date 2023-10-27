using Microsoft.AspNetCore.Mvc;
using Pizza.Models;
using Pizza.Models.Context;
using Pizza.Models.ViewModels;

namespace Pizza.Controllers
{
    public class StocksController : Controller
    {
        private PizzaProjectContext _db;
        public StocksController(PizzaProjectContext db) => _db = db;
        
        public IActionResult Index()
        {
            PromoViewModel promoModel = new PromoViewModel() { PromoActions = _db.PromoActions };
            return View(promoModel);
        }
    }
}
