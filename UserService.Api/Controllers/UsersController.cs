using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UserService.Api.Contracts.Requests;
using UserService.Application.Services.User;
using UserService.Domain.Entities;

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

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _service.GetUsers();
        
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id)
    {
        var userDto = _service.GetUser(id);
        
        return Ok(userDto);
    }

    [HttpPost]
    public IActionResult Add([FromBody] UserRequest request)
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
    public IActionResult Edit([FromRoute] string id, [FromBody] JsonPatchDocument<User> patchDoc)
    {
        var updUser = _service.EditUser(id, patchDoc);
        
        return Ok(updUser);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        _service.DeleteUser(id);
        
        return Ok();
    }
}