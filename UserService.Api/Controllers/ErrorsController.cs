using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Exceptions;

namespace UserService.Api.Controllers;

[ApiController]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)] 
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var message = exception != null ? exception.Message : "Unexpected error";
        var code = exception switch
        {
            NotFoundException => 404,
            _ => 500
        };
        
        return Problem(title: message, statusCode: code);
    }
}