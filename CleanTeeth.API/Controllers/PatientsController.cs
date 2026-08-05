using CleanTeeth.API.DTOs.Patients;
using CleanTeeth.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientsController : ControllerBase    
{
    private readonly IMediator mediator;

    public PatientsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePatientDTO createPatientDTO)
    {
        var command = new CreatePatientCommand
        {
            Name = createPatientDTO.Name,
            Email = createPatientDTO.Email
        };
        var patientId = await mediator.Send(command);
        return Ok(patientId);
    }
}
