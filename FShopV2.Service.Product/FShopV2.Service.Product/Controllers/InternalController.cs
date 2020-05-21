using FShopV2.Base.Dispatchers;
using FShopV2.Base.Mvc;
using FShopV2.Service.Product.Entities;
using FShopV2.Service.Product.Queries;
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

        [HttpGet("category/getall")]
        public async Task<IEnumerable<Category>> GetAll(GetAllCategories query)
            => await this.QueryAsync(query);
    }
}
