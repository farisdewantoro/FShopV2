using FShopV2.Base.Handlers;
using FShopV2.Base.MongoDB;
using FShopV2.Service.Customers.Dto;
using FShopV2.Service.Customers.Entities;
using FShopV2.Service.Customers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Customers.Handlers.Customers
{
    public class GetCustomerQueryHandler:IQueryHandler<GetCustomer, CustomerDto>
    {
        private readonly IMongoRepository<Customer> mongoRepository;

        public GetCustomerQueryHandler(IMongoRepository<Customer> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public async Task<CustomerDto> HandleAsync(GetCustomer query)
        {
            var customer = await mongoRepository.GetAsync(query.Id);

            return customer == null ? null : new CustomerDto(customer.Id,customer.FullName,customer.Email,customer.Phone,customer.Address);

            
        }
    }
}
