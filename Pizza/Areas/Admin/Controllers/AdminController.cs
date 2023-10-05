using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Context;
using Pizza.Context.Entities;
using Pizza.Domain.Repositories;
using Pizza.Domain.Repositories.Factories;
using Pizza.Models;
using Pizza.Models.ViewModels;

namespace Pizza.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdminController : Controller
    {
        PizzaProjectContext db;
        public AdminController(PizzaProjectContext db) => this.db = db;
        public IActionResult Index()
        {
            return View(new ProductsViewModel() { pizzaProduct = db.ProductPizzas });
        }
        [Route("/save")]
        [HttpPost]
        public IActionResult Save(ProductModel product)
        {
            ProductFactory productFactory;

            if(product.CategoriesName == "pizza")
            {
                productFactory = new ProductFactoryPizza(product.Name!, product.Price, product.ImgPath);
                IProduct pizza = productFactory.CreateProduct();
                db.ProductPizzas.Add(new ProductPizzaContext() { Name = pizza.Name, ImgPath = pizza.GetImagePath(), CategoriesName = product.CategoriesName, Price = pizza.GetPrice()});
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [Route("/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            ProductPizzaContext? pizzaContext = await db.ProductPizzas.FirstOrDefaultAsync(p => p.Id == id);
            if (pizzaContext != null)
            {
                db.ProductPizzas.Remove(pizzaContext);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
