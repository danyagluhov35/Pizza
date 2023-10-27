using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pizza.Models;
using Pizza.Models.Context;
using Pizza.Models.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using Pizza.Domain.IService;

namespace Pizza.Controllers
{
    public class BasketController : Controller
    {
        private PizzaProjectContext _db;
        IBusketService BusketService;
        public BasketController(PizzaProjectContext db, IBusketService busketService)
        {
            _db = db;
            BusketService = busketService;
        }
        public IActionResult Index()
        {
            var res = _db.Buskets.GroupBy(b => b.ProductId).Select(g => new BusketViewModel
            {
                ProductId = g.Key,
                Product = g.First().Product,
                Quantity = g.Count()
            }).ToList();
            return View(res);
        }
        [HttpPost]
        public IActionResult Take(Product product)
        {
            var data = _db.Products.FirstOrDefault(p => p.Id == product.Id);
            if(data == null) // Логика валидации
                return View(product);
            _db.Buskets.Add(new Busket() { ProductId = product.Id }); // Логика добавления
            _db.SaveChanges();



            return Json(BusketService.GetTotalPrice(_db.Buskets.Include(b => b.Product).ToList()));
        }
    }
}
