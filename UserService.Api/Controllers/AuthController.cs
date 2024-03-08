using Microsoft.AspNetCore.Mvc;
using UserService.Api.Contracts.Requests;
using UserService.Application.Services.Auth;

namespace UserService.Api.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }
    
    [Route("login")]
    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        var userDto = _service.Login(
            request.email,
            request.password
            );
        
        return Ok(userDto);
    }
    
    // [HttpPost]
    // public IActionResult Register(RegisterRequest request)
    // {
    //     
    //     return Ok(userDto);
    // }
}