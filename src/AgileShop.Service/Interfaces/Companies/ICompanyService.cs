using AgileShop.DataAccess.Utils;
using AgileShop.Domain.Entities.Companies;
using AgileShop.Service.Dtos.Companies;

namespace AgileShop.Service.Interfaces.Companies;

public interface ICompanyService
{
    public Task<bool> CreateAsync(CompanyCreateDto dto);

    public Task<IList<Company>> GetAllAsync(PaginationParams @params);

    public Task<Company> GetByIdAsync(long companyId);

    public Task<bool> UpdateAsync(long companyId, CompanyUpdateDto dto);

    public Task<bool> DeleteAsync(long companyId);
}
