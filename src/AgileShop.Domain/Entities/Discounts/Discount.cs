using System.ComponentModel.DataAnnotations;

namespace AgileShop.Domain.Entities.Discounts;

public class Discount : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public short Percentage { get; set; }

}
