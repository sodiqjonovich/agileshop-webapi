using AgileShop.DataAccess.Utils;

namespace AgileShop.DataAccess.Common.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> SearchAsync(string search,
        PaginationParams @params);
}
