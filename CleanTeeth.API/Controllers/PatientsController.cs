using CleanTeeth.API.DTOs.Patients;
using CleanTeeth.API.Utilities;
using CleanTeeth.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientList;
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

    [HttpGet]
    public async Task<ActionResult<List<PatientListDTO>>> Get([FromQuery] GetPatientListQuery query)
    {
        var result = await mediator.Send(query);
        HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
        return Ok(result.Elements);
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
