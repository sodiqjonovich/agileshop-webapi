using AgileShop.Service.Dtos.Notifications;
using AgileShop.Service.Interfaces.Notifcations;
using Microsoft.AspNetCore.Mvc;

namespace AgileShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SmsController : ControllerBase
{
    private readonly ISmsSender _smsSender;
    public SmsController(ISmsSender smsSender)
    {
        this._smsSender = smsSender;
    }

    [HttpPost]
    public async Task<IActionResult> SendAsync([FromBody] SmsMessage smsMessage)
    {
        return Ok(await _smsSender.SendAsync(smsMessage));
    }
}
