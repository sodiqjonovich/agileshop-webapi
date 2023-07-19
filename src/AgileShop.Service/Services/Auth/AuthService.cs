using AgileShop.DataAccess.Interfaces.Users;
using AgileShop.Domain.Exceptions.Users;
using AgileShop.Service.Dtos.Auth;
using AgileShop.Service.Interfaces.Auth;
using Microsoft.Extensions.Caching.Memory;
using System.Security.AccessControl;

namespace AgileShop.Service.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUserRepository _userRepository;
    private const int CACHED_MINUTES_FOR_REGISTER = 60;
    private const int CACHED_MINUTES_FOR_VERIFICATION = 5;
    public AuthService(IMemoryCache memoryCache, 
        IUserRepository userRepository)
    {
        this._memoryCache = memoryCache;
        this._userRepository = userRepository;
    }
    public async Task<(bool Result, int CachedMinutes)> RegisterAsync(RegisterDto dto)
    {
        var user = await _userRepository.GetByPhoneAsync(dto.PhoneNumber);
        if (user is not null) throw new UserAlreadyExistsException(dto.PhoneNumber);

        // delete if exists user by this phone number
        if(_memoryCache.TryGetValue(dto.PhoneNumber, out RegisterDto cachedRegisterDto))
        {
            cachedRegisterDto.FirstName = cachedRegisterDto.FirstName;
            _memoryCache.Remove(dto.PhoneNumber);
        }
        else _memoryCache.Set(dto.PhoneNumber, dto, 
            TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));

        return (Result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);
    }

    public Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string phone)
    {
        throw new NotImplementedException();
    }

    public Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int code)
    {
        throw new NotImplementedException();
    }
}
