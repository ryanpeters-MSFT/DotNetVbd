using Microsoft.AspNetCore.Mvc;
using Repositories;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    public ClientController()
    {
        
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetClient(int id, IClientRepository clientRepository)
    {
        var client = clientRepository.GetClient(id);

        return Ok(client);
    }
}