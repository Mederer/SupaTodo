using Microsoft.Extensions.DependencyInjection;
using SupaTodo.Application.Interfaces;
using SupaTodo.Application.Repositories;
using SupaTodo.Infrastructure.Persistence;
using SupaTodo.Infrastructure.Repositories;

namespace SupaTodo.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
    services.AddScoped<ITodoRepository, TodoDbRepository>();
    services.AddScoped<IDateTimeProvider, DateTimeProvider>();
    return services;
  }
}