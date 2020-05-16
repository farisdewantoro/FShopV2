using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Base.Utility
{
    public static class CodeConstant
    {
        public static class ServicesName
        {
            public const string BASE_APP = "FShopV2.Service";
            public const string CUSTOMER_SERVICE = BASE_APP+".Customers";
            public const string ORDER_SERVICE = BASE_APP + ".Order";
        }
    }
}
