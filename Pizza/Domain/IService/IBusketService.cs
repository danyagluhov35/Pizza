using Pizza.Models;

namespace Pizza.Domain.IService
{
    public interface IBusketService
    {
        int? GetTotalPrice(List<Busket> buskets);
    }
}
