using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Tests.Domain.ValueObjects;

[TestClass]
public class TimeIntervalTests
{
    [TestMethod]
    public void Constructor_EndBeforeStart_Throws()
    {
        var start = DateTime.Now;
        var end = start.AddHours(-1);
        Assert.ThrowsExactly<BusinessRuleException>(() => new TimeInterval(start, end));
    }

    [TestMethod]
    public void Constructor_ValidInterval_NoException()
    {
        var start = DateTime.Now;
        var end = start.AddHours(1);
        var interval = new TimeInterval(start, end);
        Assert.AreEqual(start, interval.Start);
        Assert.AreEqual(end, interval.End);
    }
}
