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
            var data = _db.Buskets.GroupBy(b => b.ProductId).Select(g => new BusketViewModel
            {
                ProductId = g.Key,
                Product = g.First().Product!,
                Quantity = g.Count()
            }).ToList();
            return View(data);
        }
        /// <summary>
        ///  Добавление продукта в корзину | Added product in busket
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var data = await _db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if(data != null) // Логика валидации
                await _db.Buskets.AddAsync(new Busket() { ProductId = product.Id }); // Логика добавления
            await _db.SaveChangesAsync();

            return Json(BusketService.GetTotalPrice(_db.Buskets.Include(b => b.Product).ToList()));
        }
        /// <summary>
        ///     Удаление всего количества продукта в корзине | Removing all single product
        /// </summary>
        public async Task<IActionResult> DeleteAll(int id)
        {
            using(PizzaProjectContext db = new())
            {
                try
                {
                    var data = db.Buskets.Where(b => b.ProductId == id).ToList();
                    if(data != null)
                    {
                        foreach (var item in data)
                            db.Buskets.Remove(item);
                        await db.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return RedirectToAction("Index","Basket");
        }
        /// <summary>
        ///     Удаление одного количества продукта в корзине
        /// </summary>
        public async Task<IActionResult> SingleDelete(int id)
        {
            using(PizzaProjectContext db = new())
            {
                try
                {
                    var data = await db.Buskets.FirstOrDefaultAsync(b => b.ProductId == id);
                    if (data != null)
                    {
                        db.Buskets.Remove(data);
                        await db.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return RedirectToAction("Index", "Basket");
        }
        /// <summary>
        ///     Добавление одного количества продукта в корзине
        /// </summary>
        public async Task<IActionResult> SingleAdd(int id)
        {
            using (PizzaProjectContext db = new())
            {
                try
                {
                    var data = await db.Buskets.FirstOrDefaultAsync(b => b.ProductId == id);
                    if (data != null)
                    {
                        db.Buskets.Add(new Busket() { ProductId = data.ProductId });
                        await db.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return RedirectToAction("Index", "Basket");
        }
    }
}
