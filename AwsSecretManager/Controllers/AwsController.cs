using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AwsSecretManager.Controllers;

[ApiController]
[Route("[controller]")]
public class AwsController : ControllerBase
{
    private readonly IOptions<SecretCredentials> _secrets;

    public AwsController(IOptions<SecretCredentials> secrets)
    {
        _secrets = secrets;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(!string.IsNullOrEmpty(_secrets.Value.ConnectionString));
    }
}
