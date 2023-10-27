using Pizza.Domain.IService;

namespace Pizza.Domain.Repositories.Factories
{
    public abstract class ProductFactory
    {
        public abstract IProductService Create(string name, int price, string imgPath, string categoryName);
    }
}
