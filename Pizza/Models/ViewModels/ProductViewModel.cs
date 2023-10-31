namespace Pizza.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> products = new List<Product>();
        public Product Product { get; set; } = new Product();
    }
}
