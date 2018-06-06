# Gamgaroo.AspNetCore.Kubernetes.Urls

This is useful in Kubernetes when you use Ingress to map paths to your services with the service name in path.

## Getting Started

Add required middleware in _Configure_ method:

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    ...

    app.UseUrlsMiddleware("servicename");
    
    ...
}
```

Now all requests with path
/servicename/api/values
will be rewrited to 
/api/values
