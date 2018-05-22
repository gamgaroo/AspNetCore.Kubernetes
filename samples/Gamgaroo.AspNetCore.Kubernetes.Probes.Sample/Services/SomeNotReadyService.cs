using System.Threading.Tasks;
using Gamgaroo.AspNetCore.Kubernetes.Probes.Abstractions;

namespace Gamgaroo.AspNetCore.Kubernetes.Probes.Sample.Services
{
    public sealed class SomeNotReadyService : IReadinessService
    {
        public async Task<ProbeResponse> Check()
        {
            return new ProbeResponse("SomeNotReadyService", ProbeStatus.Failure, "Not Ready");
        }
    }
}