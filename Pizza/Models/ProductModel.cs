﻿namespace Pizza.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? ImgPath { get; set; }
        public string? CategoriesName { get; set; }
    }
}
