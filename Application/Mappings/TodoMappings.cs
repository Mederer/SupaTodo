using Mapster;
using SupaTodo.Application.Dtos;
using SupaTodo.Domain.Entities;

namespace SupaTodo.Application.Mappings;

public class TodoMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Todo, TodoDto>();
    }
}