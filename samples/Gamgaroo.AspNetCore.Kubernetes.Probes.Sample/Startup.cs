using Gamgaroo.AspNetCore.Kubernetes.Probes.Extensions;
using Gamgaroo.AspNetCore.Kubernetes.Probes.Sample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Gamgaroo.AspNetCore.Kubernetes.Probes.Sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddReadinessService<SomeReadyService>();
            services.AddReadinessService<SomeNotReadyService>();

            services.AddLivenessService<SomeAliveService>();
            services.AddLivenessService<SomeNotAliveService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpReadinessEndpoint();
            app.UseHttpLivenessEndpoint();
        }
    }
}