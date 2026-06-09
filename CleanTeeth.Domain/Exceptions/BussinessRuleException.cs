using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Domain.Exceptions;

public class BussinessRuleException : Exception
{
    public BussinessRuleException(string message) : base(message)
    {
    }
}
