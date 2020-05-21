using FShopV2.Base.Messages;
using FShopV2.Base.Types;
using FShopV2.Base.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Base.MessageModels.Customers
{
    [MessageNamespace(CodeConstant.ServicesName.CUSTOMER_SERVICE)]
    public class CreateCustomerRejected : IRejectedEvent, IIdentifiable
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public CreateCustomerRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
