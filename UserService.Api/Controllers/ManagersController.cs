using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UserService.Api.Contracts.Requests;
using UserService.Api.Contracts.Responses;
using UserService.Application.Services.Manager;
using UserService.Application.Services.User;
using UserService.Domain.Entities;

namespace UserService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagersController : ControllerBase
{
    private readonly IManagerService _managerService;
    private readonly IUserService _userService;
    
    public ManagersController(IManagerService managerService, IUserService userService)
    {
        _managerService = managerService;
        _userService = userService;
    }
    
    [HttpGet]
    public IActionResult GetManagers()
    {
        var managers = _managerService.GetManagers();
        
        return Ok(managers);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id)
    {
        var manager = _managerService.GetManager(id);
        
        return Ok(manager);
    }
    
    [HttpPost]
    public IActionResult Add([FromBody] ManagerRequest request)
    {
        var user = _userService.AddUser(
            request.email,
            request.password,
            request.role,
            request.phone,
            request.avatarUrl,
            request.status
        );
        
        var manager = _managerService.AddManager(
            user.Id,
            request.medcentreId,
            request.firstName,
            request.lastName,
            request.fatherName
        );

        var response = new ManagerResponse(
            manager.Id,
            user.Id,
            manager.MedcentreId,
            manager.FirstName,
            manager.LastName,
            manager.FatherName,
            user.Email,
            user.Role,
            user.Phone,
            user.AvatarUrl,
            user.Status
            );
        
        return Ok(response);
    }
    
    // TODO
    [HttpPatch("{id}")]
    public IActionResult Edit(
        string id,
        [FromBody] JsonPatchDocument<User> patchUserDoc,
        [FromBody] JsonPatchDocument<Manager> patchManagerDoc
    )
    {
        var updUser = _userService.EditUser(id, patchUserDoc);
        var updManager = _managerService.EditManager(id, patchManagerDoc);
        
        var response = new ManagerResponse(
            updManager.Id,
            updUser.Id,
            updManager.MedcentreId,
            updManager.FirstName,
            updManager.LastName,
            updManager.FatherName,
            updUser.Email,
            updUser.Role,
            updUser.Phone,
            updUser.AvatarUrl,
            updUser.Status
        );
        
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        _managerService.DeleteManager(id);
        
        return Ok();
    }
}