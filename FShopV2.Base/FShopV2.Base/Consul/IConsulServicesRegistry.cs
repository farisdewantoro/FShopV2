using System.Threading.Tasks;
using Consul;

namespace FShopV2.Base.Consul
{
    public interface IConsulServicesRegistry
    {
        Task<AgentService> GetAsync(string name);
    }
}