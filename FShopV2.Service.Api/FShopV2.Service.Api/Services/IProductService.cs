using FShopV2.Service.Api.Model.Product;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Api.Services
{
    public interface IProductService
    {
        [AllowAnyStatusCode]
        [Get("GetAll")]
        Task<IEnumerable<CategoryDto>> GetAll();
    }
}
