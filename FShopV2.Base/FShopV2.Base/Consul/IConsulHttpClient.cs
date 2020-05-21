using System.Threading.Tasks;

namespace FShopV2.Base.Consul
{
    public interface IConsulHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}

