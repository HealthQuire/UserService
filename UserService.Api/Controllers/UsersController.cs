using Microsoft.AspNetCore.Mvc;
using UserService.Api.Contracts.Requests;
using UserService.Application.Services.User;

namespace UserService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    
    public UsersController(IUserService service)
    {
        _service = service;
    }
    
    // [HttpPost]
    // public IActionResult Login()
    // {
    //     return Ok();
    // }
    //
    // [HttpPost]
    // public IActionResult Register()
    // {
    //     return Ok();
    // }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _service.GetUsers();
        
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var userDto = _service.GetUser(id);
        
        return Ok(userDto);
    }

    [HttpPost]
    public IActionResult Add(UserRequest request)
    {
        var userDto = _service.AddUser(
            request.email,
            request.password,
            request.role,
            request.phone,
            request.avatarUrl,
            request.status
        );
        
        return Ok(userDto);
    }
    
    [HttpPatch("{id}")]
    public IActionResult Edit(string id)
    {
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        return Ok();
    }
}