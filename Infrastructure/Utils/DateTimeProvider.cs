using SupaTodo.Application.Interfaces;

namespace SupaTodo.Infrastructure;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow()
    {
        return DateTime.UtcNow;
    }
}