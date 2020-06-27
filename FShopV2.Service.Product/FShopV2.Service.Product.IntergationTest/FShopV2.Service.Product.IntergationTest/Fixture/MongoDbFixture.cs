using FShopV2.Base.Test.Fixture;
using FShopV2.Service.Product.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Service.Product.IntergationTest.Fixture
{
    public class MongoDbFixture : MongoDbFixtureBase<Category>
    {
        protected override string CollectionName { get; set; } = "Category";
        protected override string ConnectionString { get; set; } = "mongodb://admin:admin@localhost:27017";
        protected override string DatabaseName { get; set; } = "product-service-test";
     
    }
}
