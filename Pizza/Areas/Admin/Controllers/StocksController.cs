using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.Domain.IService;
using Pizza.Domain.Service;
using Pizza.Models;
using Pizza.Models.Context;
using Pizza.Models.ViewModels;

namespace Pizza.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class StocksController : Controller
    {
        private PizzaProjectContext _db;
        private readonly IPromoService _PromoService;
        public StocksController(PizzaProjectContext db, IPromoService promoService)
        {
            _db = db;
            _PromoService = promoService;
        }
        [Route("Admin/Stocks/Index")]
        public IActionResult Index()
        {
            PromoViewModel promoModel = new PromoViewModel() { PromoActions = _db.PromoActions };
            return View(promoModel);
        }
        [Route("Admin/Stocks/Details")]
        [HttpPost]
        public async Task<IActionResult> Details(PromoAction promoAction)
        {
            if(promoAction.Id == 0)
                await _PromoService.Add(promoAction!);
            else
                await _PromoService.Edit(promoAction);
            return RedirectToAction("Index");
        }
        [Route("Admin/Stocks/GetPromo")]
        [HttpPost]
        public async Task<IActionResult> GetPromo([FromBody]PromoAction promoAction)
        {
            var promo = await _PromoService.Get(promoAction);
            return Json(promo);
        }
        [Route("Admin/Stocks/DeletePromo")]
        public IActionResult DeletePromo(int id)
        {
            var promo = _db.PromoActions.FirstOrDefault(x => x.Id == id);
            if(promo != null)
            {
                _PromoService.Delete(promo);
            }
            return RedirectToAction("Index");
        }
    }
}
