using System;
using System.Linq;
using System.Threading.Tasks;
using Gamgaroo.AspNetCore.Kubernetes.Probes.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Gamgaroo.AspNetCore.Kubernetes.Probes
{
    public sealed class ProbeMiddleware<TProbeService>
        where TProbeService : IProbeService
    {
        private readonly RequestDelegate _next;
        private readonly string _path;
        private readonly IServiceProvider _serviceProvider;

        public ProbeMiddleware(RequestDelegate next, IServiceProvider serviceProvider, string path)
        {
            _next = next;
            _serviceProvider = serviceProvider;
            _path = path;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!IsProbeRequest(context, _path))
            {
                await _next(context);
                return;
            }

            var services = _serviceProvider.GetServices<TProbeService>();

            var tasks = services.Select(async ls => await ls.Check());
            var results = await Task.WhenAll(tasks);
            var data = results.Select(r => r.ToString());

            context.Response.StatusCode = results.All(r => r.Status == ProbeStatus.Success) ? 200 : 503;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonConvert.SerializeObject(data));
        }

        private static bool IsProbeRequest(HttpContext context, string path)
        {
            return string.Equals(path, context.Request.Path, StringComparison.OrdinalIgnoreCase);
        }
    }
}