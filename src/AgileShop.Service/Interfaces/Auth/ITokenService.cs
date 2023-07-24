using AgileShop.Domain.Entities.Users;

namespace AgileShop.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);
}
