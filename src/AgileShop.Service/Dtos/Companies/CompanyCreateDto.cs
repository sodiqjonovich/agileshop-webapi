using AgileShop.Domain.Entities.Companies;
using Microsoft.AspNetCore.Http;

namespace AgileShop.Service.Dtos.Companies;

public class CompanyCreateDto
{

    public string Name { get; init; } = String.Empty;

    public string PhoneNumber { get; init; } = String.Empty;

    public string Description { get; init; } = String.Empty;

    public IFormFile Image { get; init; } = default!;
   
}
