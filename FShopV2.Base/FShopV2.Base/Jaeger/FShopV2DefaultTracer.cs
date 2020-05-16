using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using OpenTracing;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FShopV2.Base.Jaeger
{
    public class FShopV2DefaultTracer
    {
        public static ITracer Create()
        => new Tracer.Builder(Assembly.GetEntryAssembly().FullName)
            .WithReporter(new NoopReporter())
            .WithSampler(new ConstSampler(false))
            .Build();
    }
}
