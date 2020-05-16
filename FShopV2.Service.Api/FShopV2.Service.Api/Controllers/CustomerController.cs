using FShopV2.Service.Api.Services;
using FShopV2.Base.RabbitMQ;
using FShopV2.Service.Api.Messages.Commands;
//using FShopV2.Service.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FShopV2.Base.Mvc;
using FShopV2.Service.Api.Framework;
using FShopV2.Service.Api.Messages.Commands.Customers;
using OpenTracing;
using FShopV2.Base;
using FShopV2.Base.Utility;
using Microsoft.AspNetCore.Authorization;
using FShopV2.Service.Api.Queries;

namespace FShopV2.Service.Api.Controllers
{
    [AllowAnonymous]
    public class CustomerController: BaseController
    {
        private readonly ICustomerService _customersService;

        public CustomerController(IBusPublisher busPublisher, ITracer tracer,
            ICustomerService customersService) : base(busPublisher, tracer)
        {
            _customersService = customersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseCustomers query)
            => Collection(await _customersService.BrowseAsync(query));

        //[HttpGet("{id}")]
        //[AdminAuth]
        //public async Task<IActionResult> Get(Guid id)
        //    => Single(await _customersService.GetAsync(id), x => x.Id == UserId || IsAdmin);

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomer command)
            => await SendAsync(command.BindId(c=>c.Id),
                resourceId: command.Id, resource: CodeConstant.ServicesName.CUSTOMER_SERVICE);
    }
}
