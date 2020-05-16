using FShopV2.Base.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Api.Framework
{
    public class AdminAuth : JwtAuthAttribute
    {
        public AdminAuth() : base("admin")
        {
        }
    }
}
