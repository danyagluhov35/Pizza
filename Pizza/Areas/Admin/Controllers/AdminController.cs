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
        public IActionResult Index(string productName)
        {
            ProductsViewModel productModel = new ProductsViewModel();
            
            if(productName != null)
                productModel.products = db.Products.Where(u => u.CategoriesName == productName);
            return View(productModel);
        }
        [Route("/save")]
        [HttpPost]
        public IActionResult Save(ProductModel product)
        {
            ProductFactory productFactory;

            productFactory = new ProductFactoryPizza(product.Name!, product.Price, product.ImgPath);
            IProduct pizza = productFactory.CreateProduct();
            db.Products.Add(new Product() { Name = pizza.Name, ImgPath = pizza.GetImagePath(), CategoriesName = product.CategoriesName, Price = pizza.GetPrice()});
            db.SaveChanges();

            return RedirectToAction("Index", new { productName = product.CategoriesName });
        }
        [Route("/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            Product? pizzaContext = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (pizzaContext != null)
            {
                db.Products.Remove(pizzaContext);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { productName = pizzaContext.CategoriesName });
        }
    }
}
