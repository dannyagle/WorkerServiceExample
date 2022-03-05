namespace WorkerServiceExample;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private int _count;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker has run {count} times.", _count);
            _count++;
            await Task.Delay(1000, cancellationToken);
        }
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting worker service...");
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping worker service...");
        return base.StopAsync(cancellationToken);
    }
}
