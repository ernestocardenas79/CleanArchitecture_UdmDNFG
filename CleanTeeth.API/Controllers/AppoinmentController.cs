using CleanTeeth.API.DTOs.Appointment;
using CleanTeeth.Application.Features.Appointments.Commands.CompleteAppointment;
using CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment;
using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail;
using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentList;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController:ControllerBase
{
    private readonly IMediator mediator;

    public AppointmentsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentsListDTO>>> Get([FromQuery] GetAppointmentListQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateAppointmentDTO createAppointmentDTO)
    {
        var command = new CreateAppointmentCommand
        {
            PatientId = createAppointmentDTO.PatientId,
            DentistId = createAppointmentDTO.DentistId,
            DentalOfficeId = createAppointmentDTO.DentalOfficeId,
            StartDate = createAppointmentDTO.StartDate,
            EndDate = createAppointmentDTO.EndDate
        };

        var result = await mediator.Send(command);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentDetailDTO>> Get(Guid id)
    {
        var query = new GetAppointmentDetailQuery { Id = id };
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("{id}/complete")]
    public async Task<IActionResult> Complete(Guid id)
    {
        var command = new CompleteAppointmentCommand { Id = id };
        await mediator.Send(command);
        return NoContent();
    }
}
