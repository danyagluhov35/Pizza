using System;
using System.Collections.Generic;

namespace Pizza.Context.Entities
{
    public partial class Slider
    {
        public int Id { get; set; }
        public string? ImgPath { get; set; }
        public string? Href { get; set; }
    }
}
