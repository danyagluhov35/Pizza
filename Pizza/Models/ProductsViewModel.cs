using Pizza.Context;
using Pizza.Context.Entities;

namespace Pizza.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> products = new List<Product>();
        public ProductModel Product { get; set; } = new ProductModel();
    }
}
