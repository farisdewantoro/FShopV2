using FShopV2.Base.Test.Fixture;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FShopV2.Service.Product.IntergationTest.Fixture
{
    public class RabbitMqFixture : RabbitMqFixtureBase
    {
        protected override string Hostnames { get; set; } = "localhost";
        protected override string VirtualHost { get; set; } = "/";
        protected override string UserName { get; set; } = "guest";
        protected override string Password { get; set; } = "guest";
        protected override string NameSpace { get; set; } = "FShopV2.Service.Product.Test";
     
    }
}
