using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using FluentValidation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CleanTheet.Tests.Application.Utilities.Mediator;

[TestClass]
public class SimpleMediatorTests
{
    public class FalseRequest : IRequest<string>
    {
        public required string Name { get; init; }
    }
    
    public class FalseRequestValidator : AbstractValidator<FalseRequest>
    {
        public FalseRequestValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
        }
    }

    [TestMethod]
    public async Task Send_WithRegisteredHandler_HandleIsExecuted()
    {
        var request = new FalseRequest(){Name="Example"};
        
        var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();
        
        var serviceProvider = Substitute.For<IServiceProvider>();
        
        serviceProvider
            .GetService(typeof(IRequestHandler<FalseRequest, string>))
            .Returns(handlerMock);
        
        var mediator = new SimpleMediator(serviceProvider);
        var result = await mediator.Send(request);
        
        await  handlerMock
            .Received(1).Handle(Arg.Is(request));
    }
    
    [TestMethod]
    public async Task Send_WithoutRegisteredHandler_Throws()
    {
        var request = new FalseRequest(){Name="Example"};
        var serviceProvider = Substitute.For<IServiceProvider>();

        serviceProvider
            .GetService(typeof(IRequestHandler<FalseRequest, string>))
            .ReturnsNull();
        
        var mediator = new SimpleMediator(serviceProvider);
        
        await Assert.ThrowsExactlyAsync<MediatiorException>( () =>  mediator.Send(request));
    }

    [TestMethod]
    public async Task Send_InvalidCommand_Throws()
    {
        var request = new FalseRequest(){Name=""};
        var serviceProvider = Substitute.For<IServiceProvider>();
        var validator = new FalseRequestValidator();
        
        serviceProvider
            .GetService(typeof(IValidator<FalseRequest>))
            .Returns(validator);
        
        var mediator = new SimpleMediator(serviceProvider);
        
        await Assert.ThrowsExactlyAsync<CustomValidationException>(  () =>   mediator.Send(request));
    }
}