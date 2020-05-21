using FShopV2.Base.Dispatchers;
using FShopV2.Base.Mvc;
using FShopV2.Service.Order.Entities;
using FShopV2.Service.Order.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Order.Controllers
{
    public class InternalController: BaseController
    {
        public InternalController(IDispatcher dispatcher) : base(dispatcher)
        {

        }

        [HttpGet("product/category/getall")]
        public async Task<IEnumerable<Category>> GetAll(GetAllCategories query)
            => await this.QueryAsync(query);
    }
}
