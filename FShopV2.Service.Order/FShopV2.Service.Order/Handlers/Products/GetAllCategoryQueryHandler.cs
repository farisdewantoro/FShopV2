using FShopV2.Base.Handlers;
using FShopV2.Base.MongoDB;
using FShopV2.Service.Order.Entities;
using FShopV2.Service.Order.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Order.Handlers.Products
{
    public class GetAllCategoryQueryHandler:IQueryHandler<GetAllCategories,IEnumerable<Category>>
    {
        private readonly IMongoRepository<Category> mongoRepository;

        public GetAllCategoryQueryHandler(IMongoRepository<Category> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public async Task<IEnumerable<Category>> HandleAsync(GetAllCategories query)
            =>await mongoRepository.FindAsync(_ => true);
       
    }
}
