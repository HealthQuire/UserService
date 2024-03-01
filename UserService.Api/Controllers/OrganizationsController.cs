using Microsoft.AspNetCore.Mvc;
using UserService.Contracts.Organizations;

namespace UserService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganizationsController : ControllerBase
{
    // private readonly IOrganizationService _service;
    
    public OrganizationsController()
    {
        // _service = service;  
    }
    
    [HttpGet]
    public IActionResult GetOrganizations()
    {
        // HttpContext.Request.Headers -> token
        var response = new List<object>();
        
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        // HttpContext.Request.Headers -> token
        
        Console.WriteLine(id);
        
        var response = new OrganizationResponse(
            0,
            0,
            "",
            ""
        );
        
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Add()
    {
        // HttpContext.Request.Headers -> token
        
        var response = new OrganizationResponse(
            0,
            0,
            "",
            ""
        );
        
        return Ok(response);
    }
    
    [HttpPatch("{id}")]
    public IActionResult Edit(int id)
    {
        // HttpContext.Request.Headers -> token
        
        var response = new OrganizationResponse(
            0,
            0,
            "",
            ""
        );
        
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // HttpContext.Request.Headers -> token
        
        return Ok();
    }
}