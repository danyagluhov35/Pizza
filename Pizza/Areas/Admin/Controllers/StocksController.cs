using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        /// <summary>
        ///     Вывод акций на страницу администратора | Display stocks on the admin page
        /// </summary>
        [Route("Admin/Stocks/Index")]
        public IActionResult Index()
        {
            PromoViewModel promoModel = new PromoViewModel() { PromoActions = _db.PromoActions };
            return View(promoModel);
        }
        /// <summary>
        ///     Добавление или редактирование акции | Adding or removing action
        /// </summary>
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
        /// <summary>
        ///     Получение значений об акции при редактировании | Getting values the actions when editing
        /// </summary>
        [Route("Admin/Stocks/GetPromo")]
        [HttpPost]
        public async Task<IActionResult> GetPromo([FromBody]PromoAction promoAction)
        {
            var data = await _PromoService.Get(promoAction);
            return Json(data);
        }
        /// <summary>
        ///     Удаление | Delete action
        /// </summary>
        [Route("Admin/Stocks/DeletePromo")]
        public async Task<IActionResult> DeletePromo(int id)
        {
            try
            {
                using(var db = new PizzaProjectContext())
                {
                    var data = await _db.PromoActions.FirstOrDefaultAsync(x => x.Id == id);
                    if (data != null)
                    {
                        await _PromoService.Delete(data);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
