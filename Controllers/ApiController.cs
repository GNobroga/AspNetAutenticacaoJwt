using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_para_emprego.Controllers;

[Route("[controller]")]
[ApiController]
public class ApiController : ControllerBase
{

    public UserManager<IdentityUser> UserManager { get; set; }

    public ApiController(UserManager<IdentityUser> manager)
    {
        UserManager = manager;
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "COMMON")]
    [HttpGet("publico")]
    public ActionResult<string> Public()
    {   
        return "Rota Publica";
    }
    
    [HttpGet("private")]
    public ActionResult<string> Private() 
    {
        return "Rota Private";
    }

}