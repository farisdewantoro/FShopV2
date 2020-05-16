
using FShopV2.Base.Messages;
using System.Threading.Tasks;
using FShopV2.Base.RabbitMQ;

namespace FShopV2.Base.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}