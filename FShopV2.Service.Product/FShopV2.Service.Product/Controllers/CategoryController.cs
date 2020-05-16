using FShopV2.Base.Dispatchers;
using FShopV2.Base.MongoDB;
using FShopV2.Service.Product.Entities;
using FShopV2.Service.Product.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        private readonly IMongoRepository<Category> mongoRepository;

        public CategoryController(IDispatcher dispatcher,IMongoRepository<Category> mongoRepository)
        {
            _dispatcher = dispatcher;
            this.mongoRepository = mongoRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
            => await this.mongoRepository.FindAsync(x => true);
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCategory command)
        {
            await _dispatcher.SendAsync(command);

            return Accepted();
        }
    }
}
