using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTheet.Domain.Exceptions;

public class BussinessRuleException : Exception
{
    public BussinessRuleException(string message) : base(message)
    {
    }
}
