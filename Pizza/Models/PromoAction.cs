using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class PromoAction
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TitleImg { get; set; }
        public string? Href { get; set; }
        public string? Content { get; set; }
    }
}
