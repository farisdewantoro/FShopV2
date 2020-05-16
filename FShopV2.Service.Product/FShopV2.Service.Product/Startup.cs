using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FShopV2.Base;
using FShopV2.Base.MongoDB;
using FShopV2.Base.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Autofac.Extensions.DependencyInjection;
using FShopV2.Base.Dispatchers;
using FShopV2.Service.Product.Entities;
using FShopV2.Base.RabbitMQ;

namespace FShopV2.Service.Product
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            
            services.AddCustomMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddInitializers(typeof(IMongoDbInitializer));
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
              .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddDispatchers();
            builder.AddMongoDb();
            builder.AddRabbitMq();
            builder.AddMongoRepository<Category>("Categories");
            Container = builder.Build();
            return new AutofacServiceProvider(Container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
