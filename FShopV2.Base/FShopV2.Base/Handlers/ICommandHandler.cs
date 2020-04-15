//using FShopV2.Base.RabbitMq;
using FShopV2.Base.Messages;
using System.Threading.Tasks;

namespace FShopV2.Base.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        //Task HandleAsync(TCommand command, ICorrelationContext context);
        Task HandleAsync(TCommand command);
    }
}