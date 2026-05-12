using CleanTheet.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTheet.Domain.Entities;

public class Dentist
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }= null!;
    public string Email { get; private set; }=null!;

    public Dentist(string name, string email)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new BussinessRuleException($"The {nameof(name)} is required.");
        }
        if(string.IsNullOrWhiteSpace(email))
        {
            throw new BussinessRuleException($"The {nameof(email)} is required.");
        }

        if(!email.Contains("@"))
        {
            throw new BussinessRuleException($"The {nameof(email)} is not valid.");
        }

        Name = name;
        Email = email;
        Id = Guid.CreateVersion7();
    }
}
