using Microsoft.AspNetCore.Mvc;
using UserService.Api.Contracts.Requests;
using UserService.Application.Services.Auth;
using UserService.Application.Services.User;

namespace UserService.Api.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public AuthController(IAuthService authservice, IUserService userService)
    {
        _authService = authservice;
        _userService = userService;
    }
    
    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var userDto = _authService.Login(
            request.email,
            request.password
            );
        
        return Ok(userDto);
    }
    
    [Route("register")]
    [HttpPost]
    public IActionResult Register([FromBody] UserRequest request)
    {
        var userDto = _userService.AddUser(
            request.email,
            request.password,
            request.role,
            request.phone,
            request.avatarUrl,
            request.status
        );
        
        return Ok(userDto);
    }
}