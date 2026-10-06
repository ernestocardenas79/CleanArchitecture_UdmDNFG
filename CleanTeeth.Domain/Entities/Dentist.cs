using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class Dentist
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }= null!;
    public Email Email { get; private set; }=null!;

    public Dentist()
    {
        
    }

    public Dentist(string name, Email email)
    {
        EnforceDentistName(name);
        EnforceEmail(email);

        Name = name;
        Email = email;
        Id = Guid.CreateVersion7();
    }

    private static void EnforceEmail(Email email)
    {
        if (email is null)
        {
            throw new BusinessRuleException($"The {nameof(email)} is required.");
        }
    }

    private static void EnforceDentistName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BusinessRuleException($"The {nameof(name)} is required.");
        }
    }

    public void UpdateName(string name)
    {
        EnforceDentistName(name);

        Name = name;
    }

    public void UpdateEmail(Email email)
    {
        EnforceEmail(email);
        Email = email;
    }
}
