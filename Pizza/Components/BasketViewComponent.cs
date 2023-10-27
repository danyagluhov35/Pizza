using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Domain.IService;
using Pizza.Models.Context;
using Pizza.Models.ViewModels;

namespace Pizza.Components
{
    public class BasketViewComponent : ViewComponent
    {
        PizzaProjectContext _db;
        IBusketService BusketService;
        public BasketViewComponent(PizzaProjectContext db, IBusketService busketService)
        {
            _db = db;
            BusketService = busketService;
        }
        public IViewComponentResult Invoke()
        {
            return View("Default", BusketService.GetTotalPrice(_db.Buskets.Include(b => b.Product).ToList()));
        }
    }
}
