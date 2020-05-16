using FShopV2.Base.Dispatchers;
using FShopV2.Base.Mvc;
using FShopV2.Service.Customers.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDispatcher dispatcher;

        public CustomerController(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateUser createUser)
        {
            await dispatcher.SendAsync(createUser.BindId(c=>c.Id));
            return Accepted();
        }

    }
}
