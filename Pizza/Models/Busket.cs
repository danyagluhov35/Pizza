using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Busket
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
