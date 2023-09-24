using Moq;
using SupaTodo.Application.Repositories;
using SupaTodo.Application.Todos.Commands;

namespace Tests.Application.Commands.Handlers;

public class DeleteTodoCommandHandlerTests
{
    [Fact]
    private void Handle_ReturnsTrue_WhenTodoExists()
    {
        var id = Guid.NewGuid();
        var mockTodoRepository = new Mock<ITodoRepository>();
        mockTodoRepository.Setup(x => x.Delete(id)).Returns(true);
        var command = new DeleteTodoCommand(id);
        var handler = new DeleteTodoCommandHandler(mockTodoRepository.Object);

        var result = handler.Handle(command, CancellationToken.None).Result;
        
        Assert.True(result);
    }

    [Fact]
    private void Handle_ReturnsFalse_WhenTodoDoesntExist()
    {
        var id = Guid.NewGuid();
        var mockTodoRepository = new Mock<ITodoRepository>();
        mockTodoRepository.Setup(x => x.Delete(id)).Returns(false);
        var command = new DeleteTodoCommand(id);
        var handler = new DeleteTodoCommandHandler(mockTodoRepository.Object);

        var result = handler.Handle(command, CancellationToken.None).Result;
        
        Assert.False(result);
        
    }
}