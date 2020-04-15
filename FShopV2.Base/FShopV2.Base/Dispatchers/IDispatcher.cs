using System.Threading.Tasks;
using FShopV2.Base.Types;
using FShopV2.Base.Messages;

namespace FShopV2.Base.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}