using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FShopV2.Base.Types;
using FShopV2.Service.Api.Model.Customer;
using FShopV2.Service.Api.Queries;
using RestEase;
namespace FShopV2.Service.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICustomerService
    {
        [AllowAnyStatusCode]
        [Get("customer/getall")]
        Task<PagedResult<CustomerDto>> BrowseAsync([Query] BrowseCustomers query);
    }
}
