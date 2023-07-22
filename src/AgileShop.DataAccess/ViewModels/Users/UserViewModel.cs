using AgileShop.Domain.Entities;
using AgileShop.Domain.Enums;

namespace AgileShop.DataAccess.ViewModels.Users;

public class UserViewModel : Auditable
{
    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string PassportSeriaNumber { get; set; } = String.Empty;

    public bool IsMale { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Country { get; set; } = String.Empty;

    public string Region { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public DateTime LastActivity { get; set; }

    public IdentityRole Role { get; set; }
}
