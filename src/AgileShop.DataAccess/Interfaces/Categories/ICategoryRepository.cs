using AgileShop.DataAccess.Common.Interfaces;
using AgileShop.Domain.Entities.Categories;

namespace AgileShop.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>,
    IGetAll<Category>
{
}
