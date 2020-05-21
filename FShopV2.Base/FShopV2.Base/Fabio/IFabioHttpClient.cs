using System.Threading.Tasks;

namespace FShopV2.Base.Fabio
{
    public interface IFabioHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}