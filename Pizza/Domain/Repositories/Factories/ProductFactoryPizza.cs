﻿using Pizza.Domain.IService;
using Pizza.Domain.Service;

namespace Pizza.Domain.Repositories.Factories
{
    public class ProductFactoryPizza : ProductFactory
    {
        public override IProductService Create(string name, int price, string imgPath, string categoryName)
        {
            return new PizzaProductService(name, price,imgPath, categoryName);
        }
    }
}
