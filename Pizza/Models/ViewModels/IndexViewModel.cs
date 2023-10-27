namespace Pizza.Models.ViewModels
{
    public class IndexViewModel
    {
        public Product Product { get; set; } = new Product();
        public IEnumerable<Product> products = new List<Product>();
        public IEnumerable<PromoAction> promoActions = new List<PromoAction>();
        public IEnumerable<Category> Categories = new List<Category>();
    }
}
