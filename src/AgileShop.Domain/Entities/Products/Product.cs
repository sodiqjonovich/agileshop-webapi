using System.ComponentModel.DataAnnotations;

namespace AgileShop.Domain.Entities.Products;

public class Product : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;

    public double UnitPrice { get; set; }

    public long CategoryId { get; set; }

    public long CompanyId { get; set; }
}
