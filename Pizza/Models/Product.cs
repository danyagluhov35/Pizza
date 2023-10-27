using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizza.Models
{
    public partial class Product
    {
        public Product()
        {
            Buskets = new HashSet<Busket>();
        }

        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string? ImgPath { get; set; }
        [Required]
        public string? CategoriesName { get; set; }
        public int? BusketId { get; set; }

        public virtual Category? CategoriesNameNavigation { get; set; }
        public virtual ICollection<Busket> Buskets { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Product otherProduct = (Product)obj;
            return Id == otherProduct.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
