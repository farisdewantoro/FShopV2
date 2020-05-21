using FShopV2.Base.Handlers;
using FShopV2.Base.MongoDB;
using FShopV2.Service.Order.Dto;
using FShopV2.Service.Order.Entities;
using FShopV2.Service.Order.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Order.Handlers.Customers
{
    public class GetCustomerQueryHandler:IQueryHandler<GetCustomer,Customer>
    {
        private readonly IMongoRepository<Customer> mongoRepository;

        public GetCustomerQueryHandler(IMongoRepository<Customer> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public async Task<Customer> HandleAsync(GetCustomer query)
            => await mongoRepository.GetAsync(query.Id);
    }
}
