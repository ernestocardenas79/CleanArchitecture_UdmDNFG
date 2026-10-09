using CleanTeeth.API.DTOs.Appointment;
using CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment;
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
}
