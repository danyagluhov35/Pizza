﻿using Pizza.Domain.IService;
using Pizza.Models.Context;
using Pizza.Models;

namespace Pizza.Domain.Service
{
    public class RollProductService : IProductService
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImgPath { get; set; }
        public string CategoryName { get; set; }
        public RollProductService(string name, int price, string imgPath, string categoryName)
        {
            Name = name;
            Price = price;
            ImgPath = imgPath;
            CategoryName = categoryName;
        }

        public void CreateProduct()
        {
            using(PizzaProjectContext _db = new PizzaProjectContext())
            {
                _db.Products.Add(new Product() { Name = Name, Price = Price, ImgPath = ImgPath, CategoriesName = CategoryName });
                _db.SaveChanges();
            }
        }
    }
}
