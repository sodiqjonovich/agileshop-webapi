using AgileShop.DataAccess.Interfaces.Companies;
using AgileShop.DataAccess.Utils;
using AgileShop.Domain.Entities.Companies;
using AgileShop.Domain.Exceptions.Companies;
using AgileShop.Service.Common.Helpers;
using AgileShop.Service.Dtos.Companies;
using AgileShop.Service.Interfaces.Common;
using AgileShop.Service.Interfaces.Companies;
using AutoMapper;

namespace AgileShop.Service.Services.Companies;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _repository;
    private readonly IFileService _fileService;
    private readonly IPaginator _paginator;
    private readonly IMapper _mapper;

    public CompanyService(ICompanyRepository companyRepository,
        IFileService fileService,
        IPaginator paginator,
        IMapper mapper)
    {
        this._repository = companyRepository;
        this._fileService = fileService;
        this._paginator = paginator;
        this._mapper = mapper;
    }
    public async Task<bool> CreateAsync(CompanyCreateDto dto)
    {
        Company company = _mapper.Map<Company>(dto);
        company.ImagePath = await _fileService.UploadImageAsync(dto.Image);
        company.CreatedAt = company.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.CreateAsync(company);
        return dbResult > 0;
    }

    public async Task<bool> DeleteAsync(long companyId)
    {
        var company = await _repository.GetByIdAsync(companyId);
        if (company is null) throw new CompanyNotFoundException();
        else
        {
            await _fileService.DeleteImageAsync(company.ImagePath);
            var result = await _repository.DeleteAsync(companyId);
            return result > 0;
        }
    }

    public async Task<IList<Company>> GetAllAsync(PaginationParams @params)
    {
        var companies = await _repository.GetAllAsync(@params);
        long count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return companies;
    }

    public async Task<Company> GetByIdAsync(long companyId)
    {
        var company = await _repository.GetByIdAsync(companyId);
        if (company is null) throw new CompanyNotFoundException();
        else return company;
    }

    public async Task<bool> UpdateAsync(long companyId, CompanyUpdateDto dto)
    {
        var company = await _repository.GetByIdAsync(companyId);
        if (company is null) throw new CompanyNotFoundException();

        company.Name = dto.Name;
        company.Description = dto.Description;
        company.PhoneNumber = dto.PhoneNumber;

        if (dto.Image is not null)
        {
            await _fileService.DeleteImageAsync(company.ImagePath);
            company.ImagePath = await _fileService.UploadImageAsync(dto.Image);
        }

        company.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(companyId, company);
        return dbResult > 0;
    }
}
