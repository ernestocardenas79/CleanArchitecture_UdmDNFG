using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CleanTheet.Tests.Application.Utilities.Mediator;

[TestClass]
public class SimpleMediatorTests
{
    public class FalseRequest: IRequest<string>{}

    [TestMethod]
    public async Task Send_WithRegisteredHandler_HandleIsExecuted()
    {
        var request = new FalseRequest();
        
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
    public void Send_WithoutRegisteredHandler_Throws()
    {
        var request = new FalseRequest();
        var serviceProvider = Substitute.For<IServiceProvider>();

        serviceProvider
            .GetService(typeof(IRequestHandler<FalseRequest, string>))
            .ReturnsNull();
        
        var mediator = new SimpleMediator(serviceProvider);
        
        Assert.ThrowsExactlyAsync<MediatiorException>(async () => await mediator.Send(request));
    }
}