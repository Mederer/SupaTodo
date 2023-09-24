using Moq;
using SupaTodo.Application.Dtos;
using SupaTodo.Application.Interfaces;
using SupaTodo.Application.Repositories;
using SupaTodo.Application.Todos.Commands;
using SupaTodo.Domain.Entities;

namespace Tests.Application.Commands.Handlers;

public class UpdateTodoCommandHandlerTests
{
    [Fact]
    private void Handle_UpdatesTodo_WhenTodoExists()
    {
        var id = Guid.NewGuid();
        var fakeNow = DateTime.UtcNow;
        
        var mockDateTimeProvider = new Mock<IDateTimeProvider>();
        var mockTodoRepository = new Mock<ITodoRepository>();
        
        var todoToUpdate = new Todo()
        {
            Id = id,
            Title = "Test Todo",
            IsComplete = false,
            CreatedAt = DateTime.MinValue,
            LastModified = DateTime.MinValue
        };
        var command = new UpdateTodoCommand(id, "Updated Test Todo", true);
        var expected = new TodoDto(Id: id, Title: command.Title, IsComplete: command.IsComplete, LastModified: fakeNow,
            CreatedAt: DateTime.MinValue);
        
        mockDateTimeProvider.Setup(x => x.UtcNow()).Returns(fakeNow);
        mockTodoRepository.Setup(x => x.FindById(todoToUpdate.Id)).Returns(todoToUpdate);

        var handler = new UpdateTodoCommandHandler(mockTodoRepository.Object, mockDateTimeProvider.Object);
        var result = handler.Handle(command, CancellationToken.None).Result;

        
        Assert.Equivalent(expected, result);
    }
}