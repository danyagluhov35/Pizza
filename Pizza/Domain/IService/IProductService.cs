namespace Pizza.Domain.IService
{
    public interface IProductService
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImgPath { get; set; }
        public string CategoryName { get; set; }
        void CreateProduct();
    }
}
