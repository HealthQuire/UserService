using Microsoft.AspNetCore.Mvc;
namespace UserService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController
{
    // For other backends
    // For my backend go directly to UserService
    
    // login register
    // короче когда там токен умер на фронте, есть рефреш токен который чекается на фронте и если он видит что 
    // скам по токену обращается к !! сервису андрея !! и говорит дай мне новый блядский токен
    // у меня токен возвращается только при реге и при логине
}