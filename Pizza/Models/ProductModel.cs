using System.ComponentModel.DataAnnotations;

namespace Pizza.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название продукта")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Не указана цена продукта")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Отсутствует изображение продукта")]
        public string? ImgPath { get; set; }
        public string? CategoriesName { get; set; }
    }
}
