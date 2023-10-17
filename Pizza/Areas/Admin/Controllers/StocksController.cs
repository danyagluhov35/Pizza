using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.Context;
using Pizza.Models;

namespace Pizza.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class StocksController : Controller
    {
        private PizzaProjectContext _db;
        public StocksController(PizzaProjectContext db) => _db = db;
        [Route("stocks")]
        public IActionResult Index()
        {
            SlideViewModel slide = new SlideViewModel() { PromoActions = _db.PromoActions };
            return View(slide);
        }
    }
}
