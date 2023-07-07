using AgileShop.DataAccess.Common.Interfaces;
using AgileShop.Domain.Entities.Discounts;

namespace AgileShop.DataAccess.Interfaces;

public interface IDiscountRepository : IRepository<Discount, Discount>,
    IGetAll<Discount>
{
}
