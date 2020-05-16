using Autofac;
using FShopV2.Base.Types;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FShopV2.Base.MongoDB
{
    public static class Extensions
    {

        public static void AddMongoDb(this ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = configuration.GetOptions<MongoDbOptions>("mongo");
                return options;
            }).SingleInstance();

            builder.Register(context =>
            {
                var options = context.Resolve<MongoDbOptions>();

                return new MongoClient(options.ConnectionString);
            }).SingleInstance();

            builder.Register(context =>
            {
                var options = context.Resolve<MongoDbOptions>();
                var client = context.Resolve<MongoClient>();
                return client.GetDatabase(options.Database);

            }).InstancePerLifetimeScope();
        }
        public static void AddMongoRepository<TEntity>(this ContainerBuilder builder, string collectionName)
        where TEntity : IIdentifiable
            => builder.Register(ctx => new MongoRepository<TEntity>(ctx.Resolve<IMongoDatabase>(), collectionName))
            .As<IMongoRepository<TEntity>>()
            .InstancePerLifetimeScope();
    }
}
