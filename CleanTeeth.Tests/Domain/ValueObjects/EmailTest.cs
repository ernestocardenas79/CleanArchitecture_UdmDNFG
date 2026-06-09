using CleanTheet.Domain.Exceptions;
using CleanTheet.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTheet.Tests.Domain.ValueObjects;

[TestClass]
public class EmailTest
{
    [TestMethod]
    public void Contructor_NullMail_Throws()
    {
        Assert.ThrowsExactly<BussinessRuleException>(() => new Email(null!));
    }

    [TestMethod]
    public void Constructor_EmailWithoutAt_Throws()
    {
        Assert.ThrowsExactly<BussinessRuleException>(()=> new Email("valid.com"));
    }

    [TestMethod]
    public void Constructor_ValidEmail_NoException()
    {
        var email = new Email("valid@email.com");
        Assert.AreEqual("valid@email.com", email.Value);
    }
}
