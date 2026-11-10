using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail;

public class GetAppointmentDetailQuery : IRequest<AppointmentDetailDTO>
{
    public Guid Id { get; set; }
}
