using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail;

public class GetAppointmentDetailQueryHandler : IRequestHandler<GetAppointmentDetailQuery, AppointmentDetailDTO>
{
    private readonly IAppointmentRepository appointmentRepository;
    public GetAppointmentDetailQueryHandler(IAppointmentRepository appointmentRepository)
    {
        this.appointmentRepository = appointmentRepository;
    }
    public async Task<AppointmentDetailDTO> Handle(GetAppointmentDetailQuery request)
    {
        var appointment = await appointmentRepository.GetById(request.Id);
        if (appointment == null)
        {
            throw new NotFoundException();
        }
        return appointment.ToDto();
    }
}