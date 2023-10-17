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
    public class ProductsController : Controller
    {
        PizzaProjectContext db;
        public ProductsController(PizzaProjectContext db) => this.db = db;
        [Route("products")]
        public IActionResult Index(string productName)
        {
            ProductsViewModel productModel = new ProductsViewModel();

            if (productName != null)
                productModel.products = db.Products.Where(u => u.CategoriesName == productName);
            return View(productModel);
        }
        [Route("save")]
        [HttpPost]
        public IActionResult Save(ProductModel product)
        {
            ProductFactory productFactory;

            productFactory = new ProductFactoryPizza(product.Name!, product.Price, product.ImgPath);
            IProduct pizza = productFactory.CreateProduct();
            db.Products.Add(new Product() { Name = pizza.Name, ImgPath = pizza.GetImagePath(), CategoriesName = product.CategoriesName, Price = pizza.GetPrice() });
            db.SaveChanges();

            return RedirectToAction("Index", new { productName = product.CategoriesName });
        }
        [Route("delete")]
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
        [Route("edit")]
        public async Task<IActionResult> Edit(ProductModel product)
        {
            Product? productData = new();
            if (ModelState.IsValid)
            {
                productData = await db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
                productData.Name = product.Name;
                productData.Price = product.Price;
                productData.ImgPath = product.ImgPath;
                db.Products.Update(productData);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { productName = productData.CategoriesName });
        }
    }
}
