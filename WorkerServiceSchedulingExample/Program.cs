using Coravel;
using WorkerServiceSchedulingExample.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScheduler();
        services.AddTransient<ScheduledService>();
    })
    .Build();

host.Services.UseScheduler(scheduler =>
{
   scheduler.Schedule<ScheduledService>()
        .EverySeconds(2)                            // note this is 2 seconds but job takes 3 seconds
        .PreventOverlapping("ScheduledService");    // so we prevent overlapping
                                                    // this may or may not be needed
});

await host.RunAsync();
