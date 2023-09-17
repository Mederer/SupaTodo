using SupaTodo.Application.Interfaces;

namespace SupaTodo.Infrastructure;

public class DateTimeProvider : IDateTimeProvider
{
  public DateTime GetCurrent()
  {
    return DateTime.UtcNow;
  }
}
