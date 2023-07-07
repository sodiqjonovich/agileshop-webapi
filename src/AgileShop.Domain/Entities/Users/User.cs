using AgileShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgileShop.Domain.Entities.Users;

public class User : Human
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = String.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;

    public DateTime LastActivity { get; set; }

    public IdentityRole Role { get; set; }
}
