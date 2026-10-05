namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentists;

public class DentistListDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}
