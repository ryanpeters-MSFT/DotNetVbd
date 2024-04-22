using Microsoft.AspNetCore.Mvc;
using Repositories;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetAccount(int id, [FromKeyedServices("psql")] IDataRepository repository)
    {
        var name = repository.GetBackendName();

        return Ok(name);
    }
}