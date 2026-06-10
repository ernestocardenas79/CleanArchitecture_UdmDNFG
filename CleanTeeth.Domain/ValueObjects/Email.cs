using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Domain.ValueObjects;

public record Email
{
    public string Value { get; private set; }
    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new BusinessRuleException($"The {nameof(email)} is required");
        }
        if (!email.Contains("@"))
        {
            throw new BusinessRuleException($"The {nameof(email)} is not valid");
        }

        Value = email;
    }
}