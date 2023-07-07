using System.ComponentModel.DataAnnotations;

namespace AgileShop.Domain.Entities.Companies;

public class Company : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;

    [MaxLength(13)]
    public string PhoneNumber { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;
}
