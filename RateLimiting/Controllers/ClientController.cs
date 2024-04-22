using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

[ApiController]
[Route("v2")]
public class ClientController : ControllerBase
{
    [Route("fixed/{id}")]
    [EnableRateLimiting("fixed-limiter")]
    public IActionResult Fixed(int id)
    {
        return Ok(id);
    }
}