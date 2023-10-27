using Pizza.Domain.IService;
using Pizza.Models;

namespace Pizza.Domain.Service
{
    public class BusketService : IBusketService
    {
        public int? GetTotalPrice(List<Busket> buskets)
        {
            int? total = 0;
            foreach(var item in buskets)
                total += item?.Product?.Price;
            return total;
        }
    }
}
