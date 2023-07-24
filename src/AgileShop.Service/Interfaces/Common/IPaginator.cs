using AgileShop.DataAccess.Utils;

namespace AgileShop.Service.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
