namespace Pizza.Domain.Repositories
{
    public class ProductPizza : IProduct
    {
        private readonly string _name;
        private readonly string? _imagePath;
        private readonly int _price;
        public ProductPizza(string name,string imagePath, int price)
        {
            _name = name;
            _imagePath = imagePath;
            _price = price;
        }
        public string GetImagePath() => _imagePath!;
        public string Name => _name;
        public int GetPrice() => _price;
    }
}
