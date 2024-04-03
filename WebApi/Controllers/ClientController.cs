using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    public ClientController()
    {
        
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetClient(int id)
    {
        return Ok();
    }
}