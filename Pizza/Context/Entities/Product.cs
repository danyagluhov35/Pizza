namespace Pizza.Context.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual int Price { get; set; }
        public virtual string? ImgPath { get; set; }
        public virtual string? CategoriesName { get; set; }
    }
}
