using Microsoft.AspNetCore.Mvc;
using Repositories;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetAccount(int id, [FromKeyedServices("psql")] IAccountRepository accountRepository)
    {
        var name = accountRepository.GetAccountName(id);

        return Ok(name);
    }
}