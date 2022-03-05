using Coravel.Invocable;

namespace WorkerServiceSchedulingExample.Services;

public class ScheduledService : IInvocable
{
    private readonly ILogger<ScheduledService> _logger;

    public ScheduledService(ILogger<ScheduledService> logger)
    {
        _logger = logger;
    }

    public async Task Invoke()
    {
        var jobId = Guid.NewGuid();
        _logger.LogInformation("Starting job: {jobId}", jobId);
        await Task.Delay(3000);
        _logger.LogInformation("Finished job: {jobId}", jobId);
    }

}
