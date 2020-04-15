//using FShopV2.Base.RabbitMq;
using FShopV2.Base.Messages;
using System.Threading.Tasks;

namespace FShopV2.Base.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        //Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}