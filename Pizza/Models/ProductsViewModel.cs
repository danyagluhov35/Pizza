using Pizza.Context;
using Pizza.Context.Entities;

namespace Pizza.Models
{
    public class ProductsViewModel
    {
        public ProductModel Product { get; set; } = new ProductModel();
        public IEnumerable<Product> products = new List<Product>();
    }
}
