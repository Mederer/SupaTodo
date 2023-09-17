using Moq;
using SupaTodo.Application.Dtos;
using SupaTodo.Application.Interfaces;
using SupaTodo.Application.Repositories;
using SupaTodo.Application.Services;
using SupaTodo.Domain.Entities;

namespace SupaTodo.Tests.Application;

public class TodoServiceTests
{
  private readonly Mock<ITodoRepository> _todoRepositoryMock;
  private readonly Mock<IDateTimeProvider> _dateTimeProviderMock;

  public TodoServiceTests()
  {
    _todoRepositoryMock = new Mock<ITodoRepository>();
    _dateTimeProviderMock = new Mock<IDateTimeProvider>();
  }

  [Fact]
  void CreateTodo_CreatesCorrectly()
  {
    var createTodoDto = new CreateTodoDto("Test Todo");
    var fakeNow = DateTime.UtcNow;

    _dateTimeProviderMock.Setup(x => x.GetCurrent()).Returns(fakeNow);
    _todoRepositoryMock.Setup(x => x.Save(It.IsAny<Todo>())).Returns<Todo>(x => x);
    var todoService = new TodoService(_todoRepositoryMock.Object, _dateTimeProviderMock.Object);

    var result = todoService.CreateTodo(createTodoDto);

    Assert.Equal(createTodoDto.Title, result.Title);
    Assert.Equal(fakeNow, result.CreatedAt);
    Assert.Equal(fakeNow, result.LastModified);
    Assert.False(result.IsComplete);
  }

  [Fact]
  void DeleteTodo_ReturnsTrue_WhenTodoDeleted()
  {
    _todoRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(true);
    var todoService = new TodoService(_todoRepositoryMock.Object, _dateTimeProviderMock.Object);
    Assert.True(todoService.DeleteTodo(Guid.NewGuid()));
  }

  [Fact]
  void DeleteTodo_ReturnsFalse_WhenTodoNotFound()
  {
    _todoRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(false);
    var todoService = new TodoService(_todoRepositoryMock.Object, _dateTimeProviderMock.Object);

    Assert.False(todoService.DeleteTodo(Guid.NewGuid()));
  }

  [Fact]
  void GetAllTodos_ShouldReturnList_WhenTodosExist()
  {
    _todoRepositoryMock.Setup(x => x.FindAll()).Returns(new List<Todo>(){
      new Todo { Id = Guid.NewGuid(), Title = "Test Todo 1", CreatedAt = DateTime.Now, IsComplete = true, LastModified = DateTime.Now},
      new Todo { Id = Guid.NewGuid(), Title = "Test Todo 2", CreatedAt = DateTime.Now, IsComplete = false, LastModified = DateTime.Now},
      new Todo { Id = Guid.NewGuid(), Title = "Test Todo 3", CreatedAt = DateTime.Now, IsComplete = true, LastModified = DateTime.Now},
    });

    var todoService = new TodoService(_todoRepositoryMock.Object, _dateTimeProviderMock.Object);
    List<TodoDto> result = todoService.GetAllTodos();
    var expectedCount = 3;

    Assert.Equal(expectedCount, result.Count);
  }

  [Fact]
  void GetAllTodos_ShouldReturnEmptyList_WhenTodosEmpty()
  {
    _todoRepositoryMock.Setup(x => x.FindAll()).Returns(new List<Todo>());

    var todoService = new TodoService(_todoRepositoryMock.Object, _dateTimeProviderMock.Object);
    List<TodoDto> result = todoService.GetAllTodos();

    Assert.True(result.Count == 0);
  }

  [Fact]
  void GetTodo_ShouldReturnTodoDto_WhenTodoExists()
  {
    _todoRepositoryMock.Setup(x => x.FindById(It.IsAny<Guid>())).Returns((Guid id) => new Todo()
    {
      Id = id,
      Title = "Test Todo",
      CreatedAt = DateTime.Now,
      LastModified = DateTime.Now,
      IsComplete = false
    });

    var todoService = new TodoService(_todoRepositoryMock.Object, _dateTimeProviderMock.Object);
    var result = todoService.GetTodo(Guid.NewGuid());

    Assert.NotNull(result);
  }

  [Fact]
  void GetTodo_ShouldReturnNull_WhenTodoDoesNotExist()
  {
    _todoRepositoryMock.Setup(x => x.FindById(It.IsAny<Guid>())).Returns<Guid>(_ => null);
    var todoService = new TodoService(_todoRepositoryMock.Object, _dateTimeProviderMock.Object);

    var result = todoService.GetTodo(Guid.NewGuid());

    Assert.Null(result);
  }
}