using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UserService.Api.Contracts.Requests;
using UserService.Api.Contracts.Responses;
using UserService.Application.Services.Manager;
using UserService.Domain.Entities;

namespace UserService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagersController : ControllerBase
{
    private readonly IManagerService _service;
    
    public ManagersController(IManagerService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult GetManagers()
    {
        var managers = _service.GetManagers();
        
        return Ok(managers);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id)
    {
        var manager = _service.GetManager(id);
        
        return Ok(manager);
    }

    // TODO
    [HttpPost]
    public IActionResult Add([FromBody] ManagerRequest request)
    {
        var userRequest = request.user;

        var user = new User();
        
        var manager = _service.AddManager(
            user.Id,
            request.medcentreId,
            request.firstName,
            request.lastName,
            request.fatherName
        );

        var response = new ManagerResponse(
            
            );
        
        return Ok(response);
    }
    
    // TODO
    [HttpPatch("{id}")]
    public IActionResult Edit(
        string id,
        [FromBody] JsonPatchDocument<Manager> patchDoc
    )
    {
        var updManager = _service.EditManager(id, patchDoc);
        
        return Ok(updManager);
    }
    
    // TODO
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        _service.DeleteManager(id);
        
        return Ok();
    }
}