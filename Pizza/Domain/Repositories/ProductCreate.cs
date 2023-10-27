using Pizza.Domain.IService;

namespace Pizza.Domain.Repositories
{
    public class ProductCreate
    {
        private IProductService _product;
        public ProductCreate(IProductService product) => _product = product;
        public void CreateProduct() 
        {
            _product.CreateProduct();
        }
    }
}
