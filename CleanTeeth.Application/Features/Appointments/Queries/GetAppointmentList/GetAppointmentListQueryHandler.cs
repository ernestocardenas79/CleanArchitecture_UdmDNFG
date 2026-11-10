using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentList;

public class GetAppointmentListQueryHandler : IRequestHandler<GetAppointmentListQuery, IEnumerable<AppointmentsListDTO>>
{
    private readonly IAppointmentRepository repository;
    public GetAppointmentListQueryHandler(IAppointmentRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<AppointmentsListDTO>> Handle(GetAppointmentListQuery request)
    {
        var appointments = await repository.GetFiltered(request);
        return appointments.Select(a => a.ToDTO());
    }
}