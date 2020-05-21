using FShopV2.Service.Customers.Dto;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Customers.Services
{
    public interface IOrderService
    {
        [AllowAnyStatusCode]
        [Get("order/customer/{id}")]
        Task<CustomerDto> GetAsync([Path] Guid id);
    }
}
