using System;
using System.Collections.Generic;

namespace Pizza.Context.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public string? ImgPath { get; set; }
        public string? CategoriesName { get; set; }

        public virtual Category? CategoriesNameNavigation { get; set; }
    }
}
