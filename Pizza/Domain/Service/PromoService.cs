using Microsoft.EntityFrameworkCore;
using Pizza.Domain.IService;
using Pizza.Models;
using Pizza.Models.Context;

namespace Pizza.Domain.Service
{
    public class PromoService : IPromoService
    {
        private PizzaProjectContext _db;
        public PromoService()
        {
            _db = new PizzaProjectContext();
        }
        public async Task Add(PromoAction promo)
        {
            await _db.PromoActions.AddAsync(promo);
            _db.SaveChanges();
        }

        public async Task Edit(PromoAction promo)
        {
            _db.PromoActions.Update(promo);
            await _db.SaveChangesAsync();
        }

        public async Task<PromoAction> Get(PromoAction promo)
        {
            var res = await _db.PromoActions.FirstOrDefaultAsync(p => p.Id == promo.Id);
            return res!;
        }
        public async Task Delete(PromoAction promo)
        {
            _db.PromoActions.Remove(promo);
            await _db.SaveChangesAsync();
        }
    }
}
