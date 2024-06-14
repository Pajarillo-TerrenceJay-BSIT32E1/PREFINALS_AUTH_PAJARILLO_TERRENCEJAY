using Microsoft.AspNetCore.Mvc;
using AuthServer.Core;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public AuthController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string username, string password)
    {
        await _userService.CreateUser(username, password);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = await _userService.GetUserByUsername(username);
        if (user == null || !_userService.VerifyPassword(user, password))
        {
            return Unauthorized();
        }
        var token = await _authService.GenerateJwtToken(user);
        return Ok(new { Token = token });
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(string username, string oldPassword, string newPassword)
    {
        var user = await _userService.GetUserByUsername(username);
        if (user == null || !_userService.VerifyPassword(user, oldPassword))
        {
            return Unauthorized();
        }
        await _userService.ChangePassword(user, newPassword);
        return Ok();
    }

    [HttpPost("lock")]
    public async Task<IActionResult> LockAccount(string username)
    {
        var user = await _userService.GetUserByUsername(username);
        if (user == null)
        {
            return NotFound();
        }
        await _userService.LockAccount(user);
        return Ok();
    }
}