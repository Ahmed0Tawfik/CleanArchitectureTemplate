using YourProjectName.Application.Interfaces.DateTimeProvider;

namespace YourProjectName.Infrastructure.Services.DateTimeProvider
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
