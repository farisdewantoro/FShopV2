using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Base.Mvc
{
    public class ServiceId : IServiceId
    {
        private static readonly string UniqueId = $"{Guid.NewGuid():N}";

        public string Id => UniqueId;
    }
}
