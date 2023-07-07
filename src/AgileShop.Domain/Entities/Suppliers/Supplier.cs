using System.ComponentModel.DataAnnotations;

namespace AgileShop.Domain.Entities.Suppliers;

public class Supplier : Auditable
{
    [MaxLength(50)]
    public string CompanyName { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    [MaxLength(13)]
    public string FaxPhoneNumber { get; set; } = String.Empty;

    [MaxLength(13)]
    public string ContactPhoneNumber { get; set; } = String.Empty;

}
