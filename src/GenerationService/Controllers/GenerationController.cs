using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GenerationService.Controllers;

[SwaggerTag("Генерация сводки")]
[Authorize]
[ApiController]
[Route("api/summary")]
[Produces("application/json")]
public class GenerationController : ControllerBase
{

    [HttpGet("generate")]
    public void GenerateScores(
        [FromQuery] Guid userId,
        CancellationToken cancellationToken)
    {

    }
}
