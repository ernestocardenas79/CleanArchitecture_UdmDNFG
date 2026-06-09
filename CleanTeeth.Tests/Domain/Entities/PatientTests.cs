using CleanTheet.Domain.Entities;
using CleanTheet.Domain.Exceptions;
using CleanTheet.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTheet.Tests.Domain.Entities;

[TestClass]
public class PatientTests
{
    [TestMethod]
    public void Constructor_NullName_Throws()
    {
        var email = new Email("valid@example.com");
        Assert.ThrowsExactly<BussinessRuleException>(() => new Patient(null!, email));
    }

    [TestMethod]
    public void Constructor_NullEmail_Throws()
    {
        Assert.ThrowsExactly<BussinessRuleException>(() => new Patient("Valid Name", null!));
    }

    [TestMethod]
    public void Constructor_ValidPatient_NoExceptions()
    {
        var email = new Email("valid@example.com");
        var patient = new Patient("Valid Name", email);
        Assert.AreEqual("Valid Name", patient.Name);
        Assert.AreEqual(email, patient.Email);
        Assert.IsTrue(Guid.TryParse(patient.Id.ToString(), out _));
    }
}