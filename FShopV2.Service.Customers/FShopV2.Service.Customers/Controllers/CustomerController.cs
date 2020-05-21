using FShopV2.Base.Dispatchers;
using FShopV2.Base.Mvc;
using FShopV2.Base.Types;
using FShopV2.Service.Customers.Dto;
using FShopV2.Service.Customers.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Customers.Controllers
{

    public class CustomerController : BaseController
    {

        public CustomerController(IDispatcher dispatcher):base(dispatcher)
        {
        }
        [HttpGet("getall")]
        public async Task<ActionResult<PagedResult<CustomerDto>>> GetAll([FromQuery] BrowseCustomers query)
        {
            //BrowseCustomers query = new BrowseCustomers();
            
            return Collection(await QueryAsync(query));
        }
        [HttpGet]
        public async Task<ActionResult<PagedResult<CustomerDto>>> Browse([FromQuery] BrowseCustomers query)
        {
            return Collection(await QueryAsync(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get([FromRoute] GetCustomer query)
            => Single(await QueryAsync(query));

    }
}
