using System.Threading.Tasks;
using FShopV2.Base.Messages;

namespace FShopV2.Base.Dispatchers
{
    public interface ICommandDispatcher
    {
         Task SendAsync<T>(T command) where T : ICommand;
    }
}