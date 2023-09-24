using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace SupaTodo.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    // Register mappings
    TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    return services;
  }
}