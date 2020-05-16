using System;
using System.Collections.Generic;
using System.Text;
using RawRabbit.Configuration;

namespace FShopV2.Base.RabbitMQ
{
    public class RabbitMqOptions : RawRabbitConfiguration
    {
       
        public string Namespace { get; set; }
        public int Retries { get; set; }
        public int RetryInterval { get; set; }
        
    }
}
