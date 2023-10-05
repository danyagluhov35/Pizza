using System;
using System.Collections.Generic;

namespace Pizza.Context.Entities
{
    public partial class Category
    {
        public Category()
        {
            ProductPizzas = new HashSet<ProductPizzaContext>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductPizzaContext> ProductPizzas { get; set; }
    }
}
