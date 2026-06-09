using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;

internal static class MapperExtensions
{
    internal static DentalOfficeDetailDTO ToDTO(this DentalOffice dentalOffice)
    {
        var dto = new DentalOfficeDetailDTO{ Id= dentalOffice.Id, Name= dentalOffice.Name };
        return dto;
    }
}