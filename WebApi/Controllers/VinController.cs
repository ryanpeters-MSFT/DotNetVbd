using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class VinController : ControllerBase
{
    [HttpGet]
    [Route("parse/{vin}")]
    public IActionResult Parse(Vin vin) => Ok(vin);
}