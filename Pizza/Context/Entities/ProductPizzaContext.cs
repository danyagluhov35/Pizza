using System;
using System.Collections.Generic;

namespace Pizza.Context.Entities
{
    public partial class ProductPizzaContext : Product
    {
        public override string? Name { get; set; }
        public override int Price { get; set; }
        public override string? ImgPath { get; set; }
        public override string? CategoriesName { get; set; }

        public virtual Category? CategoriesNameNavigation { get; set; }
    }
}
