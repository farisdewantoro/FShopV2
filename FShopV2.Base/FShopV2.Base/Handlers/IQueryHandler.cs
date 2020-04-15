using System.Threading.Tasks;
using FShopV2.Base.Types;

namespace FShopV2.Base.Handlers
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}