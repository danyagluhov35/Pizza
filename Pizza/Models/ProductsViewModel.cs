using Pizza.Context.Entities;

namespace Pizza.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<ProductPizzaContext> pizzaProduct = new List<ProductPizzaContext>();
        public ProductModel Product { get; set; } = new ProductModel();
    }
}
