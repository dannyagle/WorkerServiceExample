# WorkerServiceExample

The WorkerServiceExample is exactly that, just a simple worker service console app where a background service is created and runs.

The WorkerServiceSchedulingExample is misnamed in that it doesnt use a worker service. :(  Instead it uses package called Coravel which allows use to schedule a service to run through a variety timer related extensions.  In this case it runs a potentially long running service every 2 seconds and prevents overlapping executions.
