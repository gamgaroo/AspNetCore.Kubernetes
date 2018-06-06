using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Gamgaroo.AspNetCore.Kubernetes.Urls
{
    public sealed class UrlsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _serviceName;

        public UrlsMiddleware(RequestDelegate next, string serviceName)
        {
            if (string.IsNullOrWhiteSpace(serviceName))
                throw new ArgumentException("Service Name can not be null or whitespace", nameof(serviceName));

            _serviceName = serviceName;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var pathValue = context.Request.Path.Value;

            if (pathValue.Equals($"/{_serviceName}", StringComparison.OrdinalIgnoreCase))
                context.Request.Path = new PathString("/");
            else if (pathValue.StartsWith($"/{_serviceName}/", StringComparison.OrdinalIgnoreCase))
                context.Request.Path = pathValue.Substring(1 + _serviceName.Length);

            await _next(context);
        }
    }
}