using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Repositories;
using Pizza.Domain.Repositories.Factories;
using Pizza.Models;
using Pizza.Models.Context;
using Pizza.Models.ViewModels;

namespace Pizza.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        PizzaProjectContext db;
        public ProductsController(PizzaProjectContext db)
        {
            this.db = db;
        }

        [Route("products")]
        public IActionResult Index(string productName)
        {
            ProductViewModel productModel = new ProductViewModel();

            if (productName != null)
            {
                productModel.products = db.Products.Where(u => u.CategoriesName == productName);
                productModel.Product.CategoriesName = productName;
            }
            return View(productModel);
        }

        /// <summary>
        ///     Сохранение продукта | Save product
        /// </summary>
        [Route("Admin/Products/Save")]
        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                if(product.CategoriesName == "pizza") 
                { 
                    ProductFactory productPizza = new ProductFactoryPizza();
                    ProductCreate productCreate = new(productPizza.Create(product.Name!, product.Price, product.ImgPath!, product.CategoriesName));
                    productCreate.CreateProduct();
                }
                else if(product.CategoriesName == "drink")
                {
                    ProductFactory productDrink = new ProductFactoryDrink();
                    ProductCreate productCreate = new(productDrink.Create(product.Name!, product.Price, product.ImgPath!, product.CategoriesName));
                    productCreate.CreateProduct();
                }
                else
                {
                    ProductFactory productRoll = new ProductFactoryRoll();
                    ProductCreate productCreate = new(productRoll.Create(product.Name!, product.Price, product.ImgPath!, product.CategoriesName!));
                    productCreate.CreateProduct();
                }
            }
            return RedirectToAction("Index", new { productName = product.CategoriesName });
        }
        /// <summary>
        ///     Удаление продукта | Delete product 
        /// </summary>
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            Product? data = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (data != null)
            {
                db.Products.Remove(data);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { productName = data?.CategoriesName });
        }
        /// <summary>
        ///     Редактирование продукта | Edit product
        /// </summary>
        [Route("edit")]
        public async Task<IActionResult> Edit(Product product)
        {
            Product? data = await db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (data != null)
            {
                data = new Product() { Name = product.Name, Price = product.Price, ImgPath = product.ImgPath };
                db.Products.Update(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { productName = data?.CategoriesName });
        }
    }
}
