using AgileShop.DataAccess.Interfaces.Users;
using AgileShop.Domain.Exceptions.Users;
using AgileShop.Service.Common.Helpers;
using AgileShop.Service.Dtos.Auth;
using AgileShop.Service.Dtos.Notifications;
using AgileShop.Service.Dtos.Security;
using AgileShop.Service.Interfaces.Auth;
using AgileShop.Service.Interfaces.Notifcations;
using Microsoft.Extensions.Caching.Memory;
using System.Security.AccessControl;

namespace AgileShop.Service.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUserRepository _userRepository;
    private readonly ISmsSender _smsSender;
    private const int CACHED_MINUTES_FOR_REGISTER = 60;
    private const int CACHED_MINUTES_FOR_VERIFICATION = 5;
    public AuthService(IMemoryCache memoryCache, 
        IUserRepository userRepository,
        ISmsSender smsSender)
    {
        this._memoryCache = memoryCache;
        this._userRepository = userRepository;
        this._smsSender = smsSender;
    }

    #pragma warning disable
    public async Task<(bool Result, int CachedMinutes)> RegisterAsync(RegisterDto dto)
    {
        var user = await _userRepository.GetByPhoneAsync(dto.PhoneNumber);
        if (user is not null) throw new UserAlreadyExistsException(dto.PhoneNumber);

        // delete if exists user by this phone number
        if(_memoryCache.TryGetValue("register_"+dto.PhoneNumber, out RegisterDto cachedRegisterDto))
        {
            cachedRegisterDto.FirstName = cachedRegisterDto.FirstName;
            _memoryCache.Remove(dto.PhoneNumber);
        }
        else _memoryCache.Set("register_"+dto.PhoneNumber, dto, 
            TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));

        return (Result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);
    }

    public async Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string phone)
    {
        if (_memoryCache.TryGetValue("register_"+phone, out RegisterDto registerDto))
        {
            VerificationDto verificationDto = new VerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelper.GetDateTime();

            // make confirm code as random
            verificationDto.Code = 11111;

            if(_memoryCache.TryGetValue("verify_register_"+phone, out VerificationDto oldVerifcationDto))
            {
                _memoryCache.Remove("verify_register_" + phone);
            }
            
            _memoryCache.Set("verify_register_" + phone, verificationDto, 
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

            SmsMessage smsMessage = new SmsMessage();
            smsMessage.Title = "Agile Shop";
            smsMessage.Content = "Your verification code : " + verificationDto.Code;
            smsMessage.Recipent = phone.Substring(1);

            var smsResult = await _smsSender.SendAsync(smsMessage);
            if (smsResult is true) return (Result: true, CachedVerificationMinutes: CACHED_MINUTES_FOR_VERIFICATION);
            else return (Result: false, CachedVerificationMinutes: 0);
        }
        else throw new UserCacheDataExpiredException();
    }

    public async Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int code)
    {
        throw new Exception();
    }
}
