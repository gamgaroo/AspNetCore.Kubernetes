using System.Threading.Tasks;
using Gamgaroo.AspNetCore.Kubernetes.Probes.Abstractions;

namespace Gamgaroo.AspNetCore.Kubernetes.Probes.Sample.Services
{
    public sealed class SomeNotAliveService : ILivenessService
    {
        public async Task<ProbeResponse> Check()
        {
            return new ProbeResponse("SomeNotAliveService", ProbeStatus.Failure, "Not Alive");
        }
    }
}