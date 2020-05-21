using FShopV2.Base.Handlers;
using FShopV2.Base.MongoDB;
using FShopV2.Base.Types;
using FShopV2.Service.Customers.Dto;
using FShopV2.Service.Customers.Entities;
using FShopV2.Service.Customers.Queries;
using FShopV2.Service.Customers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Customers.Handlers.Customers
{
    public class BrowseCustomerQueryHandler : IQueryHandler<BrowseCustomers, PagedResult<CustomerDto>>
    {
        private readonly IMongoRepository<Customer> mongoRepository;

        public BrowseCustomerQueryHandler(IMongoRepository<Customer> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }
        public async Task<PagedResult<CustomerDto>> HandleAsync(BrowseCustomers query)
        {
            var pagedResult = await mongoRepository.BrowseAsync(_=>true,query);
            var customers = pagedResult.Items.Select(c => new CustomerDto(c.Id,c.FullName,c.Email,c.Phone,c.Address));
          
            return PagedResult<CustomerDto>.From(pagedResult, customers);
        }
    }
}
