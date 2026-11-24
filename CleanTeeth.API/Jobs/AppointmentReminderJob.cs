using CleanTeeth.Application.Features.SendAppointmentReminder;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.API.Jobs;

public class AppointmentReminderJob : BackgroundService
{
    private readonly IServiceScopeFactory serviceScopeFactory;
    private readonly TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

    public AppointmentReminderJob(IServiceScopeFactory serviceScopeFactory)
    {
        this.serviceScopeFactory = serviceScopeFactory;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);

            if (now.Hour==8)
            {
                using var scope = serviceScopeFactory.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(new SendAppointmentReminderCommand());
            }

            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }
    }
}
