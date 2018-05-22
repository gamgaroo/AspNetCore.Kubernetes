using System.Threading.Tasks;
using Gamgaroo.AspNetCore.Kubernetes.Probes.Abstractions;

namespace Gamgaroo.AspNetCore.Kubernetes.Probes.Sample.Services
{
    public sealed class SomeAliveService : ILivenessService
    {
        public async Task<ProbeResponse> Check()
        {
            return new ProbeResponse("SomeAliveService", ProbeStatus.Success);
        }
    }
}