using FShopV2.Base.Dispatchers;
using FShopV2.Base.MongoDB;
using FShopV2.Service.Product.Dto;
using FShopV2.Service.Product.Entities;
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
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
          var result =  await this.mongoRepository.FindAsync(x => true);
          return result.Select(x => new CategoryDto(x.Name,x.Description));
        }
    }
}
