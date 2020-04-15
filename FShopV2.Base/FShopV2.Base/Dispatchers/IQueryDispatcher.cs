using System.Threading.Tasks;
using FShopV2.Base.Types;

namespace FShopV2.Base.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}