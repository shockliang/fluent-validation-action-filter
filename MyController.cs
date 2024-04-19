using Microsoft.AspNetCore.Mvc;

namespace FluentValidationActionFilter;

[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{
    [HttpPost]
    [ServiceFilter(typeof(ValidationActionFilter<MyModel>))]
    public IActionResult Post([FromBody] MyModel myModel)
    {
        return Ok("Model is valid!");
    }
    
    [HttpPost("yourmodel")]
    [ServiceFilter(typeof(ValidationActionFilter<YourModel>))]
    public IActionResult PostYourModel([FromBody] YourModel yourModel)
    {
        return Ok("YourModel is valid!");
    }
}