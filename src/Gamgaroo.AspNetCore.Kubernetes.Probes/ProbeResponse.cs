namespace Gamgaroo.AspNetCore.Kubernetes.Probes
{
    public sealed class ProbeResponse
    {
        public ProbeResponse(string name, ProbeStatus status, string message = "OK")
        {
            Name = name;
            Status = status;
            Message = message;
        }

        public string Name { get; set; }
        public ProbeStatus Status { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Status: {Status}, Message: {Message}";
        }
    }
}