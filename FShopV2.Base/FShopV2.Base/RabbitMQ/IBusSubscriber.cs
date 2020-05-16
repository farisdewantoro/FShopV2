using FShopV2.Base.Messages;
using FShopV2.Base.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Base.RabbitMQ
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, FShopV2Exception, IRejectedEvent> onError = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
            Func<TEvent, FShopV2Exception, IRejectedEvent> onError = null)
            where TEvent : IEvent;
    }
}
