using System.Threading.Tasks;

namespace Gamgaroo.AspNetCore.Kubernetes.Probes.Abstractions
{
    public interface IProbeService
    {
        Task<ProbeResponse> Check();
    }
}