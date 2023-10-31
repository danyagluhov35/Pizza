using Pizza.Domain.IService;
using Pizza.Domain.Service;

namespace Pizza.Domain.Repositories.Factories
{
    public class ProductFactoryDrink : ProductFactory
    {
        public override IProductService Create(string name, int price, string imgPath, string categoryName)
        {
            return new DrinkProductService(name, price, imgPath, categoryName);
        }
    }
}
