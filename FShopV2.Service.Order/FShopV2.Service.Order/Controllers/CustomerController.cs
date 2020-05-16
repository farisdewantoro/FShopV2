using FShopV2.Base.Dispatchers;
using FShopV2.Base.Mvc;
using FShopV2.Base.Types;
using FShopV2.Service.Order.Dto;
using FShopV2.Service.Order.Messages.Commands;
using FShopV2.Service.Order.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Order.Controllers
{
    [AllowAnonymous]
    public class CustomerController : BaseController
    {

        public CustomerController(IDispatcher dispatcher):base(dispatcher)
        {
        }
        [HttpGet("getall")]
        public async Task<ActionResult<PagedResult<CustomerDto>>> Get([FromQuery] BrowseCustomers query)
                   => Collection(await QueryAsync(query));

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get([FromRoute] GetCustomer query)
            => Single(await QueryAsync(query));

    }
}
