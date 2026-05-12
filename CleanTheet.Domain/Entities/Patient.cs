using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTheet.Domain.Entities;

public class Patient
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
}
