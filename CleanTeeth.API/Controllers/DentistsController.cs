using CleanTeeth.Application.Features.Dentists.Queries.GetDentists;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers;

[ApiController]
[Route("api/dentists")]
public class DentistsController : ControllerBase
{
    private readonly IMediator mediator;

    public DentistsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<DentistListDTO>>> Get()
    {
        var query = new GetDentistsQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
