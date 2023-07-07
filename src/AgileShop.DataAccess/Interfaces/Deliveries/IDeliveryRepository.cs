using AgileShop.DataAccess.Common.Interfaces;
using AgileShop.DataAccess.ViewModels.Deliveries;
using AgileShop.Domain.Entities.Deliveries;

namespace AgileShop.DataAccess.Interfaces.Deliveries;

public interface IDeliveryRepository : IRepository<Deliver, Deliver>,
    IGetAll<DeliverViewModel>
{
    public Task<DeliverViewModel> GetDeliverAsync(long id);
}
