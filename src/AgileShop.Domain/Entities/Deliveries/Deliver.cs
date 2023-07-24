using System.ComponentModel.DataAnnotations;

namespace AgileShop.Domain.Entities.Deliveries;

public class Deliver : Human
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = String.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;
}
