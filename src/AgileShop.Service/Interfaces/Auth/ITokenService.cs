using AgileShop.Domain.Entities.Users;

namespace AgileShop.Service.Interfaces.Auth;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);
}
