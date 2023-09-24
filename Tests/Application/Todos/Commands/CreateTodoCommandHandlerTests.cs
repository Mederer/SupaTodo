using Moq;
using SupaTodo.Application.Interfaces;
using SupaTodo.Application.Repositories;
using SupaTodo.Application.Todos.Commands;

namespace Tests.Application.Commands.Handlers;

public class CreateTodoCommandHandlerTests
{
    [Fact]
    void Handle_CreatesTodo_WithValidCommand()
    {
        var mockTodoRepository = new Mock<ITodoRepository>();
        var mockDateTimeProvider = new Mock<IDateTimeProvider>();
        var fakeNow = DateTime.UtcNow;
        mockDateTimeProvider.Setup(x => x.UtcNow()).Returns(fakeNow);
        var handler = new CreateTodoCommandHandler(mockTodoRepository.Object, mockDateTimeProvider.Object);
        var command = new CreateTodoCommand("Test Todo");

        var result = handler.Handle(command, CancellationToken.None).Result;
        
        Assert.NotNull(result);
        Assert.Equal(fakeNow, result.LastModified);
        Assert.Equal(fakeNow, result.CreatedAt);
    }
}