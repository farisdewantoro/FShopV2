using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Consul;
using FShopV2.Base.Authentication;
using FShopV2.Base.Dispatchers;
using FShopV2.Base;
using FShopV2.Base.Mvc;
using FShopV2.Base.RabbitMQ;
using FShopV2.Base.RestEase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FShopV2.Service.Api.Services;
using FShopV2.Base.Utility;
using FShopV2.Base.Jaeger;

namespace FShopV2.Service.Api
{
    public class Startup
    {
        private static readonly string[] Headers = new[] { "X-Operation", "X-Resource", "X-Total-Count" };
        public IContainer Container { get; private set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            //services.AddSwaggerDocs();
            //services.AddConsul();
            services.AddJwt();
            services.AddJaeger();
            services.AddOpenTracing();
            //services.AddRedis();
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                        cors.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .WithExposedHeaders(Headers));
            });
            services.RegisterServiceForwarder<ICustomerService>(CodeConstant.ServicesName.CUSTOMER_SERVICE);
            services.RegisterServiceForwarder<IOrderService>(CodeConstant.ServicesName.ORDER_SERVICE);

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                    .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddDispatchers();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime applicationLifetime, 
            IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "local")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseAllForwardedHeaders();
            //app.UseSwaggerDocs();
            app.UseErrorHandler();
            //app.UseAuthentication();
            //app.UseAccessTokenValidator();
            app.UseServiceId();
            app.UseMvc();
            app.UseRabbitMq();

            //var consulServiceId = app.UseConsul();
            //applicationLifetime.ApplicationStopped.Register(() =>
            //{
            //    client.Agent.ServiceDeregister(consulServiceId);
            //    Container.Dispose();
            //});

            startupInitializer.InitializeAsync();
        }
    }
}
