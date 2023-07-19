using AgileShop.DataAccess.Interfaces.Users;
using AgileShop.Domain.Exceptions.Users;
using AgileShop.Service.Common.Helpers;
using AgileShop.Service.Dtos.Auth;
using AgileShop.Service.Dtos.Security;
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

    #pragma warning disable
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

    public async Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string phone)
    {
        if (_memoryCache.TryGetValue(phone, out RegisterDto registerDto))
        {
            VerificationDto verificationDto = new VerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelper.GetDateTime();
            // make confirm code as random
            verificationDto.Code = 11111;
            _memoryCache.Set(phone, verificationDto, 
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

            // sms sender::begin
            // sms sender::end

            return (Result: true, CachedVerificationMinutes: CACHED_MINUTES_FOR_VERIFICATION);
        }
        else throw new UserCacheDataExpiredException();
    }

    public async Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int code)
    {
        throw new Exception();
    }
}
