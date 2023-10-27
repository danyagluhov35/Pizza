namespace Pizza.Models.ViewModels
{
    public class BusketViewModel
    {
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
