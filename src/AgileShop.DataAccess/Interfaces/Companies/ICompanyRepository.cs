using AgileShop.DataAccess.Common.Interfaces;
using AgileShop.Domain.Entities.Companies;

namespace AgileShop.DataAccess.Interfaces.Companies;

public interface ICompanyRepository : IRepository<Company, Company>,
    IGetAll<Company>
{
}
