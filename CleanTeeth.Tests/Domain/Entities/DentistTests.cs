using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Tests.Domain.Entities;


[TestClass]
public class DentistTests
{
    [TestMethod]
    public void Constructor_NullName_Throws()
    {
        var email = new Email("valid@example.com");
        Assert.ThrowsExactly<BusinessRuleException>(() => new Dentist(null!, email));
    }

    [TestMethod]
    public void Constructor_NullEmail_Throws()
    {
        Assert.ThrowsExactly<BusinessRuleException>(() => new Dentist("Valid Name", null!));
    }

    [TestMethod]
    public void Constructor_ValidDentist_NoExceptions()
    {
        var email = new Email("valid@example.com");
        var dentist = new Dentist("Valid Name", email);
        Assert.AreEqual("Valid Name", dentist.Name);
        Assert.AreEqual(email, dentist.Email);
    }
}