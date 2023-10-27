using Pizza.Models;

namespace Pizza.Domain.IService
{
    public interface IPromoService
    {
        Task<PromoAction> Get(PromoAction promo);
        Task Edit(PromoAction promo);
        Task Add(PromoAction promo);
        Task Delete(PromoAction promo);
    }
}
