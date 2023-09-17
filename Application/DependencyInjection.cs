using Microsoft.Extensions.DependencyInjection;
using SupaTodo.Application.Services;
using SupaTodo.Application.Interfaces;

namespace SupaTodo.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<ITodoService, TodoService>();
    return services;
  }
}