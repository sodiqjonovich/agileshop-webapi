using AgileShop.DataAccess.Common.Interfaces;
using AgileShop.DataAccess.ViewModels.Products;
using AgileShop.Domain.Entities.Products;

namespace AgileShop.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product, ProductViewModel>,
    IGetAll<ProductViewModel>, ISearchable<ProductViewModel>
{
}
