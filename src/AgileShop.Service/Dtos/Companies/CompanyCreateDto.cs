using Microsoft.AspNetCore.Http;

namespace AgileShop.Service.Dtos.Companies;

public class CompanyCreateDto
{
    public string Name { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public IFormFile Image { get; set; } = default!;
}
