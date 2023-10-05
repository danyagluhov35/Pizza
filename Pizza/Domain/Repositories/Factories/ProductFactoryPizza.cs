using Pizza.Context;
using Pizza.Context.Entities;

namespace Pizza.Domain.Repositories.Factories
{
    public class ProductFactoryPizza : ProductFactory
    {
        private readonly string? imagePath;
        private readonly int price;
        private readonly string _name;
        public ProductFactoryPizza(string name,int price, string? imagePath)
        {
            _name = name;   
            this.price = price;
            this.imagePath = imagePath;
        }

        public override IProduct CreateProduct()
        {
            return new ProductPizza(_name,imagePath!, price);
        }
    }
}
