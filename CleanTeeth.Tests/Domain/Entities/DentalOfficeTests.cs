using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Tests.Domain.Entities;

[TestClass]
public class DentalOfficeTests
{
    [TestMethod]
    public void Constructor_NullName_Throws()
    {
        Assert.ThrowsExactly<BussinessRuleException>(() => new DentalOffice(null!));
    }
}
