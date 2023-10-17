using Pizza.Context.Entities;

namespace Pizza.Models
{
    public class SlideViewModel
    {
        public IEnumerable<PromoAction> PromoActions { get; set; } = new List<PromoAction>();
    }
}
