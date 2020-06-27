using System;
using RawRabbit.Common;
using System.Reflection;
using FShopV2.Base.Messages;
namespace FShopV2.Base.Test.Config
{
    public class RabbitMqNamingConventions : NamingConventions
    {
        public RabbitMqNamingConventions(string defaultNamespace)
        {
            ExchangeNamingConvention = type => GetNamespace(type, defaultNamespace).ToLowerInvariant();
            RoutingKeyConvention = type =>
                $"#.{GetRoutingKeyNamespace(type, defaultNamespace)}{type.Name.Underscore()}".ToLowerInvariant();
            ErrorExchangeNamingConvention = () => $"{defaultNamespace}.error";
            RetryLaterExchangeConvention = span => $"{defaultNamespace}.retry";
            RetryLaterQueueNameConvetion = (exchange, span) =>
                $"{defaultNamespace}.retry_for_{exchange.Replace(".", "_")}_in_{span.TotalMilliseconds}_ms".ToLowerInvariant();
        }

        private static string GetRoutingKeyNamespace(Type type, string defaultNamespace)
        {
            var @namespace = type.GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace+".test" ?? defaultNamespace;

            return string.IsNullOrWhiteSpace(@namespace) ? string.Empty : $"{@namespace}.";
        }

        private static string GetNamespace(Type type, string defaultNamespace)
        {
            var @namespace = type.GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace+".test" ?? defaultNamespace;

            return string.IsNullOrWhiteSpace(@namespace) ? "#" : $"{@namespace}";
        }
    }
}
