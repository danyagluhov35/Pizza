namespace Pizza.Models.ViewModels
{
    public class PromoViewModel
    {
        public IEnumerable<PromoAction> PromoActions { get; set; } = new List<PromoAction>();
        public PromoAction PromoAction { get; set; } = new();
    }
}
