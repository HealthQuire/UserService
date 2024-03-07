using Microsoft.AspNetCore.Mvc;

namespace UserService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganizationsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrganizations()
    {
        
        return Ok();
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        
        return Ok();
    }

    [HttpPost]
    public IActionResult Add()
    {

        return Ok();
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