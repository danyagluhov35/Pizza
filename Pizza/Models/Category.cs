using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? RusName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
