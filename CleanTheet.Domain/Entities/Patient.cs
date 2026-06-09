using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Domain.Entities;

public class Patient
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;

    public Patient(string name, Email email)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new BussinessRuleException($"The {nameof(name)} is required.");
        }
        if(email is null)
        {
            throw new BussinessRuleException($"The {nameof(email)} is required.");
        }

        Name = name;
        Email = email;
        Id = Guid.CreateVersion7();
    }
}