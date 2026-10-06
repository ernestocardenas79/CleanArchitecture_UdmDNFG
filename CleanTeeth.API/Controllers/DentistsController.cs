using CleanTeeth.API.DTOs.Dentist;
using CleanTeeth.Application.Features.Dentists.Commands.CreateDentist;
using CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<DentistDetailDTO>> Get(Guid id)
    {
        var query = new GetDentistDetailQuery { Id = id };
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateDentistDTO createDentistDTO)
    {
        var command = new CreateDentistCommand
        {
            Name = createDentistDTO.Name,
            Email = createDentistDTO.Email
        };

        await mediator.Send(command);
        return Ok();
    }
}
