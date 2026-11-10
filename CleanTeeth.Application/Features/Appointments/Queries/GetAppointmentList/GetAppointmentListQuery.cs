using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentList;

public class GetAppointmentListQuery: AppointmentsFilterDTO, IRequest<IEnumerable<AppointmentsListDTO>>
{}
