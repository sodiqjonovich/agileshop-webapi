using AgileShop.Domain.Entities.Companies;
using AgileShop.Service.Dtos.Companies;
using AutoMapper;

namespace AgileShop.WebApi.Configurations;
public class MapperConfiguration : Profile
{
	public MapperConfiguration()
	{
		CreateMap<CompanyCreateDto, Company>().ReverseMap();

		CreateMap<CompanyUpdateDto, Company>().ReverseMap();
	}
}
