using Microsoft.AspNetCore.Mvc;
using AuthServer.Core;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
