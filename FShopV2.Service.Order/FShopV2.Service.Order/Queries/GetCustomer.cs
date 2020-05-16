using FShopV2.Base.Types;
using FShopV2.Service.Order.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Order.Queries
{
    public class GetCustomer : IQuery<CustomerDto>
    {
        public Guid Id { get; set; }
    }
}
