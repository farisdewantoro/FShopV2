using RawRabbit.Common;
using RawRabbit.Configuration;
using RawRabbit.Instantiation;
using RawRabbit;
using RawRabbit.Enrichers.MessageContext;
using System;
using System.Collections.Generic;
using System.Text;
using FShopV2.Base.RabbitMQ;
using FShopV2.Base.Test.Config;
using System.Threading.Tasks;
using FShopV2.Base.Messages;
using FShopV2.Base.Types;

namespace FShopV2.Base.Test.Fixture
{
    public abstract class RabbitMqFixtureBase
    {
        protected readonly RawRabbit.Instantiation.Disposable.BusClient _client;
        protected abstract string Hostnames { get; set; }
        protected abstract string VirtualHost { get; set; }
        protected abstract string UserName { get; set; }
        protected abstract string Password { get; set; }
        protected abstract string NameSpace { get; set; }
        bool _disposed = false;
        public RabbitMqFixtureBase()
        {
            _client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions()
            {
                ClientConfiguration = new RawRabbitConfiguration
                {
                    Hostnames = new List<string> { Hostnames }, // localhost
                    VirtualHost = VirtualHost,
                    Port = 5672,
                    Username = UserName,
                    Password = Password,
                },
                DependencyInjection = ioc =>
                {
                    ioc.AddSingleton<INamingConventions>(new RabbitMqNamingConventions(NameSpace));
                },
                Plugins = p => p
                    .UseAttributeRouting()
                    .UseRetryLater()
                    .UseMessageContext<CorrelationContext>()
                    .UseContextForwarding()
            });
        }
        public Task PublishAsync<TMessage>(TMessage message, string @namespace = null) where TMessage : class
        => _client.PublishAsync(message, ctx =>
            ctx.UseMessageContext(CorrelationContext.Empty).UsePublishConfiguration(p => p.WithRoutingKey(GetRoutingKey(@message, @namespace))));

        public async Task<TaskCompletionSource<TResponse>> SubscribeAndGetAsync<TEvent,TResponse>(
         Func<Guid, TaskCompletionSource<TResponse>, Task> onMessageReceived, Guid id) 
            where TEvent : IEvent
            where TResponse :class
        {
            var taskCompletionSource = new TaskCompletionSource<TResponse>();
            var guid = Guid.NewGuid().ToString();

            await _client.SubscribeAsync<TEvent>(
                async _ => await onMessageReceived(id, taskCompletionSource),
                ctx => ctx.UseSubscribeConfiguration(cfg =>
                    cfg
                        .FromDeclaredQueue(
                            builder => builder
                                .WithDurability(false)
                                .WithName(guid))));
            return taskCompletionSource;
        }

        private string GetRoutingKey<T>(T message, string @namespace = null)
        {
            @namespace = @namespace ?? NameSpace;
            @namespace = string.IsNullOrWhiteSpace(@namespace) ? string.Empty : $"{@namespace}.";

            return $"{@namespace}{typeof(T).Name.Underscore()}".ToLowerInvariant();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _client.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
