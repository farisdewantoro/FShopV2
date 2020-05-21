using FShopV2.Base.MessageModels.Products;
using FShopV2.Base.Mvc;
using FShopV2.Base.RabbitMQ;
using FShopV2.Base.Utility;
using FShopV2.Service.Api.Model.Product;
using FShopV2.Service.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Api.Controllers
{
    [AllowAnonymous]
    public class ProductController:BaseController
    {
        private readonly IProductService productService;

        public ProductController(IBusPublisher busPublisher, ITracer tracer,IProductService productService):base(busPublisher,tracer)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return await productService.GetAll();
        }
        [HttpPost("category")]
        public async Task<IActionResult> Post(CreateCategory command)
          => await SendAsync(command.BindId(c => c.Id),
              resourceId: command.Id, resource: CodeConstant.ServicesName.PRODUCT_SERVICE);
    }
}
