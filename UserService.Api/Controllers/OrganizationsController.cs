using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UserService.Api.Contracts.Requests;
using UserService.Application.Services.Organization;
using UserService.Domain.Entities;

namespace UserService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationService _service;

    public OrganizationsController(IOrganizationService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult GetOrganizations()
    {
        var organizations = _service.GetOrganizations();
        
        return Ok(organizations);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id)
    {
        var organization = _service.GetOrganization(id);
        
        return Ok(organization);
    }

    [HttpPost]
    public IActionResult Add([FromBody] OrganizationRequest request)
    {
        var organization = _service.AddOrganization(
            request.ownerId,
            request.name,
            request.status
        );
        
        return Ok(organization);
    }
    
    [HttpPatch("{id}")]
    public IActionResult Edit(
        string id,
        [FromBody] JsonPatchDocument<Organization> patchDoc
    )
    {
        var updOrganization = _service.EditOrganization(id, patchDoc);
        
        return Ok(updOrganization);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        _service.DeleteOrganization(id);
        
        return Ok();
    }
}