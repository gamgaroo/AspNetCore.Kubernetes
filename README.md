# AspNetCore.Kubernetes

## Getting Started

Create a class implementing _IReadinessService_ or _ILivenessService_ with your custom logic

```csharp
public sealed class SomeLivenessService : ILivenessService
{
    public async Task<ProbeResponse> Check()
    {
        ProbeStatus result = ... // Some custom logic
        return new ProbeResponse("SomeAliveService", result);
    }
}
```
Edit _Startup.cs_:

1) Register your Liveness and Readiness services in _ConfigureServices_ method

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddReadinessService<SomeReadynessService>();
    services.AddLivenessService<SomeLivenessService>();
    
    ...
}
```

2) Add required middlewares in _Configure_ method:

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    ...

    app.UseHttpReadinessEndpoint();
    app.UseHttpLivenessEndpoint();
    
    ...
}
```

You can override paths for endpoints:

```csharp
app.UseHttpReadinessEndpoint("/api/some"); // Default: api/ready
app.UseHttpLivenessEndpoint("/api/other"); // Default: api/alive
```

Each middleware will check all services of appropriate type and run Check() method. 
If at least one response status is Failure, HTTP Status Code 503 is returned. Otherwise 200. 

The response body also contains a JSON array with string representations of each service response:

```json
[
    "Name: SomeReadyService, Status: Success, Message: OK",
    "Name: SomeNotReadyService, Status: Failure, Message: Not Ready"
]
```
