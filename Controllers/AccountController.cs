using Atividade_para_emprego.Auth;
using Atividade_para_emprego.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_para_emprego.Controllers
{   
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ActionResult<object>> Create(CreateAccount createAccount, TokenService service)
        {

            IdentityUser user = new() {
                UserName = createAccount.Username,
                Email = createAccount.Email
            };

            var result = await userManager.CreateAsync(user, createAccount.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "COMMON");
                return new {
                    Title = "Bearer",
                    Token = service.GenerateToken(user.Id)
                };
            }

            return BadRequest(result.Errors);
        }
    }

}